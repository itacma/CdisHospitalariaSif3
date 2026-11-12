using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class ArticulosIsstepForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ArticulosIsstepForm(SIFModelo.Cliente cliente, string CodigoCliente, bool porClaveArticulo)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.CodigoCliente = CodigoCliente;
            this.porClaveArticulo = porClaveArticulo;
            CargaArticulos();
        }
        bool porClaveArticulo = false;
        SIFModelo.Cliente cliente = null;
        string CodigoCliente = "";
        SIFNegocio.Subrogacion.Articulos logica = new SIFNegocio.Subrogacion.Articulos();

        private void CargaArticulos()
        {
            if (porClaveArticulo)
            {
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs,CodigoCliente, cliente.ID );
            }
            else
            {
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs, cliente.ID, CodigoCliente);
            }
            this.dataGridViewX1.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB;
        }

        public SIFModelo.Articulo articuloSeleccionado { get; set; }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            seleccionaArticulo();
        }

        private void seleccionaArticulo()
        {
            if (dataGridViewX1.SelectedRows.Count == 0)
            {
               MessageBox.Show("Debe seleccionar un artículo");
                return;
            }

            SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow row = ((DataRowView)dataGridViewX1.SelectedRows[0].DataBoundItem).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
            SIFModelo.Articulo articulo = new SIFNegocio.Articulo().BuscarPorClave(row.ARTICULO_ID);

            articuloSeleccionado = new SIFModelo.Articulo();
            articuloSeleccionado.ACTIVO = SIFModelo.Tipos.SiNo.SI;
            articuloSeleccionado.ARTICULO_ID = row.ARTICULO_ID;
            articuloSeleccionado.CODIGO_CLI = row.CODIGOCLI;
            articuloSeleccionado.CODIGO_CLI_ID = (int)row.ID;
            articuloSeleccionado.LABORATORIO_ID = row.LABORATORIO_ID;
            articuloSeleccionado.LABORATORIO_NOMBRE = articulo.LABORATORIO_NOMBRE;
            articuloSeleccionado.LISTA_SUCURSAL_VTA = articulo.LISTA_SUCURSAL_VTA;
            articuloSeleccionado.NOMBRE1 = row.NOMBRE1;
            articuloSeleccionado.NOMBRE2 = row.NOMBRE2;
            articuloSeleccionado.PAQUETE = articulo.PAQUETE;
            articuloSeleccionado.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
            articuloSeleccionado.PROVEEDOR_NOMBRE = articulo.PROVEEDOR_NOMBRE;
            articuloSeleccionado.TIPO_MEDICAMENTO_CVE = row.TIPO_MEDICAMENTO_CLI;
            articuloSeleccionado.TIPO_MONEDA = articulo.TIPO_MONEDA;
            articuloSeleccionado.U_COMPRA = articulo.U_COMPRA;
            articuloSeleccionado.U_VENTA = articulo.U_VENTA;
            articuloSeleccionado.VTA_SIN_EXISTENCIA = articulo.VTA_SIN_EXISTENCIA;

            this.articuloSeleccionado = articuloSeleccionado;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.seleccionaArticulo();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void codigoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.dataGridViewX1.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.ubicar();
            }
        }

        private void ubicar()
        {
            foreach (DataGridViewRow grow in dataGridViewX1.Rows)
            {

                SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow row = ((DataRowView)grow.DataBoundItem).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;


                if (row.ARTICULO_ID == this.codigoTextBoxX.Text || row.CODIGOCLI == this.codigoTextBoxX.Text)
                {
                    if (porClaveArticulo)
                    {
                        if (row.CODIGOCLI!= this.codigoTextBoxX.Text)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (row.ARTICULO_ID != this.codigoTextBoxX.Text)
                        {
                            continue;
                        }
                    }


                    dataGridViewX1.ClearSelection();
                    grow.Selected = true;
                    this.seleccionaArticulo();
                    return;
                }

            }
            MessageBox.Show("La clave del artículo no existe con el código del cliente");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.ubicar();
        }
    }
}
