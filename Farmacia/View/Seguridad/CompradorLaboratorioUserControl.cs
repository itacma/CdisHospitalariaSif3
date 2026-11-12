using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Seguridad
{
    public partial class CompradorLaboratorioUserControl : Templates.CatalogoUserControl
    {
        public CompradorLaboratorioUserControl()
        {
            InitializeComponent();
            FormatoGrid();
        }

        private void FormatoGrid()
        {
            this.dataGridViewX1.AutoGenerateColumns = false;

            LISTA_PROVEEDOR_IDColumn.ButtonCustom.Visible = true;
            LISTA_PROVEEDOR_IDColumn.ButtonCustomClick += PROVEEDORColumn_ButtonCustom_CLICK;
            LISTA_SUCURSAL_IDColumn.ButtonCustom.Visible = true;
            LISTA_SUCURSAL_IDColumn.ButtonCustomClick += LISTA_SUCURSAL_Column_ButtonCustom_CLICK;
        }

        SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow current;


        void LISTA_SUCURSAL_Column_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
    sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                this.current = ((DataRowView)this.bindingSource.Current).Row as SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow;
                Catalogos.ListaSucursalVentaForm sucursalesForm = new Catalogos.ListaSucursalVentaForm(current);
                if (sucursalesForm.ShowDialog() == DialogResult.OK)
                {
                    current.LISTA_SUCURSAL_ID = sucursalesForm.ListaSucursales;
                    dataGridViewX1.EndEdit();
                    compradoresN.Actualiza(current);
                }
            }
        }

        void PROVEEDORColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                current = ((DataRowView)this.bindingSource.Current).Row as SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow;
                Catalogos.ClienteControl ClientesForm = new Catalogos.ClienteControl(current.LISTA_PROVEEDOR_ID);
                ClientesForm.Owner = this;
                ClientesForm.PROVEEDOR = true;
                ClientesForm.Muestra();
            }
        }

        public Menu.ConfiguracionMenu Owner { get; set; }

        internal void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            this.Mostrado = true;
        }

        public void ActivaComandos()
        {
            //throw new NotImplementedException();
        }

        public bool Mostrado { get; set; }


        private void Eliminar()
        {
            if (bindingSource.Current == null)
            {
               MessageBox.Show("Seleccione un usuario de la lista");
                return;
            }

            current = ((DataRowView)this.bindingSource.Current).Row as SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow;

            if (MessageBoxEx.Show("¿Eliminar el comprador " + current.ACCESO_ID + " ?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            //this.current = ((DataRowView)this.bindingSource.Current).Row as SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow;
            current.ACTIVO = "N";

            compradoresN.Actualiza(current);
            this.cargaCompradores();

        }

        private void Back()
        {
            if (this.Mostrado && Owner.Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                if (Owner.Owner.Contains(this))
                {
                    Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                }
                this.Owner.ActivaComandos();
                this.Owner.Owner.ActivaComandos();
                this.Mostrado = false;
            }
        }

        private void SeleccionaUsuario()
        {
            View.Catalogos.UsuarioUserControl frmUsuario = new Catalogos.UsuarioUserControl();
            frmUsuario.Owner = this;
            frmUsuario.Muestra();
        }

        public void AgregaUsuario(SIFModelo.Usuario usuario)
        {
            if (usuario == null)
            {
                return;
            }

            

            SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow comprador = this.compradoresN.compradores.NewCOMPRADORRow();
            comprador.USUARIO_ID = usuario.UsuariosID.ToString();
            SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow compradorExistente = compradoresN.CompradorPorID(comprador);
            if (compradorExistente  != null)
            {
                if (compradorExistente.ACTIVO == "S")
                {
                   MessageBox.Show("Ya existe un comprador relacionado al usuario " + compradorExistente.ACCESO_ID.ToString() + " [" + comprador.NOMBRE + " " + comprador.APELLIDOS + "]?");
                    return;
                }

                if (compradorExistente.ACTIVO == "N")
                {
                    if (MessageBoxEx.Show("¿Activar el comprador " + compradorExistente.ACCESO_ID.ToString() + " [" + compradorExistente.NOMBRE + " " + compradorExistente.APELLIDOS + "]?", "Activar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        compradorExistente.ACTIVO = "S";
                        compradoresN.Actualiza(compradorExistente);

                        comprador.TIPO = compradorExistente.TIPO;
                        comprador.NOMBRE = compradorExistente.NOMBRE;
                        comprador.APELLIDOS = compradorExistente.APELLIDOS;
                        comprador.LISTA_PROVEEDOR_ID = compradorExistente.LISTA_PROVEEDOR_ID;
                        comprador.LISTA_SUCURSAL_ID = compradorExistente.LISTA_SUCURSAL_ID;
                        comprador.FECHA_ALTA = compradorExistente.FECHA_ALTA;
                        comprador.ACTIVO = "S";
                        comprador.ACCESO_ID = compradorExistente.ACCESO_ID;

                        this.compradoresN.compradores.AddCOMPRADORRow(comprador);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            comprador.TIPO = "E";
            comprador.NOMBRE = usuario.Nombre;
            comprador.APELLIDOS = usuario.Apellidos;
            comprador.LISTA_PROVEEDOR_ID = "|";
            comprador.LISTA_SUCURSAL_ID = "|";
            comprador.FECHA_ALTA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            comprador.ACTIVO = "S";
            comprador.ACCESO_ID = usuario.AccesoID;
            compradoresN.Nuevo(comprador);

            this.compradoresN.compradores.AddCOMPRADORRow(comprador);
        }


        private void BuscaLocal()
        {
            this.bindingSource.Filter = "NOMBRE LIKE '%" + this.buscarTextBoxX.Text + "%' OR APELLIDOS LIKE '%" + this.buscarTextBoxX.Text + "%' OR ACCESO_ID LIKE '%" + this.buscarTextBoxX.Text + "%'";
        }

        SIFNegocio.Compradores compradoresN = new SIFNegocio.Compradores();
        private void cargaCompradores()
        {
            bindingSource.DataSource = compradoresN.CargaCompradores();
        }

        public void DesactivaComandos()
        {
            //throw new NotImplementedException();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void CompradorLaboratorioUserControl_Load(object sender, EventArgs e)
        {
            cargaCompradores();
        }

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.BuscaLocal();
        }

        internal void AgregaProveedores(string ListaProveedores)
        {
            this.current.LISTA_PROVEEDOR_ID = ListaProveedores;
            this.compradoresN.Actualiza(current);
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.SeleccionaUsuario();
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

    }
}
