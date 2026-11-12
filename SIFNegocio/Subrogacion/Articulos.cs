using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIFModelo.Inventarios;


namespace SIFNegocio.Subrogacion
{
    public class Articulos
    {
        public Articulos()
        {
            ArticulosDs.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = DateTime.Now;
        }

        public SIFModelo.SubRogacion.Sobrogacion ArticulosDs = new SIFModelo.SubRogacion.Sobrogacion();

        public SIFModelo.SubRogacion.Sobrogacion GetArticulos(SIFModelo.SubRogacion.Sobrogacion ds, int ClienteID)
        {
            return SIFDatos.Subrogacion.Articulos.Get(ds, ClienteID);
        }

        public SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticulo(String Articulo_ID, int ClienteID)
        {
            return SIFDatos.Subrogacion.Articulos.Get(Articulo_ID, ClienteID);
        }

        public SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloID(String Articulo_ID, int ClienteID)
        {
            return SIFDatos.Subrogacion.Articulos.GetArticuloID(Articulo_ID, ClienteID);
        }

        public SIFModelo.SubRogacion.Sobrogacion Update(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            return SIFDatos.Subrogacion.Articulos.Update(ds);
        }
        
        public SIFModelo.SubRogacion.Sobrogacion insert(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            return SIFDatos.Subrogacion.Articulos.insert(ds);
        }
        public static string Delete(String ClienteID, string userId, int? institucionId = null)
        {
            return SIFDatos.Subrogacion.Articulos.Delete(ClienteID, userId, institucionId);
        }

        public SIFModelo.SubRogacion.Sobrogacion GetArticulos(SIFModelo.SubRogacion.Sobrogacion sobrogacion, int ClienteID, string CodigoCliente)
        {
            return SIFDatos.Subrogacion.Articulos.Get(sobrogacion, ClienteID, CodigoCliente);
        }

        public SIFModelo.SubRogacion.Sobrogacion GetArticulos(SIFModelo.SubRogacion.Sobrogacion sobrogacion, string CodigoArticulo, int ClienteID )
        {
            return SIFDatos.Subrogacion.Articulos.Get(sobrogacion, CodigoArticulo, ClienteID);
        }

        internal SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloSubID(string ArticuloId, string ArticuloSub_ID, int ClienteID)
        {
            return SIFDatos.Subrogacion.Articulos.GetArticuloSubID(ArticuloId, ArticuloSub_ID,  ClienteID);
        }

        internal SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow GetArticuloSubID(string ArticuloSub_ID, int ClienteID)
        {
            return SIFDatos.Subrogacion.Articulos.GetArticuloSubID(ArticuloSub_ID,  ClienteID);
        }
        public String sp_insCatalogoSubImp3012(
            int cliente,
            string usuarioid,
            String[] Clave,
            String[] ClaveGob,
            String[] Isss,
            Decimal[] Precio,
            String[] tipo,
            //string fechaInicio,
            //string fechaFin,
            string agregar) {
            return SIFDatos.Subrogacion.Articulos.sp_insCatalogoSubImp3012(cliente,usuarioid,  Clave, ClaveGob,Isss,Precio,tipo, agregar);
        }

        public String insertaCatalogoImp(
            //int cliente, string usuarioid, String[] Clave, String[] ClaveGob, String[] Isss, String[] Tipo, Decimal[] Precio, String[] fechaInicio, String[] fechaFin, string agrega)
            int cliente,
            String[] Clave,
            Decimal[] Precio,
            //string fechaInicio,
            //string fechaFin,
            string name_file,
            string usuario,
            int? institucionId//,
            //string agregar
            )
        {
            return SIFDatos.Subrogacion.Articulos.insertaCatalogoSubImp(cliente, Clave, Precio,  name_file, usuario, institucionId);
        }

        // Passthrough a la función de datos para detectar overlapping
        public static List<Tuple<string, DateTime, DateTime, int?>> GetOverlappingArticles(int clienteId, int? institucionId, IEnumerable<string> articuloIds, DateTime newInicio, DateTime newFin)
        {
            return SIFDatos.Subrogacion.Articulos.GetOverlappingArticles(clienteId, institucionId, articuloIds, newInicio, newFin);
        }

        public static List<SIFModelo.SubRogacion.CatalogoConvenio> GetCatalogosMes(int? ClienteID = null)
        {
            return SIFDatos.Subrogacion.Articulos.GetCatalogosMes(ClienteID);
        }

    }

}
