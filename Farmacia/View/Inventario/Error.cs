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
    public partial class Error : Form
    {
         
        public string mensaje = string.Empty;
        public Error( )
        {
            
            //labelX1.Text = mensaje;
            InitializeComponent();
        }

        private void Error_Load(object sender, EventArgs e)
        {
            labelX1.Text = mensaje;
            Console.Beep(800, 450);
        }
    }
}
