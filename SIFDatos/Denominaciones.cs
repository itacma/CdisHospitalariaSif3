using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace SIFDatos
{
    public static class Denominaciones
    {
        public static SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESDataTable CargaDenominaciones()
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Catalogo.CatalogoDataSetTableAdapters.DENOMINACIONESTableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.DENOMINACIONESTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.Fill(ds.DENOMINACIONES);
            }

            return ds.DENOMINACIONES;
        }


        public static SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow CargaDenominacionesPorId(int p)
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Catalogo.CatalogoDataSetTableAdapters.DENOMINACIONESTableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.DENOMINACIONESTableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByDenominacionesID(ds.DENOMINACIONES, p);
            }

            return ds.DENOMINACIONES.FirstOrDefault();
        }
    }
}
