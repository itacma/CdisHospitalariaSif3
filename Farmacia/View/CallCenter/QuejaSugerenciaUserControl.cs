using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.CallCenter
{
    public partial class QuejaSugerenciaUserControl : Templates.CatalogoUserControl
    {

        public QuejaSugerenciaUserControl(SIFModelo.Usuario usuario, SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow Queja)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.CargaQuejasSugetencias();
            this.CargaSucursales();
            fechaSucesoDateTimeInput.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            if (Queja != null)
            {
                SIFNegocio.Clientes LogCliente = new SIFNegocio.Clientes();

                cliente = LogCliente.ClientePorID(Queja.CLIENTE_ID);
                clienteLabelX.Text = Queja.CAT_CLIENTES_NOMBRE + " " + Queja.CAT_CLIENTES_APE_PATERNO + " " + Queja.CAT_CLIENTES_APE_MATERNO;
                fechaSucesoDateTimeInput.Value = Queja.FECHA_SUCESO;
                sucursalComboBoxEx.Text = Queja.CAT_SUCURSALES_NOMBRE;
                tipoQuejaSugerenciaComboBoxEx.Text = Queja.CAT_QUEJA_SUGERENCIA_NOMBRE;
                quejaTextBox.Text = Queja.COMENTARIO;
                textBoxX1.Text = Queja.SOLUCION;
                tableLayoutPanel2.Visible = true;
                if (Queja.QUEJA_SUGERENCIA == "S")
                    sugerenciaRadioButton.Checked = true;
                else
                    quejaRadioButton.Checked = true;
            }
            else
            {
                tableLayoutPanel2.Visible = false;
            }
            QuejaSugerencia = Queja;
        }

        public QuejasSugerenciasUserControl Owner { get; set; }
        SIFModelo.Usuario usuario;
        SIFModelo.CallCenter.CallCenterDataSet.QUEJA_SUGERENCIARow QuejaSugerencia;
        SIFNegocio.CallCenter.QuejasSugerencias Negocio = new SIFNegocio.CallCenter.QuejasSugerencias();

        internal void Mostrar()
        {
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;

            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;

        }

        private void Back()
        {
            try
            {
                Owner.ActivaComandos();
                this.DesactivaComandos();
                Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {
            this.backButton.Shortcuts.Clear();
            this.seleccionaClienteButtonItem.Shortcuts.Clear();
            this.guardarButtonItem.Shortcuts.Clear();
        }

        public void ActivaComandos()
        {
            this.seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.guardarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }


        #region funciones y metodos

        private void CargaSucursales()
        {
            this.sucursalComboBoxEx.DataSource = new SIFNegocio.Sucursales().Buscar("", "").DataSource;
            sucursalComboBoxEx.DisplayMember = "NOMBRE";
            sucursalComboBoxEx.ValueMember = "SUCURSALESID";
        }

        private void CargaQuejasSugetencias()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = new SIFNegocio.CallCenter.QuejasSugerencias().CatalogoQuejasSugerenciasActivas().CAT_QUEJA_SUGERENCIA;
            this.tipoQuejaSugerenciaComboBoxEx.DataSource = bs;
            tipoQuejaSugerenciaComboBoxEx.DisplayMember = "NOMBRE";
            tipoQuejaSugerenciaComboBoxEx.ValueMember = "CAT_QUEJA_SUGERENCIA_ID";
        }

        private bool Valida()
        {
            if (this.cliente == null)
            {
               MessageBox.Show("Elija el cliente que realiza la queja o sugerencia");
                this.SeleccionaCliente();
                return false;
            }

            if (!this.quejaRadioButton.Checked && !this.sugerenciaRadioButton.Checked)
            {
               MessageBox.Show("Indique si es queja o sugerencia", "Queja/Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.quejaRadioButton.Focus();
                return false;
            }

            if (this.fechaSucesoDateTimeInput.Value == new DateTime())
            {
               MessageBox.Show("Ingrese la fecha del suceso");
                fechaSucesoDateTimeInput.Focus();
                return false;
            }

            if (this.tipoQuejaSugerenciaComboBoxEx.SelectedValue == null)
            {
               MessageBox.Show("Seleccione el tipo de queja o sugerencia");
                tipoQuejaSugerenciaComboBoxEx.Focus();
                tipoQuejaSugerenciaComboBoxEx.DroppedDown = true;
                return false;
            }

            if (this.comboBoxEx1.SelectedValue == null)
            {
               MessageBox.Show("Seleccione el sub tipo de queja o sugerencia");
                comboBoxEx1.Focus();
                comboBoxEx1.DroppedDown = true;
                return false;
            }
            if (this.sucursalComboBoxEx.SelectedValue == null)
            {
               MessageBox.Show("Seleccione el tipo de queja o sugerencia");
                sucursalComboBoxEx.Focus();
                sucursalComboBoxEx.DroppedDown = true;
                return false;
            }

            if (string.IsNullOrEmpty(this.quejaTextBox.Text))
            {
               MessageBox.Show("Describa la queja o sugerencia", "Queja/Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                quejaTextBox.Focus();
                return false;
            }

            return true;
        }

        #endregion

        public bool Mostrado { get; set; }

        private void backButton_Click(object sender, EventArgs e)
        {
            backButton.Enabled = false;
            this.Back();
            backButton.Enabled = true;
        }

        private void SeleccionaCliente()
        {
            View.Catalogos.ClienteControl frmCliente = new View.Catalogos.ClienteControl();
            frmCliente.Dock = DockStyle.Fill;
            frmCliente.Owner = this;

            frmCliente.Muestra();
        }

        SIFModelo.Cliente cliente;
        public void AgregaCliente(SIFModelo.Cliente cliente)
        {
            this.cliente = cliente;

            this.clienteLabelX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            seleccionaClienteButtonItem.Enabled = false;
            this.SeleccionaCliente();
            seleccionaClienteButtonItem.Enabled = true;
        }

        private void Guardar()
        {
            if (this.Valida())
            {
                QuejaSugerencia.SUCURSAL_ID = int.Parse(sucursalComboBoxEx.SelectedValue.ToString());


                if (QuejaSugerencia.QUEJA_SUGERENCIA_ID != 0)
                {
                    QuejaSugerencia.USER_GENERO_ID = this.usuario.UsuariosID.ToString();
                    QuejaSugerencia.SOLUCION = textBoxX1.Text;
                    QuejaSugerencia.FECHA_SOLUCION = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    QuejaSugerencia.ESTATUS = "C";
                    Negocio.ModificaQuejaSugerencia(QuejaSugerencia);
                    this.Back();
                }

                else
                {
                    QuejaSugerencia.SOLUCION = textBoxX1.Text;
                    QuejaSugerencia.FECHA_SOLUCION = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    QuejaSugerencia.USER_GENERO_ID = this.usuario.UsuariosID.ToString();
                    QuejaSugerencia.CLIENTE_ID = this.cliente.ID;
                    QuejaSugerencia.COMENTARIO = this.quejaTextBox.Text;
                    QuejaSugerencia.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                    QuejaSugerencia.FECHA_SUCESO = this.fechaSucesoDateTimeInput.Value;
                    QuejaSugerencia.QUEJA_SUGERENCIA = quejaRadioButton.Checked ? "Q" : "S";
                    QuejaSugerencia.CAT_QUEJA_SUGERENCIA_ID = short.Parse(tipoQuejaSugerenciaComboBoxEx.SelectedValue.ToString());
                    QuejaSugerencia.CAT_QUEJA_SUGERENCIA_TIPO_ID = (short)int.Parse(comboBoxEx1.SelectedValue.ToString());

                    QuejaSugerencia.USER_LEVANTO_ID = this.usuario.UsuariosID.ToString();
                    QuejaSugerencia.ESTATUS = "A";
                    if (Negocio.NuevaQuejaSugerencia(QuejaSugerencia))
                    {
                       MessageBox.Show("Se ha creado la queja o sugerencia");
                        this.Back();
                    }
                    else
                    {
                       MessageBox.Show("No se ha guardado la queja o sugerencia, verifique sus datos", "Queja/Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void QuejaSugerenciaUserControl_Load(object sender, EventArgs e)
        {
            this.usuarioGeneraLabelX.Text = this.usuario.Nombre + " " + usuario.Apellidos;
            if (this.QuejaSugerencia == null)
            {
                this.QuejaSugerencia = this.Negocio.DataSet.QUEJA_SUGERENCIA.NewQUEJA_SUGERENCIARow();
                this.QuejaSugerencia.QUEJA_SUGERENCIA_ID = 0;
            }
        }

        private void guardarButtonItem_Click(object sender, EventArgs e)
        {
            guardarButtonItem.Enabled = false;
            this.Guardar();
            guardarButtonItem.Enabled = true;
        }

        private void tipoQuejaSugerenciaComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoQuejaSugerenciaComboBoxEx.SelectedValue.ToString().IsInteger())
            {
                SIFNegocio.QuejasSug.CatQuejasSugTipo QuejaSug = new SIFNegocio.QuejasSug.CatQuejasSugTipo();
                DataSet DsCatQuejas;
                BindingSource bs = new BindingSource();
                bs.DataSource = QuejaSug.Buscar("", "", int.Parse(tipoQuejaSugerenciaComboBoxEx.SelectedValue.ToString()));
                bs.DataMember = "CatQuejasSugTipo";
                this.comboBoxEx1.DataSource = bs;
                comboBoxEx1.DisplayMember = "NOMBRE";
                comboBoxEx1.ValueMember = "CAT_QUEJA_SUGERENCIA_TIPO_ID";
            }
        }
    }
}
