using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Catalogos
{
    public partial class ExistenciaSucForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFModelo.Articulo articulo;
        DataTable DtExistencia;
        public ExistenciaSucForm(SIFModelo.Articulo articulo)
        {
            this.articulo = articulo;
            InitializeComponent();
            this.cargalista();
        }
        

        private void cargalista()
        {
            
            DtExistencia = new DataTable();
            DtExistencia.Columns.Add("id", typeof(string));
            DtExistencia.Columns.Add("Sucursal", typeof(string));
            DtExistencia.Columns.Add("Existencia", typeof(int));
            SIFNegocio.Sucursales LogSuc = new SIFNegocio.Sucursales();


        }


        

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }
}