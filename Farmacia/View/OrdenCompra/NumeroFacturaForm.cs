using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class NumeroFacturaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public NumeroFacturaForm()
        {
            InitializeComponent();
            dataGridViewX1.AutoGenerateColumns = false;
        }

        public NumeroFacturaForm(SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC)
        {
            this.InitializeComponent();
            // TODO: Complete member initialization
            this.oC = oC;
            this.ordenCompraLabel.Text = oC.FOLIO_OC_ID;
            this.proveedorLabel.Text = "[" + oC.PROVEEDOR_ID + "]" + oC.CAT_CLIENTES_NOMBRE;
        }

        public string NumeroFactura = "";
        private SIFModelo.OrdenCompra.OrdenesCompraDataSet.V_ORDEN_COMPRARow oC;
        private bool validaFactura()
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Debe seleccionar la factura");
                return false;
            }


            return true;
        }


        SIFNegocio.OrdenCompra.OrdenCompra ordenComrpaL = new SIFNegocio.OrdenCompra.OrdenCompra();
        private void cargaFacturas()
        {


            this.dataGridViewX1.DataSource = new DataView(ordenComrpaL.FacturasCoincidente(this.oC, this.dateTimeInput1.Value, dateTimeInput2.Value));
        }
        DataGridViewCellStyle TransferCellStyle = new DataGridViewCellStyle();//superGridControl1.DefaultVisualStyles.RowStyles;




        private void buscaLocal()
        {
            if (this.dataGridViewX1.DataSource == null)
            {
                return;
            }

            ((DataView)this.dataGridViewX1.DataSource).RowFilter = "NUM_FACTURA LIKE '%" + this.numeroFacturaTextBoxX.Text + "%'";
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void Aceptar()
        {
            if (validaFactura())
            {
                if (this.dataGridViewX1.CurrentRow == null)
                {
                   MessageBox.Show("Elija una factura de la lista");
                    return;
                }

                SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow factura = ((DataRowView)this.dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow;

                this.NumeroFactura = factura.NUM_FACTURA;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.aceptarButtonX_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.numeroFacturaTextBoxX.Clear();
                this.buscaLocal();
            }
        }

        private void NumeroFacturaForm_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Value = DateTime.Now;
            dateTimeInput2.Value = DateTime.Now;

            dataGridViewX1.AutoGenerateColumns = false;

            TransferCellStyle.BackColor = Color.FromArgb(200, 100, 100);
            TransferCellStyle.BackColor = Color.FromArgb(200, 100, 100);

            this.cargaFacturas();
        }

        private void numeroFacturaTextBoxX_TextChanged(object sender, EventArgs e)
        {
            this.buscaLocal();
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow row = ((DataRowView)(((dataGridViewX1.Rows[e.RowIndex]).DataBoundItem))).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.FACTURA_PROVEEDORRow;

            if (row != null)
            {
                if (row.ESTADO == "A")
                {
                    dataGridViewX1.Rows[e.RowIndex].DefaultCellStyle = TransferCellStyle;
                }
            }

        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            cargaFacturas();
        }

        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            cargaFacturas();
        }
    }
}
