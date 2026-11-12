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
    public partial class FaltantesForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FaltantesForm(SIFModelo.Usuario usuario, List<SIFModelo.Articulo> articulos)
        {
           // InitializeComponent();
            //dataGridViewX1.AutoGenerateColumns = false;
            this.usuario = usuario;
            this.articulos = articulos;
            this.CargaFaltantes(articulos);
            this.GuardarFaltantes();
            //foreach (SIFModelo.Articulo a in articulos)
              //  a.TIPO_MONEDA = 0;
        }

        private SIFModelo.Usuario usuario;
        private List<SIFModelo.Articulo> articulos;

        private bool Valida()
        {
            if (this.dataGridViewX1.Rows.Count == 0)
            {
               MessageBox.Show("No hay artículos a reportar");

                return false;
            }

            return true;
        }

        SIFModelo.Inventarios.InventarioDataSet.FALTANTERow faltante;
        private void CargaFaltantes(List<SIFModelo.Articulo> articulos)
        {


            faltante = this.faltantesL.DataSet.FALTANTE.NewFALTANTERow();
            faltante.USER_GENERO_ID = usuario.UsuariosID.ToString();
            faltante.CAT_USUARIOS_NOMBRE = usuario.Nombre;
            //faltante.COMENTARIO = this.comentariosTextBoxX.Text;
            faltante.COMENTARIO="";
            faltante.FECHA_FALTANTE = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            faltante.SUCURSAL_ID = Helpers.Sesion.Sucursal.SucursalesID;
            faltante.SUCURSAL_NOMBRE = Helpers.Sesion.Sucursal.Nombre;
            //faltantesL.InsertaFaltante(faltante);

           // this.folioLabel.Text = faltantesL.FolioFalntante(Helpers.Sesion.Sucursal).ToString();


            foreach (SIFModelo.Articulo articulo in articulos)
            {
                SIFModelo.Inventarios.InventarioDataSet.FALTANTE_DETRow faltanteD = this.faltantesL.DataSet.FALTANTE_DET.NewFALTANTE_DETRow();
                faltanteD.ARTICULO_ID = articulo.ARTICULO_ID;
                faltanteD.CANTIDAD = articulo.TIPO_MONEDA;
                //faltanteD.FOLIO_FALTANTE = faltante.FOLIO_FALTANTE;
                faltanteD.NOMBRE1 = articulo.NOMBRE1;
                faltanteD.SUCURSAL_ID = faltante.SUCURSAL_ID;

                var vFaltante = from f in faltantesL.DataSet.FALTANTE_DET where f.ARTICULO_ID == articulo.ARTICULO_ID select f;

                if (vFaltante.Count() > 0)
                {
                    vFaltante.First().CANTIDAD += articulo.TIPO_MONEDA;
                }
                else
                {
                    this.faltantesL.DataSet.FALTANTE_DET.AddFALTANTE_DETRow(faltanteD);
                }
                //faltantesL.InsertaFaltanteDetalle(faltanteD);
            }

            //this.dataGridViewX1.DataSource = this.faltantesL.DataSet.FALTANTE_DET;
        }

        SIFNegocio.Inventario.Faltantes faltantesL = new SIFNegocio.Inventario.Faltantes();
        private void GuardarFaltantes()
        {
          //  if (Valida())
            //{

                this.faltante.USER_GENERO_ID = this.usuario.UsuariosID.ToString();
                SIFModelo.Sucursal sucursal = new SIFNegocio.Sucursales().SucursalPorID(faltante.SUCURSAL_ID);
                this.faltante.FOLIO_FALTANTE = faltantesL.FolioFalntante(sucursal);
                //COLOCAR LOS DEMAS
                faltantesL.InsertaFaltante(faltante);

                foreach (SIFModelo.Inventarios.InventarioDataSet.FALTANTE_DETRow detalle in this.faltantesL.DataSet.FALTANTE_DET)
                {
                    detalle.FOLIO_FALTANTE = faltante.FOLIO_FALTANTE;
                    if (detalle.CANTIDAD==0)
                        detalle.CANTIDAD=1;
                    faltantesL.InsertaFaltanteDetalle(detalle);
                }

               MessageBox.Show("Se ha notificado el faltante en el inventario", "Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (SIFModelo.Inventarios.InventarioDataSet.FALTANTE_DETRow detalle in this.faltantesL.DataSet.FALTANTE_DET)
                {
                    detalle.CANTIDAD = 0;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
           // }

        }

        private void Cancelar()
        {
            DialogResult res =MessageBox.Show("¿Salir sin notificar los faltantes?", "Faltantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cancelarButtonX_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.GuardarFaltantes();
        }

        private void FaltantesForm_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.comentariosTextBoxX.Focus();
        }
    }
}
