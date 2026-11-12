using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;
using DevComponents.DotNetBar.Controls;
using SIF.Helpers;

namespace SIF.Clases
{
    class SIFUtils
    {
        public static void InitializeDataGridViewPedidoDet(DataGridViewX dgv)
        {

            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();

            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].HeaderText = "Lote";
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Name = "Col_LotePedDet";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[1].Frozen = true;
            dgv.Columns[1].HeaderText = "Código";
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[1].Name = "Col_CodigoPedDet";
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[2].Frozen = true;
            dgv.Columns[2].HeaderText = "Descripción";
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].Name = "Col_DescPedDet";
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            ////ColCantidad.HeaderText = "Cantidad";
            ////ColCantidad.MaxValue = 999;
            ////ColCantidad.MinValue = 1;
            ////ColCantidad.Name = "Col_CantidadPedDet";
            ////ColCantidad.ReadOnly = false;
            ////ColCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////ColCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ////ColCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;

            ////dgv.Columns[3].ValueType = ColCantidad.CellType;
            dgv.Columns[3].HeaderText = "Cantidad";
            dgv.Columns[3].Frozen = false;
            ////dgv.Columns[3].ValueType = 
            dgv.Columns[3].ReadOnly = false;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[3].Name = "Col_CantidadPedDet"; // DataGridViewIntegerInputColumn
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[4].Frozen = false;
            dgv.Columns[4].HeaderText = "Precio";
            dgv.Columns[4].ReadOnly = true;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[4].Name = "Col_PrecioPedDet";
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[4].Visible = false;

            dgv.Columns[5].Frozen = false;
            dgv.Columns[5].HeaderText = "Total";
            dgv.Columns[5].ReadOnly = true;
            dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[5].Name = "Col_TotalPedDet";
            dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[5].Visible = false;

        }

        public static void InitializeDataGridViewAjusteDet(DataGridViewX dgv)
        {
            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();

            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].HeaderText = "Lote";
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Name = "Col_LoteAjusteDet";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[1].Frozen = true;
            dgv.Columns[1].HeaderText = "Código";
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[1].Name = "Col_CodigoAjusteDet";
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[2].Frozen = true;
            dgv.Columns[2].HeaderText = "Descripción";
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].Name = "Col_DescAjusteDet";
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[3].HeaderText = "Cantidad";
            dgv.Columns[3].Frozen = false;
            ////dgv.Columns[3].ValueType = 
            dgv.Columns[3].ReadOnly = false;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[3].Name = "Col_CantidadAjusteDet"; // DataGridViewIntegerInputColumn
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[4].Frozen = false;
            dgv.Columns[4].HeaderText = "Precio";
            dgv.Columns[4].ReadOnly = true;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[4].Name = "Col_PrecioAjusteDet";
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[4].Visible = true;

            dgv.Columns[5].Frozen = false;
            dgv.Columns[5].HeaderText = "Costo";
            dgv.Columns[5].ReadOnly = true;
            dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[5].Name = "Col_CostoAjusteDet";
            dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[5].Visible = false;

            dgv.Columns[6].Frozen = false;
            dgv.Columns[6].HeaderText = "Concepto";
            dgv.Columns[6].ReadOnly = true;
            dgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[6].Name = "Col_ConcepAjusteDet";
            dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[6].Visible = true;

            dgv.Columns[7].Frozen = false;
            dgv.Columns[7].HeaderText = "Total";
            dgv.Columns[7].ReadOnly = true;
            dgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[7].Name = "Col_TotalAjsuteDet";
            dgv.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[7].Visible = false;        
        }

        public static void InitializeDataGridViewTraspasoDet(DataGridViewX dgv)
        {

            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();

            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].HeaderText = "Lote";
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].Name = "Col_LoteTraDet";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[0].Visible = false;

            dgv.Columns[1].Frozen = true;
            dgv.Columns[1].HeaderText = "Código";
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[1].Name = "Col_CodigoTraDet";
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[2].Frozen = true;
            dgv.Columns[2].HeaderText = "Descripción";
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[2].Name = "Col_DescTraDet";
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            ////ColCantidad.HeaderText = "Cantidad";
            ////ColCantidad.MaxValue = 999;
            ////ColCantidad.MinValue = 1;
            ////ColCantidad.Name = "Col_CantidadPedDet";
            ////ColCantidad.ReadOnly = false;
            ////ColCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////ColCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ////ColCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;

            ////dgv.Columns[3].ValueType = ColCantidad.CellType;
            dgv.Columns[3].HeaderText = "Cantidad Solicitada";
            dgv.Columns[3].Frozen = false;
            ////dgv.Columns[3].ValueType = 
            dgv.Columns[3].ReadOnly = true;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[3].Name = "Col_CSolictaTraDet"; // DataGridViewIntegerInputColumn
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[4].HeaderText = "Cantidad Enviada";
            dgv.Columns[4].Frozen = false;
            ////dgv.Columns[3].ValueType = 
            dgv.Columns[4].ReadOnly = false;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[4].Name = "Col_CEnviaTraDet"; // DataGridViewIntegerInputColumn
            dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[5].Frozen = false;
            dgv.Columns[5].HeaderText = "Precio";
            dgv.Columns[5].ReadOnly = true;
            dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[5].Name = "Col_PrecioTraDet";
            dgv.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[5].Visible = false;

            dgv.Columns[6].HeaderText = "Caja";
            dgv.Columns[6].Frozen = false;
            ////dgv.Columns[3].ValueType = 
            dgv.Columns[6].ReadOnly = false;
            dgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[6].Name = "Col_CajaTraDet"; // DataGridViewIntegerInputColumn
            dgv.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[7].Frozen = false;
            dgv.Columns[7].HeaderText = "Pedido";
            dgv.Columns[7].ReadOnly = true;
            dgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[7].Name = "Col_PedidoTraDet";
            dgv.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[7].Visible = false;

            dgv.Columns[8].Frozen = false;
            dgv.Columns[8].HeaderText = "Total";
            dgv.Columns[8].ReadOnly = true;
            dgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[8].Name = "Col_TotalTraDet";
            dgv.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[8].Visible = false;


        }
        
        public static void InitDataGridViewPedidoDet(DataGridViewX dgv)
        {
            dgv.MultiSelect = true;
            DataGridViewIntegerInputColumn ColLote = new DataGridViewIntegerInputColumn();
            DataGridViewTextBoxColumn ColCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColDescri = new DataGridViewTextBoxColumn();
            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();
            DataGridViewDoubleInputColumn ColPrecio = new DataGridViewDoubleInputColumn();

            ColLote.BackgroundStyle.Class = "DataGridViewNumericBorder";
            ColLote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ColLote.HeaderText = "Lote";
            ColLote.MaxValue = 2;
            ColLote.MinValue = 1;
            ColLote.Name = "Col_LotePedDet";
            ColLote.ReadOnly = true;
//            ColInt.Frozen = true;
            ColLote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColLote.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColLote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColLote);

            ColCodigo.HeaderText = "Código";
            ColCodigo.Name = "Col_CodigoPedDet";
            ColCodigo.ReadOnly = true;
//            ColStr.Frozen = true;
            ColCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            ColCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCodigo);

            ColDescri.HeaderText = "Descripción";
            ColDescri.Name = "Col_DescPedDet";
            ColDescri.ReadOnly = true;
//            ColStr.Frozen = true;
            ColDescri.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColDescri.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            ColDescri.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColDescri);

            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.MaxValue = 999;
            ColCantidad.MinValue = 1;
            ColCantidad.Name = "Col_CantidadPedDet";
            ColCantidad.ReadOnly = false;
            ColCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCantidad);

            ColPrecio.HeaderText = "Precio";
            ColPrecio.Name = "Col_PrecioPedDet";
            ColPrecio.ReadOnly = true;
//            ColDbl.Frozen = true;
            ColPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ColPrecio.Visible = false;
            dgv.Columns.Add(ColPrecio);

        }

        public static void InitDataGridViewTraspasoDet(DataGridViewX dgv)
        {
            dgv.MultiSelect = true;
            DataGridViewIntegerInputColumn ColLote = new DataGridViewIntegerInputColumn();
            DataGridViewTextBoxColumn ColCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColDescri = new DataGridViewTextBoxColumn();
            DataGridViewIntegerInputColumn ColCSolicita = new DataGridViewIntegerInputColumn();
            DataGridViewIntegerInputColumn ColCEnvia = new DataGridViewIntegerInputColumn();
            DataGridViewDoubleInputColumn ColPrecio = new DataGridViewDoubleInputColumn();
            DataGridViewDoubleInputColumn ColCaja = new DataGridViewDoubleInputColumn();

            ColLote.BackgroundStyle.Class = "DataGridViewNumericBorder";
            ColLote.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ColLote.HeaderText = "Lote";
            ColLote.MaxValue = 2;
            ColLote.MinValue = 1;
            ColLote.Name = "Col_LoteTraDet";
            ColLote.ReadOnly = true;
            //            ColInt.Frozen = true;
            ColLote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColLote.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColLote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColLote);

            ColCodigo.HeaderText = "Código";
            ColCodigo.Name = "Col_CodigoTraDet";
            ColCodigo.ReadOnly = true;
            //            ColStr.Frozen = true;
            ColCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            ColCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCodigo);

            ColDescri.HeaderText = "Descripción";
            ColDescri.Name = "Col_DescTraDet";
            ColDescri.ReadOnly = true;
            //            ColStr.Frozen = true;
            ColDescri.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColDescri.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            ColDescri.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColDescri);

            ColCSolicita.HeaderText = "Cantidad Solicitada";
            ColCSolicita.MaxValue = 999;
            ColCSolicita.MinValue = 1;
            ColCSolicita.Name = "Col_CSolicitaTraDet";
            ColCSolicita.ReadOnly = true;
            ColCSolicita.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCSolicita.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColCSolicita.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCSolicita);

            ColCEnvia.HeaderText = "Cantidad Enviada";
            ColCEnvia.MaxValue = 999;
            ColCEnvia.MinValue = 1;
            ColCEnvia.Name = "Col_CEnviaTraDet";
            ColCEnvia.ReadOnly = false;
            ColCEnvia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCEnvia.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColCEnvia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCEnvia);

            ColPrecio.HeaderText = "Precio";
            ColPrecio.Name = "Col_PrecioTraDet";
            ColPrecio.ReadOnly = true;
            //            ColDbl.Frozen = true;
            ColPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            ColPrecio.Visible = false;
            dgv.Columns.Add(ColPrecio);

            ColCaja.HeaderText = "No. Caja";
            ColCaja.MaxValue = 99;
            ColCaja.MinValue = 1;
            ColCaja.Name = "Col_CajaTraDet";
            ColCaja.ReadOnly = false;
            ColCaja.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColCaja.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColCaja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgv.Columns.Add(ColCaja);

        }

        public static void InitializeDataGridViewCalculoEoQ(DataGridViewX dgv, string HdrCols, int nCols)
        {
            int PerCol = dgv.ColumnCount - 9;
            int ind = 2;

            DataGridViewIntegerInputColumn ColCantidad = new DataGridViewIntegerInputColumn();

            dgv.Columns[0].Frozen = true;
            dgv.Columns[0].HeaderText = "Código";
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[0].Name = "Col_CodigoArtEoQ";
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            dgv.Columns[1].Frozen = true;
            dgv.Columns[1].HeaderText = "Descripción";
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].Name = "Col_DescArtEoQ";
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            for (ind = 2; ind < PerCol; ind++)
            {
                dgv.Columns[ind].Frozen = true;
                dgv.Columns[ind].ReadOnly = true;
                dgv.Columns[ind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[ind].Name = "Col_Periodo" + ind; 
                dgv.Columns[ind].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            dgv.Columns[ind].Frozen = true;
            dgv.Columns[ind].HeaderText = "Total";
            dgv.Columns[ind].ReadOnly = true;
            dgv.Columns[ind].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind].Name = "Col_TotalVtas";
            dgv.Columns[ind].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dgv.Columns[ind].Visible = false;

            dgv.Columns[ind + 1].Frozen = false;
            dgv.Columns[ind + 1].HeaderText = "Ult. Movimiento";
            dgv.Columns[ind + 1].ReadOnly = true;
            dgv.Columns[ind + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 1].Name = "Col_UltMov";
            dgv.Columns[ind + 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[ind + 1].Visible = true;

            dgv.Columns[ind + 2].Frozen = false;
            dgv.Columns[ind + 2].HeaderText = "Faltante";
            dgv.Columns[ind + 2].ReadOnly = true;
            dgv.Columns[ind + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 2].Name = "Col_FaltanteVtas";
            dgv.Columns[ind + 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[ind + 3].Frozen = false;
            dgv.Columns[ind + 3].HeaderText = "Existencia";
            dgv.Columns[ind + 3].ReadOnly = true;
            dgv.Columns[ind + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 3].Name = "Col_ExistenciaVtas";
            dgv.Columns[ind + 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgv.Columns[ind + 4].Frozen = false;
            dgv.Columns[ind + 4].HeaderText = "Precio";
            dgv.Columns[ind + 4].ReadOnly = true;
            dgv.Columns[ind + 4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 4].Name = "Col_PrecioArt";
            dgv.Columns[ind + 4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[ind + 4].Visible = true;

            dgv.Columns[ind + 5].Frozen = false;
            dgv.Columns[ind + 5].HeaderText = "Costo";
            dgv.Columns[ind + 5].ReadOnly = true;
            dgv.Columns[ind + 5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 5].Name = "Col_CostoArt";
            dgv.Columns[ind + 5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader; // .ColumnHeader;
            dgv.Columns[ind + 5].Visible = true;

            dgv.Columns[ind + 6].Frozen = false;
            dgv.Columns[ind + 6].HeaderText = "Tipo";
            dgv.Columns[ind + 6].ReadOnly = true;
            dgv.Columns[ind + 6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[ind + 6].Name = "Col_TipoArt";
            dgv.Columns[ind + 6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 6].Visible = true;

            dgv.Columns[ind + 7].Frozen = false;
            dgv.Columns[ind + 7].HeaderText = "Factor";
            dgv.Columns[ind + 7].ReadOnly = false;
            dgv.Columns[ind + 7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[ind + 7].Name = "Col_FactorArt";
            dgv.Columns[ind + 7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 7].Visible = true;

            dgv.Columns[ind + 8].Frozen = false;
            dgv.Columns[ind + 8].HeaderText = "EoQ";
            dgv.Columns[ind + 8].ReadOnly = true;
            dgv.Columns[ind + 8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[ind + 8].Name = "Col_EoQArt";
            dgv.Columns[ind + 8].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns[ind + 8].Visible = true;
        }

        public static void FillPedidoDet(DataTable dt, DataGridView dgv)
        {
            DataRow[] results = dt.Select(null, "lote, id");
            int ind = 0;
            dgv.Rows.Clear();
            dgv.Rows.Add(results.Length);

            foreach (DataRow row in results)
            {
                dgv["Col_LotePedDet", ind].Value = Convert.ToInt16(row["lote"].ToString());
                dgv["Col_CodigoPedDet", ind].Value = row[0].ToString();
                dgv["Col_DescPedDet", ind].Value = row[1].ToString();
                dgv["Col_CantidadPedDet", ind].Value = Convert.ToInt16(row["cantidad"]);
                dgv["Col_PrecioPedDet", ind].Value = Convert.ToDouble(row["precio"].ToString());
                ind++;
            }

            //dtPedido.Columns.Add("id", typeof(string));
            //dtPedido.Columns.Add("nombre", typeof(string));
            //dtPedido.Columns.Add("lote", typeof(int));
            //dtPedido.Columns.Add("cantidad", typeof(int));
            //dtPedido.Columns.Add("precio", typeof(double));

        }

        public static void AutoNumberRowsForGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                for (int count = 0; (count <= (dataGridView.Rows.Count - 1)); count++)
                {
                    // dataGridView.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                    dataGridView.Rows[count].HeaderCell.Value = (count + 1).ToString().PadLeft(2, '0');
                }
            }
        }

        public static void FillListViewTelCel(ListView lv, string Carrier)
        {
            lv.Items.Clear();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem[] subItems = null;
            string CtasMail = ConfigSettings.ReadSetting(Carrier); //"ProdTelCel"
            string[] producto = null;

            if (!string.IsNullOrEmpty(CtasMail))
            {
                foreach (string Cad in CtasMail.Split('|'))
                {
                    if (!string.IsNullOrEmpty(Cad))
                    {
                        producto = Cad.Split(',');
                        item = new ListViewItem(producto[0]);
                        subItems = new ListViewItem.ListViewSubItem[] {
                        new ListViewItem.ListViewSubItem(item, producto[1]),
                        new ListViewItem.ListViewSubItem(item, producto[2]),
                        new ListViewItem.ListViewSubItem(item, producto[3])
                        };
                        item.SubItems.AddRange(subItems);
                        lv.Items.Add(item);
                    }
                }
            }
        }

        public static string ReadXMLFile(string FileName, int FileSize)
        {
            string filereadbuf;
            // lets define an array of type char field (i.e. variable) buf
            char[] buf = new char[FileSize];
            StreamReader sr = new StreamReader(
                new FileStream(FileName, FileMode.Open, FileAccess.Read), System.Text.Encoding.GetEncoding("iso-8859-1"));
            int retval = sr.ReadBlock(buf, 0, FileSize); // no. of bytes read 
            filereadbuf = new string(buf); // store it in our field 

            sr.Close();

            return filereadbuf;

        }

        public static OracleDataReader GetConciliapFizer(string PerIni, string PerFin)
        {
            OracleDataReader _rdrObj = null;
            string BD = "SIF";
            string OraGAC = ConfigurationManager.ConnectionStrings[BD].ConnectionString;
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
                OracleParameter pFizer = cmd.Parameters.Add("refcur", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("FecIni", OracleDbType.Varchar2, PerIni , ParameterDirection.Input);
                cmd.Parameters.Add("FecFin", OracleDbType.Varchar2, PerFin, ParameterDirection.Input);

                _rdrObj = cmd.ExecuteReader();

                return _rdrObj;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //if (_rdrObj != null)
                //{
                //    _rdrObj.Close();
                //    _rdrObj.Dispose();
                //}

                if (null != conn)
                {
                    conn.Close();
                    conn.Dispose();
                   //OracleConnection.ClearPool(conn);

                }
            }

        }

        public static DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        public static int DaysBetweenDates(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2 - dt1;

            return Convert.ToInt32(Math.Truncate(ts.TotalDays)) + 1;
        }
    }
}
