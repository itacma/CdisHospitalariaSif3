using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.OrdenCompra
{
    public partial class FoliosGeneradosForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FoliosGeneradosForm()
        {
            InitializeComponent();
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
