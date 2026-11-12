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
using SIF.Clases;

namespace SIF.View.Configuracion
{
    public partial class ConciliacionPfizerForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ConciliacionPfizerForm()
        {
            InitializeComponent();
        }

       

        private void btn_GetVaspFizer_Click(object sender, EventArgs e)
        {
            int nRow = 1, ind = 0;
            string PerIni = dti_pFizerIni.Value.ToString("dd/MM/yyyy 00:00:00");
            string PerFin = dti_pFizerFin.Value.ToString("dd/MM/yyyy 23:59:59");

            //string BD = "SIF";
            string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion; // ConfigurationManager.ConnectionStrings[BD].ConnectionString;
            OracleConnection conn = new OracleConnection(OraGAC);

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PFIZER.SP_GET_VTAS_PFIZER";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pFizer = cmd.Parameters.Add("REFCUR", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);

                OracleDataReader _rdrpFizer = cmd.ExecuteReader();

                //OracleDataReader _rdrpFizer = SIFUtils.GetConciliapFizer(PerIni, PerFin);

                if (_rdrpFizer.HasRows)
                {
                    GridConciliapFizer.Rows.Clear();

                    while (_rdrpFizer.Read())
                    {
                        GridConciliapFizer.Rows.Add(nRow);
                        GridConciliapFizer["CadenaId", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("Cadena_ID"));
                        GridConciliapFizer["SucursalId", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("Sucursal_Id"));
                        GridConciliapFizer["FecMov", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Fecha"));
                        GridConciliapFizer["Sku", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Articulo_ID"));
                        GridConciliapFizer["CantCompra", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("Cant_Compra"));
                        GridConciliapFizer["CantBenef", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("Cant_Beneficio"));
                        GridConciliapFizer["CotizacionId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Cotizacion_ID"));
                        if (_rdrpFizer.IsDBNull(_rdrpFizer.GetOrdinal("No_Confirmacion")) == false)
                            GridConciliapFizer["ConfirmaId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("No_Confirmacion"));
                        GridConciliapFizer["ActivoId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Activo"));
                        ind++;
                    }
                    SIFUtils.AutoNumberRowsForGridView(GridConciliapFizer);
                }
                else
                {
                    GridConciliapFizer.Rows.Clear();
                   MessageBox.Show("NO existe información de Conciliación pFizer...", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _rdrpFizer.Close();
                _rdrpFizer.Dispose();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);

                }
            }
        }

        private void btn_CreaConciliapFizer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string PerIni = dti_pFizerIni.Value.ToString("dd/MM/yyyy 00:00:00");
            string PerFin = dti_pFizerFin.Value.ToString("dd/MM/yyyy 23:59:59");
            string Result = string.Empty;

            string PathpFizer = ConfigSettings.ReadSetting("PathpFizerSalida");
            string FilepFizer = "Conciliacion";
            string FileAux = string.Empty;
            string FilepFizerExt = ".txt";
            string FileConcilia = string.Empty;
            TextWriter tw_writer = TextWriter.Null;

            //string BD = "SIF";
            string OraGAC = SIFNegocio.Configuracion.Configuraciones.ServidorOracle.CadenaConexion; // ConfigurationManager.ConnectionStrings[BD].ConnectionString;
            OracleConnection conn = new OracleConnection(OraGAC);

            try
            {
                conn.Open();

                // Create an OracleCommand
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_PFIZER.SP_GET_CONCILIACION";
                cmd.BindByName = true;

                // OUT REF CURSOR bound
                OracleParameter pHdr = cmd.Parameters.Add("Dat", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni, ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);

                OracleDataReader _rdrObj = cmd.ExecuteReader();

                // Header
                if (_rdrObj.HasRows)
                {
                    // Crea Archivo de Conciliación
                    if (!Directory.Exists(PathpFizer))
                    {
                       MessageBox.Show("Configure el archivo de conciliación Pfizer");
                        Directory.CreateDirectory(PathpFizer);
                        return;
                    }


                    FileAux = FilepFizer + SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yyyyMMdd") + FilepFizerExt;
                    FileConcilia = Path.Combine(PathpFizer, FileAux);
                    tw_writer = new StreamWriter(@FileConcilia, false, Encoding.GetEncoding(1252));
                    while (_rdrObj.Read())
                    {
                        tw_writer.WriteLine(_rdrObj.GetString(_rdrObj.GetOrdinal("Reg")));
                    }
                    tw_writer.Close();
                    tw_writer.Dispose();
                    Result += @FileConcilia + Environment.NewLine;
                }
                else
                {
                   MessageBox.Show("NO existe información de Conciliación pFizer..", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ConciliacionPfizerForm_Load(object sender, EventArgs e)
        {
            this.dti_pFizerIni.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 0);
            this.dti_pFizerIni.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
        }
    }
}
