using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Oracle.DataAccess.Client;
using System.IO;
using SIF.Helpers;
using System.Configuration;

namespace SIF.View.Reportes.Venta
{
    public partial class ConciliacionTAEForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ConciliacionTAEForm()
        {
            InitializeComponent();
            dti_TaeIni.MonthCalendar.SelectedDate = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            dti_TaeFin.MonthCalendar.SelectedDate = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            this.GetCarriers();
        }

        SIFNegocio.WebServices.TAE taeL = new SIFNegocio.WebServices.TAE();
        private void GetVentas()
        {
            this.GridConciliaTae.DataSource = taeL.ConsultaVentas(cmb_CarriersTae.Text, dti_TaeIni.Value, dti_TaeFin.Value);
        }

        private void GetCarriers()
        {
            this.cmb_CarriersTae.DataSource = taeL.Carriers();

            cmb_CarriersTae.SelectedIndex = 0;
        }

        private void btn_GetVtasTae_Click(object sender, EventArgs e)
        {
            this.GetVentas();
        }

        private void btn_GetConciliaTae_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string PerIni = dti_TaeIni.Text + " 00:00:00";
            string PerFin = dti_TaeFin.Text + " 23:59:59";
            string CarrierId = cmb_CarriersTae.Text.Split('-')[0].Trim();
            string Result = string.Empty;

            string PathRecarga = ConfigSettings.ReadSetting("PathTAESalida");
            string FileTae = ConfigSettings.ReadSetting("ConfigPrefijoTelCel"); // "R_ 1ZE";
            string FileAux = string.Empty;
            string FileTaeExt = ".txt";
            string FileConcilia = string.Empty; // Path.Combine(PathRecarga, FileTae);
            TextWriter tw_writer = TextWriter.Null;

            OracleConnection conn = new OracleConnection(SIFNegocio.Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_TAE.SP_GET_CONCILIA_TAE";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pHdr = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pDet = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pPie = cmd.Parameters.Add("Pie", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);
                cmd.Parameters.Add("Carrier", OracleDbType.Int16, CarrierId, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                // Header
                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        // Crea Archivo(s) Conciliación
                        if (!Directory.Exists(PathRecarga))
                            Directory.CreateDirectory(PathRecarga);

                        FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                        FileConcilia = Path.Combine(PathRecarga, FileAux);
                        tw_writer = new StreamWriter(@FileConcilia, false, Encoding.GetEncoding(1252));
                        tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                            _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                        tw_writer.Close();
                        tw_writer.Dispose();
                        Result += @FileConcilia + Environment.NewLine;
                        //MessageBoxEx.Show("Header: " + _rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) + " - " + 
                        //    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                    }
                }
                else
                {
                   MessageBox.Show("NO existe información de Conciliación TAE Header..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //GENERAR EL ARCHIVO VACIO
                    string name = FileTae + System.Convert.ToDateTime(PerIni).ToString("ddMMyyyy") + FileTaeExt;
                    string header = "HDR" + System.Convert.ToDateTime(PerIni).ToString("yyyyMMdd");
                    string foot = "TLR00000000000000000000";

                    FileConcilia = Path.Combine(PathRecarga, name);
                    tw_writer = new StreamWriter(@FileConcilia, false, Encoding.GetEncoding(1252));
                    tw_writer.WriteLine(header);
                    tw_writer.WriteLine(foot);
                    tw_writer.Close();
                    tw_writer.Dispose();
                    Result += @FileConcilia + Environment.NewLine;

                   MessageBox.Show("Se generó el archivo " + Result);

                    return;
                }

                // Detalle
                string CtrlFile = string.Empty;
                if (_rdrObj.NextResult())
                {
                    if (_rdrObj.HasRows)
                    {
                        while (_rdrObj.Read())
                        {
                            if (CtrlFile.Contains(_rdrObj.GetString(_rdrObj.GetOrdinal("FecFile"))))
                            {
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Hora")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("NoAutorizacion")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("num_telefono")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("concilia_id")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("importe")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("canal")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("terminalid")));
                            }
                            else
                            {
                                if (tw_writer != null)
                                {
                                    tw_writer.Close();
                                    tw_writer.Dispose();
                                }
                                FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                                FileConcilia = Path.Combine(PathRecarga, FileAux);
                                tw_writer = new StreamWriter(@FileConcilia, true, Encoding.GetEncoding(1252));
                                CtrlFile = FileConcilia;
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Hora")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("NoAutorizacion")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("num_telefono")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("concilia_id")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("importe")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("canal")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("terminalid")));
                            }
                            //MessageBoxEx.Show("Detalle: " + _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) + " - " + 
                            //    _rdrObj.GetDecimal(_rdrObj.GetOrdinal("num_telefono")));
                        } // while
                        tw_writer.Close();
                        tw_writer.Dispose();
                    }
                    else
                    {
                       MessageBox.Show("NO existe información de Conciliación TAE Detalle..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Pie
                CtrlFile = string.Empty;
                if (_rdrObj.NextResult())
                {
                    if (_rdrObj.HasRows)
                    {
                        while (_rdrObj.Read())
                        {
                            if (CtrlFile.Contains(_rdrObj.GetString(_rdrObj.GetOrdinal("FecFile"))))
                            {
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                            }
                            else
                            {
                                if (tw_writer != null)
                                {
                                    tw_writer.Close();
                                    tw_writer.Dispose();
                                }
                                FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                                FileConcilia = Path.Combine(PathRecarga, FileAux);
                                tw_writer = new StreamWriter(@FileConcilia, true, Encoding.GetEncoding(1252));
                                CtrlFile = FileConcilia;
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                            }

                            //MessageBoxEx.Show("Pie: " + _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) + " - " + 
                            //    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                        } // while
                        tw_writer.Close();
                        tw_writer.Dispose();
                    }
                    else
                    {
                       MessageBox.Show("NO existe información de Conciliación TAE Pie..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                _rdrObj.Close();
                _rdrObj.Dispose();
               MessageBox.Show("Archivo(s) de conciliacion creado(s):" + Environment.NewLine + Result, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (tw_writer != null)
                {
                    tw_writer.Close();
                    tw_writer.Dispose();
                }

                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);

                }
                Cursor.Current = Cursors.Default;

            }
        }

        private void btn_GetConciliaMul_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string PerIni = dti_TaeIni.Value.ToString("dd/MM/yyyy") + " 00:00:00";
            string PerFin = dti_TaeFin.Value.ToString("dd/MM/yyyy") + " 23:59:59";
            string CarrierId = cmb_CarriersTae.Text.Split('-')[0].Trim();
            string Result = string.Empty;

            string PathRecarga = ConfigSettings.ReadSetting("PathTAESalida");
            string FileTae = ConfigSettings.ReadSetting("ConfigPrefijoMultir"); // "R_ 1ZE";
            string FileAux = string.Empty;
            string FileTaeExt = ".txt";
            string FileConcilia = string.Empty; // Path.Combine(PathRecarga, FileTae);
            TextWriter tw_writer = TextWriter.Null;

            //string BD = "SIF";
            //string OraGAC = ConfigurationManager.ConnectionStrings[BD].ConnectionString;
            OracleConnection conn = new OracleConnection(SIFNegocio.Helpers.ConnectionString.Connection());

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_TAE.SP_GET_CONCILIA_MULTI";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pHdr = cmd.Parameters.Add("Hdr", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pDet = cmd.Parameters.Add("Det", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleParameter pPie = cmd.Parameters.Add("Pie", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);
                cmd.Parameters.Add("Carrier", OracleDbType.Int16, CarrierId, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                // Header
                if (_rdrObj.HasRows)
                {
                    while (_rdrObj.Read())
                    {
                        // Crea Archivo(s) Conciliación
                        if (!Directory.Exists(PathRecarga))
                            Directory.CreateDirectory(PathRecarga);

                        FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                        FileConcilia = Path.Combine(PathRecarga, FileAux);
                        tw_writer = new StreamWriter(@FileConcilia, false, Encoding.GetEncoding(1252));
                        tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                            _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                        tw_writer.Close();
                        tw_writer.Dispose();
                        Result += @FileConcilia + Environment.NewLine;
                        //MessageBoxEx.Show("Header: " + _rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) + " - " + 
                        //    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")));
                    }
                }
                else
                {
                   MessageBox.Show("NO existe información de Conciliación Multirecarga Header..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //GENERAR EL ARCHIVO VACIO
                    string name = FileTae + System.Convert.ToDateTime(PerIni).ToString("ddMMyyyy") + FileTaeExt;
                    string header = "HDR" + System.Convert.ToDateTime(PerIni).ToString("yyyyMMdd");
                    string foot = "TLR000000000000000000";

                    FileConcilia = Path.Combine(PathRecarga, name);
                    tw_writer = new StreamWriter(@FileConcilia, false, Encoding.GetEncoding(1252));
                    tw_writer.WriteLine(header);
                    tw_writer.WriteLine(foot);
                    tw_writer.Close();
                    tw_writer.Dispose();
                    Result += @FileConcilia + Environment.NewLine;

                   MessageBox.Show("Se generó el archivo " + Result);

                    return;
                }

                // Detalle
                string CtrlFile = string.Empty;
                if (_rdrObj.NextResult())
                {
                    if (_rdrObj.HasRows)
                    {
                        while (_rdrObj.Read())
                        {
                            if (CtrlFile.Contains(_rdrObj.GetString(_rdrObj.GetOrdinal("FecFile"))))
                            {
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Hora")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("NoAutorizacion")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("num_telefono")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("concilia_id")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("importe")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("canal")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("terminalid")));
                            }
                            else
                            {
                                if (tw_writer != null)
                                {
                                    tw_writer.Close();
                                    tw_writer.Dispose();
                                }
                                FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                                FileConcilia = Path.Combine(PathRecarga, FileAux);
                                tw_writer = new StreamWriter(@FileConcilia, true, Encoding.GetEncoding(1252));
                                CtrlFile = FileConcilia;
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Fecha")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Hora")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("NoAutorizacion")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("num_telefono")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("concilia_id")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("importe")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("canal")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("terminalid")));
                            }
                            //MessageBoxEx.Show("Detalle: " + _rdrObj.GetString(_rdrObj.GetOrdinal("rn")) + " - " + 
                            //    _rdrObj.GetDecimal(_rdrObj.GetOrdinal("num_telefono")));
                        } // while
                        tw_writer.Close();
                        tw_writer.Dispose();
                    }
                    else
                    {
                       MessageBox.Show("NO existe información de Conciliación Multirecarga Detalle..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Pie
                CtrlFile = string.Empty;
                if (_rdrObj.NextResult())
                {
                    if (_rdrObj.HasRows)
                    {
                        while (_rdrObj.Read())
                        {
                            if (CtrlFile.Contains(_rdrObj.GetString(_rdrObj.GetOrdinal("FecFile"))))
                            {
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                            }
                            else
                            {
                                if (tw_writer != null)
                                {
                                    tw_writer.Close();
                                    tw_writer.Dispose();
                                }
                                FileAux = FileTae + _rdrObj.GetString(_rdrObj.GetOrdinal("FecFile")) + FileTaeExt;
                                FileConcilia = Path.Combine(PathRecarga, FileAux);
                                tw_writer = new StreamWriter(@FileConcilia, true, Encoding.GetEncoding(1252));
                                CtrlFile = FileConcilia;
                                tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("IFila")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) +
                                                    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                            }

                            //MessageBoxEx.Show("Pie: " + _rdrObj.GetString(_rdrObj.GetOrdinal("Regs")) + " - " + 
                            //    _rdrObj.GetString(_rdrObj.GetOrdinal("Total")));
                        } // while
                        tw_writer.Close();
                        tw_writer.Dispose();
                    }
                    else
                    {
                       MessageBox.Show("NO existe información de Conciliación Multirecarga Pie..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                _rdrObj.Close();
                _rdrObj.Dispose();
               MessageBox.Show("Archivo(s) de conciliacion creado(s):" + Environment.NewLine + Result, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (tw_writer != null)
                {
                    tw_writer.Close();
                    tw_writer.Dispose();
                }

                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);

                }
                Cursor.Current = Cursors.Default;

            }
        }

        private void queryButtonX_Click(object sender, EventArgs e)
        {
            SIFNegocio.WebServices.TAE taeN = new SIFNegocio.WebServices.TAE();

            if (GridConciliaTae.SelectedRows.Count == 0)
            {
               MessageBox.Show("Seleccione la consulta a verificar");
                return;
            }

            SIFModelo.Catalogo.CatalogoDataSet.CTL_TAERow control = (SIFModelo.Catalogo.CatalogoDataSet.CTL_TAERow)((DataRowView)((DataGridViewRow)GridConciliaTae.SelectedRows[0]).DataBoundItem).Row;

            if (control.FECHA_ALTA < new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 0) && control.FECHA_ALTA > new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59))
            {
               MessageBox.Show("La consulta no es posible en transacciones de diferente fecha a la actual", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (control.IsREFERENCIANull())
            {
               MessageBox.Show("La transacción no ha sido cerradas", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            SIFModelo.WebServices.TAE ctlTae = new SIFModelo.WebServices.TAE();
            SIFModelo.Remision remision = new SIFModelo.Remision() { NumeroRemision = control.NUM_REMISION, SucursalID = control.SUCURSAL };


            ctlTae = new SIFNegocio.WebServices.TAE().Control(remision, false);
            //ctlTae.Archivo = control.NOM_ARCHIVO;
            //ctlTae.Articulo = control.ARTICULO_ID;
            //ctlTae.Cadena = control.CADENA;
            //ctlTae.Caja = control.CAJA;
            //ctlTae.Carrier = control.CARRIER_ID;
            //ctlTae.Fecha = control.FECHA_ALTA;
            //ctlTae.Grupo = control.GRUPO;
            //ctlTae.Importe = control.IMPORTE;
            //ctlTae.Referencia = control.REFERENCIA.ToString();
            //ctlTae.Remision = control.NUM_REMISION;
            //ctlTae.Respuesta = control.RESPUESTA_DESC;
            //ctlTae.RespuestaID = ctlTae.RespuestaID;
            //ctlTae.Sucursal = ctlTae.Sucursal;
            //ctlTae.Telefono = ctlTae.Telefono;


            if (ctlTae.Carrier == 1)
            {
                taeN.QueryTae(ctlTae, SIFNegocio.Configuracion.Configuraciones.TAE);
            }
            else
            {
                taeN.QueryTae(ctlTae, SIFNegocio.Configuracion.Configuraciones.MultiRecargas);
            }
        }

        private void ConciliacionTAEForm_Load(object sender, EventArgs e)
        {
            this.GetVentas();
        }


    }
}
