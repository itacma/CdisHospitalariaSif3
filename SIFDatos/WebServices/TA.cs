using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data;
using DevComponents.DotNetBar;

namespace SIFDatos.WebServices
{
    public static class TAE
    {
        public static SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable GetVentasTAE(string carrier, DateTime fechaInicio, DateTime fechaTermino)
        {
            Cursor.Current = Cursors.WaitCursor;

            // int nRow = 1, ind = 0;
            string PerIni = fechaInicio.ToString("dd/MM/yyy 00:00:00");
            string PerFin = fechaTermino.ToString("dd/MM/yyy 23:59:59");
            string CarrierId = carrier.Split('-')[0].Trim();

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());
            SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable ta = new SIFModelo.Catalogo.CatalogoDataSet().CTL_TAE;
            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_TAE.SP_GET_VTAS_TAE";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pFizer = cmd.Parameters.Add("refcur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);
                cmd.Parameters.Add("Carrier", OracleDbType.Int16, CarrierId, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();


                if (_rdrObj.HasRows)
                {
                    ta.Clear();

                    while (_rdrObj.Read())
                    {
                        SIFModelo.Catalogo.CatalogoDataSet.CTL_TAERow row = ta.NewCTL_TAERow();
                        // GridConciliaTae.Rows.Add(nRow);
                        row.NUM_REMISION = _rdrObj.GetString(_rdrObj.GetOrdinal("num_remision"));
                        //                        MessageBox.Show(_rdrObj.GetString(_rdrObj.GetOrdinal("num_remision"))); // + Environment.NewLine + _rdrObj.GetDecimal(_rdrObj.GetOrdinal("num_telefono")));
                        row.NUM_TELEFONO = _rdrObj.GetString(_rdrObj.GetOrdinal("num_telefono"));
                        row.IMPORTE = _rdrObj.GetDecimal(_rdrObj.GetOrdinal("importe"));
                        row.FECHA_ALTA = DateTime.Parse( _rdrObj.GetString(_rdrObj.GetOrdinal("fecha")));
                        row.SUCURSAL = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Sucursal"));
                        row.CAJA = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Caja"));
                        var referencia = _rdrObj.GetOrdinal("Referencia");
                        row.REFERENCIA = int.Parse(_rdrObj.GetOrdinal("Referencia").ToString());
                        row.RESPUESTA_DESC = _rdrObj.GetOrdinal("Respuesta_Desc").ToString();

                        if (int.Parse( _rdrObj.GetOrdinal("Respuesta_Id").ToString()) == 0)
                            row.RESPUESTA_ID = 1;
                        else
                            row.RESPUESTA_ID = 0;

                        ////if (_rdrObj.IsDBNull(_rdrObj.GetOrdinal("No_Confirmacion")) == false)
                        ////    GridConciliapFizer["ConfirmaId", ind].Value = _rdrObj.GetString(_rdrObj.GetOrdinal("No_Confirmacion"));
                        //ind++;
                        ta.Rows.Add(row);
                    }
                    //SIFUtils.AutoNumberRowsForGridView(GridConciliaTae);
                }
                else
                {
                    ta.Rows.Clear();
                   MessageBox.Show("NO existe información de Conciliación TAE...", "Conciliación TAE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Conciliación TAE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   OracleConnection.ClearPool(conn);

                }
                Cursor.Current = Cursors.Default;

            }

            return ta;
        }


        public static List<string> Carriers()
        {
            // Example demonstrates how to use REF CURSORs returned from
            // PL/SQL Stored Procedures or Functions

            //cmb_Carriers.Items.Clear();
            //cmb_CarriersTae.Items.Clear();
            
            List<string> carriers = new List<string>();

            OracleConnection conn = new OracleConnection(Helpers.ConnectionString.Connection());


            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GET_CAT_CARRIERS";

                // OUT REF CURSOR bound
                OracleParameter pCarriers = cmd.Parameters.Add("outparam", OracleDbType.RefCursor);
                pCarriers.Direction = ParameterDirection.Output;

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                if (_rdrObj.HasRows)
                {
                    //SIFModelo.Catalogo.CatalogoDataSet.CAT_CARRIERSRow row = taCarrier.NewCAT_CARRIERSRow();
                    while (_rdrObj.Read())
                    {
                        String _data = "";
                        _data = _rdrObj.GetInt16(_rdrObj.GetOrdinal("Carrier_ID")) +
                            " - " + _rdrObj.GetString(_rdrObj.GetOrdinal("Nombre"));

                        carriers.Add(_data);
                        //cmb_Carriers.Items.Add(_data);
                        //cmb_CarriersTae.Items.Add(_data);
                    }
                    //cmb_Carriers.SelectedIndex = 0;
                    //cmb_CarriersTae.SelectedIndex = 0;
                }
                else
                    //rtb_Msg.AppendText("NO existe información de Carriers..." + Environment.NewLine);

                _rdrObj.Close();
                _rdrObj.Dispose();
            }
            catch (Exception ex)
            {
                //rtb_Msg.AppendText(ex.ToString() + System.Environment.NewLine);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   OracleConnection.ClearPool(conn);

                }
            }

            return carriers;
        }

        public static SIFModelo.Catalogo.CatalogoDataSet.CTL_TAEDataTable RecargaNoExitosa()
        {
            SIFModelo.Catalogo.CatalogoDataSet ds = new SIFModelo.Catalogo.CatalogoDataSet();
            using (OracleConnection cnx = new OracleConnection(Helpers.ConnectionString.Connection()))
            {
                SIFModelo.Catalogo.CatalogoDataSetTableAdapters.CTL_TAETableAdapter ta = new SIFModelo.Catalogo.CatalogoDataSetTableAdapters.CTL_TAETableAdapter();
                ta.Connection.ConnectionString = cnx.ConnectionString;

                ta.FillByNoRespuesta(ds.CTL_TAE);
            }

            return ds.CTL_TAE;
        }
    }
}
