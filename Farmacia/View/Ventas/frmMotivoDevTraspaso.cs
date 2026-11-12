using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.View.Ventas
{
    public partial class frmMotivoDevTraspaso : DevComponents.DotNetBar.Metro.MetroForm
    {
        string Param = string.Empty;

        internal int SetDevolucion(string NoFolio, string NoLote, int NoPartida, string Sol, string Edo, int Cant)
        {
            SIFNegocio.Inventario.Traspasos tSol = new SIFNegocio.Inventario.Traspasos();
            return tSol.SetDevolucion(NoFolio, NoLote.ToString(), NoPartida, Sol, Edo, Cant);
        }

        public frmMotivoDevTraspaso()
        { }

        public frmMotivoDevTraspaso(string traspaso)
        {
            InitializeComponent();
            Param = traspaso;
            this.articuloLabel.Text = traspaso.Split('|')[2];
            this.cantidadDevueltaLabel.Text = traspaso.Split('|')[3];
            this.CantDev.Value = int.Parse(traspaso.Split('|')[3]);
            switch (Param.Split('|')[6])
            {
                case "A":
                case "X":
                    this.CantDev.Minimum = int.Parse(traspaso.Split('|')[3]);
                    break;
                default:
                    this.CantDev.Minimum = 0;
                    break;
            }
            this.CantDev.Maximum = int.Parse(traspaso.Split('|')[3]);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmMotivoDevTraspaso_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SIFNegocio.Inventario.Traspasos TipoDev = new SIFNegocio.Inventario.Traspasos();
            dt = TipoDev.GetTipoDevolucion();
            cmb_TipoDedvolucion.DataSource = dt;
            cmb_TipoDedvolucion.ValueMember = "TipDev"; // "ID";
            cmb_TipoDedvolucion.DisplayMember = "Devolucion"; // "NOMBRE";

            cmb_TipoDedvolucion.SelectedIndex =cmb_TipoDedvolucion.FindStringExact(Param.Split('|')[4].Trim());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int result = 0;

            result = SetDevolucion(Param.Split('|')[0], Param.Split('|')[1], 
                        Convert.ToInt16(Param.Split('|')[5]), Param.Split('|')[6],
                cmb_TipoDedvolucion.Text, Convert.ToInt16(CantDev.Value)); 

            if (result > 0)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();

        }


    }
}