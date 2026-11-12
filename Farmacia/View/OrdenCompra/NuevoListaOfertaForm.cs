using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.OrdenCompra
{
    public partial class NuevoListaOfertaForm : DevComponents.DotNetBar.Metro.MetroForm
    {
     
        public NuevoListaOfertaForm()
        {
            InitializeComponent();

            fechaInicioDateTimeInput.MonthCalendar.SelectedDate = DateTime.Now.AddMinutes(5);
        }

        private void MuestraSucursales()
        {
            SIFModelo.Articulo articulo = new SIFModelo.Articulo();
            articulo.LISTA_SUCURSAL_VTA = this.sucursalesTextBoxX.Text;


            Catalogos.ListaSucursalVentaForm frmLista = new Catalogos.ListaSucursalVentaForm(articulo);
            if (frmLista.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                sucursalesTextBoxX.Text ="|"+ frmLista.ListaSucursales;
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(this.nombreTextBoxX.Text))
            {
                this.nombreTextBoxX.SelectAll();
                this.nombreTextBoxX.Focus();
               MessageBox.Show("Debe asignar un nombre para la oferta");
                return false;
            }

            if (string.IsNullOrEmpty(this.sucursalesTextBoxX.Text))
            {
               MessageBox.Show("Elija la lista de sucursales donde se aplicará la oferta");
                this.buttonX1.PerformClick();
                return false;
            }

            if (fechaInicioDateTimeInput.Value < SIFNegocio.Configuracion.Configuraciones.fechaServidor())
            {
               MessageBox.Show("La fecha de inicio para la oferta no puede ser retroactiva");
                fechaInicioDateTimeInput.Focus();
                return false;
            }

            if (fechaTerminoDateTimeInput.Value < fechaInicioDateTimeInput.Value)
            {
               MessageBox.Show("La fecha de caducidad no puede ser menor que la de aplicación");
                fechaTerminoDateTimeInput.Focus();
                return false;
            }

            this.Nombre = nombreTextBoxX.Text;
            this.ListaSucursal = sucursalesTextBoxX.Text;
            this.FechaAlta = this.fechaInicioDateTimeInput.Value;
            this.FechaBaja = this.fechaTerminoDateTimeInput.Value;

            return true;
        }

        private void Aceptar()
        {
            if (this.Valida())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            MuestraSucursales();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        public string Nombre { get; set; }
        public string ListaSucursal { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        
        private void impArchivoButton_Click(object sender, EventArgs e)
        {
            this.ArchivoImp();
        }
        private void ArchivoImp() {
            if (!String.IsNullOrEmpty(buscarArchivoI())) {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
        private String  buscarArchivoI()
        {
            String rsp = string.Empty;
            if (!this.Valida())
                return rsp;
            SIFNegocio.Articulo art = new SIFNegocio.Articulo();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Seleccione el archivo a Procesar";
            fdlg.Filter = "CSV files (*.csv)|*.csv";
            fdlg.RestoreDirectory = true;
            bool FmtValid = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                SIFNegocio.Subrogacion.Factura insr = new SIFNegocio.Subrogacion.Factura();
                DataTable dtPedido = new DataTable();
                dtPedido.Columns.Add("articulo_id", typeof(string));         //Corresponde al codigo del Articulo
                dtPedido.Columns.Add("descuento", typeof(Decimal));      //Corresponde al desceunto de la campaña
                StreamReader reader = StreamReader.Null;
                string str = null;
                int Regs = 0;
                string FName = fdlg.SafeFileName;
                string FPath = Path.GetDirectoryName(fdlg.FileName);
                string FExt = Path.GetExtension(FName);
                //Regex objNotNumPattern = new Regex(@"[^0-9]([.][0-9]{1,3})");
                Regex objNotNumPattern = new Regex(@"[^0-9]");
                Regex objNotAlphaPattern = new Regex(@"[^a-zA-Z0-9\s]");
                try
                {
                    // Valida formato de archivo
                    reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                    List<String> listaInex = new List<string>();
                    while ((str = reader.ReadLine()) != null)
                    {
                        int x = str.Split(',').Count();
                        if (x != 2)
                        {
                            FmtValid = false;
                           MessageBox.Show("El formato de Archivo " + FName + " es Invalido");
                            break;
                        }
                        string codigo = str.Split(',')[0];

                        SIFModelo.Articulo Exs = art.BuscarPorClave(codigo);
                        if (Exs == null)
                        {
                            listaInex.Add(codigo);
                        }
                        // Valida cantidad
                        if (objNotNumPattern.IsMatch(str.Split(',')[1]))
                        {
                            FmtValid = false;
                            MessageBox.Show("la  cantidad de promocion " + str.Split(',')[1].ToString() + "  no es valida");
                            break;
                        }
                    }

                    if (listaInex.Count > 0)
                    {
                        string msg = string.Empty;
                        msg += "No existen los codigos:" + Environment.NewLine;
                        foreach (string s in listaInex)
                        {
                            msg += s.ToString() + Environment.NewLine;
                        }
                        MessageBox.Show(msg);
                        return rsp;
                    }                  
                    // Lee archivo
                    string Result = "";
                    if (FmtValid)
                    {
                        reader.Close();
                        reader = new StreamReader(Path.Combine(FPath, FName), System.Text.Encoding.GetEncoding("iso-8859-1"));
                        while ((str = reader.ReadLine()) != null)
                        {

                            dtPedido.Rows.Add(str.Split(',')[0],
                                              str.Split(',')[1]                                              
                                              );

                            Regs++;
                        }

                        DataRow[] results = dtPedido.Select(null, "articulo_id");



                        String[] Clave = new String[results.Length];
                        Decimal[] Descuento = new decimal[results.Length];
                        int ind = 0;

                        foreach (DataRow rows in dtPedido.Rows)
                        {
                            Clave[ind] = rows["articulo_id"].ToString().Trim();
                            Descuento[ind] =Convert.ToDecimal( rows["descuento"]);
                            
                            ind++;
                        }
                        string resul = string.Empty;
                        try
                        {
                            SIFNegocio.OrdenCompra.ManejoDescuentos artNg = new SIFNegocio.OrdenCompra.ManejoDescuentos();
                             resul = artNg.insertaOfertasMensuales(Clave, Descuento);
                        }
                        catch (Exception EX2) {

                        }
                        
                        if (resul.Contains("1: OK"))
                           SIF.View.OrdenCompra.ManejoDescuentosUserControl.tomaArchivo = true;
                        MessageBox.Show(resul, "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return resul;


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return ex.Message.ToString();

                }
                finally
                {
                    reader.Close();
                }

            }
            return rsp;

        }

    }
}
