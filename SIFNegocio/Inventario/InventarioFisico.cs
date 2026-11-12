using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Data;

namespace SIFNegocio.Inventario
{
    public class InventarioFisico
    {

        public DataTable GetPeriodos()
        {
            return SIFDatos.Inventario.InventarioFisico.GetPeriodos();
        }

        public DataTable GetFila(int periodo)
        {
            return SIFDatos.Inventario.InventarioFisico.GetFila(periodo);
        }

        public DataTable GetAnaquel(int periodo)
        {
            return SIFDatos.Inventario.InventarioFisico.GetAnaquel(periodo);
        }

        public DataTable sp_Get_Articulos_InvFis(int periodo, int fila,int anaquel)
        {
            return SIFDatos.Inventario.InventarioFisico.sp_Get_Articulos_InvFis(periodo, fila, anaquel);
        }
        public DataTable sp_Get_Articulos_InvFis(int periodo, int fila, string filas, int j)
        {
            return SIFDatos.Inventario.InventarioFisico.sp_Get_Articulos_InvFis(periodo, fila, filas, j);
        }

        public bool CreaInvFisico()
        {
            return SIFDatos.Inventario.InventarioFisico.CreaInvFisico();
        }

        public bool ActualizaInventarioFisico(DataTable dtArticulos, int periodo, SIFModelo.Sucursal sucursal)
        {
            DataTable dt = new DataTable("Articulos");
            dt.Columns.Add("articulo_id");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Nombre2");
            dt.Columns.Add("Fila");
            dt.Columns.Add("Anaquel");
            dt.Columns.Add("Nivel");
            dt.Columns.Add("Existencia");
            dt.Columns.Add("Conteo1");
            dt.Columns.Add("Dif1");
            dt.Columns.Add("Conteo2");
            dt.Columns.Add("Dif2");
            dt.Columns.Add("Costo_Prom");
            dt.Columns.Add("Modificada");
            //dtArticulos.AcceptChanges();
            //var rows = dtArticulos.Select("", "", DataViewRowState.ModifiedOriginal);

            foreach (DataRow row in dtArticulos.Select(" MODIFICADA = 1 ", ""))
            {
                dt.ImportRow(row);
            }

            return SIFDatos.Inventario.InventarioFisico.Actualiza(dt, periodo, sucursal);
        }

        public DataTable TaInventario { get; set; }

        public string AjusteInventarioFisico(int periodo, SIFModelo.Sucursal sucursal)
        {
            return SIFDatos.Inventario.InventarioFisico.AjusteInventarioFisico(periodo, sucursal);
        }

        public bool CreaInvFisico(DataRow row, string periodo, int sucursal)
        {
            return SIFDatos.Inventario.InventarioFisico.CreaInvFisico(row, periodo, sucursal);
        }

        public SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow sp_Get_Articulos_InvFis(string periodo, string fila, string anaquel, SIFModelo.Articulo articulo)
        {
            return null;
            return SIFDatos.Inventario.InventarioFisico.sp_Get_Articulos_InvFis(periodo, fila, anaquel, articulo);
        }
    }
}
