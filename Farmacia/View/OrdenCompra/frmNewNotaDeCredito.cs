using DevComponents.DotNetBar;
using Oracle.DataAccess.Types;
//using SIFDatos.OrdenCompra;
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
    public partial class frmNewNotaDeCredito : DevComponents.DotNetBar.Metro.MetroForm
    {
        private string folio;

        public frmNewNotaDeCredito(string folio)
        {
            InitializeComponent();
            load_controls();
            //this.folio = folio;
            //datosFolio = SIFNegocio.OrdenCompra.NotasDecredito.ObtenerDatosFolio(folio);
            //CargarDatosFolio();
            if (string.IsNullOrEmpty(folio))
            {                
                this.Text = "Crear Nueva Nota de Crédito";                
            }
            else
            {
                this.folio = folio;
                //datosFolio = SIFNegocio.OrdenCompra.NotasDecredito.ObtenerDatosFolio(folio);
                CargarDatosFolio();
            }
        }

        private void load_controls() {
            this.FechaIniciodateTimeInput.Value = DateTime.Parse("01/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            this.FechaFindateTimeInput.Value = DateTime.Parse(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month.ToString() + "/" + SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year.ToString());
            MotivoTextBoxX.MaxLength = 100;
            conceptoTextBoxX.MaxLength = 100;
            cargaProveedores();
        }

        bool decimalEnteredSubtotal = false;
        private void SubtotalTextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'
                || (e.KeyChar == '.'
                && decimalEnteredSubtotal
                ))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    decimalEnteredSubtotal = true;
                }
            }
           

        }
        bool decimalEnterediVA = false;
        private decimal subtotal;
        private decimal iva;
        private decimal total;
        //private DatosFolio datosFolio;

        private void IvaTextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'
                || (e.KeyChar == '.'
                && decimalEnterediVA
                ))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    decimalEnterediVA = true;
                }
            }
            if (!String.IsNullOrEmpty(SubtotalTextBoxX.Text))
            {

                if (SubtotalTextBoxX.Text.Length > 0) { 
                
                
                }
            }
            
        }
        private void calculaImporte(decimal iva) {
            total = numericUpDownSubtotal.Value + iva;
            labelImporte.Text="$"+total.ToString("F2");            
        }

        private void checkBoxIVA_CheckedChanged_1(object sender, EventArgs e)
        {
            subtotal = numericUpDownSubtotal.Value;

            if (checkBoxIVA.Checked)
            {
                iva = subtotal * 0.16M;
                Console.WriteLine("El valor del IVA es: " + iva.ToString("C2"));
                calculaImporte(iva);
            }
            else
            {
                calculaImporte(0);
            }
        }

        private void FechaIniciodateTimeInput_ValueChanged(object sender, EventArgs e)
        {
            //code
        }
        private void FechaFindateTimeInput_ValueChanged(object sender, EventArgs e)
        {
            //code
        }
        private void ProveedorComboBoxEx_SelectedValueChanged(object sender, EventArgs e)
        {
            //segment code
        }

        private void numericUpDownSubtotal_ValueChanged(object sender, EventArgs e)
        {
            calculaImporte(0);
        }

        private void CargarDatosFolio()
        {
           /* var datosFolio = SIFNegocio.OrdenCompra.NotasDecredito.ObtenerDatosFolio(folio);

            if (datosFolio != null)
            {
                DateTime fechaInicio = ((OracleDate)datosFolio.FechaInicio).Value;
                DateTime fechaFin = ((OracleDate)datosFolio.FechaFin).Value;
                FechaIniciodateTimeInput.Value = fechaInicio;
                FechaFindateTimeInput.Value = fechaFin;
                MotivoTextBoxX.Text = datosFolio.Motivo;
                FolioFiscalTextBoxX.Text = datosFolio.FolioFiscal;
                ProveedorComboBoxEx.Text = datosFolio.Proveedor;
                SubtotalTextBoxX.Text = datosFolio.Subtotal.ToString("F2");
                IvaTextBoxX.Text = datosFolio.Iva.ToString("F2");
                var total = datosFolio.Subtotal + datosFolio.Iva;
                numericUpDownSubtotal.Text = total.ToString("F2");

                checkBoxIVA.Checked = datosFolio.Iva > 0;

                FechaIniciodateTimeInput.Enabled = false;
                FechaFindateTimeInput.Enabled = false;
                MotivoTextBoxX.Enabled = false;
                ProveedorComboBoxEx.Enabled = false;
            }

            else
            {
                MessageBox.Show("No se encontró información para el folio seleccionado.");
            }*/
        }

        
        private void cargaProveedores()
        {
            SIFNegocio.Clientes clientesL = new SIFNegocio.Clientes();
            if (SIFNegocio.Clientes.ProveedoresList.Count == 0)
            {
                SIFNegocio.Clientes.ProveedoresList = clientesL.BuscarProveedores("", "").DataSource as List<SIFModelo.Cliente>;
            }

            List<SIFModelo.Cliente> proveedores = SIFNegocio.Clientes.ProveedoresList;

            foreach (SIFModelo.Cliente cliente in proveedores)
            {
                cliente.Nombre = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno + " - " + cliente.ID;
            }

            this.ProveedorComboBoxEx.DataSource = proveedores;
            ProveedorComboBoxEx.DisplayMember = "Nombre";
            ProveedorComboBoxEx.ValueMember = "ID";
        }



        private DialogResult guardar() {
            if (valida())
            {
                decimal iva = 0;

                SIFNegocio.OrdenCompra.NotasDecredito NotasCredito = new SIFNegocio.OrdenCompra.NotasDecredito();
                SIFModelo.Cliente pro = ProveedorComboBoxEx.SelectedItem as SIFModelo.Cliente;
                Decimal[] _prov = { pro.ID };
                Decimal[] _partida = { 1 };
                Decimal[] _saldoTot = { total };
                String[] _Concepto = { "Creacion" };
                String[] _Foliofiscal = { FolioFiscalTextBoxX.Text };
                decimal _subtotal =  subtotal ;
                decimal _iva = iva;

                if (string.IsNullOrEmpty(folio))
                {
                    String respuesta = NotasCredito.insNotaDeCredtio(Helpers.Sesion.Usuario.UsuariosID.ToString(),
                    MotivoTextBoxX.Text,
                    FechaIniciodateTimeInput.Value.ToString("dd/MM/yyyy"),
                    FechaFindateTimeInput.Value.ToString("dd/MM/yyyy"),
                    _prov,
                    _partida,
                    _saldoTot,
                    _Concepto,
                    _Foliofiscal,
                    _subtotal,
                    _iva);
                    return showmensaje(respuesta, "I");
                }

                else
                {
                    DateTime fechaInicio = FechaIniciodateTimeInput.Value;
                    DateTime fechaFin = FechaFindateTimeInput.Value;
                    decimal total = _subtotal + _iva;
                    new SIFNegocio.OrdenCompra.NotasDecredito().ActualizarDatosFolio(folio, fechaInicio, fechaFin, _subtotal, _Foliofiscal[0], _iva, total);
                    
                    return showmensaje("Datos actualizados correctamente.", "I");
                }
            }
                return DialogResult.Cancel;
        }

        private bool valida() {
            // Validamos si la fecha inicial es anterior a la fecha final
            DateTime fechaInicial = FechaIniciodateTimeInput.Value;
            DateTime fechaFinal = FechaFindateTimeInput.Value;
            if (fechaInicial >= fechaFinal)
            {
                showmensaje("La fecha inicio de vigencia no puede ser mayor a fecha Fin\nFavor de validar", "I");
                return false;
            }

            //Validamos el motivo 
            if (MotivoTextBoxX.Text.Length <= 2) {
                showmensaje("Capture el motivo de la nota de credito", "I");
                return false;
            }
            //Validamos el CFDI 
            if (FolioFiscalTextBoxX.Text.Length <= 2)
            {
                showmensaje("Capture el CFDI Fiscal", "I");
                return false;
            }
            //Validamos el Subtotal 
            if (numericUpDownSubtotal.Value==0)
            {
                showmensaje("El subtotal de la nota de credito debe de ser mayor a cero", "I");
                return false;
            }                      
            return true;        
        }
        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
          this.DialogResult=   guardar();
            this.Close();
        }
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            this.Close();
        }

        private DialogResult showmensaje(string p_mensaje, string mtype) {
            DialogResult dlg = DialogResult.Cancel;
            switch (mtype) {
                case "I":
               MessageBox.Show(p_mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg = DialogResult.OK;
                break;
                case "W":
                   MessageBox.Show(p_mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dlg = DialogResult.OK;
                    break;
                case "S":
                   MessageBox.Show(p_mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dlg = DialogResult.OK;
                    break;
                case "Q":

                    if (DialogResult.Yes ==MessageBox.Show(p_mensaje, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        dlg = DialogResult.Yes;
                    }
                    else
                    {
                        dlg = DialogResult.No;
                    }


                    break;
            }
            return dlg;
        }

        private void frmNewNotaDeCredito_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
