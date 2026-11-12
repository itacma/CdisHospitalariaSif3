using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;

using Equin.ApplicationFramework;
namespace SIF.View.OrdenCompra
{
    public partial class IncidenciasCompras : Templates.CatalogoUserControl
    {
        public IncidenciasCompras()
        {
            InitializeComponent();
        }

        public bool Mostrado;
        public OrdenesCompraUserControl Owner;

        private SIFNegocio.Clientes logica = new SIFNegocio.Clientes();
        private string propiedadBusqueda = "";
        SIFModelo.Cliente current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        private void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
        }

        private void Back()
        {
            try
            {               
               
                    Owner.DesactivaComandos();
                    this.DesactivaComandos();
                    SIF.View.Menu.ComprasMenu parent = (SIF.View.Menu.ComprasMenu)(Owner.Owner);
                    parent.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                  
                    this.Mostrado = true;
            }
            catch
            {

            }
        }

        private void Salir()
        {
            DialogResult res = MessageBox.Show("¿Desea salir del catálogo?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Back();
            }
        }

        public void Muestra()
        {

            if (this.Owner is OrdenesCompraUserControl)
            {
                Owner.DesactivaComandos();
                this.ActivaComandos();
                this.Dock = DockStyle.Fill;

                SIF.View.Menu.ComprasMenu parent = (SIF.View.Menu.ComprasMenu)(Owner.Owner);
                parent.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                this.Mostrado = true;
            }

            this.Buscar();
            this.dateTimeInput1.Focus();
        }


        #endregion

        #region Funciones y Metodos Privados

        private void Buscar()
        {
            SIFNegocio.OrdenCompra.OrdenCompra ocL = new SIFNegocio.OrdenCompra.OrdenCompra();
            string proveedorID = "";

            if (clienteSeleccionado != null)
            {
                proveedorID = clienteSeleccionado.Nombre;
            }
            this.dataGridViewX1.DataSource = ocL.incidenciasComrpas(dateTimeInput1.Value, proveedorID);
           // this.dataGridViewX1.DataSource = ocL.facturasRecepcion(dateTimeInput1.Value, dateTimeInput2.Value, proveedorID);
        }

        private Boolean Modificar(SIFModelo.Cliente Cliente)
        {
            if (Cliente.ID == 90 || Cliente.ID == 24)
            {
               MessageBox.Show("El cliente se encuentra bloqueado");
                return false;
            }

            this.Cursor = Cursors.WaitCursor;
            this.statusLabel.Text = "Actualizando registro...";

            bool modificado = logica.Modificar(Cliente);

            if (!modificado)
            {
                if (dataGridViewX1.IsCurrentCellInEditMode)
                {
                    dataGridViewX1.CancelEdit();
                }
                dataGridViewX1.Refresh();
            }

            this.Cursor = Cursors.Default;

            this.statusLabel.Text = "";
            return modificado;
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }


        private void imprimirButtonItem_Click(object sender, EventArgs e)
        {
            //FechasForm frmFechas = new FechasForm();
            //if (frmFechas.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            string f1 = dateTimeInput1.Value.ToString("yyyy,MM,dd");
           // string f2 = dateTimeInput2.Value.ToString("yyyy,MM,dd");

            SIFNegocio.Usuarios Logusu = new SIFNegocio.Usuarios();
            SIFModelo.Usuario Vend = Helpers.Sesion.Usuario;

            string filtro = "  DATE({reporte_incidencias_compras.FECHA}) = DATE('" + f1 + "') ";
           /* if (clienteSeleccionado != null)
            {
                filtro += " AND {CS_FACTURAS_COMPRAS.PROVEEDOR} = '" + clienteSeleccionado.Nombre + "'";
            }
            */
            SIF.View.Reportes.frmImpresion Impresion = new Reportes.frmImpresion("RPT_iNCIDENCIAS_cOMPRAS.rpt", filtro);
            Impresion.ShowDialog();
        }


        private void CuentasPagarControl_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            //dateTimeInput2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }

        private void proveedorButtonX_Click(object sender, EventArgs e)
        {
          //  SeleccionaProveedor();
        }

        View.OrdenCompra.ProveedoresControl frmProveedor;
        private void SeleccionaProveedor()
        {
            if (frmProveedor == null)
            {
                frmProveedor = new View.OrdenCompra.ProveedoresControl();
                frmProveedor.Dock = DockStyle.Fill;
                frmProveedor.Owner = this;
            }
            //string listaProveedores = new SIFNegocio.Usuarios().ListaProveedores(usuario);


            ////string listaLineas = new SIFNegocio.Compradores()
            //frmProveedor.ListaProveedores = listaProveedores.Trim('|');
            frmProveedor.Muestra();
        }



        SIFModelo.Cliente clienteSeleccionado = null;
        internal void AgregaCliente(SIFModelo.Cliente cliente)
        {
            if (cliente.Activo == SIFModelo.Tipos.SiNo.NO)
            {
               MessageBox.Show("El proveedor ya no está activo");
                return;
            }
            //if (cliente.Boletinado == SIFModelo.Tipos.SiNo.SI)
            //{
            //   MessageBox.Show("El proveedor está boletinado");
            //    return;
            //}

            //SIFModelo.Seguridad.Seguridad seguridad = new SIFModelo.Seguridad.Seguridad();
            //SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter cOMPRADOR_LINEATableAdapter = new SIFModelo.Seguridad.SeguridadTableAdapters.COMPRADOR_LINEATableAdapter();

            //cOMPRADOR_LINEATableAdapter.Connection = new Oracle.DataAccess.Client.OracleConnection(SIFNegocio.Configuracion.Configuraciones.ReadDataBase());
            //cOMPRADOR_LINEATableAdapter.FillByComprador(seguridad.COMPRADOR_LINEA, usuario.UsuariosID.ToString());

            //string listaProveedores = "";
            //foreach (var linea in seguridad.COMPRADOR_LINEA)
            //{
            //    listaProveedores += linea.LINEA + "|";
            //}

            ////if (!listaProveedores.Contains(cliente.ID.ToString()))
            ////{
            ////   MessageBox.Show("El usuario no puede comprar a de este proveedor");
            ////    return;
            ////}



            clienteSeleccionado = cliente;

            proveedorLabelX.Text = cliente.ID.ToString() + " - " + cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            Buscar();
        }
    }
}
