using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace SIF.View.Seguridad
{
    public partial class PerfilesUserControl : Templates.CatalogoUserControl
    {
        private int Cual = 0;
        public Boolean MostradoArt = false;
        SIFNegocio.Seguridad.Privilegios Privilegios = new SIFNegocio.Seguridad.Privilegios();
        SIFModelo.Seguridad.Seguridad DsSeguridad;
        private Boolean BolActualiza = false;
        public PerfilesUserControl()
        {
            InitializeComponent();

            DsSeguridad = Privilegios.Get(Privilegios.SeguridadDataSet, UsuarioTextBoxX.Text);
            DataRow[] Modulos = DsSeguridad.MODULOS.Select("MODULO_ID <= 10", "MODULO_ID");
            int w = 0;
            foreach (DataRow Modulo in Modulos)
            {
                DataRow[] Opciones = DsSeguridad.OPCIONES.Select("MODULO='" + Modulo["MODULO"] + "'");
                int x = 0;
                int y = 0;

                foreach (DataRow Opcion in Opciones)
                {
                    if (Opcion[0].ToString() == "Principal")
                    {
                        continue;
                    }

                    if (x == 4)
                    { x = 0; y++; }
                    DevComponents.DotNetBar.Controls.GroupPanel Panel = new DevComponents.DotNetBar.Controls.GroupPanel();
                    #region Diseño del Panel
                    Panel.Location = new System.Drawing.Point(39 * (6 * x), 27 * (8 * y));

                    Panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    Panel.CanvasColor = System.Drawing.SystemColors.Control;
                    Panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
                    Panel.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Green;
                    Panel.Size = new System.Drawing.Size(185, 195);

                    Panel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
                    Panel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(231)))));
                    Panel.Style.BackColorGradientAngle = 90;
                    Panel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    Panel.Style.BorderBottomWidth = 1;
                    Panel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(164)))), ((int)(((byte)(90)))));
                    Panel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    Panel.Style.BorderLeftWidth = 1;
                    Panel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    Panel.Style.BorderRightWidth = 1;
                    Panel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    Panel.Style.BorderTopWidth = 1;
                    Panel.Style.CornerDiameter = 4;
                    Panel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
                    Panel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
                    Panel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(74)))), ((int)(((byte)(31)))));
                    Panel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
                    #endregion
                    Panel.Tag = Opcion["Opcion_ID"].ToString();
                    Panel.Text = Opcion["Opcion"].ToString();
                    //obtenemos las operaciones de cada opcion
                    int z = 0;
                    DataRow[] Operaciones = DsSeguridad.SEGURIDAD.Select("OPCION_ID=" + Opcion["Opcion_ID"].ToString());
                    foreach (DataRow Operacion in Operaciones)
                    {
                        DevComponents.DotNetBar.Controls.CheckBoxX ChkBox = new DevComponents.DotNetBar.Controls.CheckBoxX();
                        ChkBox.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
                        ChkBox.BackgroundStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(231)))));
                        ChkBox.Location = new System.Drawing.Point(10, 10 * (2 * z));
                        ChkBox.Size = new System.Drawing.Size(100, 23);
                        ChkBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
                        ChkBox.Text = Operacion["OPERACION"].ToString();
                        ChkBox.Tag = Operacion["ID"].ToString();
                        string tagg = ChkBox.Tag.ToString();
                        if (tagg.Equals(36) && Helpers.Sesion.Usuario.TipoUsuario.ToString().Equals('A'))
                            ChkBox.Enabled = true;
                        else if(tagg.Equals(36))
                            ChkBox.Enabled = false;
                        ChkBox.AutoSize = true;
                        ChkBox.CheckedChanged += new EventHandler(ChkBox_CheckedChanged);
                        z++;
                        Panel.Controls.Add(ChkBox);
                    }

                    this.tabControl1.Tabs[w].AttachedControl.Controls.Add(Panel);
                    this.tabControl1.Tabs[w].Text = Modulo["Modulo"].ToString();
                    x++;
                }
                w++;
            }
            /*superGridControl1.DataBindingComplete += SuperGridControl1DataBindingComplete;
            
            this.superGridControl1.PrimaryGrid.DataSource 
            this.superGridControl1.PrimaryGrid.DataMember = "MODULOS";*/
            PPrivilegios();
        }

        void ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BolActualiza)
            {
                DevComponents.DotNetBar.Controls.CheckBoxX ChkBox = sender as DevComponents.DotNetBar.Controls.CheckBoxX;

                //DataRow[] Regs = DsSeguridad.SEGURIDAD.Select("ID=" + ChkBox.Tag.ToString());

                //Regs[0]["Activo"] = checkBox1.Checked;

                var encontrado = from r in DsSeguridad.SEGURIDAD where r.ID == int.Parse(ChkBox.Tag.ToString()) select r;
                SIFModelo.Seguridad.Seguridad.SEGURIDADRow NewReg = DsSeguridad.SEGURIDAD.NewSEGURIDADRow();
                SIFModelo.Seguridad.Seguridad.SEGURIDADRow Reg = encontrado.First();

                NewReg.ACTIVO = ChkBox.Checked;
                NewReg.ID = Reg.ID;
                NewReg.OPCION = Reg.OPCION;
                NewReg.OPCION_ID = Reg.OPCION_ID;
                NewReg.OPERACION = Reg.OPERACION;
                DsSeguridad.SEGURIDAD.RemoveSEGURIDADRow(Reg);
                DsSeguridad.SEGURIDAD.AddSEGURIDADRow(NewReg);

                Actualiza();
            }
        }


        void PPrivilegios()
        {
            SIFNegocio.Seguridad.Privilegios vf = new SIFNegocio.Seguridad.Privilegios();
            foreach (ButtonItem Xbtn in bar1.Items)
            {
                if (Xbtn.Tag != null & Xbtn.Tag != "")
                    Xbtn.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 79, int.Parse(Xbtn.Tag.ToString()));

            }
            //superGridControl1.Enabled = vf.VerificaOperacion(Helpers.Sesion.Usuario.UsuariosID.ToString(), 79, 2);
        }

        void Actualiza()
        {
            if (UsuarioTextBoxX.Text != "")
                Privilegios.Update(DsSeguridad, UsuarioTextBoxX.Text);
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        public bool Mostrado { get; set; }

        public MainForm Owner { get; set; }

        public void Muestra()
        {
            if (Mostrado)
            {
                return;
            }
            Mostrado = true;
            this.Dock = DockStyle.Fill;
            this.ActivaComandos();
            Owner.ShowModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
        }

        public void ActivaComandos()
        {

        }

        public void Back()
        {
            try
            {
                Owner.CloseModalPanel(this, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                //this.DesactivaComandos();
                //((this.Owner.ActivaComandos();
                Mostrado = false;
            }
            catch { }
        }

        public void DesactivaComandos()
        {

        }

        private void SeleccionaArticulo(object sender, EventArgs e)
        {
            View.Catalogos.UsuarioUserControl frmUsuario = new Catalogos.UsuarioUserControl();

            MostradoArt = true;
            MainForm lanza;
            frmUsuario.Dock = DockStyle.Fill;
            //frmArticulo.Muestra();
            frmUsuario.Owner = this;
            frmUsuario.Muestra();
            this.DesactivaComandos();
        }



        public void Buscar()
        {
            //Privilegios.SeguridadDataSet.Clear();
            DsSeguridad.Clear();
            BolActualiza = false;
            DsSeguridad = Privilegios.Get(Privilegios.SeguridadDataSet, UsuarioTextBoxX.Text);
            CargaPrivilegios(DsSeguridad.SEGURIDAD);
            BolActualiza = true;

        }
        private void CargaPrivilegios(SIFModelo.Seguridad.Seguridad.SEGURIDADDataTable Privilegios)
        {
            foreach (TabItem Tab in tabControl1.Tabs)
            {
                foreach (DevComponents.DotNetBar.Controls.GroupPanel Panel in Tab.AttachedControl.Controls)
                {
                    // Panel.Style = DevComponents.DotNetBar.StyleManager.;
                    foreach (DevComponents.DotNetBar.Controls.CheckBoxX ChkBox in Panel.Controls)
                    {
                        DataRow[] Pri = Privilegios.Select("ID=" + ChkBox.Tag);
                        if (Pri.Count() > 0)
                            ChkBox.Checked = Boolean.Parse(Pri[0]["Activo"].ToString());

                    }

                }
            }

        }
        private void buscarButtonX_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }



        public void AsignaUsuario(SIFModelo.Usuario usuario)
        {
            //this.current = ((ObjectView<SIFModelo.Sucursal>)bindingSource.Current).Object as SIFModelo.Sucursal;

            UsuarioTextBoxX.Text = usuario.UsuariosID.ToString();
            this.Buscar();

            //current.ResponsableID = usuario.UsuariosID;
            //current.ResponsableNombre = usuario.Nombre;
            //this.Modificar(current);
        }



        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {
            View.Seguridad.TiposUsuarioUserControl frmUsuario = new TiposUsuarioUserControl();

            MostradoArt = true;
            MainForm lanza;
            frmUsuario.Dock = DockStyle.Fill;
            //frmArticulo.Muestra();
            frmUsuario.Owner = this.Owner;
            frmUsuario.Muestra();
            this.DesactivaComandos();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            BolActualiza = false;
            foreach (TabItem Tab in tabControl1.Tabs)
            {
                foreach (DevComponents.DotNetBar.Controls.GroupPanel Panel in Tab.AttachedControl.Controls)
                {
                    foreach (DevComponents.DotNetBar.Controls.CheckBoxX ChkBox in Panel.Controls)
                    {
                        ChkBox.Checked = checkBox1.Checked;
                    }

                }
            }
            DataRow[] Pri = DsSeguridad.SEGURIDAD.Select();
            foreach (DataRow Reg in Pri)
                Reg["Activo"] = checkBox1.Checked;

            Actualiza();
            BolActualiza = true;
        }

        private void superGridControl1_RowValidated(object sender, GridRowValidatedEventArgs e)
        {
            Actualiza();
        }






    }
}
