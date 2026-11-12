using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class CorteCajaUserControl : Templates.CatalogoUserControl
    {
        //public CorteCajaUserControl()
        //{
        //    InitializeComponent();
        //    pagosDataGridViewX.AutoGenerateColumns = false;
        //    valoresDataGridViewX.AutoGenerateColumns = false;
        //    this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
        //    this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

        //    this.CargaSucursales();

        //    //this.CargaCajas();
        //}

        public CorteCajaUserControl(SIFModelo.Caja caja)
        {
            InitializeComponent();
            pagosDataGridViewX.AutoGenerateColumns = false;
            //valoresDataGridViewX.AutoGenerateColumns = false;
            this.caja = caja;
            //this.dateTimeInput1.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            //this.dateTimeInput2.Value = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

            SIFModelo.Caja controlCaja = new SIFNegocio.Cajas().ControlCaja(Helpers.Sesion.Sucursal, caja);

            if (controlCaja != null)
            {
                caja.FechaApertura = controlCaja.FechaApertura;
                caja.FechaCierre = controlCaja.FechaCierre;

                fechaLabel.Text = caja.FechaApertura.ToString("dd/MM/yyyy HH:mm:ss");
                if (caja.FechaCierre == null)
                {
                    caja.FechaCierre = caja.FechaApertura.AddDays(1);
                }
            }

            this.CargaSucursales();

            nombreCajaLabel.Text = caja.Nombre;
            montoAperturaLabel.Text = caja.MontoInicial.ToString("C2");
            //this.CargaCajas();
        }

        SIFModelo.Caja caja;

        private void CargaSucursales()
        {
            SIFNegocio.Sucursales sucursalL = new SIFNegocio.Sucursales();
            SIFModelo.Sucursal sucursal = sucursalL.SucursalPorID(caja.SucursalID);
            this.CargaCajas(sucursal);
            //sucursalComboBoxEx.DataSource = sucursalL.Buscar("", "").DataSource;
            //sucursalComboBoxEx.DisplayMember = "Nombre";
            //sucursalComboBoxEx.ValueMember = "SucursalesID";

            //sucursalComboBoxEx.SelectedIndex = -1;
        }



        private void CargaCajas(SIFModelo.Sucursal sucursal)
        {
            //SIFModelo.Sucursal sucursal = sucursalComboBoxEx.SelectedItem as SIFModelo.Sucursal;

            //if (sucursal == null)
            //{
            //    return;
            //}

            //SIFNegocio.Cajas cajasL = new SIFNegocio.Cajas();
            //cajaComboBoxEx.DataSource = cajasL.BuscarPorSucursal(sucursal).DataSource;
            //cajaComboBoxEx.DisplayMember = "Nombre";
            //cajaComboBoxEx.ValueMember = "ID";

            //cajaComboBoxEx.SelectedIndex = -1;
        }


        SIFNegocio.Cajas CajasN = new SIFNegocio.Cajas();
        decimal totalGeneralPagos = 0;
        decimal totalGeneralValores = 0;
        // SIFModelo.Ventas.CorteCajaDataSet valoresTable = new SIFModelo.Ventas.CorteCajaDataSet();
        private void CargaValores()
        {
            //SIFModelo.Caja caja = cajaComboBoxEx.SelectedItem as SIFModelo.Caja;

            //if (caja == null)
            //{
            //    return;
            //}

            //if (valoresTable.Tables.Contains(""))
            //{
            //    valoresTable.Tables.Remove(valoresTable.Tables[""]);
            //}

            //CajasN.BuscaValores(caja);

            this.valoresDataGridViewX.DataSource = CajasN.BuscaValores(caja);

            var valoresCondensadoTable = CajasN.BuscaValoresCondensado(caja);
            this.totalesValoresDataGridViewX.DataSource = valoresCondensadoTable;

            var totalPagos = CajasN.DataSet.V_VALORES.Compute("SUM(IMPORTE)", "");
            if (totalPagos.ToString().IsFloat())
            {
                totalGeneralValores = decimal.Parse(totalPagos.ToString());
                totalValoresLabel.Text = totalGeneralValores.ToString("C2");
            };
        }

        SIFNegocio.Pagos pagosN = new SIFNegocio.Pagos();
        private void CargaPagos()
        {
            //SIFModelo.Caja caja = cajaComboBoxEx.SelectedItem as SIFModelo.Caja;

            //if (caja == null)
            //{
            //    return;
            //}

            var pagosTable = pagosN.BuscaPagosDetalle(caja, caja.FechaApertura, new DateTime( caja.FechaApertura.Year, caja.FechaApertura.Month,  caja.FechaApertura.Day, 23,59,59));
            this.pagosDataGridViewX.DataSource = pagosTable;

            var vpagosCondensadoTable = pagosN.BuscaPagosCondensado(caja, caja.FechaApertura, new DateTime(caja.FechaApertura.Year, caja.FechaApertura.Month, caja.FechaApertura.Day, 23, 59, 59));
            this.resumenPagosDataGridViewX.DataSource = vpagosCondensadoTable;

            var totalPagos = pagosTable.Compute("SUM(IMPORTE)", "");
            if (totalPagos.ToString().IsFloat())
            {
                totalGeneralPagos = decimal.Parse(totalPagos.ToString());
                totalPagoslabel.Text = totalGeneralPagos.ToString("C2");
            };
        }

        private decimal CalculaDiferencia()
        {
            decimal diferencia = totalGeneralValores - this.totalGeneralPagos ;
            this.diferenciaLabel.Text = diferencia.ToString("C2");
            return diferencia;
        }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;

            Owner.Owner.Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }

        private void ActivaComandos()
        {
            if (this.Mostrado && Owner.Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                if (Owner.Owner.Owner.Owner.Contains(this))
                {
                    Owner.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.Owner.Owner.ActivaComandos();
                this.Mostrado = false;
            }
        }

        private void DesactivaComandos()
        {

        }

        private void Back()
        {
            if (this.Mostrado && Owner.Owner.Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                if (Owner.Owner.Owner.Owner.Contains(this))
                {
                    Owner.Owner.Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.Owner.Owner.ActivaComandos();
                this.Mostrado = false;
            }
        }

        public ControlCajasUserControl Owner { get; set; }

        public bool Mostrado { get; set; }

        private void sucursalComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.CargaCajas();
        }

        private void ActualizaCorteButtonItem_Click(object sender, EventArgs e)
        {
            this.CargaPagos();
            this.CargaValores();
            this.CalculaDiferencia();
           MessageBox.Show("Se volvieron a cargar los datos correctamente");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void cajaComboBoxEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargaValores();
            this.CargaPagos();
            CalculaDiferencia();
        }

        private void dateTimeInput1_Click(object sender, EventArgs e)
        {
            this.CargaValores();
            this.CargaPagos();
            CalculaDiferencia();
        }

        private void dateTimeInput2_Click(object sender, EventArgs e)
        {
            this.CargaValores();
            this.CargaPagos();
            CalculaDiferencia();
        }

        private void CorteCajaUserControl_Load(object sender, EventArgs e)
        {
            this.CargaValores();
            this.CargaPagos();
            CalculaDiferencia();
        }

        private void valoresDataGridViewX_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = valoresDataGridViewX.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void pagosDataGridViewX_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = pagosDataGridViewX.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void imprimirButtonItem_Click(object sender, EventArgs e)
        {

            string Param1 = "{VALORES.SUCURSAL_ID}=" + Helpers.Sesion.Sucursal.SucursalID.ToString() + " and {VALORES.FECHA}>={CONTROL_CAJAS.FECHA_APERTURA} AND {VALORES.FECHA}<={CONTROL_CAJAS.FECHA_CIERRE}  AND  {CONTROL_CAJAS.FECHA_APERTURA} = DATE(" + caja.FechaApertura.ToString("yyyy,MM,dd") + ") AND {CONTROL_CAJAS.CAJA_ID}=" + caja.ID.ToString() + " AND NOT({VALORES.ACTIVO}  LIKE 'N')  AND {CAT_USUARIOS_1.USUARIOS_ID} = '" + caja.CajeroID + "'";
            if (caja.FechaApertura.AddDays(1) == caja.FechaCierre)
            {
                Param1 = "{VALORES.SUCURSAL_ID}=" + Helpers.Sesion.Sucursal.SucursalID.ToString() + " and {VALORES.FECHA}>={CONTROL_CAJAS.FECHA_APERTURA} AND {VALORES.FECHA}<= DATE(" + caja.FechaApertura.AddDays(1).ToString("yyyy,MM,dd") + ")  AND  {CONTROL_CAJAS.FECHA_APERTURA} = DATE(" + caja.FechaApertura.ToString("yyyy,MM,dd") + ") AND {CONTROL_CAJAS.CAJA_ID}=" + caja.ID.ToString() + " AND NOT({VALORES.ACTIVO}  LIKE 'N')  AND {CAT_USUARIOS_1.USUARIOS_ID} = '" + caja.CajeroID + "'";
                MessageBox.Show("Advertencia: La caja no ha sido cerrada");
            }
            //MessageBox.Show(Param1);
            SIF.View.Reportes.frmImpresion Reporte = new SIF.View.Reportes.frmImpresion("CorteDeCaja.rpt", Param1);
            var Resul = Reporte.ShowDialog(this);

            if (Resul == DialogResult.OK)
            {
               MessageBox.Show("Ok");
            }

        }

    }
}
