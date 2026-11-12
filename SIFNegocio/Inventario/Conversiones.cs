using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Inventario
{
    public class Conversiones
    {
        public SIFModelo.Inventarios.InventarioDataSet AjustesDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet GetConversion(DateTime fechaInicio, DateTime fechaFin,string Activo,string Folio)
        {
            
            return SIFDatos.Inventario.ConversionAlmacen.GetConversion(fechaInicio.ToString("dd/MM/yyyy hh:mm:ss"), fechaFin.ToString("dd/MM/yyyy hh:mm:ss"), Activo, Folio, Helpers.Sesion.Sucursal);
        }
        public SIFModelo.Inventarios.InventarioDataSet GetConversion(string Folio)
        {
            return SIFDatos.Inventario.ConversionAlmacen.GetConversion( Folio,Helpers.Sesion.Sucursal);
        }

        public void InsConversion(String Referencia, String Fecha, String UsuarioID,
                                 String Estado,
                                 String[] ArtId,
                                 String[] Nombre,
                                 int[] Cant,
                                 String[] EquiID,
                                 String[] EquiDes,
                                 int[] CantE,
                                double[] Costo, double[] CostoE, int[] Sec)
        {
            SIFDatos.Inventario.ConversionAlmacen.InsConversion(Helpers.Sesion.Sucursal, Referencia, Fecha, UsuarioID, Estado, ArtId, Nombre, Cant, EquiID, EquiDes, CantE, Costo, CostoE,Sec);
        }

        public void UpdConversion(string Folio, String Referencia, String UsuarioID, String Estado,
                                String[] ArtId, String[] Nombre,
                                int[] Cant, String[] ArtidIDe, String[] NombreE,
                                int[] CantE, double[] Costo, double[] CostoE, int[] Sec)
        {
            SIFDatos.Inventario.ConversionAlmacen.UpdConversion(Folio, Referencia, UsuarioID, Estado, ArtId, Nombre, Cant, ArtidIDe, NombreE, CantE, Costo, CostoE, Sec);
        }

        public void CancelaConversion(string Folio)
        {
            SIFDatos.Inventario.ConversionAlmacen.CancelaConversion(Folio);
        }
        public int AplicaConversion(string Folio, int Sucursal, string Usuario,
                                    String[] ArtId, String[] Nombre, int[] Cant, String[] ArtIDe,
                                    String[] NombreE, int[] CantE, double[] Costo, double[] CostoE)
        {
            return SIFDatos.Inventario.ConversionAlmacen.AplicaConversion(Folio, Sucursal, Usuario,
                                    ArtId, Nombre, Cant, ArtIDe,
                                    NombreE, CantE, Costo, CostoE);
        }
     }

}
