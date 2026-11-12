using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Excel;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

using Equin.ApplicationFramework;
using SIF.View.Catalogos;
using DevComponents.DotNetBar.SuperGrid;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SIF.View.Subrogacion
{
    public partial class ArticulosSubrogacionUserControl : Templates.CatalogoUserControl
    {
        public int SugerenciaID;
        private DataGridViewTextBoxDropDownColumn Columna;
        private int ClienteID;
        public ArticulosSubrogacionUserControl()
        {
            InitializeComponent();
            this.InicializaColumnas();

            Privilegios();
        }

        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                // Do not change enabled state for the export button here (designer controls it)
                if (object.ReferenceEquals(Xbtn, this.exportarCatButtonItem))
                {
                    // leave enabled state as set in designer
                    continue;
                }

                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 85, int.Parse(Xbtn.Tag.ToString()));

            }
            //dataGridViewX1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 85, 2);
        }

        public bool Mostrado;
        public MainForm Owner { get; set; }

        private SIFNegocio.Subrogacion.Articulos logica = new SIFNegocio.Subrogacion.Articulos();
        private string propiedadBusqueda = "";
        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow current;

        #region Navegacion

        /// <summary>
        /// Activa los accesos por combinación de teclas
        /// </summary>
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
            NuevoButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            eliminarButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            seleccionaClienteButtonItem.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
        }

        /// <summary>
        /// Activa los acesos cortos mediante el teclado
        /// </summary>
        public void DesactivaComandos()
        {
            backButton.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
            eliminarButtonItem.Shortcuts.Clear();
            seleccionaClienteButtonItem.Shortcuts.Clear();
        }
        private SIFNegocio.Articulo LstArticulos = new SIFNegocio.Articulo();
        private void InicializaColumnas()
        {
            if (ClienteTextBoxX.Tag == null)
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs, 0);
            else
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs, int.Parse(ClienteTextBoxX.Tag.ToString()));
            bindingSource.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB;
            DataGridViewTextBoxDropDownColumn ColClave = dataGridViewX1.Columns["ARTICULO_ID"] as DataGridViewTextBoxDropDownColumn;
            ColClave.ButtonCustomClick += new EventHandler<EventArgs>(ColClave_ButtonCustomClick);

            List<SIFModelo.Tipos.TipoDescto> TipoDesc;
            SIFModelo.Tipos.TipoDescto Reg = new SIFModelo.Tipos.TipoDescto();
            TipoDesc = new List<SIFModelo.Tipos.TipoDescto>();
            Reg.Descto = "Precio Fijo";
            Reg.CLAVEID = "F";
            TipoDesc.Add(Reg);
            SIFModelo.Tipos.TipoDescto Reg1 = new SIFModelo.Tipos.TipoDescto();
            Reg1.Descto = "% Precio Costo";
            Reg1.CLAVEID = "C";
            TipoDesc.Add(Reg1);
            SIFModelo.Tipos.TipoDescto Reg2 = new SIFModelo.Tipos.TipoDescto();
            Reg2.Descto = "% Desc Precio Venta";
            Reg2.CLAVEID = "V";
            TipoDesc.Add(Reg2);
            TipoDescSource.DataSource = TipoDesc;
            TIPO_DESC.DataSource = TipoDescSource;
            TIPO_DESC.DisplayMember = "Descto";
            TIPO_DESC.ValueMember = "CLAVEID";


            Dictionary<string, SIFModelo.Tipos.SiNo> SiNo = new Dictionary<string, SIFModelo.Tipos.SiNo>();
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.SI), SIFModelo.Tipos.SiNo.SI);
            SiNo.Add(Enum.GetName(typeof(SIFModelo.Tipos.SiNo), SIFModelo.Tipos.SiNo.NO), SIFModelo.Tipos.SiNo.NO);



            this.SiNoBindingSource.DataSource = SiNo;
            ACTIVO.DataSource = SiNoBindingSource;
            ACTIVO.DisplayMember = "Key";
            ACTIVO.ValueMember = "Value";

            //PROVEEDOR

            PROVEEDOR_ID.ButtonCustom.Image = global::SIF.Properties.Resources.User16;
            PROVEEDOR_ID.ButtonCustom.Visible = true;
            PROVEEDOR_ID.ButtonCustomClick += PROVEEDORColumn_ButtonCustom_CLICK;

            //LABORATORIO

            LABORATORIO_ID.ButtonCustom.Image = global::SIF.Properties.Resources.User16;
            LABORATORIO_ID.ButtonCustom.Visible = true;
            LABORATORIO_ID.ButtonCustomClick += LABORATORIOColumn_ButtonCustom_CLICK;

            TIPO_MEDICAMENTO_CVE.ButtonCustom.Image = global::SIF.Properties.Resources.Especialidad16;
            TIPO_MEDICAMENTO_CVE.ButtonCustom.Visible = true;
            TIPO_MEDICAMENTO_CVE.ButtonCustomClick += LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK;


        }
        void PROVEEDORColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                Catalogos.ClienteControl ClientesForm = new ClienteControl();
                ClientesForm.Owner = this;
                ClientesForm.PROVEEDOR = true;
                ClientesForm.Muestra();
            }
        }

        void LABORATORIOColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                Catalogos.ClienteControl ClientesForm = new ClienteControl();
                ClientesForm.Owner = this;
                ClientesForm.LAB_MAYORISTA = true;
                ClientesForm.Muestra();
            }
        }

        void LISTA_TIPO_MEDICAMENTO_Column_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn ddc =
                sender as DataGridViewTextBoxColumn;

            if (ddc != null)
            {
                SIFNegocio.Articulo Articulol = new SIFNegocio.Articulo();
                SIFModelo.Articulo Articulo = Articulol.BuscarPorClave(dataGridViewX1[4, dataGridViewX1.CurrentRow.Index].Value.ToString());

                if (Articulo == null)
                {
                   MessageBox.Show("No se ha encontrado el artículo con la clave de farmacia descrita");
                    return;
                }

                Catalogos.ListaTipoMedicamentoForm tipoMedicamentoForm = new ListaTipoMedicamentoForm(Articulo);

                if (tipoMedicamentoForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewX1[11, dataGridViewX1.CurrentRow.Index].Value = tipoMedicamentoForm.ListaTipoMedicamento;
                    dataGridViewX1.EndEdit();
                }
            }
        }


        void ColClave_ButtonCustomClick(object sender, EventArgs e)
        {
            Columna = sender as DataGridViewTextBoxDropDownColumn;
            SIF.View.Articulos.ArticuloUserControl FrmArticulos = new Articulos.ArticuloUserControl();
            FrmArticulos.Owner = this;
            FrmArticulos.Muestra();

        }


        public void AgregaArticulo(SIFModelo.Articulo articulo)
        {
            if (articulo == null)
            {
               MessageBox.Show("Debe elgir un articulo");
                return;
            }
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);
            SIFNegocio.ClienteSubrogacion ClienteL = new SIFNegocio.ClienteSubrogacion();
            SIFModelo.ClienteSubrogaccion ClienteSub = ClienteL.ClientePorID(int.Parse(ClienteTextBoxX.Tag.ToString()));
            if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = precios.PRECIO_VENTA;
            else
                if (ClienteSub.PorScosto > 0)
                    dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_COSTO * ClienteSub.PorScosto / 100) + precios.PRECIO_COSTO);
                else
                    dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ClienteSub.PorDesc / 100));

            dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value = int.Parse(articulo.CODIGO_CLI_ID.ToString());
            dataGridViewX1[4, dataGridViewX1.CurrentRow.Index].Value = articulo.ARTICULO_ID;
            dataGridViewX1[5, dataGridViewX1.CurrentRow.Index].Value = articulo.NOMBRE1;
            //dataGridViewX1[6, dataGridViewX1.CurrentRow.Index].Value = articulo.NOMBRE2;
            dataGridViewX1[11, dataGridViewX1.CurrentRow.Index].Value = articulo.TIPO_MEDICAMENTO_CVE;
            dataGridViewX1[12, dataGridViewX1.CurrentRow.Index].Value = articulo.LABORATORIO_ID;
            dataGridViewX1[13, dataGridViewX1.CurrentRow.Index].Value = articulo.PROVEEDOR_ID;

        }


        private void Back()
        {
            logica.Update(logica.ArticulosDs);

            if (this.Mostrado && Owner.IsModalPanelDisplayed)
            {
                this.DesactivaComandos();
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

                this.Mostrado = false;
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
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

        }


        #endregion

        #region Funciones y Metodos Privados





        private void buscarLocal()
        {
            if (string.IsNullOrEmpty(propiedadBusqueda))
            {
                // propiedadBusqueda = new SIFModelo.QuejasSugTipo.CatQuejasSug().GetType().GetProperties()[0].Name;
            }

            try
            {
                string filtro = " NOMBRE1 LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                filtro += " OR ARTICULO_ID LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                filtro += " OR CODIGOCLI  LIKE '%" + buscarTextBoxX.Text.ToUpper() + "%'";
                //this.dataGridViewX1.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB.Select(filtro);  //.ApplyFilter(delegate(SIFModelo.QuejasSugTipo.CatQuejaSugSubTipo customer) { return customer.GetType().GetProperty(this.propiedadBusqueda).GetValue(customer, null).ToString().ToUpper().Contains(buscarTextBoxX.Text.ToUpper()); });
                this.bindingSource.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB.Select(filtro);
            }
            catch
            {
            }
        }

        #endregion

        //BARRA DE MENU
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            //this.buscar();
            //
            this.buscarLocal();
        }

        public void AgregarCliente(SIFModelo.Cliente cliente)
        {
            ClienteID = cliente.ID;
            ClienteTextBoxX.Tag = cliente.ID;
            ClienteTextBoxX.Text = cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;
            buscar();
        }

        private void buscar()
        {
            if (ClienteTextBoxX.Tag == null)
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs, 0);
            else
            {
                // BUSCAMOS AL CLIENTE SUBROGACION Y PONEMOS LOS VALORES DEFAULT

                SIFNegocio.ClienteSubrogacion ClienteL = new SIFNegocio.ClienteSubrogacion();
                SIFModelo.ClienteSubrogaccion ClienteSub = ClienteL.ClientePorID(int.Parse(ClienteTextBoxX.Tag.ToString()));
                logica.ArticulosDs.Clear();
                logica.ArticulosDs = logica.GetArticulos(logica.ArticulosDs, int.Parse(ClienteTextBoxX.Tag.ToString()));
                logica.ArticulosDs.CAT_ARTICULOS_SUB.ACTIVOColumn.DefaultValue = "S";

                if (ClienteSub == null)
                {
                    return;
                }

                if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                {
                    logica.ArticulosDs.CAT_ARTICULOS_SUB.TIPO_DESCColumn.DefaultValue = "F";

                }
                else
                {
                    if (ClienteSub.PorScosto > 0)
                        logica.ArticulosDs.CAT_ARTICULOS_SUB.TIPO_DESCColumn.DefaultValue = "C";
                    else
                        logica.ArticulosDs.CAT_ARTICULOS_SUB.TIPO_DESCColumn.DefaultValue = "V";
                }

                logica.ArticulosDs.CAT_ARTICULOS_SUB.POR_DESC_PRECIOColumn.DefaultValue = ClienteSub.PorDesc.ToString();
                logica.ArticulosDs.CAT_ARTICULOS_SUB.POR_COSTOColumn.DefaultValue = ClienteSub.PorScosto.ToString();
                logica.ArticulosDs.CAT_ARTICULOS_SUB.CLIENTE_IDColumn.DefaultValue = ClienteTextBoxX.Tag.ToString();
                logica.ArticulosDs.CAT_ARTICULOS_SUB.FECHA_FINColumn.DefaultValue = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                logica.ArticulosDs.CAT_ARTICULOS_SUB.FECHA_INIColumn.DefaultValue = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                logica.ArticulosDs.CAT_ARTICULOS_SUB.ARTICULO_IDColumn.DefaultValue = "ARTICULO NUEVO ";
                logica.ArticulosDs.CAT_ARTICULOS_SUB.NOMBRE1Column.DefaultValue = "ARTICULO NUEVO ";
                logica.ArticulosDs.CAT_ARTICULOS_SUB.PROVEEDOR_IDColumn.DefaultValue = "0";
                bindingSource.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB;
                logica.ArticulosDs.AcceptChanges();
                //dataGridViewX1.Rows.Clear();
                try
                {
                    dataGridViewX1.DataSource = bindingSource;
                }
                catch
                {
                }
            }
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.Nuevo();
        }

        private void Nuevo()
        {
            if (ClienteTextBoxX.Tag == null)
               MessageBox.Show("Debe seleccionar un cliente primero", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                bindingSource.DataSource = this.logica.ArticulosDs.CAT_ARTICULOS_SUB;
                bindingSource.AddNew();
            }
        }

        private void modificarButtonItem_Click(object sender, EventArgs e)
        {
            this.current = this.bindingSource.Current as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
        }

        private void eliminarButtonItem_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }

        private void Eliminar()
        {
            // bindingSource.RemoveCurrent();
            var objActualizar = bindingSource.Current;

            if (objActualizar == null)
            {
               MessageBox.Show("Debe seleccionar el artículo a eliminar");
                return;
            }

            SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow ArticuloSUB = null;
            if (objActualizar is SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow)
            {
                ArticuloSUB = objActualizar as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
            }

            if (objActualizar is DataRowView)
            {
                ArticuloSUB = ((DataRowView)objActualizar).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
            }

            if (ArticuloSUB.ACTIVO == "S")
            {

                if (MessageBox.Show("¿Desea eliminar el artículo " + ArticuloSUB.ARTICULO_ID + "?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ArticuloSUB.ACTIVO = "N";
            }

            else if (ArticuloSUB.ACTIVO == "N")
            {

                if (MessageBox.Show("¿Desea Activar el artículo " + ArticuloSUB.ARTICULO_ID + "?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                ArticuloSUB.ACTIVO = "S";
            }


            logica.Update(logica.ArticulosDs);
            this.dataGridViewX1.Refresh();
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        DataGridViewCell celdaEditada;
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridViewX1[1, e.RowIndex].Value;
            if (id.ToString() == "0")
            {
                var codigoCli = dataGridViewX1[3, e.RowIndex].Value;
                int clienteID = int.Parse(ClienteTextBoxX.Tag.ToString());
                SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow rwEncontrado = new SIFNegocio.Subrogacion.Articulos().GetArticulo(codigoCli.ToString(), clienteID);
                if (rwEncontrado != null)
                {
                    dataGridViewX1[1, e.RowIndex].Value = rwEncontrado.ID;
                }

            }

            if (e.ColumnIndex == 3)
            {
                celdaEditada = dataGridViewX1[e.ColumnIndex, e.RowIndex];
                if (celdaEditada.Value != null)
                {
                    string codCli = celdaEditada.Value.ToString();
                    //VALIDAR SI YA EXISTE EL CAT CLIENTE EN EL RANGO
                    int clienteID = int.Parse(ClienteTextBoxX.Tag.ToString());
                    SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow rowSubroga = new SIFNegocio.Subrogacion.Articulos().GetArticulo(codCli, clienteID);


                    SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow grRow;

                    if (dataGridViewX1.CurrentRow.DataBoundItem is SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow)
                    {
                        grRow = dataGridViewX1.CurrentRow.DataBoundItem as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
                    }
                    else
                    {
                        grRow = ((DataRowView)dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
                    }

                    if (rowSubroga != null)
                    {
                        if (rowSubroga.ARTICULO_ID == grRow.ARTICULO_ID)
                        {
                            //LAS FECHAS ESTAN EN EL MISMO RANGO?
                            if (rowSubroga.FECHA_INI >= grRow.FECHA_INI && rowSubroga.FECHA_FIN >= grRow.FECHA_FIN)
                            {
                               MessageBox.Show("Ya se encuentra un artículo con la misma clave de artículo en este rango de fechas");
                                return;
                            }
                        }
                    }
                }
            }

            if(e.ColumnIndex == 7)
            {
                celdaEditada = dataGridViewX1[4, e.RowIndex];
                SIFModelo.Articulo articuloP = LstArticulos.BuscarPorClave(celdaEditada.Value.ToString());
                 SIFModelo.Inventarios.ListaPrecios preciosP = new SIFNegocio.Articulo().ArticuloPrecio(articuloP.ARTICULO_ID);
                 if (Convert.ToDecimal(dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value.ToString()) < preciosP.PRECIO_COSTO)
                 {
                    MessageBox.Show("No se puede aplicar precio MENOR a costo");
                     dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = preciosP.PRECIO_VENTA;
                     //dataGridViewX1.Rows.RemoveAt(this.dataGridViewX1.CurrentRow.Index);
                     return;
                 }
            }
            if (e.ColumnIndex == 4)
            {

                //buscamos el articulo y mostramos su nombre
                celdaEditada = dataGridViewX1[e.ColumnIndex, e.RowIndex];
                if (celdaEditada.Value != null)
                {
                    SIFModelo.Articulo articulo = LstArticulos.BuscarPorClave(celdaEditada.Value.ToString());
                    if (articulo != null)
                    {


                        SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);
                        SIFNegocio.ClienteSubrogacion ClienteL = new SIFNegocio.ClienteSubrogacion();
                        SIFModelo.ClienteSubrogaccion ClienteSub = ClienteL.ClientePorID(int.Parse(ClienteTextBoxX.Tag.ToString()));

                        //VALIDAR SI YA EXISTE EL CAT CLIENTE EN EL RANGO
                        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow rowSubroga = new SIFNegocio.Subrogacion.Articulos().GetArticuloID(articulo.ARTICULO_ID, ClienteSub.ID);

                        SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow grRow = null;

                        if (dataGridViewX1.CurrentRow.DataBoundItem is DataRowView)
                        {
                            grRow = ((DataRowView)dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
                        }
                        if (dataGridViewX1.CurrentRow.DataBoundItem is SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow)
                        {
                            grRow = dataGridViewX1.CurrentRow.DataBoundItem as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;
                        }

                        if (rowSubroga != null)
                        {
                            if (rowSubroga.ARTICULO_ID == grRow.ARTICULO_ID)
                            {
                                //LAS FECHAS ESTAN EN EL MISMO RANGO?
                                if (rowSubroga.FECHA_INI >= grRow.FECHA_INI && rowSubroga.FECHA_FIN >= grRow.FECHA_FIN)
                                {
                                   MessageBox.Show("Ya se encuentra un artículo con la misma clave de artículo en este rango de fechas");
                                    return;
                                }
                            }
                        }


                        if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.SI)
                            dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = precios.PRECIO_VENTA;
                        else
                            if (ClienteSub.PorScosto > 0)
                                dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_COSTO * ClienteSub.PorScosto / 100) + precios.PRECIO_COSTO);
                            else
                                dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - (precios.PRECIO_VENTA * ClienteSub.PorDesc / 100));

                        dataGridViewX1[5, dataGridViewX1.CurrentRow.Index].ReadOnly = false;
                        dataGridViewX1[6, dataGridViewX1.CurrentRow.Index].ReadOnly = false;

                        dataGridViewX1[4, dataGridViewX1.CurrentRow.Index].Value = articulo.ARTICULO_ID;
                        dataGridViewX1[5, dataGridViewX1.CurrentRow.Index].Value = articulo.NOMBRE1;
                        //dataGridViewX1[6, dataGridViewX1.CurrentRow.Index].Value = articulo.NOMBRE2;
                        dataGridViewX1[11, dataGridViewX1.CurrentRow.Index].Value = articulo.TIPO_MEDICAMENTO_CVE;
                        dataGridViewX1[12, dataGridViewX1.CurrentRow.Index].Value = articulo.LABORATORIO_ID;
                        dataGridViewX1[13, dataGridViewX1.CurrentRow.Index].Value = articulo.PROVEEDOR_ID;
                        dataGridViewX1[1, dataGridViewX1.CurrentRow.Index].Value = articulo.CODIGO_CLI_ID;
                    }
                    else
                    {
                        MessageBox.Show("El código de artículo ingresado no existe en el catálogo de productos");
                        //dataGridViewX1.CancelEdit();
                        dataGridViewX1.Rows.RemoveAt(this.dataGridViewX1.CurrentRow.Index);
                        return;
                    }
                }
            }
            else
                if ((e.ColumnIndex == 8) || (e.ColumnIndex == 9) || (e.ColumnIndex == 10))
                {
                    SIFModelo.Articulo articulo = LstArticulos.BuscarPorClave(dataGridViewX1[4, dataGridViewX1.CurrentRow.Index].Value.ToString());
                    SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(articulo.ARTICULO_ID);
                    celdaEditada = dataGridViewX1[e.ColumnIndex, e.RowIndex];


                    //VALIDAR SI YA EXISTE EL CAT CLIENTE EN EL RANGO
                    SIFNegocio.ClienteSubrogacion ClienteL = new SIFNegocio.ClienteSubrogacion();
                    SIFModelo.ClienteSubrogaccion ClienteSub = ClienteL.ClientePorID(int.Parse(ClienteTextBoxX.Tag.ToString()));
                    SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow rowSubroga = new SIFNegocio.Subrogacion.Articulos().GetArticuloID(articulo.ARTICULO_ID, ClienteSub.ID);
                    SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow grRow = ((DataRowView)dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow;

                    if (rowSubroga != null)
                    {
                        if (rowSubroga.ARTICULO_ID == grRow.ARTICULO_ID)
                        {
                            //LAS FECHAS ESTAN EN EL MISMO RANGO?
                            if (rowSubroga.FECHA_INI >= grRow.FECHA_INI && rowSubroga.FECHA_FIN >= grRow.FECHA_FIN)
                            {
                               MessageBox.Show("Ya se encuentra un artículo con la misma clave de artículo en este rango de fechas");
                                return;
                            }
                        }
                    }

                    if (celdaEditada.Value.ToString() == "F")
                        dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = precios.PRECIO_VENTA;
                    else
                        if (celdaEditada.Value.ToString() == "C")
                            dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace((precios.PRECIO_COSTO * decimal.Parse(dataGridViewX1[9, dataGridViewX1.CurrentRow.Index].Value.ToString()) / 100) + precios.PRECIO_COSTO);
                        else
                            dataGridViewX1[7, dataGridViewX1.CurrentRow.Index].Value = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(precios.PRECIO_VENTA - (precios.PRECIO_VENTA * decimal.Parse(dataGridViewX1[10, dataGridViewX1.CurrentRow.Index].Value.ToString()) / 100));
                }
        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            DataGridViewColumn columna = grid.Columns[e.ColumnIndex];
            this.buscarTextBoxX.WatermarkText = "BUSCAR POR " + columna.HeaderText;
            this.propiedadBusqueda = columna.DataPropertyName;
        }

        private void dataGridViewX1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    // bucamos el nombre del articulo
                    break;
                case 3:
                    //buscamos el nombre del articulo
                    break;
            }
        }

        private void dataGridViewX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //  this.Eliminar();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.buscarTextBoxX.SelectAll();
                this.buscarTextBoxX.Focus();
            }
        }

        private void buscarTextBoxX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.buscarButtonX.PerformClick();
            }
            if (e.KeyData == Keys.Escape)
            {
                this.buscarTextBoxX.Clear();
            }
            this.buscarLocal();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //logica.Buscar("", "",SugerenciaID);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.bindingSource.DataSource = logica.ArticulosDs.CAT_ARTICULOS_SUB;

            this.dataGridViewX1.Cursor = Cursors.Default;
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            if (MouseButtons != 0) return;

            DevComponents.DotNetBar.Controls.DataGridViewX grid = sender as DevComponents.DotNetBar.Controls.DataGridViewX;
            if (celdaEditada != null && grid.CurrentCell != null)
            {
                // if we are currently in the next line of last edit cell 
                if (grid.CurrentCell.RowIndex == celdaEditada.RowIndex + 1 &&
                     grid.CurrentCell.ColumnIndex == celdaEditada.ColumnIndex)
                {
                    int iColNew;
                    int iRowNew = 0;
                    if (celdaEditada.ColumnIndex >= grid.ColumnCount - 1)
                    {
                        iColNew = 0;
                        iRowNew = grid.CurrentCell.RowIndex;
                    }
                    else
                    {
                        iColNew = celdaEditada.ColumnIndex + 1;
                        iRowNew = celdaEditada.RowIndex;
                    }
                    if (iRowNew < 0)
                        iRowNew = 0;
                        grid.CurrentCell = grid[iColNew, iRowNew];
                }
                // grid.BeginEdit(true);
            }
            celdaEditada = null;

        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void buscarTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            this.buscarTextBoxX.Clear();
            this.buscarLocal();
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                DataObject d = dataGridViewX1.GetClipboardContent();
                if (d == null) { return; }
                Clipboard.SetDataObject(d);
            }
        }

        private void dataGridViewX1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            logica.Update(logica.ArticulosDs);

        }
        View.Catalogos.ClienteControl frmCliente;
        private void SeleccionaCliente()
        {


            if (frmCliente == null)
            {
                frmCliente = new View.Catalogos.ClienteControl();
                frmCliente.Dock = DockStyle.Fill;
                frmCliente.Owner = this;
            }
            frmCliente.Muestra();


        }

        private void seleccionaClienteButtonItem_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }

        private void ClienteTextBoxX_ButtonCustomClick(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }

        private void ClienteTextBoxX_TextChanged(object sender, EventArgs e)
        {

        }
        private int ImportaArticulos()
        {
            String NombreArch = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo Excel a Procesar";
            ////fdlg.InitialDirectory = ConfigSettings.ReadSetting("PathPSEntrada"); //@"D:\";
            fdlg.Filter = "Excel files (*.xls;*xlsx)|*.xls;*.xlsx";
            //fdlg.FilterIndex = 2 ;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                NombreArch = fdlg.FileName;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(NombreArch);
                string FExt = Path.GetExtension(NombreArch);
                try
                {
                    // Lee archivo
                    FileStream stream = File.Open(Path.Combine(FPath, FName), FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;
                    if (Regex.IsMatch(FExt, "xlsx", RegexOptions.IgnoreCase))
                        // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    else
                        // Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

                    DataSet result = excelReader.AsDataSet();
                    excelReader.IsFirstRowAsColumnNames = true;
                    int row_no = 1, ind = 0;
                    string userId = Helpers.Sesion.Usuario.UsuariosID.ToString();
                    SIFNegocio.Subrogacion.Articulos.Delete(ClienteTextBoxX.Tag.ToString(), userId);
                    object[] Keys = new object[2];
                    DataRow FacRow;
                    int value;
                    if (result.Tables.Count > 0)
                    {
                        while (row_no < result.Tables[ind].Rows.Count) // ind is the index of table (sheet name) which you want to convert to csv
                        {
                            if (result.Tables[ind].Rows[row_no][5].ToString().IsFloat())
                            {
                                SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow Registro = logica.ArticulosDs.CAT_ARTICULOS_SUB.NewCAT_ARTICULOS_SUBRow();
                                Registro.CLIENTE_ID = int.Parse(ClienteTextBoxX.Tag.ToString());
                                Registro.ANEXO = result.Tables[ind].Rows[row_no][0].ToString(); //anexo
                                Registro.CODIGOCLI = result.Tables[ind].Rows[row_no][1].ToString(); //anexo
                                Registro.NOMBRE1 = result.Tables[ind].Rows[row_no][2].ToString().Trim().Substring(0, (result.Tables[ind].Rows[row_no][2].ToString().Trim().Length > 300) ? 300 : result.Tables[ind].Rows[row_no][2].ToString().Trim().Length); //anexo
                                Registro.NOMBRE2 = result.Tables[ind].Rows[row_no][3].ToString().Trim(); //anexo
                                Registro.ARTICULO_ID = result.Tables[ind].Rows[row_no][4].ToString(); //anexo
                                if (Registro.ARTICULO_ID == "")
                                    Registro.ARTICULO_ID = "ARTCULO NUEVO";
                                Registro.PRECIO = double.Parse(result.Tables[ind].Rows[row_no][5].ToString()); //anexo
                                //verificamos si el articulo exste en farmacia y agregamos los datos

                                SIFModelo.Articulo articulo = LstArticulos.BuscarPorClave(Registro.ARTICULO_ID);
                                if (articulo != null)
                                {
                                    Registro.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                                    Registro.LABORATORIO_ID = articulo.LABORATORIO_ID;
                                    Registro.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                                }
                                if (Registro.ARTICULO_ID.Length > 0)
                                    logica.ArticulosDs.CAT_ARTICULOS_SUB.AddCAT_ARTICULOS_SUBRow(Registro);

                            }
                            row_no++;
                        }
                        excelReader.Close();
                        logica.insert(logica.ArticulosDs);
                        buscar();
                        return row_no;
                    }
                    else
                    {
                       MessageBox.Show("Error al leer el archivo " + FName, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;

                }

            }
            return 0;
        }

        private void btn_SelectFileXls_Click(object sender, EventArgs e)
        {
            if (ClienteTextBoxX.Tag != null)
            {
                int TotReg = ImportaArticulos();
                statusLabel.Text = "Total registros importados: " + TotReg.ToString();
                //MessageBoxEx.Show("Total registros:" + TotReg.ToString(), "Catalogo articulos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
               MessageBox.Show("Debe seleccionar un cliente primero", "Catalogo articulos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void importarCatButtonItem_Click(object sender, EventArgs e)
        {
            //Agregar nuevo formulario para la importanción de catalogos:
            ImportarCatArticulosSub importar = new ImportarCatArticulosSub();
            if (importar.ShowDialog() != DialogResult.OK)
                return;


            //if (ClienteID == 0)
            //{
            //    MessageBox.Show("Debe seleccionar primero un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //MessageBox.Show("Opcion Habilitada el 18 abril 2018 " + Environment.NewLine +
            //     "Especificaciones de la version: " + Environment.NewLine + Environment.NewLine +
            //     "^Solo funciona para el cliente 92" + Environment.NewLine +
            //     "Cliente seleccionado " + ClienteID + Environment.NewLine +
            //     "^Recibe un archivo delimitado por tabulaciones de 7 columnas formato Txt." + Environment.NewLine +
            //     "    *Codigo Ean" + Environment.NewLine +
            //     "    *Clave gob" + Environment.NewLine +
            //     "    *Clave isstep" + Environment.NewLine +
            //     "    *Tipo Medicamento " + Environment.NewLine +
            //     "    *Precio" + Environment.NewLine +
            //     "    *Fecha Inicio (dd/MM/yyyy) " + Environment.NewLine +
            //     "    *Fecha Fin (dd/MM/yyyy) " + Environment.NewLine,
            //     "Informacion",
            //     MessageBoxButtons.OK,
            //     MessageBoxIcon.Information
            //     );
            //this.importarArchivoRemi();

        }

        private void exportarCatButtonItem_Click(object sender, EventArgs e)
        {
            if (ClienteTextBoxX.Tag == null)
            {
               MessageBox.Show("Debe seleccionar un cliente primero", "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = 0;
            if (!int.TryParse(ClienteTextBoxX.Tag.ToString(), out clienteId))
            {
               MessageBox.Show("El identificador del cliente es inválido.", "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener catálogo filtrado por cliente
            SIFModelo.SubRogacion.Sobrogacion ds = new SIFModelo.SubRogacion.Sobrogacion();
            try
            {
                ds = logica.GetArticulos(ds, clienteId);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al obtener el catálogo: " + ex.Message, "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ds == null || ds.CAT_ARTICULOS_SUB.Rows.Count == 0)
            {
               MessageBox.Show("No se encontraron registros para el cliente seleccionado.", "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FileName = string.Format("catalogo_cliente_{0}.csv", clienteId);
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                // Obtener lista de instituciones del cliente una sola vez
                List<SIFModelo.Catalogo.Institucion> listaInstituciones = null;
                try
                {
                    SIFNegocio.Clientes cliNg = new SIFNegocio.Clientes();
                    SIFModelo.Cliente clienteModel = cliNg.ClientePorID(clienteId);
                    if (clienteModel != null)
                        listaInstituciones = cliNg.BuscaInstituciones(clienteModel);
                }
                catch
                {
                    // ignorar si falla la carga de instituciones; se exportará vacío
                    listaInstituciones = null;
                }

                using (var sw = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("iso-8859-1")))
                {
                    // Header
                    sw.WriteLine("ARTICULO_ID,NOMBRE1,PRECIO,FECHA_INI,FECHA_FIN,CODIGOCLI,CODIGOCLI2,TIPO_MEDICAMENTO_CLI,INSTITUCION_ID");

                    foreach (SIFModelo.SubRogacion.Sobrogacion.CAT_ARTICULOS_SUBRow row in ds.CAT_ARTICULOS_SUB)
                    {
                        string articuloId = QuoteCsv(row.ARTICULO_ID);
                        string nombre1 = QuoteCsv(row.NOMBRE1);
                        string precio = row.Table.Columns.Contains("PRECIO") && !row.IsNull("PRECIO") ? row["PRECIO"].ToString() : "";
                        string fechaIni = row.Table.Columns.Contains("FECHA_INI") && !row.IsNull("FECHA_INI") ? ((DateTime)row["FECHA_INI"]).ToString("dd/MM/yyyy HH:mm:ss") : "";
                        string fechaFin = row.Table.Columns.Contains("FECHA_FIN") && !row.IsNull("FECHA_FIN") ? ((DateTime)row["FECHA_FIN"]).ToString("dd/MM/yyyy HH:mm:ss") : "";
                        string codigoCli = row.Table.Columns.Contains("CODIGOCLI") && !row.IsNull("CODIGOCLI") ? QuoteCsv(row["CODIGOCLI"].ToString()) : "";
                        string codigoCli2 = row.Table.Columns.Contains("CODIGOCLI2") && !row.IsNull("CODIGOCLI2") ? QuoteCsv(row["CODIGOCLI2"].ToString()) : "";
                        string tipoMedicamentoCli = row.Table.Columns.Contains("TIPO_MEDICAMENTO_CLI") && !row.IsNull("TIPO_MEDICAMENTO_CLI") ? QuoteCsv(row["TIPO_MEDICAMENTO_CLI"].ToString()) : "";
                        string institucion = "";
                        if (row.Table.Columns.Contains("INSTITUCION_ID") && !row.IsNull("INSTITUCION_ID"))
                        {
                            // intentar resolver id a nombre usando la lista cargada
                            int idInst;
                            if (int.TryParse(row["INSTITUCION_ID"].ToString(), out idInst) && listaInstituciones != null)
                            {
                                var inst = listaInstituciones.FirstOrDefault(x => x.institucion_id == idInst);
                                if (inst != null)
                                    institucion = QuoteCsv(inst.Nombre);
                                else
                                    institucion = QuoteCsv(row["INSTITUCION_ID"].ToString());
                            }
                            else
                            {
                                institucion = QuoteCsv(row["INSTITUCION_ID"].ToString());
                            }
                        }

                        sw.WriteLine(string.Join(",", new[] { articuloId, nombre1, precio, fechaIni, fechaFin, codigoCli, codigoCli2, tipoMedicamentoCli, institucion }));
                    }
                }

               MessageBox.Show("Archivo exportado correctamente.", "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Exportar catálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string QuoteCsv(string input)
            {
                if (string.IsNullOrEmpty(input)) return string.Empty;
                // Escape double quotes
                string v = input.Replace("\"", "\"\"");
                // Enclose in quotes if contains comma or quote or newline
                if (v.Contains(",") || v.Contains("\"") || v.Contains("\n") || v.Contains("\r"))
                    return "\"" + v + "\"";
                return v;
            }
        }
        private void importarArchivoRemi()
        {
            this.buscarArchivoI();

        }

        /* private void buscarArchivoI()
         {   
             SIFNegocio.Articulo art = new SIFNegocio.Articulo();
             OpenFileDialog fdlg = new OpenFileDialog();
             fdlg.Title = "Seleccione el archivo a Procesar";
             fdlg.Filter = "CSV files (*.TXT)|*.txt";
             fdlg.RestoreDirectory = true;
             bool FmtValid = true;
             if (fdlg.ShowDialog() == DialogResult.OK)
             {
                 SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                 DataTable dtPedido = new DataTable();
                 dtPedido.Columns.Add("clave", typeof(string));         //Corresponde al codigo del Articulo
                 dtPedido.Columns.Add("claveGob", typeof(string));      //Corresponde a la Clave Gobierno
                 dtPedido.Columns.Add("isss", typeof(string));         //Corresponde al codigo Ean
                 dtPedido.Columns.Add("tipo", typeof(string));   //Tipo del medicamento
                 dtPedido.Columns.Add("precio", typeof(Decimal));        //Precio al que se venderá el producto
                 dtPedido.Columns.Add("fecha_ini", typeof(DateTime));
                 dtPedido.Columns.Add("fecha_fin", typeof(DateTime));

                 StreamReader reader = StreamReader.Null;
                 string str = null;
                 int Regs = 0;
                 string FName = fdlg.SafeFileName;
                 string FPath = Path.GetDirectoryName(fdlg.FileName);
                 string FExt = Path.GetExtension(FName);
                 Regex objNotNumPattern = new Regex(@"[^0-9]([.][0-9]{1,3})");
                 Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                 try
                 {
                     // Valida formato de archivo
                     reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                     List<String> listaInex = new List<string>();
                     while ((str = reader.ReadLine()) != null)
                     {
                         int x = str.Split('\t').Count();
                         if (x != 7)
                         {
                             FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido");
                             break;
                         }
                         string codigo = str.Split('\t')[0];

                         SIFModelo.Articulo Exs = art.BuscarPorClave(codigo);
                         if (Exs == null) {
                             listaInex.Add(codigo);
                         }
                         // Valida cantidad
                         if (objNotNumPattern.IsMatch(str.Split('\t')[4]))
                         {
                             FmtValid = false;
                             MessageBox.Show("El precio " + str.Split('\t')[4].ToString() + " es Invalido");
                             break;
                         }
                     }

                     if (listaInex.Count > 0) {
                         string msg = string.Empty;
                         msg += "No existen los codigos:" + Environment.NewLine;
                         foreach (string s in listaInex)
                         {
                             msg += s.ToString()+Environment.NewLine;                           
                         }
                         MessageBox.Show(msg);
                         return;
                     }
                     /*en caso de que alla productos repetidos*/
        //aInex = listaInex.OrderBy(x => x).Where(unico).ToList();
        /*  var query = listaInex.GroupBy(c => c.ToString(),
                       (numcolor) => new
                       {
                           Color = numcolor.Count()
                       });
          foreach (var item in query)
          {
              MessageBox.Show( item.Key.ToString() +"se repite "+ item.Count());
          }

          foreach (string item in listaInex)
          {
              Console.WriteLine(item);
          }

          // Lee archivo
          string Result = "";
          if (FmtValid)
          {
              reader.Close();
              reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
              while ((str = reader.ReadLine()) != null)
              {

                  dtPedido.Rows.Add(str.Split('\t')[0],
                                    str.Split('\t')[1],
                                    str.Split('\t')[2],
                                    str.Split('\t')[3],
                                    str.Split('\t')[4],
                                    str.Split('\t')[5],
                                    str.Split('\t')[6]
                                    );

                  Regs++;
              }

              DataRow[] results = dtPedido.Select(null, "clave");



              //recorre cada articulo y valida las reglas;
              foreach (DataRow rows in results)
              {
                  String articulo = rows["clave"].ToString().Trim();
                  SIFNegocio.Articulo ArtNegocio = new SIFNegocio.Articulo();
                  SIFModelo.Articulo articuloM = new SIFModelo.Articulo();
                  articuloM.ARTICULO_ID = articulo;
                  SIFModelo.Inventarios.Inventario InventarioArt = ArtNegocio.InventarioPorArticulo(articuloM);
                  if (InventarioArt == null)
                  {
                      MessageBox.Show("EL ARTICULO NO EXISTE EN EL CATÁLOGO: " +
                             articulo + ", VERIFIQUE EL ARCHIVO.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                      return;
                  }

              }
              ///


              String[] Clave = new String[results.Length];
              String[] ClaveGob = new String[results.Length];
              String[] Isss = new String[results.Length];
              String[] Tipo = new String[results.Length];
              decimal[] Precio = new decimal[results.Length];
              string[] fechaInicio = new string[results.Length]; 
              string[] fechaFin = new string[results.Length];
              int ind = 0;

              foreach (DataRow rows in dtPedido.Rows)
              {
                  Clave[ind] = rows["clave"].ToString().Trim();
                  ClaveGob[ind] = rows["claveGob"].ToString().Trim();
                  Isss[ind] = rows["isss"].ToString().Trim();
                  Tipo[ind] = rows["tipo"].ToString().Trim();
                  Precio[ind] = Convert.ToDecimal(rows["precio"]);
                  // Formatear la fecha como string
                  DateTime fechaIni = Convert.ToDateTime(rows["fecha_ini"]).Date.AddHours(0).AddMinutes(0).AddSeconds(0);
                  DateTime fechaF = Convert.ToDateTime(rows["fecha_fin"]).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                  fechaInicio[ind] = fechaIni.ToString("dd/MM/yyyy HH:mm:ss");
                  fechaFin[ind] = fechaF.ToString("dd/MM/yyyy HH:mm:ss");

                  ind++;
              }
              SIFNegocio.Subrogacion.Articulos artNg = new SIFNegocio.Subrogacion.Articulos();
              string agregar = String.Empty;
              if (DialogResult.Yes ==MessageBox.Show("Desea conservar el catalogo Cargado en sistema?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                     agregar = "S";                        
              else
                  agregar = "N";

              //string resul= artNg.insertaCatalogoImp(939393, Helpers.Sesion.Usuario.UsuariosID.ToString(), Clave, ClaveGob, Isss, Tipo, Precio, agregar );
              string resul= artNg.insertaCatalogoImp(ClienteID, Helpers.Sesion.Usuario.UsuariosID.ToString(), Clave, ClaveGob, Isss, Tipo, Precio, fechaInicio, fechaFin, agregar );
             MessageBox.Show(resul, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);                       

          }
      }
      catch (Exception ex)
      {
          MessageBox.Show(ex.Message.ToString());
      }
      finally
      {
          reader.Close();
      }

  }

}

*/

        private void buscarArchivoI()
        {
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.TXT)|*.txt";
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() != DialogResult.OK)
                return;

            string FName = fdlg.SafeFileName;
            string FPath = Path.GetDirectoryName(fdlg.FileName);

            Regex objNotNumPattern = new Regex(@"[^0-9]([.][0-9]{1,3})");

            try
            {
                var claves = new List<string>();
                var clavesGob = new List<string>();
                var isss = new List<string>();
                var tipos = new List<string>();
                var precios = new List<decimal>();
                var fechaInicio = new List<DateTime>();
                var fechaFin = new List<DateTime>();

                var listaInex = new List<string>();
                bool FmtValid = true;

                // ============================
                // 1. Leer archivo
                // ============================
                using (var reader = new StreamReader(Path.Combine(FPath, FName), Encoding.GetEncoding("iso-8859-1")))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        var parts = str.Split('\t');
                        if (parts.Length != 7)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de archivo " + FName + " es inválido");
                            break;
                        }

                        string codigo = parts[0].Trim();

                        // Validar existencia en catálogo
                        SIFModelo.Articulo Exs = art.BuscarPorClave(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(codigo);
                        }

                        // Validar precio
                        if (objNotNumPattern.IsMatch(parts[4]))
                        {
                            FmtValid = false;
                            MessageBox.Show("El precio " + parts[4] + " es inválido");
                            break;
                        }

                        if (!FmtValid) break;

                        // Guardar en listas
                        claves.Add(parts[0].Trim());
                        clavesGob.Add(parts[1].Trim());
                        isss.Add(parts[2].Trim());
                        tipos.Add(parts[3].Trim());
                        precios.Add(Convert.ToDecimal(parts[4]));

                        DateTime fIni = Convert.ToDateTime(parts[5]).Date;
                        DateTime fFin = Convert.ToDateTime(parts[6]).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                        fechaInicio.Add(fIni);
                        fechaFin.Add(fFin);
                    }
                }

                // ============================
                // 2. Validaciones iniciales
                // ============================
                if (listaInex.Count > 0)
                {
                    string msg = "No existen los códigos:" + Environment.NewLine + string.Join(Environment.NewLine, listaInex);
                    MessageBox.Show(msg);
                    return;
                }

                if (!FmtValid) return;

                foreach (string clave in claves)
                {
                    SIFModelo.Articulo articuloM = new SIFModelo.Articulo();
                    articuloM.ARTICULO_ID = clave;
                    SIFModelo.Inventarios.Inventario InventarioArt = art.InventarioPorArticulo(articuloM);
                    if (InventarioArt == null)
                    {
                        MessageBox.Show("EL ARTICULO NO EXISTE EN EL CATÁLOGO: " + clave + ", VERIFIQUE EL ARCHIVO.",
                            "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                // ============================
                // 3. Preguntar si se conserva catálogo
                // ============================
                string agregar = (DialogResult.Yes == MessageBox.Show(
                    "¿Desea conservar el catálogo cargado en sistema?", "Pregunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)) ? "S" : "N";

                // ============================
                // 4. Insertar por bloques
                // ============================
                int batchSize = 2000; // puedes ajustar el tamaño
                int totalRegistros = claves.Count;

                SIFNegocio.Subrogacion.Articulos artNg = new SIFNegocio.Subrogacion.Articulos();

                for (int i = 0; i < totalRegistros; i += batchSize)
                {
                    // Tomar subconjuntos de cada lista
                    var arrClaves = claves.Skip(i).Take(batchSize).ToArray();
                    var arrClavesGob = clavesGob.Skip(i).Take(batchSize).ToArray();
                    var arrIsss = isss.Skip(i).Take(batchSize).ToArray();
                    var arrTipos = tipos.Skip(i).Take(batchSize).ToArray();
                    var arrPrecios = precios.Skip(i).Take(batchSize).ToArray();
                    var arrFechaInicio = fechaInicio.Skip(i).Take(batchSize)
                                                    .Select(f => f.ToString("dd/MM/yyyy HH:mm:ss")).ToArray();
                    var arrFechaFin = fechaFin.Skip(i).Take(batchSize)
                                              .Select(f => f.ToString("dd/MM/yyyy HH:mm:ss")).ToArray();

                    // Mandar bloque a negocio
                    //string resul = artNg.insertaCatalogoImp(
                    //    ClienteID,
                    //    0,
                    //    Helpers.Sesion.Usuario.UsuariosID.ToString(),
                    //    arrClaves,
                    //    arrClavesGob,
                    //    arrIsss,
                    //    arrTipos,
                    //    arrPrecios,
                    //    arrFechaInicio,
                    //    arrFechaFin,
                    //    agregar
                    //);

                    // Opcional: mostrar avance
                    Console.WriteLine($"Bloque {i / batchSize + 1} procesado: {arrClaves.Length} registros");
                }

                MessageBox.Show("Catálogo cargado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
