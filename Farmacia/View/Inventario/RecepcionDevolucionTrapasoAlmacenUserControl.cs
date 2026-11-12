using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
//using SIF.View.Ventas;

namespace SIF.View.Inventario
{
    public partial class RecepcionDevolucionTrapasoAlmacenUserControl : Templates.CatalogoUserControl //Form
    {
        public string TraspasoID;
        public int lote;
        public String SucursalO;
        public String SucursalD;
        public string Usr_Envia;
        DataTable dtTraspaso = new DataTable();

        SIFNegocio.Inventario.Traspasos traspasoAlmacenL = new SIFNegocio.Inventario.Traspasos();

        #region carga
        private void CargaSucursalOrigen()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalOrigenComboBox.DataSource = sucursales;
            SucursalOrigenComboBox.DisplayMember = "NOMBRE";
            SucursalOrigenComboBox.ValueMember = "SUCURSALESID";
        }

        private void CargaSucursalDestino()
        {
            BindingList<SIFModelo.Sucursal> sucursales = new BindingList<SIFModelo.Sucursal>();
            List<SIFModelo.Sucursal> sucursalesBD = new SIFNegocio.Sucursales().Buscar("", "").DataSource as List<SIFModelo.Sucursal>;

            foreach (SIFModelo.Sucursal sucursalBd in sucursalesBD)
            {
                sucursales.Add(sucursalBd);
            }

            SucursalDestinoComboBox.DataSource = sucursales;
            SucursalDestinoComboBox.DisplayMember = "NOMBRE";
            SucursalDestinoComboBox.ValueMember = "SUCURSALESID";
        }

        public bool Mostrado { get; set; }
        public RecepcionTraspasosAlmacenUserControl Owner { get; set; }

        internal void Muestra()
        {
            if (Mostrado)
            {
                return;
            }

            this.Dock = DockStyle.Fill;
            Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Right);
            this.ActivaComandos();
            //this.Owner.DesactivaComandos();
            Mostrado = true;
        }

        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            this.btn_Productos.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
        }

        public void Back()
        {
            try
            {
                Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                //this.Owner.ActivaComandos();
                Mostrado = false;
                Owner.Buscar();
            }catch { }
        }

        private void InicializaPedido()
        {
            foliotextBoxX.Text = TraspasoID.ToString();
            SucursalOrigenComboBox.Text = SucursalO;
            SucursalDestinoComboBox.Text = SucursalD;
            dtTraspaso = traspasoAlmacenL.GetTraspasoDetalle(TraspasoID.ToString(), lote);
            Grd_DevTraspaso.DataSource = dtTraspaso;
            string CadSol, ArtID = string.Empty;
            int CIncidencia = 0;
            //for (int i = 0; i < Grd_Pedido.Columns.Count; i++)
            //    Grd_Pedido.Columns[i].ReadOnly = true;

            //Grd_Pedido.Columns["Recibido"].ReadOnly = false;
            //Grd_Pedido.Columns["Recibe"].ReadOnly = false;
            //Grd_Pedido.Columns["ColTipDev"].ReadOnly = false;
            //foreach (DataGridViewRow row in Grd_Pedido.Rows)
            //{
            //    CadSol = row.Cells["Solicita"].Value.ToString();
            //    ArtID = row.Cells["ID"].Value.ToString();
            //    CIncidencia = int.Parse(row.Cells["Incidencia"].Value.ToString());
            //    switch (CadSol)
            //    {
            //        case "S":
            //        case "A":
            //            row.Cells["Recibe"].Value = true;
            //            break;
            //        default:
            //            row.Cells["Recibe"].Value = false;
            //            break;
            //    }

            //    if (CodigoTextBoxX.Text.Contains(ArtID))
            //    {
            //        row.Selected = true;
            //        int ren = row.Cells["ID"].RowIndex;
            //        Grd_Pedido.FirstDisplayedCell = Grd_Pedido[row.Cells["ID"].ColumnIndex, ren];
            //    }

            //    // Color Incidencia
            //    if (CIncidencia > 0) //Positivo
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Blue;
            //    }
            //    else if (CIncidencia < 0) // Negativo
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Red;
            //    }
            //    else // Cero
            //    {
            //        Grd_Pedido[row.Cells["Incidencia"].ColumnIndex, row.Cells["Incidencia"].RowIndex].Style.ForeColor = Color.Black;
            //    }
            //}
            CalculaTotal();
        }

        #endregion carga

        #region cierre
        private void Cerrar()
        {
            if (MessageBoxEx.Show("¿Cerrar la Devolución del Traspaso " + foliotextBoxX.Text + "?",
                              ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (CierraTraspaso(foliotextBoxX.Text, lote) > 0)
                    this.Back();
        }

        private int CierraTraspaso(string NoFolio, int NoLote)
        {
            SIFNegocio.Inventario.Traspasos tRAS = new SIFNegocio.Inventario.Traspasos();
            return tRAS.CierraDevolucionTraspaso(Helpers.Sesion.Usuario.UsuariosID.ToString(), NoFolio, NoLote.ToString());
        }   

        #endregion cierre
        private decimal CalculaTotal()
        {
            lineasLabel.Text = dtTraspaso.Rows.Count.ToString();

            object objSum = dtTraspaso.Compute("Sum(total)", "");
            decimal total = 0;
            if (objSum.ToString().IsFloat())
            {
                total = System.Convert.ToDecimal(objSum);
            }

            this.label1.Text = total.ToString("C2");

            object objPiezas = dtTraspaso.Compute("Sum(Recibido)", "");
            decimal totalPiezas = 0;
            if (objPiezas.ToString().IsInteger())
            {
                totalPiezas = System.Convert.ToInt32(objPiezas);
                label2.Text = totalPiezas.ToString();
            }

            object objPzasEnvio = dtTraspaso.Compute("Sum(Enviado)", null);
            decimal totalPzasEnv = 0;
            if (objPzasEnvio.ToString().IsInteger())
            {
                totalPzasEnv = System.Convert.ToInt32(objPzasEnvio);
                label2.Text += " / " + totalPzasEnv.ToString();
            }
            else
            {
                label2.Text += " / 0";
            }

            return total;
        }

        public RecepcionDevolucionTrapasoAlmacenUserControl()
        {
            InitializeComponent();
            ////this.CargaSucursalOrigen();
            ////this.CargaSucursalDestino();
            //this.CargaTipoDevolucion();
            this.CodigoTextBoxX.Focus();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void RecepcionDevolucionTrapasoAlmacenUserControl_Load(object sender, EventArgs e)
        {
            this.InicializaPedido();
        }

        private void Grd_DevTraspaso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Col_Name = Grd_DevTraspaso.Columns[e.ColumnIndex].Name;
            int CIncidencia = 0;

            CIncidencia = Convert.ToInt16(Grd_DevTraspaso["Devolucion", e.RowIndex].Value.ToString()) + Convert.ToInt16(Grd_DevTraspaso["Incidencia", e.RowIndex].Value.ToString());
            switch (Col_Name)
            {
                case "Recibe":
                    if (!Grd_DevTraspaso[Col_Name, e.RowIndex].ReadOnly)
                    {
                        if (CIncidencia <= 0)
                            Grd_DevTraspaso.CancelEdit();
                        else
                            Grd_DevTraspaso.EndEdit();
                    }
                    break;
                default: // Otra Columna
                    Grd_DevTraspaso.CancelEdit();
                    break;
            }

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }


    }
}
