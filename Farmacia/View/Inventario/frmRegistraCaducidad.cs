using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Inventario
{
    public partial class frmRegistraCaducidad : DevComponents.DotNetBar.Metro.MetroForm
    {
        #region declaracion de Variables globales para el formulario
        SIFModelo.modeloCaducidades articuloLote = new SIFModelo.modeloCaducidades();
        SIFNegocio.caducidades snc = new SIFNegocio.caducidades();
        DataTable dt1 = new DataTable();
        string tipo_mov = string.Empty;
        #endregion

        public frmRegistraCaducidad(SIFModelo.modeloCaducidades art, string tipo_movimiento)
        {
            InitializeComponent();
            this.cargaMetodosPorMovimiento(art, tipo_movimiento);
        }
        private void cargaMetodosPorMovimiento(SIFModelo.modeloCaducidades _art, string tm) {
            ///<summary>
            ///carga los metodos iniciales  cuando el formulario es invocado por la entrada por compra
            /// </summary>
            tipo_mov = tm;
            switch (tm)
            {
                case "11":
                    articuloLote = _art;// asigna los datos del articulo al formulario
                    cargacontroles();   //carga los controles principales[label y columnas datagrid ]
                    cargaDatos();       //Carga los datos de control_caducidades del producto
                    break;
            }

        }
        private void cargacontroles() {
            label1.Text = articuloLote.ARTICULO_ID;
            label3.Text = "Referencia: " + articuloLote.referencia;
            label4.Text = "Cant. Recibir: " + articuloLote.cantRecibida;
            textBox1.Focus();
            dt1.Columns.Add("LOTE", typeof(string));
            dt1.Columns.Add("CADUCIDAD", typeof(string));
            dt1.Columns.Add("CANTIDAD", typeof(Decimal));


        }
        private void cargaDatos() {
            dt1 = snc.sp_Get_Art_cadPorFolio(articuloLote.referencia, articuloLote.ARTICULO_ID);

            if (dt1.Rows.Count > 0)
            {
                ///DataRow row = dt1.Rows[0];

                dataGridView1.DataSource = dt1.DefaultView.ToTable(false, "LOTE", "CADUCIDAD", "CANTIDAD");
            }
            else {
                if (dt1 != null)
                    dataGridView1.DataSource = dt1;
            }
            refrescaGrid();

        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                seleccionaObjeto(1);

        }
        private void NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                seleccionaObjeto(2);
        }
        private void NumericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                seleccionaObjeto(3);
        }
        private void NumericUpDown3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.agregarCaducidad();
        }
        private void despliegaMensage(string msj) { MessageBox.Show(msj, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void agregarCaducidad() {

            if (!this.valida()) ////validamos que los campos ingresados sean validos
                return;
            DataRow drow = dt1.NewRow();
            drow["lote"] = textBox1.Text.ToString();
            drow["caducidad"] = Convert.ToDateTime("01/" + numericUpDown1.Value.ToString().PadLeft(2, '0') + "/" + numericUpDown2.Value.ToString());
            drow["cantidad"] = numericUpDown3.Value.ToString();
            dt1.Rows.Add(drow);
            dataGridView1.DataSource = dt1;
            seleccionaObjeto(0);
            this.refrescaGrid();

        }
        private bool valida() {
            if (textBox1.Text.Length <= 1)
            {
                despliegaMensage("El lote no es valido");
                textBox1.Focus();
                textBox1.Select(0, textBox1.Text.Length);
                return false;
            }

            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["LOTE"].ToString() == textBox1.Text.ToString())
                {
                    despliegaMensage("El Numero de lote ya fue capturado");
                    return false;
                }
            }

            object sumObject;
            sumObject = dt1.Compute("Sum(CANTIDAD)", string.Empty);

            string s = String.IsNullOrEmpty(sumObject.ToString()) ? "0" : sumObject.ToString();
            Int32 totalC = Convert.ToInt32(s) + Convert.ToInt32(numericUpDown3.Value.ToString());

            if (totalC > articuloLote.cantRecibida)
            {
                despliegaMensage("La cantidad capturada supera a la cantidad recibida"
                    + Environment.NewLine +
                    "Total a Capturar:  " + totalC.ToString()
                   + Environment.NewLine
                   + "Cantidad recibida: " + articuloLote.cantRecibida.ToString());
                return false;
            }
            DateTime dts = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            int m = Convert.ToInt16(dts.ToString("MM"));
            int y = Convert.ToInt16(dts.ToString("yyyy"));
            if (m >= numericUpDown1.Value  )
            {
                if (y >= numericUpDown2.Value)
                {
                    despliegaMensage("El mes no es valido");
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                    numericUpDown1.Focus();
                    return false;
                }
            }
            
            
            return true;
        }
        private void guardar() {
            List<SIFModelo.modeloCaducidades> lmd = new List<SIFModelo.modeloCaducidades>();
            foreach (DataRow dtr in dt1.Rows) {
                SIFModelo.modeloCaducidades newArticuloCad = new SIFModelo.modeloCaducidades();
                newArticuloCad.ARTICULO_ID = articuloLote.ARTICULO_ID;
                newArticuloCad.lote = dtr["lote"].ToString();

                newArticuloCad.caducidad = dtr["caducidad"].ToString().Substring(0, 10);
                newArticuloCad.cantLote = Convert.ToInt32(dtr["cantidad"].ToString());
                lmd.Add(newArticuloCad);
            }
            if (lmd.Count() > 0)
            {
                int respuestaInsert = snc.ins_Caducidades_bulk(articuloLote.referencia, "11", SIF.Helpers.Sesion.Usuario.UsuariosID.ToString(), lmd);
                if (respuestaInsert > 0)
                {
                    despliegaMensage("Se insertaron los registros");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else {
                if (DialogResult.Yes != (MessageBox.Show("No tiene registros guardados  para este producto seguro que desea salir", "Espera", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    return;
                }
                else {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }


            }
            



        }
        private void GuardarButtonX_Click(object sender, EventArgs e)
        {
            this.guardar();
        }
        private void EditarButtonX_Click(object sender, EventArgs e)
        {
            this.editar();
        }
        private void editar() {
            if (DialogResult.Yes !=MessageBox.Show("Se eliminaran las caducidades capturadas"+Environment.NewLine+" desea continuar?", "Espere", MessageBoxButtons.YesNo, MessageBoxIcon.Question)){
                return;
            }
            int r=snc.del_Caducidades(articuloLote.ARTICULO_ID, articuloLote.referencia);
            if (r > 0)
            {
                this.cargaDatos();
            }
            else {
                despliegaMensage("No puedes editar lotes y caducidades ");
            }
        }
        private void seleccionaObjeto(int _objeto) {
            ///<summary>
            ///metodo que envia el focus a los objetos
            ///  ID         CORRESPONDE A OBJETO
            ///  ----       ---------------------------
            ///  0          textbox1 donde se captura el lote 
            ///  1          numericupdown1 donde se captura el mes de caducidad
            ///  2          numericupdown2  donde se captura el año de caducidad
            ///  3          numericupdown3 donde se captura  la cantidad de piezas
            ///  
            /// </summary>
            switch (_objeto) {
                case 0:
                    textBox1.Focus();
                    textBox1.Select(0, textBox1.Text.Length);
                    break;
                case 1:                    
                    numericUpDown1.Focus();
                    numericUpDown1.Select(0, numericUpDown1.Text.Length);
                    break;
                case 2:                    
                    numericUpDown2.Focus();
                    numericUpDown2.Select(0, numericUpDown2.Text.Length);
                    break;
                case 3:
                    numericUpDown3.Focus();
                    numericUpDown3.Select(0, numericUpDown3.Text.Length);
                    break;
            }



        }    
        private void refrescaGrid() {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;

            }
        }

    }
}
