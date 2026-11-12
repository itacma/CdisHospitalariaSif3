using SIFModelo.OrdenCompra;
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
    public partial class frmSelectNotaDeCredito : DevComponents.DotNetBar.Metro.MetroForm
    {
        
        public TipoNcSaldoUtilizado modelo;
        public bool exito = false;
        private string _rmd= string.Empty;
        private Decimal _SaldoRequerido =0M;
        public frmSelectNotaDeCredito( string p_rdm, decimal  p_saldo_requerido)
        {
            InitializeComponent();
            load_controls();
            _rmd = p_rdm;
            _SaldoRequerido=p_saldo_requerido  ;

        }

        private void load_controls() {
            SIFNegocio.OrdenCompra.NotasDecredito NotasCredito = new SIFNegocio.OrdenCompra.NotasDecredito();
            DataSet ds = NotasCredito.getNotasCreditoVigentes();
            this.dataGridViewX1.DataSource = ds;
            this.dataGridViewX1.DataMember = "FC_NOTA_CREDITO";

        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Decimal saldoDisponible = Convert.ToDecimal( dataGridViewX1.CurrentRow.Cells[5].Value.ToString());

            if (saldoDisponible <= _SaldoRequerido) {
                MessageBox.Show($"El saldo disponible ${saldoDisponible} no es suficiente para cubrir el saldo requerido ${_SaldoRequerido}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            modelo = new TipoNcSaldoUtilizado();
            modelo.Id = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            modelo.Sucursal_id = Helpers.Sesion.Sucursal.SucursalesID;
            modelo.Partida = 1;
            modelo.Concepto ="Saldo disponble NC " +saldoDisponible.ToString();
            modelo.Folio_rdm=_rmd;
            modelo.Folio_referencia = "Referencia";
            modelo.Saldo = _SaldoRequerido;
            modelo.Usuario_id = Helpers.Sesion.Usuario.UsuariosID.ToString();
            modelo.Activo = "P";



            if (DialogResult.Yes == MessageBox.Show($"¿Asociar nota de credito {modelo.Id}?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                SIFNegocio.OrdenCompra.NotasDecredito NotasCredito = new SIFNegocio.OrdenCompra.NotasDecredito();
                string respuesta = NotasCredito.insertaRelacionNC(modelo);
                if (respuesta.Contains("1:OK"))
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: "+respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modelo = new TipoNcSaldoUtilizado();
                    this.DialogResult = DialogResult.Cancel;
                    return;
                    
                }

            }
            else {
                this.DialogResult = DialogResult.Cancel;
                modelo = new TipoNcSaldoUtilizado();
                return;
            
            }
        }
    }
}
