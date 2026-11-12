using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace SIFDatos.Extras
{
    public static class Estado
    {
        public static List<SIFModelo.Extras.Estado> CargaEstados()
        {
            List<SIFModelo.Extras.Estado> estados = new List<SIFModelo.Extras.Estado>();

            string sentencia = "SELECT * FROM estados ORDER BY nombre ASC ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Extras.Estado registro = new SIFModelo.Extras.Estado();

                            registro.EstadoID = int.Parse(oreader["ID"].ToString());
                            registro.Nombre = oreader["NOMBRE"].ToString();
                            registro.Clave = oreader["CLAVE"].ToString();
                            registro.Abreviatura = oreader["ABREV"].ToString();

                            estados.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return estados;
        }

        public static List<SIFModelo.Extras.Municipio> CargaMunicipios(SIFModelo.Extras.Estado estado)
        {
                List<SIFModelo.Extras.Municipio> municipios = new List<SIFModelo.Extras.Municipio>();
            try
            {
                string sentencia = "SELECT municipios.* FROM municipios WHERE UPPER(municipios.ESTADO) = :eEstado ORDER BY municipios.NOMBRE";

                using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
                {

                    using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                    {
                        //parametros
                        cmd.Parameters.Add("eEstado", estado.Nombre.ToUpper());
                        //
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                        if (oreader.HasRows)
                        {
                            while (oreader.Read())
                            {
                                SIFModelo.Extras.Municipio registro = new SIFModelo.Extras.Municipio();

                                registro.MunicipioID = int.Parse(oreader["MUNICIPIO"].ToString().ToUpper());
                                registro.Nombre = oreader["NOMBRE"].ToString().ToUpper();
                                registro.Estado = oreader["ESTADO"].ToString().ToUpper();

                                municipios.Add(registro);
                            }
                        }
                        cmd.Connection.Close();
                        cmd.Dispose();
                       //OracleConnection.ClearPool(cmd.Connection);

                    }

                }
                return municipios;
            }
            catch (Exception x) { return municipios; }
        }

        public static List<SIFModelo.Extras.Colonia> CargaColonias(SIFModelo.Extras.Municipio municipio)
        {
            List<SIFModelo.Extras.Colonia> municipios = new List<SIFModelo.Extras.Colonia>();

            string sentencia = "SELECT * FROM colonias WHERE UPPER(municipio) = :Municipio ORDER BY nombre ASC ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Municipio", municipio.Nombre);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Extras.Colonia registro = new SIFModelo.Extras.Colonia();

                            registro.ColoniaID = int.Parse(oreader["COLONIA"].ToString().ToUpper());
                            registro.Nombre = oreader["NOMBRE"].ToString().ToUpper();
                            registro.Municipio = oreader["MUNICIPIO"].ToString().ToUpper();

                            municipios.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return municipios;
        }

        public static List<SIFModelo.Extras.Colonia> CargaColoniasPorEstado(SIFModelo.Extras.Municipio municipio)
        {
            List<SIFModelo.Extras.Colonia> colonias = new List<SIFModelo.Extras.Colonia>();

            string sentencia = "SELECT C.* FROM MUNICIPIOS M " +
                               " INNER JOIN COLONIAS C " +
                               " ON C.MUNICIPIO = M.NOMBRE " + 
                               " WHERE UPPER(M.NOMBRE) = :Municipio ORDER BY C.nombre ASC ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Municipio", municipio.Estado.ToUpper());
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Extras.Colonia registro = new SIFModelo.Extras.Colonia();

                            registro.ColoniaID = int.Parse(oreader["COLONIA"].ToString().ToUpper());
                            registro.Nombre = oreader["NOMBRE"].ToString().ToUpper();
                            registro.Municipio = oreader["MUNICIPIO"].ToString().ToUpper();

                            colonias.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return colonias;
        }

        public static List<SIFModelo.Extras.CPS> CargaCPS(SIFModelo.Extras.Colonia colonia)
        {
            List<SIFModelo.Extras.CPS> municipios = new List<SIFModelo.Extras.CPS>();

            string sentencia = "SELECT * FROM cps WHERE UPPER(nombre) = :Colonia ";

            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {

                using (OracleCommand cmd = new OracleCommand(sentencia, cnx))
                {
                    //parametros
                    cmd.Parameters.Add("Colonia", colonia.Nombre);
                    //
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    OracleDataReader oreader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (oreader.HasRows)
                    {
                        while (oreader.Read())
                        {
                            SIFModelo.Extras.CPS registro = new SIFModelo.Extras.CPS();

                            registro.cpsID = int.Parse(oreader["CPS"].ToString().ToUpper());
                            registro.Nombre = oreader["NOMBRE"].ToString().ToUpper();
                            registro.Codigo = oreader["CODIGO"].ToString().ToUpper();

                            municipios.Add(registro);
                        }
                    }
                    cmd.Connection.Close();
                    cmd.Dispose();
                   //OracleConnection.ClearPool(cmd.Connection);

                }

            }
            return municipios;
        }
    }
}
