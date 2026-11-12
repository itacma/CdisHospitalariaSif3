using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIF.View.Ventas
{
    public partial class RecoleccionValoresUserControl : Templates.ListaUserControl
    {
        private SIFModelo.Caja modelo;

        public RecoleccionValoresUserControl()
        {
            InitializeComponent();
        }

        public RecoleccionValoresUserControl(SIFModelo.Caja modelo)
            : base()
        {
            this.modelo = modelo;
            CargaDenominaciones();
        }


        private void CargaDenominaciones()
        { 
        
        }

        private void CargaNombresRecoleccion()
        { 
        
        }



        public ControlCajasUserControl Owner { get; set; }

        private void superGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.C) || (e.Shift && e.KeyCode == Keys.C))
            {
                superGridControl1.PrimaryGrid.CopySelectedCellsToClipboard(true, true);
            }
        }

    }
}
