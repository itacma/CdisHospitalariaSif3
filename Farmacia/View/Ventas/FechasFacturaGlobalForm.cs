using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class FechasFacturaGlobalForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FechasFacturaGlobalForm()
        {
            InitializeComponent();
            AsignaFechas();
        }


        private void AsignaFechas()
        {
            dateTimeInput1.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 0, 0, 0);
            dateTimeInput2.Value = new DateTime(SIFNegocio.Configuracion.Configuraciones.fechaServidor().Year, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Month, SIFNegocio.Configuracion.Configuraciones.fechaServidor().Day, 23, 59, 59);
        }

        private bool ValidaFechas()
        {
            if (this.dateTimeInput1.Value >= SIFNegocio.Configuracion.Configuraciones.fechaServidor())
            {
               MessageBox.Show("La fecha de inicio es mayor al día actual");
                dateTimeInput1.Focus();
                return false;
            }

            if (this.dateTimeInput1.Value >= dateTimeInput2.Value)
            {
               MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de término");
                dateTimeInput1.Focus();
                return false;
            }

            return true;

        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (ValidaFechas())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
