using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class NotasDeCreditoControl : Templates.ListaUserControl
    {
        private String  Cual = "";
        public int ModuloID;
        public string tipo_movi_c;
        public AsignacionPreciosOrdenCompraDetallesUserControl Ownern;
        
        public NotasDeCreditoControl()
        {
            InitializeComponent();
            this.dateTimeInput1.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.dateTimeInput2.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    if (ModuloID == 3)
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 24, int.Parse(Xbtn.Tag.ToString()));
                    else if (Xbtn.Tag.ToString() == "47")//PIT 18/01/2022 Respetar el permiso del tag original
                    {

                    }
                    else
                        Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 36, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        private void Nuevo()
        {
            //BOTON PARA NUEVO REGISTRO
            frmNewNotaDeCredito frm =new frmNewNotaDeCredito(null);
            frm.Show();
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

         public MainForm Owner { get; set; }
        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Buscar();

        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);                
                Mostrado = false;
            }
            catch { }
        }

        public void Buscar()
        {
            String stado ="";
            string p_folio = "";
            switch (Cual) { 

            
                case "ABIERTOS":                stado = "S"; break;
                case "CERRADOS":                stado = "C"; break;
                case "CANCELADOS":              stado = "X"; break;
                case "LIBERADOS":               stado = "L"; break;
            default:                 stado = "%";
                    
                    break;

            }
            
            p_folio = (!string.IsNullOrEmpty(foliotextBoxX.Text)) ? "%"+foliotextBoxX.Text+"%" : "%";

            SIFNegocio.OrdenCompra.NotasDecredito NotasCredito = new SIFNegocio.OrdenCompra.NotasDecredito();
            DataSet ds = NotasCredito.getNotasCredito(
                dateTimeInput1.Value.ToString("dd/MM/yyyy"), dateTimeInput2.Value.ToString("dd/MM/yyyy"), p_folio, stado);
            ds.Relations.Add("1",
                                ds.Tables["FC_NOTA_CREDITO"].Columns["ID"],
                                ds.Tables["FC_NOTA_CREDITO_DET"].Columns["ID"],
                                false);

            this.superGridControl1.PrimaryGrid.DataSource = ds;
            this.superGridControl1.PrimaryGrid.DataMember = "FC_NOTA_CREDITO";

        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }         
                       
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            //BOTÓN CANCELAR
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridRow activeRow = panel.ActiveRow as GridRow;
            if (activeRow != null)
            {
                if (activeRow.Cells[0] != null)
                {

                    string folioSeleccionado = activeRow.Cells[0].Value.ToString();
                    new SIFNegocio.OrdenCompra.NotasDecredito().ActualizarEstadoNotaDeCredito(folioSeleccionado, "X");
                    MessageBox.Show("La nota de crédito ha sido cancelada.");

                }               
                else
                {
                    MessageBox.Show("No hay una fila activa seleccionada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una nota de crédito para cancelar.");
            }
        }
                  
        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            imprimir();
        }
                
        private void imprimir()
        {
            String ProductName = "Ajuste";
            
            GridPanel panel = superGridControl1.PrimaryGrid;
            if (panel.ActiveRow == null)
            {
                return;
            }

            var container = ((GridContainer)panel.ActiveRow);
            if (!(container is GridRow))
            {
               MessageBox.Show("Seleccione la cabecera del traspaso");
                return;
            }
            var row = (GridRow)container;
            if (!row.Cells["ACTIVO"].Value.ToString().Contains('X') & !row.Cells["ACTIVO"].Value.ToString().Contains('R'))
            {
                string folio = row.Cells[0].Value.ToString();
                SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_AJUSTES.rpt", " {AJUSTES.FOLIO}='" + folio + "'");
                Impresion.ShowDialog();
            }
            else
                if (row.Cells["ACTIVO"].Value.ToString().Contains('R'))
               MessageBox.Show("El Ajuste no se a recibido", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
               MessageBox.Show("El Ajuste esta cancelado", "Traspasos", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void superGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridRow activeRow = panel.ActiveRow as GridRow;
            if (activeRow != null)
            {
                if (activeRow.Cells[0] != null)
                {
                    string folioSeleccionado = activeRow.Cells[0].Value.ToString();
                    frmNewNotaDeCredito frm = new frmNewNotaDeCredito(folioSeleccionado);
                    frm.Show();
                }
            }
        }

        private void porsurtirRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (porsurtirRadioButton.Checked)
            {
                Cual = "ABIERTOS";
                this.Buscar();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Cual = "CERRADOS";
                this.Buscar();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Cual = "CANCELADOS";
                this.Buscar();
            }
        }

        private void creditoRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (creditoRadioButton.Checked)
            {
                Cual = "LIBERADOS";
                this.Buscar();
            }
        }              
       
        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            //BOTÓN CERRAR FOLIO
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridRow activeRow = panel.ActiveRow as GridRow;
            if (activeRow != null)
            {
                if (activeRow.Cells[0] != null)
                {

                    string folioSeleccionado = activeRow.Cells[0].Value.ToString();
                    new SIFNegocio.OrdenCompra.NotasDecredito().ActualizarEstadoNotaDeCredito(folioSeleccionado, "C");
                    MessageBox.Show("La nota de crédito ha sido cerrada.");
                }
                else
                {
                    MessageBox.Show("No hay una fila activa seleccionada.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una nota de crédito para cancelar.");
            }
        }

        private void foliotextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void foliotextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void nuevoPedidoButtonItem_Click_1(object sender, EventArgs e)
        {
            this.Nuevo();

        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            //BOTÓN PARA EDITAR EL FOLIO           
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridRow activeRow = panel.ActiveRow as GridRow;
            if (activeRow != null)
            {
                if (activeRow.Cells[0] != null)
                {
                    string folioSeleccionado = activeRow.Cells[0].Value.ToString();
                    frmNewNotaDeCredito frm = new frmNewNotaDeCredito(folioSeleccionado);
                    frm.Show();
                }
            }

        }

        private void reposicionButtonItem_Click(object sender, EventArgs e)
        {
            String ProductName = "Reposición";

            Ventas.FechasFacturaGlobalForm frmFechas = new Ventas.FechasFacturaGlobalForm();
            frmFechas.ShowDialog();

            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_AJUSTES.rpt", " {AJUSTES.FECHA_REG} >= DATE(" + frmFechas.dateTimeInput1.Value.ToString("yyyy,MM,dd") + ") AND  {AJUSTES.FECHA_REG} >= DATE(" + frmFechas.dateTimeInput2.Value.ToString("yyyy,MM,dd") + ")", "", ProductName);
            Impresion.ShowDialog();
        }        
    }
}
