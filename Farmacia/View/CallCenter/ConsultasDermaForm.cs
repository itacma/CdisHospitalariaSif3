using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.Schedule.Model;
using DevComponents.DotNetBar;

namespace SIF.View.CallCenter
{
    public partial class ConsultasDermaForm : Templates.CatalogoUserControl
    {
        SIFModelo.Cliente cliente;
        SIFModelo.Medico medico;

        public ConsultasDermaForm()
        {
            InitializeComponent();

            this.cargaHorarios();
            this.cargaSucursales();
            this.cargaDatos(Helpers.Sesion.Sucursal.SucursalesID);
            Privilegios();

        }
        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 26, int.Parse(Xbtn.Tag.ToString()));
            }

        }

        public Menu.CatMenu Owner;
        public Boolean Mostrado = false;

        Dictionary<Appointment, SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow> DiccionarioCitas = new Dictionary<Appointment, SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow>();

        public void ActivaComandos()
        {
            this.nuevaCitaButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.seleccionaMedicoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.eliminarArticuloButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }

        private void cargaHorarios()
        {
            this.horarioComboBoxEx.DataSource = new SIFNegocio.CallCenter.Horarios().CargaHorarios().HORARIOS;
            horarioComboBoxEx.DisplayMember = "NOMBRE";
            horarioComboBoxEx.ValueMember = "HORARIO_ID";
        }

        private void cargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            this.sucursalesComboBoxEx.DataSource = sucursalL.Buscar("", "");
            sucursalesComboBoxEx.DisplayMember = "Nombre";
            sucursalesComboBoxEx.ValueMember = "SucursalesID";
            sucursalesComboBoxEx.Text = Helpers.Sesion.Sucursal.Nombre;
        }
        private void cargaDatos(int SucursalID)
        {
            monthCalendarAdv1.DisplayMonth = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            calendarView.ShowDate(DateTime.Today);
            SIFModelo.CallCenter.CallCenterDataSet Consulta;
            SIFNegocio.CallCenter.ConsultasDerma Logica = new SIFNegocio.CallCenter.ConsultasDerma();
            SIFModelo.CallCenter.CallCenterDataSet.CONSULTADataTable ConsultaDerDTA;
            Consulta = Logica.CatalogoConsultasActivas();
            ConsultaDerDTA = Consulta.CONSULTA;
            string Descripcion;
            List<DateTime> Dias = new List<DateTime>();
            this.DiccionarioCitas.Clear();
            calendarView.CalendarModel.Appointments.Clear();
            foreach (SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow xy in ConsultaDerDTA.Select("SUCURSAL_ID=" + SucursalID))
            {

                Descripcion = "Cliente: " + xy.CAT_CLIENTE_NOMBRE + "" + "\n" +
               "Medico: " + xy.NOMBRE + "\n" +
               "Fecha: " + xy.FECHA_CITA.ToShortDateString() + "\n";
                Appointment app = new Appointment();
                app.StartTime = xy.FECHA_CITA;
                app.EndTime = xy.FECHA_CITA.AddHours(2);
                app.Description = Descripcion;
                app.Id = xy.CONSULTA_ID;
                //dias=xy.FECHA_CITA;
                calendarView.CalendarModel.Appointments.Add(app);
                calendarView.EnsureVisible(app);
                this.DiccionarioCitas.Add(app, xy);
                Dias.Add(xy.FECHA_CITA);

            }

            //agregamos los dias que tengan citas
            monthCalendarAdv1.MarkedDates = Dias.ToArray();

            monthCalendarAdv1.Update();
            calendarView.ShowDate(DateTime.Today);
        }

        public void DesactivaComandos()
        {
            this.nuevaCitaButtonItem.Shortcuts.Clear();
            this.eliminarArticuloButtonItem.Shortcuts.Clear();
            this.backButton.Shortcuts.Clear();
        }

        public void Mostrar()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void Back()
        {
            try
            {
                Owner.ActivaComandos();
                this.DesactivaComandos();
                this.Mostrado = false;

                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
            catch { }
        }


        #region  funciones y metodos
        SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow ConsultaDerma;
        SIFNegocio.CallCenter.ConsultasDerma Negocio = new SIFNegocio.CallCenter.ConsultasDerma();

        private void Nueva()
        {
            SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow rowConsulta = Negocio.dsConsultas.CONSULTA.NewCONSULTARow();
            if (cliente == null)
            {
               MessageBox.Show("seleccionar  un cliente");

                return;
            }

            if (cliente == null)
            {
               MessageBox.Show("seleccionar un cliente");

                return;
            }
            if (medico == null)
            {
               MessageBox.Show("seleccionar un medico");

                return;
            }

            rowConsulta.CLIENTE_ID = cliente.ID;
            rowConsulta.CONSULTA_ID = -1;
            rowConsulta.SUCURSAL_ID = int.Parse(sucursalesComboBoxEx.SelectedValue.ToString());
            if (horarioComboBoxEx.Text == "MATUTINO")
            {
                rowConsulta.FECHA_CITA = monthCalendarAdv1.SelectedDate;
                //rowConsulta.FECHA_CITA = rowConsulta.FECHA_CITA.AddHours(8);
                rowConsulta.HORARIO_ID = 1;
            }
            else
            {
                rowConsulta.FECHA_CITA = monthCalendarAdv1.SelectedDate;
                //rowConsulta.FECHA_CITA=rowConsulta.FECHA_CITA.AddHours(14);
                rowConsulta.HORARIO_ID = 2;
            }

            rowConsulta.MEDICO_ID = (short)medico.ID;
            rowConsulta.NOMBRE = medico.Nombre;
            rowConsulta.CAT_CLIENTE_NOMBRE = cliente.Nombre;
            rowConsulta.CAT_CLIENTES_APE_PATERNO = cliente.ApellidoPaterno;
            rowConsulta.CAT_CLIENTES_APE_MATERNO = cliente.ApellidoMaterno;


            string Descripcion = "Cliente: " + cliente.Nombre + "" + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + "\n" +
                "Medico: " + medico.Nombre + "\n" +
                "Fecha: " + rowConsulta.FECHA_CITA.ToShortDateString() + "\n";

            Appointment app = new Appointment();


            app.StartTime = rowConsulta.FECHA_CITA;
            app.EndTime = rowConsulta.FECHA_CITA.AddHours(1);
            app.Description = Descripcion;
            app.Locked = false;

            calendarView.CalendarModel.Appointments.Add(app);
            calendarView.EnsureVisible(app);
            this.DiccionarioCitas.Add(app, rowConsulta);

        }
        SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow rowConsulta;
        private void guardar()
        {

        }

        private void Inserta()
        {
            rowConsulta.FECHA_CITA = currentAppointment.StartTime;
            if (Negocio.NuevaConsulta(rowConsulta))
            {
               MessageBox.Show("Se ha creado la Consulta");
                this.Back();
            };
        }

        private void Actualizar()
        {
            rowConsulta.FECHA_CITA = currentAppointment.StartTime;
            if (Negocio.ModificaConsulta(rowConsulta))
            {
               MessageBox.Show("Se ha actualizado la Consulta");
                this.Back();
            };

        }
        private SIFNegocio.CallCenter.ConsultasDerma Logica = new SIFNegocio.CallCenter.ConsultasDerma();
        private void Eliminar()
        {
            int registros = calendarView.SelectedAppointments.Count;
            if (registros <= 0 && calendarView.SelectedAppointments == null)
            {
               MessageBox.Show("Seleccione el registro a eliminar");
                return;
            }


        }

        private void AsignaAppointment()
        {
            SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow rowConsulta = this.DiccionarioCitas[currentAppointment];

            this.sucursalesComboBoxEx.SelectedValue = rowConsulta.SUCURSAL_ID;
            this.horarioComboBoxEx.SelectedValue = rowConsulta.HORARIO_ID;
            //this.consultaTextBoxX.Text = "Cliente: "+ rowConsulta.CAT_CLIENTE_NOMBRE + " "+ rowConsulta.CAT_CLIENTES_APE_PATERNO +" "+rowConsulta.CAT_CLIENTES_APE_MATERNO+ "\n" + 
            //    "Medico: " +rowConsulta.NOMBRE + "\n" + 
            //    "Fecha: " + rowConsulta.FECHA_CITA.ToShortDateString() + "\n" ;

        }

        #endregion

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void nuevaCitaButtonItem_Click(object sender, EventArgs e)
        {
            this.Nueva();
        }

        private void monthCalendarAdv1_DateChanged(object sender, EventArgs e)
        {
            this.calendarView.DayViewDate = monthCalendarAdv1.SelectedDate;
        }

        private Appointment currentAppointment = null;
        private void calendarView_ItemClick(object sender, EventArgs e)
        {

            if (calendarView.SelectedAppointments.Count > 0)
            {
                currentAppointment = calendarView.SelectedAppointments[0].Appointment;

                AsignaAppointment();
            }
        }


        private void SeleccionaCliente()
        {
            View.Catalogos.ClienteControl frmCliente = new View.Catalogos.ClienteControl();
            frmCliente.Dock = DockStyle.Fill;
            frmCliente.Owner = this;

            frmCliente.Muestra();
        }
        private void SeleccionaMedico()
        {
            View.Catalogos.MedicosUserControl frmMedico = new View.Catalogos.MedicosUserControl();
            frmMedico.Dock = DockStyle.Fill;
            frmMedico.Owner = this;
            frmMedico.Muestra();
        }
        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }


        public void AgregaCliente(SIFModelo.Cliente cliente)
        {
            this.cliente = cliente;

            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
        }


        public void AgregaMedico(SIFModelo.Medico medico)
        {
            this.medico = medico;

            this.medicoLabelX.Text = medico.Nombre;
        }

        private void seleccionaMedicoButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaMedico();
        }

        private void monthCalendarAdv1_ItemClick(object sender, EventArgs e)
        {
            this.calendarView.DateSelectionStart = monthCalendarAdv1.SelectedDate;

        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            if (calendarView.SelectedAppointments.Count > 0)
            {
                currentAppointment = calendarView.SelectedAppointments[0].Appointment;
            }
            else
            {
               MessageBox.Show("Debe agregar una consulta");
                return;
            }

            rowConsulta = this.DiccionarioCitas[currentAppointment];

            if (rowConsulta.CONSULTA_ID == -1)
            {
                Inserta();
            }
            else
            {
                Actualizar();
            }

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }

        private void btnMedico_Click(object sender, EventArgs e)
        {
            SeleccionaMedico();
        }

        private void calendarView_ItemRemoved(object sender, ItemRemovedEventArgs e)
        {

        }

        private void calendarView_Click(object sender, EventArgs e)
        {
            if (calendarView.DateSelectionStart != null)
            {
                monthCalendarAdv1.SelectedDate = (DateTime)calendarView.DateSelectionStart;

            }
        }

        private void ConsultasDermaForm_Load(object sender, EventArgs e)
        {

        }

        private void sucursalesComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sucursalesComboBoxEx.SelectedValue.ToString().IsInteger())
                this.cargaDatos(int.Parse(sucursalesComboBoxEx.SelectedValue.ToString()));
        }

        private void calendarView_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            //{
            //    DataObject d = calendarView.GetClipboardContent();
            //    Clipboard.SetDataObject(d);
            //}
        }
    }
}
