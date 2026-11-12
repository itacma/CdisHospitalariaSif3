using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.OrdenCompra
{
    public partial class ManejoDescuentosUserControl : Templates.ListaUserControl
    {
        public static Boolean tomaArchivo = false;
        public ManejoDescuentosUserControl()
        {
            InitializeComponent();
            Privilegios();
            InicializaColumnas();
        }


        void Privilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 15, int.Parse(Xbtn.Tag.ToString()));
            }

        }
        
        #region Navegacion

        public View.Menu.ComprasMenu Owner;
        private bool Mostrado = false;
        public void Muestra()
        {
            Owner.Owner.DesactivaComandos();
            Owner.DesactivaComandos();
            this.ActivaComandos();
            this.Dock = DockStyle.Fill;
            this.Mostrado = true;

            Owner.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void Back()
        {
            Owner.Owner.DesactivaComandos();
            Owner.ActivaComandos();
            this.DesactivaComandos();
            this.Mostrado = false;

            if (Owner.Owner.Contains(this))
            {
                Owner.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
            }
        }


        private void InicializaColumnas()
        {
            GridTextBoxDropDownEditControl LISTA_SUCURSAL_IDColumn = this.superGridControl1.PrimaryGrid.Columns["LISTA_SUCURSAL_IDColumn"].EditControl as GridTextBoxDropDownEditControl;
            LISTA_SUCURSAL_IDColumn.ButtonCustom.Image = global::SIF.Properties.Resources.TableofContents16;
            LISTA_SUCURSAL_IDColumn.ButtonCustom.Visible = true;
            LISTA_SUCURSAL_IDColumn.ButtonCustomClick += LISTA_SUCURSAL_IDColumn_ButtonCustom_CLICK;

            GridDateTimeInputEditControl FECHA_BAJAColumn = this.superGridControl1.PrimaryGrid.Columns["FECHA_BAJAColumn"].EditControl as GridDateTimeInputEditControl;
            FECHA_BAJAColumn.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            FECHA_BAJAColumn.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;

            GridDateTimeInputEditControl FECHA_ALTAColumn = this.superGridControl1.PrimaryGrid.Columns["FECHA_ALTAColumn"].EditControl as GridDateTimeInputEditControl;
            FECHA_ALTAColumn.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            FECHA_ALTAColumn.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;

        }

        private void LISTA_SUCURSAL_IDColumn_ButtonCustom_CLICK(object sender, EventArgs e)
        {
            GridTextBoxDropDownEditControl ddc =
                sender as GridTextBoxDropDownEditControl;

            if (ddc != null)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow row = ((DataRowView)ddc.EditorCell.GridRow.DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow;

                SIFModelo.Articulo articulo = new SIFModelo.Articulo();
               // articulo.ARTICULO_ID = row.ARTICULO_ID;
                 articulo.LISTA_SUCURSAL_VTA = row.LISTA_SUCURSAL_ID;
                View.Catalogos.ListaSucursalVentaForm frmVenta = new Catalogos.ListaSucursalVentaForm(articulo);
                if (frmVenta.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                ddc.Text = frmVenta.ListaSucursales;
                row.LISTA_SUCURSAL_ID = frmVenta.ListaSucursales;
                ModificaOferta(row);
            }
        }

        public void ActivaComandos()
        {
            agregaProductoButtonItem.Shortcuts.Add(eShortcut.F3);
            aplicarButtonItem.Shortcuts.Add(eShortcut.F5);
            NuevoButtonItem.Shortcuts.Add(eShortcut.F2);
            cancelarButtonItem.Shortcuts.Add(eShortcut.F8);
        }

        public void DesactivaComandos()
        {
            agregaProductoButtonItem.Shortcuts.Clear();
            aplicarButtonItem.Shortcuts.Clear();
            cancelarButtonItem.Shortcuts.Clear();
            NuevoButtonItem.Shortcuts.Clear();
        }

        #endregion

        private SIFModelo.OrdenCompra.OrdenesCompraDataSet ocDS = new SIFModelo.OrdenCompra.OrdenesCompraDataSet();
        private SIFNegocio.OrdenCompra.ManejoDescuentos descuentosL = new SIFNegocio.OrdenCompra.ManejoDescuentos();
        #region Funciones Y Metodos


        private void Buscar()
        {
            this.ocDS = descuentosL.Buscar(nombreTextBoxX.Text, dateTimeInput1.Value, dateTimeInput2.Value);
            this.superGridControl1.PrimaryGrid.DataSource = ocDS;
            this.superGridControl1.PrimaryGrid.DataMember = "LISTA_OFERTAS_VENTA";
        }

        View.Catalogos.ArticuloUserControl frmArticulo;
        private void AgregaArticulo()
        {
            if (frmArticulo == null)
            {
                frmArticulo = new View.Catalogos.ArticuloUserControl();
                frmArticulo.Dock = DockStyle.Fill;
                frmArticulo.Owner = this;

            }
            frmArticulo.Muestra();
        }

        private void NuevaOferta()
        {
            View.OrdenCompra.NuevoListaOfertaForm frmOferta = new NuevoListaOfertaForm();
            if (frmOferta.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow lista = ocDS.LISTA_OFERTAS_VENTA.NewLISTA_OFERTAS_VENTARow();
            lista.NOMBRE = frmOferta.Nombre;
            lista.LISTA_SUCURSAL_ID = frmOferta.ListaSucursal;
            lista.FECHA_ALTA = frmOferta.FechaAlta;
            lista.FECHA_BAJA = frmOferta.FechaBaja;
            lista.FECHA_GENERADA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            lista.ACTIVO = "S";
            lista.TOTAL = 0;

            if (this.descuentosL.Nuevo(lista, tomaArchivo))
            {
                MessageBox.Show("Se creo la Campaña!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Buscar();
            //this.ModificaOferta(lista);
        }

        private void AgregaOferta()
        {

            if(this.superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Seleccione la oferta para editar");
                return;
            }


            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow row = (SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow)((DataRowView) ((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row;
           // ManejoDescuentosDetalleUserControl frmDetalle = new ManejoDescuentosDetalleUserControl(row);
            ManejoDescuentosDetalleUserControlV2 frmDetalle = new ManejoDescuentosDetalleUserControlV2(row);
            frmDetalle.Owner = this;
            frmDetalle.Muestra();
        }


       

        private void ModificaOferta(SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow lista = null)
        {
            if (lista == null)
            {
                if (this.superGridControl1.PrimaryGrid.ActiveRow == null)
                {
                   MessageBox.Show("Elija una oferta para mostrar los artículos asociados");
                    return;
                }
                else
                { 
                 lista = (SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow) ((DataRowView) ((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row;
                }
            }


           // SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow oferta = null;
            //oferta = this.superGridControl1.PrimaryGrid.ActiveRow;

            ManejoDescuentosDetalleUserControl frmDetalle = new ManejoDescuentosDetalleUserControl(lista);
            frmDetalle.Owner = this;
            frmDetalle.Muestra();
        }


        private void Aplicar()
        {

            if (superGridControl1.PrimaryGrid.ActiveRow == null)
            {
               MessageBox.Show("Debe seleccinar la oferta que desea aplicar");
                return;
            }

            SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow lista = (SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow)((DataRowView)((GridRow)superGridControl1.PrimaryGrid.ActiveRow).DataItem).Row;


            if (lista.ACTIVO == "N")
            {
               MessageBox.Show("La oferta seleccionada esta cancelada", "Aplicar",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBoxEx.Show("¿Aplicar la lista de ofertas " + lista.NOMBRE  + "?", "Aplicar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;

            }

            lista.ACTIVO = "A";

            descuentosL.Modificar(lista);
            //foreach (var oferta in this.ocDS.LISTA_OFERTAS_VENTA)
            //{
            //    if (oferta.ACTIVO == "A")
            //    {
            //        oferta.ACTIVO = "S";
                    
            //    }
            //}
           MessageBox.Show("¡La oferta ha sido aplicada!");
            this.Buscar();
        }

        private void Cancelar()
        {
            if (this.superGridControl1.GetSelectedRows().Count == 0)
            {
               MessageBox.Show("Seleccione al menos una oferta");
                return;
            }

            if (MessageBoxEx.Show("¿Cancelar las ofertas seleccionadas?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            foreach (var row in this.superGridControl1.PrimaryGrid.SelectedRows)
            {
                SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow oferta = ((DataRowView)((GridRow) row).DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow;
                oferta.ACTIVO = "N";
                descuentosL.Modificar(oferta);
            }

           MessageBox.Show("Las ofertas seleccionadas han sido canceladas");
            this.Buscar();
        }

        #endregion

        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        private void ManejoDescuentosUserControl_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = new System.DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, 1, 0, 0, 1);
            this.dateTimeInput2.Value = new System.DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, DateTime.DaysInMonth(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year,  SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month) , 23, 59, 59);
            this.nombreTextBoxX.Focus();
            this.Buscar();
        }

        private void agregaProductoButtonItem_Click(object sender, EventArgs e)
        {
            this.AgregaOferta();
        }

        private void aplicarButtonItem_Click(object sender, EventArgs e)
        {
            this.Aplicar();
        }
        private void importarLayoutButtonItem_Click(object sender, EventArgs e)
        {
            this.importarLayout();
        }
        
        private void cancelarButtonItem_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void articuloTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Buscar();
            }
        }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

        private void NuevoButtonItem_Click(object sender, EventArgs e)
        {
            this.NuevaOferta();
        }

        private void dateTimeInput2_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void superGridControl1_EndEdit(object sender, GridEditEventArgs e)
        {
             SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow row = ((DataRowView)e.GridCell.GridRow.DataItem).Row as SIFModelo.OrdenCompra.OrdenesCompraDataSet.LISTA_OFERTAS_VENTARow;

             this.descuentosL.Modificar(row);
        }

        private void superGridControl1_DoubleClick(object sender, EventArgs e)
        {
            this.AgregaOferta();
        }

        private void importarLayout() 
        {
            
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.CSV)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                System.Data.DataTable dtPromocines = new System.Data.DataTable();
                dtPromocines.Columns.Add("codigo", typeof(string));
                dtPromocines.Columns.Add("oferta", typeof(Int16));
                dtPromocines.Columns.Add("precio_de_venta", typeof(Decimal));
                dtPromocines.Columns.Add("cantidad_req", typeof(Int16));
                dtPromocines.Columns.Add("cantidad_beneficio", typeof(Int16));
                dtPromocines.Columns.Add("fecha_inicio", typeof(string));
                dtPromocines.Columns.Add("fecha_fin", typeof(string));
                dtPromocines.Columns.Add("aplica_sucursales", typeof(string));
                dtPromocines.Columns.Add("tipo_promocion", typeof(string));

                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^0-9]");
                Regex objNotNumPatternDecimal = new Regex(@"[^0-9].[^0-9]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {
                    DateTime fechaservidor = SIFNegocio.Configuracion.Configuraciones.fechaServidor();

                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    List<String> listaInexTemp = new List<string>();
                    List<String> listaInexReplazo = new List<string>();//contien los codigos de remplazo
                    bool cantidadValida = true;
                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x != 9)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido" + Environment.NewLine + "Sugerencia el numero de colmnas son mayor o menor a las solicitadas ");
                            break;
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            cantidadValida = false;
                            MessageBox.Show("La oferta " + str.Split(',')[1].ToString() + " no es valida");
                            break;
                        }

                        //if (objNotNumPatternDecimal.IsMatch(str.Split(',')[2]))
                        //{
                        //    cantidadValida = false;
                        //    MessageBox.Show("La oferta " + str.Split(',')[1].ToString() + " no es valida");
                        //    break;
                        //}

                        if (!str.Split(',')[5].IsDatetime())
                        {
                            cantidadValida = false;
                            MessageBox.Show("La fecha de inicio " + str.Split(',')[5].ToString() + " no es valido");
                            break;
                        }
                        DateTime fechaInicio = Convert.ToDateTime(str.Split(',')[5]);

                        if (!str.Split(',')[6].IsDatetime())
                        {
                            cantidadValida = false;
                            MessageBox.Show("La fecha fin " + str.Split(',')[6].ToString() + " no es valida");
                            break;
                        }
                        DateTime fechaFin = Convert.ToDateTime(str.Split(',')[6]);
                        TimeSpan difFechas = fechaFin - fechaInicio;
                        int result = DateTime.Compare(fechaFin , fechaInicio);
                        if (result < 0) {
                            cantidadValida = false;
                            MessageBox.Show("La fecha fin " + str.Split(',')[6].ToString() + " debe de ser mayor a la fecha inicio");
                            break;
                        }
                        difFechas =   fechaservidor- fechaInicio;
                        TimeSpan difFechas2 = fechaInicio-fechaservidor;
                         result = DateTime.Compare( fechaInicio, fechaservidor);
#if !DEBUG
                        if (result<0)
                        {
                            cantidadValida = false;
                            MessageBox.Show("La fecha inicio " + str.Split(',')[5].ToString() + " debe de ser mayor a la fecha del dia de hoy");
                            break;
                        }
#endif

                        string codigo = str.Split(',')[0];
                        SIFModelo.Articulo Exs = art.BuscarPorClaveActivo(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(str);
                            
                        }
                        else
                        {
                            dtPromocines.Rows.Add(
                                            str.Split(',')[0],                                             
                                             str.Split(',')[1],
                                             str.Split(',')[2],
                                             str.Split(',')[3],
                                             str.Split(',')[4],
                                             str.Split(',')[5],
                                             str.Split(',')[6],
                                             str.Split(',')[7],
                                             str.Split(',')[8]
                                             );
                            Regs++;

                        }

                    }
                    if ((!FmtValid) || !cantidadValida)
                    {
                        return;
                    }

                    Int16 ArticulosInex2 = 0;

                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        Int16 cnt = 0;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                            cnt ++;
                            if (cnt > 20)
                                break;
                            
                        }

                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "Favor de validar el codigo correcto!", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        FmtValid = true;
                    }

                    // Lee archivo

                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                     

                        DataRow[] results = dtPromocines.Select(null, "codigo");



                        String[] a_codigo = new String[results.Length];
                        Int16[] a_oferta = new Int16[results.Length];
                        Decimal[] a_precio_de_venta = new Decimal[results.Length];
                        Int16[] a_cantidad_req = new Int16[results.Length];
                        Int16[] a_cantidad_beneficio = new Int16[results.Length];
                        String[] a_fecha_inicio = new String[results.Length];
                        String[] a_fecha_fin = new String[results.Length];
                        String[] a_aplica_sucursales = new String[results.Length];
                        String[] a_tipo_promocion = new String[results.Length];

                        Int16[] a_partida = new Int16[results.Length];

                        int ind = 0;

                        foreach (DataRow rows in dtPromocines.Rows)
                        {
                            a_codigo[ind] = rows["codigo"].ToString().Trim();
                            a_partida[ind] = Convert.ToInt16(ind +1);
                            a_oferta[ind] = Convert.ToInt16(rows["oferta"].ToString().Trim());
                            a_precio_de_venta[ind] = Convert.ToDecimal(rows["precio_de_venta"].ToString().Trim());
                            a_cantidad_req[ind] = Convert.ToInt16(rows["cantidad_req"].ToString().Trim());
                            a_cantidad_beneficio[ind] = Convert.ToInt16(rows["cantidad_beneficio"].ToString().Trim());
                            a_fecha_inicio[ind] = rows["fecha_inicio"].ToString().Trim();
                            a_fecha_fin[ind] = rows["fecha_fin"].ToString().Trim();
                            a_aplica_sucursales[ind] = rows["aplica_sucursales"].ToString().Trim();
                            a_tipo_promocion[ind] = rows["tipo_promocion"].ToString().Trim();
                            ind++;
                        }
                        //   this.enviarArchivoPorCorreo(FPath);
                        SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();


                        
                        string resul = new SIFNegocio.OrdenCompra.ManejoDescuentos().InsertaPromocionesLayout(
                                FName,
                                "N",
                                  Convert.ToInt16(Helpers.Sesion.Usuario.UsuariosID.ToString()),
                                    a_codigo,
                                    a_partida,
                                    a_oferta,
                                    a_precio_de_venta,
                                    a_cantidad_req,
                                    a_cantidad_beneficio,
                                    a_fecha_inicio,
                                    a_fecha_fin,
                                    a_aplica_sucursales,
                                    a_tipo_promocion

                            );
                       

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
    }
}
