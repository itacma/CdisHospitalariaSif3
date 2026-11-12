using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Catalogos
{
    public partial class frmCompradores : DevComponents.DotNetBar.Metro.MetroForm
    {
        private String _art = string.Empty;
        BindingSource f = new BindingSource();
        public frmCompradores(string proveedorid)
        {
            InitializeComponent();
            this.mainForm();
        }
        
        public frmCompradores(string proveedorid, string art )
        {
            InitializeComponent();
            this.mainForm();
            _art = art;
        }
        private void btnXAceptar_Click(object sender, EventArgs e)
        {
            this.seleccionaCompradores();
            this.Close();
        }

        private void mainForm() {
            this.cargalistaCompradores();
        }
        
        private void cargalistaCompradores()
        {  
            
            f.DataSource= new SIFNegocio.Usuarios().BuscarCompradores("").DataSource;
            foreach (SIFModelo.Compradores tipo in f)
            {                
                if (tipo.SActivo.ToString()=="C")
                {                    
                    checkedListBox1.Items.Add(tipo.AccesoId+" - "+tipo.Nombre,true);
                }
                else
                {
                    checkedListBox1.Items.Add(tipo.AccesoId + " - " + tipo.Nombre, false);
                }
            }
        }

        private void btnXCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void seleccionaCompradores() {
            SIFNegocio.OrdenCompra.InformacionMayorista inf = new SIFNegocio.OrdenCompra.InformacionMayorista();
            foreach ( string  row in checkedListBox1.Items)
            {
                if (checkedListBox1.GetItemChecked(checkedListBox1.FindStringExact(row))) {
                    if (!inf.actualizaCompradorArticuloMay(_art, row.ToString().Split('-')[0]))
                        MessageBox.Show("No se Actualizo el comprador reintente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
