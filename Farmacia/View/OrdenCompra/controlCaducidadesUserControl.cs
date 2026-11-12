using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace SIF.View.OrdenCompra
    {
    public partial class controlCaducidadesUserControl : Templates.CatalogoUserControl
    {

        public OrdenesCompraUserControl Owner;
        public bool Mostrado;
        SIFNegocio.caducidades NegocioCaucidades = new SIFNegocio.caducidades();
        //BindingListView<SIFModelo.Inventarios.SkuCaducidad> ListCaducidades = new BindingListView<SIFModelo.Inventarios.SkuCaducidad>();
        private SIFModelo.Usuario usuario = new SIFModelo.Usuario();
        String FolioCompra = string.Empty;
        DataTable ListArticulosRecepcion = new DataTable();
        DataTable ListArticulosRecepcioCaptura = new DataTable();
        DataGridViewCell celdaEditada;


        public controlCaducidadesUserControl(SIFModelo.Usuario user, string folioOrdencompra)
        {

            usuario = user;
            FolioCompra = folioOrdencompra;
            InitializeComponent();
            inicializaColoresFilas();
            buscar();




        }

        private void buscar() {

            ///<summary> itacma 
            /// + Uyilizo 2 data tables 1 para el origen de datos y 2 para la capruta de datos ya que la cantidad por lote puede variar
            /// </summary>

            //Recibo las caducidades Capturadas
            DataTable dt = new SIFNegocio.caducidades().sp_GetDataRcc(FolioCompra);

            //Recibo los productos con caducidad Recibida en la Orden de compra
            ListArticulosRecepcion = new SIFNegocio.caducidades().sp_GetDataRc(FolioCompra);


            ListArticulosRecepcioCaptura = dt;



            if (dt.Rows.Count > 0)
            {

                ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "NO_LOTE", "CADUCIDAD");
                ListArticulosRecepcion.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX2.DataSource = ListArticulosRecepcion.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD");
                FolioCompra = ListArticulosRecepcioCaptura.Rows[0].ItemArray[0].ToString();


            }



        }

        List<Int32> L_partida = new List<Int32>();
        List<string> L_articulo_id = new List<string>();
        List<string> L_Lote_Interno = new List<string>();
        List<Int32> L_cant_lote = new List<Int32>();
        List<string> L_lote = new List<string>();
        List<string> L_loteProdcesado = new List<string>();
        List<string> L_caducidad = new List<string>();



        private bool Validar(DataTable dt) {
            int partida = 0;
            L_partida = new List<Int32>();
            L_articulo_id = new List<string>();
            L_Lote_Interno = new List<string>();
            L_cant_lote = new List<Int32>();
            L_lote = new List<string>();
            L_loteProdcesado = new List<string>();
            L_caducidad = new List<string>();


            foreach (DataRow _d in ListArticulosRecepcion.Rows)
            {
                string jh = _d["CADUCIDAD"].ToString();


                Int32 total = 0;


                //Recorremos el grid de articulos Capturados para identificar la cantidad total capturada
                foreach (DataRow _drcapturados in dt.Rows)
                {
                    string acaducidad = _drcapturados["ARTICULO_ID"].ToString();
                    string pcaducidad = _drcapturados["CADUCIDAD"].ToString();
                    string plote = _drcapturados["NO_LOTE"].ToString();

                    if (_d["ARTICULO_ID"].ToString() == _drcapturados["ARTICULO_ID"].ToString())
                    {
                        if (!fechaCaducidadValida(_drcapturados["CADUCIDAD"].ToString(), _drcapturados["NO_LOTE"].ToString()))
                        {

                            pintar(_drcapturados["ARTICULO_ID"].ToString(), faltanteRowStyle);
                           MessageBox.Show("Valide que la fecha de caducidad sean correctas(Puede dejar vacias las celdas para guardar sin caducidad)"
                                , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (!String.IsNullOrEmpty(_drcapturados["NO_LOTE"].ToString()) && !String.IsNullOrEmpty(_drcapturados["CADUCIDAD"].ToString()))
                        {
                            partida++;
                            L_partida.Add(partida);
                            L_articulo_id.Add(_drcapturados["ARTICULO_ID"].ToString());
                            L_Lote_Interno.Add(FolioCompra + "-" + partida.ToString().PadLeft(6, '0'));
                            L_lote.Add(_drcapturados["NO_LOTE"].ToString());
                            L_caducidad.Add(_drcapturados["CADUCIDAD"].ToString());
                            L_loteProdcesado.Add("N");
                            L_cant_lote.Add(int.Parse(_drcapturados["CANTIDAD"].ToString()));
                            total += Int32.Parse(_drcapturados["CANTIDAD"].ToString());

                        }

                        if (String.IsNullOrEmpty(_drcapturados["NO_LOTE"].ToString()) && String.IsNullOrEmpty(_drcapturados["CADUCIDAD"].ToString()))
                        {
                            total += Int32.Parse(_drcapturados["CANTIDAD"].ToString());
                        }






                    }
                }


                if (int.Parse(_d["CANTIDAD"].ToString()) > total && total > 0)
                {

                    pintar(_d["ARTICULO_ID"].ToString(), faltanteRowStyle);
                   MessageBox.Show("El total de piezas capturadas es menor a la las piezas recibidas" +
                        " "
                        , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (int.Parse(_d["CANTIDAD"].ToString()) < total && total > 0)
                {

                    pintar(_d["ARTICULO_ID"].ToString(), faltanteRowStyle);
                   MessageBox.Show("El total de piezas capturadas es mayor a la las piezas recibidas "
                        , "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
            if (L_partida.Count <= 0) {
               MessageBox.Show("Sin registros a procesar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }

        private bool fechaCaducidadValida(string _f, string _lote) {
            try
            {
                if (_f.Length == 0 && _lote.Length == 0)
                {
                    return true;
                }
                if (_f.Length >= 0 && _lote.Length == 0)
                {
                    return false;
                }
                DateTime fechaservidor = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                DateTime FechaCaducidad = DateTime.ParseExact("01" + _f, "ddMMyy", CultureInfo.InvariantCulture);
                int dif = ((FechaCaducidad.Year - fechaservidor.Year) * 12) + FechaCaducidad.Month - fechaservidor.Month;
                if (dif > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception _x)

            {
                return false;

            }


        }
        private void guardar()
        {
            ListArticulosRecepcioCaptura = (DataTable)(dataGridViewX1.DataSource);

            if (!Validar(ListArticulosRecepcioCaptura))
                return;

            SIFNegocio.caducidades negocio = new SIFNegocio.caducidades();
            string RespuestaInsertaMsg = "";
            decimal inserta = negocio.sp_GuardadCaducidadesCapturadas(FolioCompra, Helpers.Sesion.Usuario.UsuariosID.ToString(),
                    L_partida,
                    L_articulo_id,
                    L_Lote_Interno,
                    L_cant_lote,
                    L_lote,
                    L_loteProdcesado,
                    L_caducidad
                , out RespuestaInsertaMsg);
            if (inserta <= 0)
            {

               MessageBox.Show(RespuestaInsertaMsg, "Guardar ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;

            }
            else {
                foreach (string artic in L_articulo_id) {
                    pintar(artic, GuardadosRowStyle);
                }

            }


        }
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            this.guardar();
        }


        private void CerrarbuttonItem_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        private void Cerrar()
        {

            String respuesta = SIFNegocio.OrdenCompra.Compras.spCierraCaducidades(FolioCompra);
           MessageBox.Show(respuesta.ToString());
            this.Back();

        }

        private void RestaurarbuttonItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==MessageBox.Show("Se Restablecera la captura de caducidades " + Environment.NewLine + "Desea continuar?", "Restaurar caducidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                ListArticulosRecepcioCaptura = ListArticulosRecepcion;
                ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";

                dataGridViewX1.DataSource = ListArticulosRecepcioCaptura.DefaultView.ToTable(false, "ARTICULO_ID", "NOMBRE", "CANTIDAD", "NO_LOTE", "CADUCIDAD");

            }
        }


        public void Muestra()
        {

            if (this.Owner is OrdenesCompraUserControl)
            {
                if (this.Owner is OrdenesCompraUserControl)
                {
                    this.ActivaComandos();
                    this.Dock = DockStyle.Fill;
                    SIF.View.Menu.ComprasMenu parent = (SIF.View.Menu.ComprasMenu)(Owner.Owner);
                    parent.Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    this.Mostrado = true;
                }
            }
        }
        public void ActivaComandos()
        {
            backButton.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F12);
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }



        private void Back()
        {
            try
            {


                Owner.DesactivaComandos();


                SIF.View.Menu.ComprasMenu parent = (SIF.View.Menu.ComprasMenu)(Owner.Owner);
                parent.Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);

                this.Mostrado = true;
                Owner.Buscar();


            }
            catch (Exception e)
            {

            }
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            celdaEditada = dataGridViewX1.CurrentRow.Cells[e.ColumnIndex];

            ListArticulosRecepcioCaptura = (DataTable)(dataGridViewX1.DataSource);

            object objSum = ListArticulosRecepcion.Compute("Sum(CANTIDAD)", "ARTICULO_ID = '" + dataGridViewX1.CurrentRow.Cells[0].Value + "'");

            if (celdaEditada.ColumnIndex == 2)
            {
                try
                {
                    int newCantidadRow = 0;
                    var valor = celdaEditada.Value;


                    if (!valor.ToString().IsIntegerPositive())
                    {
                       MessageBox.Show("El valor debe ser numérico");
                        celdaEditada.Value = 0;
                        return;
                    }
                    if (int.Parse(valor.ToString()) == 0)
                    {
                       MessageBox.Show("El valor debe ser mayor a cero");
                        celdaEditada.Value = 1;
                        return;
                    }


                    //CALCULAR EL TOTAL
                    var datagridRow = dataGridViewX1.Rows[e.RowIndex].DataBoundItem;

                    if (!(datagridRow is DataRowView))
                    {
                        return;
                    }

                    DataRow dgRow = ((DataRowView)((dataGridViewX1.Rows[e.RowIndex].DataBoundItem))).Row;
                    decimal cantiad = decimal.Parse(dgRow["cantidad"].ToString());



                    int totalEnCaptura = 0;
                    foreach (DataRow _dr in ListArticulosRecepcioCaptura.Rows)
                    {


                        if (_dr["ARTICULO_ID"].ToString() == dataGridViewX1.CurrentRow.Cells[0].Value.ToString())
                        {
                            totalEnCaptura += int.Parse(_dr["CANTIDAD"].ToString());
                        }
                    }
                    newCantidadRow = Convert.ToInt32(objSum.ToString())
                         - totalEnCaptura;


                    if (newCantidadRow > 0)
                    {

                        DataRow nEWrOW = ListArticulosRecepcioCaptura.NewRow();

                        nEWrOW["ARTICULO_ID"] = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                        nEWrOW["NOMBRE"] = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                        nEWrOW["CANTIDAD"] = newCantidadRow;
                        nEWrOW["NO_LOTE"] = "";
                        nEWrOW["CADUCIDAD"] = "";

                        ListArticulosRecepcioCaptura.Rows.Add(nEWrOW);

                        ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";
                        dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;
                        pintar();
                    }



                }
                catch (Exception _EX)
                {

                   MessageBox.Show(_EX.ToString());
                }
            }


        }




        private void pintar(string p_articulo_id = "", DataGridViewCellStyle _style = null)
        {
            if (String.IsNullOrEmpty(p_articulo_id))
            {
                foreach (DataGridViewRow grow in dataGridViewX1.Rows)
                {
                    //PintaFila(grow);
                    if (grow.Index % 2 == 0)
                    {
                        grow.DefaultCellStyle = normalRowStyle;
                        grow.DefaultCellStyle.ApplyStyle(normalRowStyle);
                    }
                    else
                    {

                        grow.DefaultCellStyle = revisarRowStyle;
                        grow.DefaultCellStyle.ApplyStyle(revisarRowStyle);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow grow in dataGridViewX1.Rows)
                {
                    //PintaFila(grow);
                    if (grow.Cells["ARTICULOIDComlumn"].Value.ToString() == p_articulo_id)
                    {
                        grow.DefaultCellStyle = _style;
                        grow.DefaultCellStyle.ApplyStyle(_style);
                    }
                }

            }
        }


        private void inicializaColoresFilas()
        {
            revisarRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            revisarRowStyle.BackColor = Color.FromArgb(218, 247, 166);
            //revisarRowStyle.BackColor.Color2 = Color.FromArgb(255, 35, 35);

            WarningCellStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            WarningCellStyle.BackColor = Color.FromArgb(253, 215, 0);
            //WarningCellStyle.BackColor.Color2 = Color.FromArgb(253, 215, 0);

            GuardadosRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            GuardadosRowStyle.BackColor = Color.FromArgb(115, 240, 109);
            //margenRowStyle.BackColor.Color2 = Color.FromArgb(200, 100, 100);

            faltanteRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            faltanteRowStyle.BackColor = Color.FromArgb(255, 87, 51);
            //faltanteRowStyle.Background.Color2 = Color.FromArgb(0, 176, 80);

            normalRowStyle = new DataGridViewCellStyle(this.dataGridViewX1.DefaultCellStyle);
            normalRowStyle = this.dataGridViewX1.DefaultCellStyle;
        }

        DataGridViewCellStyle revisarRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle GuardadosRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle faltanteRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle normalRowStyle = new DataGridViewCellStyle();
        DataGridViewCellStyle WarningCellStyle = new DataGridViewCellStyle();

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewRow grow = ((DataGridViewX)sender).CurrentRow as DataGridViewRow;

            if (grow == null)
            {
                return;
            }
            var datagridRow = grow.DataBoundItem;

            if (!(datagridRow is DataRowView))
            {
                return;
            }

            //PintaFila(grow);
            if (grow.Index % 2 == 0)
            {
                grow.DefaultCellStyle = normalRowStyle;
                grow.DefaultCellStyle.ApplyStyle(normalRowStyle);
            }
            else
            {

                grow.DefaultCellStyle = revisarRowStyle;
                grow.DefaultCellStyle.ApplyStyle(revisarRowStyle);
            }
        }

        private void controlCaducidadesUserControl_Load(object sender, EventArgs e)
        {
            pintar();
            folioCompralabelDto.Text = FolioCompra;
        }

        private void importarButtonItem_Click(object sender, EventArgs e)
        {
            this.importaCaducidadesHUP();
        }

        
        private void importarButtonItemCDIS_Click(object sender, EventArgs e)
        {
            this.importaCaducidadesCDis();
        }

        private void importaCaducidadesHUP(){
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.CSV)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                System.Data.DataTable dtPedido = new System.Data.DataTable();
                dtPedido.Columns.Add("codigo", typeof(string));         //Corresponde al codigo del Articulo
                //dtPedido.Columns.Add("nombre1", typeof(string));      //Corresponde al nmombre del Producto                
                dtPedido.Columns.Add("cantidad", typeof(Int32));        //cantidad pedida de Eoq
                dtPedido.Columns.Add("lote", typeof(String));           //cantidad pedida de Eoq
                dtPedido.Columns.Add("caducidad", typeof(string));      //cantidad pedida de Eoq

                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^0-9]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {

                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    List<String> listaInexTemp = new List<string>();
                    List<String> listaInexReplazo = new List<string>();//contien los codigos de remplazo
                    bool cantidadValida = true;

                    //  ListArticulosRecepcioCaptura.Rows.Remove(DR);
                    ListArticulosRecepcioCaptura.Clear();



                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x !=4)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido" + Environment.NewLine + "Sugerencia el numero de colmnas son mayor o menor a las solicitadas ");
                            break;
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad " + str.Split(',')[1].ToString() + " no es valido");
                            break;
                        }
                        if (Convert.ToUInt32(str.Split(',')[1].ToString()) <= 0)
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad Eoq " + str.Split(',')[1].ToString() + " Debe de ser mayor a Cero");
                            break;
                        }

                        string codigo = "HUP"+str.Split(',')[0];
                        SIFModelo.Articulo Exs = art.BuscarPorClaveActivo(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(str);
                            //FmtValid = false;
                        }
                        else
                        {
                            /*dtPedido.Rows.Add(str.Split(',')[0],
                                             //  str.Split(',')[1],
                                             str.Split(',')[1],
                                             str.Split(',')[2]
                                             );
                            */
                            DataRow nEWrOW = ListArticulosRecepcioCaptura.NewRow();

                            nEWrOW["ARTICULO_ID"] = codigo;//str.Split(',')[0];
                            nEWrOW["NOMBRE"] = Exs.NOMBRE1;
                            nEWrOW["CANTIDAD"] = str.Split(',')[1];
                            nEWrOW["NO_LOTE"] = str.Split(',')[2];
                            nEWrOW["CADUCIDAD"] = str.Split(',')[3];

                            ListArticulosRecepcioCaptura.Rows.Add(nEWrOW);

                            ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";
                            dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;

                            Regs++;

                        }

                    }
                    if ((!FmtValid) || !cantidadValida)
                    {
                        return;
                    }

                    Int16 ArticulosInex2 = 0;//guardara los articulos inexistentes despues del autocomplatado
                   

                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                            if (this.limitaForeach(false, true) > 20)
                            {
                                msg += "..................." + Environment.NewLine;
                                this.limitaForeach(true, false);
                                break;
                            }


                        }

                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "Favor de validar el codigo correcto!", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        FmtValid = true;
                    }

                    // Lee archivo

                    /*if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                      

                        DataRow[] results = dtPedido.Select(null, "codigo");



                        String[] Clave = new String[results.Length];
                        
                        Int32[] Cantidad = new Int32[results.Length];
                        String[] Caducidad = new String[results.Length];

                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            Clave[ind] = rows["codigo"].ToString().Trim();                            
                            Cantidad[ind] = int.Parse(rows["cantidad"].ToString().Trim());
                            Caducidad[ind] = rows["caducidad"].ToString().Trim();
                            ind++;
                        }
                        
                        SIFNegocio.Inventario.EOQ snieoq = new SIFNegocio.Inventario.EOQ();


                        //string resul = snieoq.insertaEoqImpFile(Clave, Cantidad);
                        //MessageBox.Show(resul, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    */
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

        private void importaCaducidadesCDis()
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
                System.Data.DataTable dtPedido = new System.Data.DataTable();
                dtPedido.Columns.Add("codigo", typeof(string));         //Corresponde al codigo del Articulo
                //dtPedido.Columns.Add("nombre1", typeof(string));      //Corresponde al nmombre del Producto                
                dtPedido.Columns.Add("cantidad", typeof(Int32));        //cantidad pedida de Eoq
                dtPedido.Columns.Add("lote", typeof(String));           //cantidad pedida de Eoq
                dtPedido.Columns.Add("caducidad", typeof(string));      //cantidad pedida de Eoq

                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                Regex objNotNumPattern = new Regex(@"[^0-9]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {

                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    List<String> listaInexTemp = new List<string>();
                    List<String> listaInexReplazo = new List<string>();//contien los codigos de remplazo
                    bool cantidadValida = true;

                    //  ListArticulosRecepcioCaptura.Rows.Remove(DR);
                    ListArticulosRecepcioCaptura.Clear();



                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x != 4)
                        {
                            FmtValid = false;
                            MessageBox.Show("El formato de Archivo " + FName + " es Invalido" + Environment.NewLine + "Sugerencia el numero de colmnas son mayor o menor a las solicitadas ");
                            break;
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad " + str.Split(',')[1].ToString() + " no es valido");
                            break;
                        }
                        if (Convert.ToUInt32(str.Split(',')[1].ToString()) <= 0)
                        {
                            cantidadValida = false;
                            MessageBox.Show("La cantidad Eoq " + str.Split(',')[1].ToString() + " Debe de ser mayor a Cero");
                            break;
                        }

                        string codigo =  str.Split(',')[0];
                        SIFModelo.Articulo Exs = art.BuscarPorClaveActivo(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(str);
                            //FmtValid = false;
                        }
                        else
                        {
                          
                            DataRow nEWrOW = ListArticulosRecepcioCaptura.NewRow();

                            nEWrOW["ARTICULO_ID"] = codigo;//str.Split(',')[0];
                            nEWrOW["NOMBRE"] = Exs.NOMBRE1;
                            nEWrOW["CANTIDAD"] = str.Split(',')[1];
                            nEWrOW["NO_LOTE"] = str.Split(',')[2];
                            nEWrOW["CADUCIDAD"] = str.Split(',')[3];

                            ListArticulosRecepcioCaptura.Rows.Add(nEWrOW);

                            ListArticulosRecepcioCaptura.DefaultView.Sort = " NOMBRE ASC";
                            dataGridViewX1.DataSource = ListArticulosRecepcioCaptura;

                            Regs++;

                        }

                    }
                    if ((!FmtValid) || !cantidadValida)
                    {
                        return;
                    }

                    Int16 ArticulosInex2 = 0;//guardara los articulos inexistentes despues del autocomplatado


                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                            if (this.limitaForeach(false, true) > 20)
                            {
                                msg += "..................." + Environment.NewLine;
                                this.limitaForeach(true, false);
                                break;
                            }


                        }

                        MessageBox.Show(msg + Environment.NewLine + Environment.NewLine + "Favor de validar el codigo correcto!", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        FmtValid = true;
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


        Int16 conteoForEach = 0;
        private Int16 limitaForeach(bool inicia, bool responde)
        {
            /// por cada consumo en la sintaxis this.limitaForeach(false, true)  realiza un incremento a su valor de retorno
            // la sintaxis del consumo del metodo this.limitaForeach(true, false) su valor de retorno sera cero (0)
            if (inicia)
            {
                conteoForEach = 0;
                return 0;
            }
            if (responde)
            {
                conteoForEach++;
                return conteoForEach;
            }
            return -1;
        }


    }
}
