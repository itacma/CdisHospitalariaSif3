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
    public partial class ConciliacionNadroForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ConciliacionNadroForm()
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
                cmd.CommandText = "PKG_NADRO.SP_GET_VTAS_NADRO";
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
                        GridConciliapFizer["CadenaId", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("cadena"));
                        GridConciliapFizer["SucursalId", ind].Value = _rdrpFizer.GetInt16(_rdrpFizer.GetOrdinal("sucursal"));
                        GridConciliapFizer["FecMov", ind].Value = _rdrpFizer["FECHA"].ToString();
                        GridConciliapFizer["Sku", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("sku"));
                        GridConciliapFizer["CotizacionId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("sesion"));
                        if (_rdrpFizer.IsDBNull(_rdrpFizer.GetOrdinal("autorizacion")) == false)
                            GridConciliapFizer["ConfirmaId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("autorizacion"));
                        //GridConciliapFizer["ActivoId", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Activo"));

                        GridConciliapFizer["Folio", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("Folio"));
                        //GridConciliapFizer["producto", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("producto"));
                        //GridConciliapFizer["precio", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("precio"));
                        //GridConciliapFizer["precio_sif", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("precio_sif"));
                        GridConciliapFizer["CantCompra", ind].Value = _rdrpFizer["piezas_pedido"].ToString();
                        GridConciliapFizer["CantBenef", ind].Value = _rdrpFizer["piezas_beneficio"].ToString();
                        //GridConciliapFizer["precio_fijo", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("precio_fijo"));
                        //GridConciliapFizer["porcentaje_descuento", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("porcentaje_descuento"));
                        //GridConciliapFizer["monto_descuento", ind].Value = _rdrpFizer.GetString(_rdrpFizer.GetOrdinal("monto_descuento"));

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
            //if (this.GridConciliapFizer.Rows.Count <= 0)
            //{
            //   MessageBox.Show("No hay datos a exportar");
            //    return;
            //}


            Cursor.Current = Cursors.WaitCursor;

            string PerIni = dti_pFizerIni.Value.ToString("yyyy,MM,dd,0,0,0");
            string PerFin = dti_pFizerFin.Value.ToString("yyyy,MM,dd,23,59,59");

            string filtro = " {CS_CONCILIACION_NADRO.FECHA_COMPRA}  >= DATETIME(" + PerIni + ")";
            filtro += " AND  {CS_CONCILIACION_NADRO.FECHA_COMPRA} <= DATETIME(" + PerFin + ")";
            View.Reportes.frmImpresion frmimp = new Reportes.frmImpresion("RPT_conciliacion_nadro.rpt", filtro);
            frmimp.ShowDialog();

            Cursor.Current = Cursors.Default;
        }

        private void ConciliacionPfizerForm_Load(object sender, EventArgs e)
        {
            this.dti_pFizerIni.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 0);
            this.dti_pFizerIni.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
            
        }
    }
}
