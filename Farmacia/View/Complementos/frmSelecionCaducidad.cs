using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Complementos
{
    public partial class frmSelecionCaducidad : DevComponents.DotNetBar.Metro.MetroForm
    {
        //string pArticuloID, pFolio  = string.Empty;
        //Int32 pCantidad, pLote = 0;
        DataTable ListArticulosRecepcion = new DataTable();
        List<SIFModelo.Inventarios.SkuCaducidad> l_lotes = new List<SIFModelo.Inventarios.SkuCaducidad>();
        public Int32 Totalpescaneado=0;
        SIFModelo.Inventarios.SkuCaducidad MCaducidad = new SIFModelo.Inventarios.SkuCaducidad();

        public frmSelecionCaducidad(SIFModelo.Inventarios.SkuCaducidad pMCaducidad)
        {
            InitializeComponent();
            CargaValores(pMCaducidad);
            cargaDatos();
        }
        private void CargaValores(SIFModelo.Inventarios.SkuCaducidad pMCaducidad)
        {
            MCaducidad = pMCaducidad;

            if (pMCaducidad.CantidadPedida == 0)
            {
                Totalpp.Minimum = 1;
                Totalpp.Maximum = 99999;
                Totalpp.Value = pMCaducidad.cantidad;
               
            }
            else
            {
                
                Totalpp.Minimum = pMCaducidad.cantidad;
                Totalpp.Maximum = pMCaducidad.CantidadPedida;
                Totalpp.Value = pMCaducidad.cantidad;
            }
            label2.Text = "Escaneadas: " + pMCaducidad.cantidad.ToString();
            label1.Text = pMCaducidad.articuloId.ToString() + " - " + pMCaducidad.nombre.ToString();
            lblcantidadpedida.Text = "Pedido: " + MCaducidad.CantidadPedida.ToString();
        }

        private void cargaDatos() { 
        //Recibo los productos con caducidad Recibida en la Orden de compra
        ListArticulosRecepcion = new SIFNegocio.CaducidadesSalida().sp_GetDataskuCaducidades(MCaducidad);

        







            if (ListArticulosRecepcion.Rows.Count > 0)
            {

                ListArticulosRecepcion.DefaultView.Sort = " NOMBRE ASC";
                dataGridViewX1.DataSource = ListArticulosRecepcion.DefaultView.ToTable(false, "CANTIDAD_LOTE", "CANTIDAD_ENV", "CANTIDAD_DISPONIBLE", "NO_LOTE", "CADUCIDAD", "LOTE_INTERNO");
                

            }
    }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {


                case Keys.F11:
                    this.guardar();
                    return true;
                    //case Keys.A | Keys.Control://Asginar Valores  de grid al modelo
                    //    this.AsginarM();
                    //    return true;
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        private void guardar() {
            if (!validar()) {
                MessageBox.Show("No se valido la seleccion");
                return;
            }
            string Respuesta = new SIFNegocio.CaducidadesSalida().sp_GuardadCaducidadesSeleccionadasT(MCaducidad.Foliot,MCaducidad.articuloId ,MCaducidad.lotet,l_lotes) ;

            if (Respuesta.Contains("1:OK"))
            {
                Totalpescaneado = Int32.Parse(Totalpp.Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }
        private bool validar() {
            
            if (MCaducidad.cantidad != Int32.Parse(Totalpp.Value.ToString()))
            {
                MCaducidad.cantidad = Int32.Parse( Totalpp.Value.ToString());
            }
           // if(MCaducidad.cantidad>MCaducidad.)
            l_lotes = new List<SIFModelo.Inventarios.SkuCaducidad>();
            int sec = 1;
            foreach (DataGridViewRow StNolote in dataGridViewX1.Rows) {
                try
                {
                    //if (int.Parse(StNolote.Cells["CANTIDAD_ENVColumn"].Value.ToString()) <= 0)
                    //{
                    //    richTextBox1.Text="La cantidad enviada(Cantidad env )  debe ser mayor a cero en las filas seleccionadas";
                    //    return false;
                    //}

                        }
                catch {
                    richTextBox1.Text = "valide la cantidad enviada";
                    return false;
                }

                if (//Convert.ToBoolean( StNolote.Cells["SELEC"].Value) == true && 
                    int.Parse(StNolote.Cells["CANTIDAD_ENVColumn"].Value.ToString())>0) 
                {

                    SIFModelo.Inventarios.SkuCaducidad skuModelo = new SIFModelo.Inventarios.SkuCaducidad();
                    skuModelo.partida = sec;
                    skuModelo.lote__interno = StNolote.Cells["LOTE_INTERNOColumn"].Value.ToString();
                    if (int.Parse(StNolote.Cells["CANTIDAD_DISPONIBLEColumn"].Value.ToString()) >= int.Parse(StNolote.Cells["CANTIDAD_ENVColumn"].Value.ToString()))
                    {


                    }
                    else {
                        richTextBox1.Text= "La cantidad Enviada es mayor a la cantidad disponible";
                        return false;
                    
                    }

                    //if (int.Parse(StNolote.Cells["CANTIDAD_DISPONIBLEColumn"].Value.ToString()) >= pCantidad)
                    //{

                        skuModelo.cantidad = int.Parse(StNolote.Cells["CANTIDAD_ENVColumn"].Value.ToString());
                    //}
                    //else {
                    //    skuModelo.cantidad = int.Parse(StNolote.Cells["CANTIDAD_DISPONIBLEColumn"].Value.ToString());
                    //}
                    
                    l_lotes.Add(skuModelo);
                    sec++;
                }
            }




            if (l_lotes.Count <= 0) {
                return false;
            }

            int Total  = l_lotes.Sum(x => x.cantidad);
            if (Total != MCaducidad.cantidad) 
            {
                richTextBox1.Text = "El total de Piezas escaneadas no coincide con el Seleccionado";
                return false;
            }

            return true;
        }
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            

        }
       /* private void formFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Impedir que el formulario se cierre pulsando X o Alt + F4
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }
        }*/


    }
}
