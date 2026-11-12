using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using DevComponents.DotNetBar;
using Equin.ApplicationFramework;


namespace SIFNegocio.Inventario
{
    public class Kardex
    {
        public BindingListView<SIFModelo.LTipoMK> ListaTipoM;
        public BindingListView<SIFModelo.Proveedor> ListaProv;

        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetKardex(DateTime fechaInicio, DateTime fechaFin, string Activo, string Artculo_ID, string  TipoMovimiento)
        {
            return SIFDatos.Inventario.KardexAlmacen.GetKardex(fechaInicio.ToString("dd/MM/yyyy HH:mm:ss"), fechaFin.ToString("dd/MM/yyyy HH:mm:ss"), Artculo_ID, TipoMovimiento);
        }
        public BindingListView<SIFModelo.LTipoMK> BuscaTipoMK()
        {
            ListaTipoM = new BindingListView<SIFModelo.LTipoMK>(SIFDatos.Inventario.KardexAlmacen.BTMK());
            return ListaTipoM;
        }

        public BindingListView<SIFModelo.Proveedor> BuscaProv()
        {
            ListaProv = new BindingListView<SIFModelo.Proveedor>(SIFDatos.Inventario.KardexAlmacen.PROV());
            return ListaProv;
        }

        public DataTable sp_Get_Art_cadPorFecha(DateTime fechaI)
            {
            return SIFDatos.Inventario.KardexAlmacen.sp_Get_Art_cad_porFecha(fechaI.ToString("dd/MM/yyyy HH:mm:ss"));
            }
        public DataSet GetKardexN(DateTime fechaInicio, DateTime fechaFin, string Activo, string Artculo_ID, string TipoMovimiento,string Proveedor)
        {
         
            return SIFDatos.Inventario.KardexAlmacen.getKardexCad(fechaInicio.ToString("dd/MM/yyyy HH:mm:ss"), fechaFin.ToString("dd/MM/yyyy HH:mm:ss"), Artculo_ID, TipoMovimiento,Proveedor);

        }



    }
    

}
