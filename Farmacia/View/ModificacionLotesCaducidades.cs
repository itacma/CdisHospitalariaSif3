using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SIF.View
{
    

    public partial class ModificacionLotesCaducidades : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFNegocio.caducidades caducidades = new SIFNegocio.caducidades();
       
        readonly DateTime hoy= SIFNegocio.Configuracion.Configuraciones.fechaServidor();//fecha del servidor

        SIFNegocio.Extras.Parametros param = new SIFNegocio.Extras.Parametros();

        public string _folio;
        public string _tipo_mov;
        public string _usuario;
        public string _lote="1";
        private int row_select = 0;

        public bool muestra_form = false;//si hay lotes para modificar, se muestra el formulario
        

        public ModificacionLotesCaducidades()
        {
            InitializeComponent();
            
        }
        
        public bool validParametro()//si la funcion de modificar los lotes y caducidades esta habilitada
        {
            int parametro = 0;
            bool valida = false;
            parametro = param.ObtenParametro("MODIFICA_LOTEYCADUCIDAD");
            if(parametro==1)
            {
                valida = true;
            }

            return valida;
        }

        public bool modificacionConSalida()//si es valida realizar el cambio en lotes internos que tengan salida en inv_Kardex
        {
            int parametro = 0;
            bool valida = false;
            parametro = param.ObtenParametro("MODIFICA_LOTES_SALIDA");
            if (parametro == 1)
            {
                valida = true;
            }

            return valida;
        }


        public DateTime fechaEnDateTime()
        {
            string fechaCad = txt_caducidad.Text;
            string fechaValidar = "01/" + fechaCad.Substring(0, 2) + "/20" + fechaCad.Substring(2, 2);//toma la fecha del textbox
            DateTime caducidad = Convert.ToDateTime(fechaValidar);//convierte a Datetime
            return caducidad;
        }

        public void LlenadoDatos()
        {
            lb_usuario.Text = _usuario;
            lb_folio.Text = _folio;
            lb_otros.Text = _tipo_mov;
            //gb_modificaciones.Visible = false;

            LlenarGrid(_folio,_tipo_mov,_lote);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private bool validaCaducidad()
        {
            string fechaCad = txt_caducidad.Text;
            bool fecha_valida = false;
            if (fechaCad.Length < 4)
            {
                MessageBox.Show("La fecha debe contener 4 numeros");
            }
            else
            {
                string fechaValidar = "01/" + fechaCad.Substring(0, 2) + "/20" + fechaCad.Substring(2, 2);//toma la fecha del textbox
                DateTime caducidad = Convert.ToDateTime(fechaValidar);//convierte a Datetime
                DateTime fecha_ser = hoy.AddMonths(3);//toma la fecha del servidor
                string fecha_max = "01/01/2100";
                DateTime fecha_maxima = Convert.ToDateTime(fecha_max);
                if (caducidad>fecha_maxima)
                {
                    MessageBox.Show("NO son validas las caducidades del año 2100",
                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                int comparacion;
                comparacion = (caducidad - fecha_ser).Days;//hace la resta de los 3 meses a partir del dia de hoy
                
                if(comparacion>=1)
                {
                    fecha_valida= true;
                }
                else
                {
                    MessageBox.Show("La fecha no es valida \n Favor de validar",
                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
               
            }

            return fecha_valida;

        }

        private bool validaLote()
        {
            bool valida = false;
            String pattern = @"^[A-Z\s-0-9]+$";
            Regex regex = new Regex(pattern);
            string caracteres = txt_lote.Text;
            if (!regex.IsMatch(caracteres))
            {
                MessageBox.Show("El lote NO debe contener caracteres especiales y debe ser con letras Mayusculas",
                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                valida = true;
            }

            return valida;

        }
        
        private void LlenarGrid(string folio,string tipo_mov,string lote)
        {
            
            try
            {
                DataTable dt;

                if (modificacionConSalida())
                {
                    dt = caducidades.getLotesYCaducidad_Salida(folio, tipo_mov, lote);
                }
                else
                {
                    dt = caducidades.getLotesYCaducidadM(folio, tipo_mov, lote);
                }

                if (dt.Rows.Count > 0)
                {
                    dt.Columns[0].ReadOnly = true;
                    dt.Columns[1].ReadOnly = true;
                    dt.Columns[2].ReadOnly = true;
                    dt.Columns[3].ReadOnly = true;
                    dt.Columns[4].ReadOnly = true;
                    dt.Columns[5].ReadOnly = true;

                    

                    dt_lotes.DataSource = dt.DefaultView.ToTable(false,"CODIGO", "DESCRIPCION","CANTIDAD","LOTE", "CADUCIDAD","CADUCIDAD_MOD","LOTE_INTERNO");
                    dt_lotes.Columns[4].Visible = false;
                    dt_lotes.Columns[6].Visible = false;
                    dt_lotes.Columns[0].Width = 120;
                    dt_lotes.Columns[1].Width = 200;
                    

                    muestra_form = true;
                }
                else
                {
                    MessageBox.Show("No existen lotes o caducidades para modificar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_lote_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.RealizarCambio();
                
            }

        }

        private void txt_caducidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                
                this.RealizarCambio();
            }

        }

        private void btn_aceptarCambio_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private bool validaCambio(string lote_interno)
        {
            decimal num_partidas=caducidades.ValidaCambio(lote_interno);
            bool result = false;
            if(num_partidas==0)
                result = true;
            else
            {
                MessageBox.Show("Algo Salio Mal \n Cierre y vuelva a intentar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
            return result;
            
        }

        private void dt_lotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gb_modificaciones.Visible = true;

            string lote,caducidad,articulo_id,loteInterno;
            //MessageBox.Show(e.RowIndex.ToString());

            articulo_id=dt_lotes.CurrentRow.Cells["CODIGO"].Value.ToString();
            lote = dt_lotes.CurrentRow.Cells["LOTE"].Value.ToString();
            caducidad = dt_lotes.CurrentRow.Cells["CADUCIDAD_MOD"].Value.ToString();
            loteInterno = dt_lotes.CurrentRow.Cells["LOTE_INTERNO"].Value.ToString();


            txt_lote.Text = lote;
            txt_loteViejo.Text = lote;
            txt_caducidad.Text = caducidad;
            txt_cadVieja.Text = caducidad;
            lb_loteInterno.Text = loteInterno;
            lb_articuloId.Text = articulo_id;

            row_select = e.RowIndex;
            
        }

        private void btn_aceptarCambio_Click(object sender, EventArgs e)
        {
            this.RealizarCambio();   
        }


        private void RealizarCambio()
        {
            string usuario = Helpers.Sesion.Usuario.UsuariosID.ToString(); //"304";
            string movimiento = lb_otros.Text;
            string articulo_id = lb_articuloId.Text;
            char columna;
            string dAntiguo;
            string dNuevo;
            string loteInt = lb_loteInterno.Text;
            string caducidadPrueba = fechaEnDateTime().ToString("dd/MM/yyyy HH:mm:ss");
            //
            //bool validaCambioSinSalida=validaCambio(loteInt);
            bool validaCambioSinSalida = true;
            bool validaCambioConSalida = modificacionConSalida();
            bool validaCad = validaCaducidad();
            bool validaLot = validaLote();

            decimal respuesta_act = 0;
            if (!validaCambioConSalida)//realiza el cambio sin importar si ya tuvo salidas en CDIS
            {
                validaCambioSinSalida = validaCambio(loteInt);//REVISA SI YA TUVO SALIDA

            }
            
            if (validaCambioSinSalida) { 
            if (validaLot && validaCad)
                {
                    if (txt_caducidad.Text != txt_cadVieja.Text && txt_lote.Text != txt_loteViejo.Text)
                    {
                        decimal pro1 = caducidades.spActualizaLotesCaducidades_pro(usuario, movimiento, articulo_id, 'L', txt_loteViejo.Text, txt_lote.Text, loteInt);

                        decimal pro2 = caducidades.spActualizaLotesCaducidades_pro(usuario, movimiento, articulo_id, 'C', txt_cadVieja.Text, caducidadPrueba, loteInt);

                        respuesta_act = pro1 + pro2;//si ambos se ejecutan correctamente, sumaran 2
                        if (respuesta_act != 2)
                        {
                            MessageBox.Show("Algo Salio Mal \n Cierre y vuelva a intentar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        
                    }

                    else if (txt_lote.Text != txt_loteViejo.Text)
                    {
                        columna = 'L';
                        dAntiguo = txt_loteViejo.Text;
                        dNuevo = txt_lote.Text;
                        respuesta_act = caducidades.spActualizaLotesCaducidades_pro(usuario, movimiento, articulo_id, columna, dAntiguo, dNuevo, loteInt);
                    }
                    else if (txt_caducidad.Text != txt_cadVieja.Text)
                    {
                        columna = 'C';
                        dAntiguo = txt_cadVieja.Text;
                        dNuevo = caducidadPrueba;
                        respuesta_act = caducidades.spActualizaLotesCaducidades_pro(usuario, movimiento, articulo_id, columna, dAntiguo, dNuevo, loteInt);
                    }


                    if (respuesta_act == 0)
                    {
                        MessageBox.Show("Ocurrio algun error \n No se procesaron los cambios", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                    else if (respuesta_act >= 1)
                    {
                        MessageBox.Show("Se aplicaron los cambios :) ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        LlenarGrid(_folio, _tipo_mov,_lote);
                        Refresh();
                        gb_modificaciones.Refresh();
                        dt_lotes.Rows[row_select].DefaultCellStyle.SelectionBackColor = Color.Green;
                        dt_lotes.Rows[row_select].DefaultCellStyle.BackColor = Color.Green;


                    }
                }
                else
                {
                    MessageBox.Show("NO SE REALIZARON CAMBIOS", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ModificacionLotesCaducidades_Load(object sender, EventArgs e)
        {

        }

        private void txt_lote_TextChanged(object sender, EventArgs e)
        {

        }

        private void dt_lotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gb_modificaciones.Visible = true;

            string lote, caducidad, articulo_id, loteInterno;
            //MessageBox.Show(e.RowIndex.ToString());

            articulo_id = dt_lotes.CurrentRow.Cells["CODIGO"].Value.ToString();
            lote = dt_lotes.CurrentRow.Cells["LOTE"].Value.ToString();
            caducidad = dt_lotes.CurrentRow.Cells["CADUCIDAD_MOD"].Value.ToString();
            loteInterno = dt_lotes.CurrentRow.Cells["LOTE_INTERNO"].Value.ToString();


            txt_lote.Text = lote;
            txt_loteViejo.Text = lote;
            txt_caducidad.Text = caducidad;
            txt_cadVieja.Text = caducidad;
            lb_loteInterno.Text = loteInterno;
            lb_articuloId.Text = articulo_id;

            row_select = e.RowIndex;
        }
    }
}
