using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIF.Templates
{
    public partial class SplashCreenForm : Form
    {
        public SplashCreenForm()
        {
            InitializeComponent();

        }

        private void SplashCreenForm_Load(object sender, EventArgs e)
        {
            StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, Color.FromArgb(46, 97, 157));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
