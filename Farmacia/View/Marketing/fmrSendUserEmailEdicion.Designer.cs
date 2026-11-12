
using System;

namespace SIF.View.Marketing
{
    partial class fmrSendUserEmailEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNoEmp = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.GrupoEmailBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ListEmailBoxEx = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.rbdeditarGrupo = new System.Windows.Forms.RadioButton();
            this.rbAgregarUsuario = new System.Windows.Forms.RadioButton();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnDesvincular = new System.Windows.Forms.Button();
            this.rbAgregarExistente = new System.Windows.Forms.RadioButton();
            this.cbxUsuarios = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(562, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Eliminar Usuario";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(544, 226);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.label2.Location = new System.Drawing.Point(51, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.label3.Location = new System.Drawing.Point(51, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID Empleado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.label4.Location = new System.Drawing.Point(51, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Email";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 81);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(469, 20);
            this.txtNombre.TabIndex = 5;
            //this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtNoEmp
            // 
            this.txtNoEmp.Location = new System.Drawing.Point(150, 145);
            this.txtNoEmp.Name = "txtNoEmp";
            this.txtNoEmp.Size = new System.Drawing.Size(76, 20);
            this.txtNoEmp.TabIndex = 7;
            //this.txtNoEmp.TextChanged += new System.EventHandler(this.txtNoEmp_TextChanged);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(150, 113);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(469, 20);
            this.txtApellidos.TabIndex = 6;
            //this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.label6.Location = new System.Drawing.Point(51, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Apellidos";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 177);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(469, 20);
            this.txtEmail.TabIndex = 8;
            //this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // GrupoEmailBoxEx
            // 
            this.GrupoEmailBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GrupoEmailBoxEx.DisplayMember = "Text";
            this.GrupoEmailBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GrupoEmailBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GrupoEmailBoxEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GrupoEmailBoxEx.FormattingEnabled = true;
            this.GrupoEmailBoxEx.ItemHeight = 14;
            this.GrupoEmailBoxEx.Location = new System.Drawing.Point(150, 195);
            this.GrupoEmailBoxEx.Name = "GrupoEmailBoxEx";
            this.GrupoEmailBoxEx.Size = new System.Drawing.Size(473, 20);
            this.GrupoEmailBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.GrupoEmailBoxEx.TabIndex = 2;
            this.GrupoEmailBoxEx.Visible = false;
            this.GrupoEmailBoxEx.SelectedValueChanged += new System.EventHandler(this.GrupoEmailBoxEx_SelectedValueChanged);
            // 
            // ListEmailBoxEx
            // 
            this.ListEmailBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListEmailBoxEx.DisplayMember = "Text";
            this.ListEmailBoxEx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListEmailBoxEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListEmailBoxEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListEmailBoxEx.FormattingEnabled = true;
            this.ListEmailBoxEx.ItemHeight = 14;
            this.ListEmailBoxEx.Location = new System.Drawing.Point(150, 50);
            this.ListEmailBoxEx.Name = "ListEmailBoxEx";
            this.ListEmailBoxEx.Size = new System.Drawing.Size(473, 20);
            this.ListEmailBoxEx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ListEmailBoxEx.TabIndex = 9;
            this.ListEmailBoxEx.SelectedValueChanged += new System.EventHandler(this.ListEmailBoxEx_SelectedValueChanged);
            // 
            // rbdeditarGrupo
            // 
            this.rbdeditarGrupo.AutoSize = true;
            this.rbdeditarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.rbdeditarGrupo.Location = new System.Drawing.Point(38, 2);
            this.rbdeditarGrupo.Name = "rbdeditarGrupo";
            this.rbdeditarGrupo.Size = new System.Drawing.Size(104, 21);
            this.rbdeditarGrupo.TabIndex = 1;
            this.rbdeditarGrupo.TabStop = true;
            this.rbdeditarGrupo.Text = "Editar grupo";
            this.rbdeditarGrupo.UseVisualStyleBackColor = true;
            this.rbdeditarGrupo.CheckedChanged += new System.EventHandler(this.rbdeditarGrupo_CheckedChanged);
            // 
            // rbAgregarUsuario
            // 
            this.rbAgregarUsuario.AutoSize = true;
            this.rbAgregarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.rbAgregarUsuario.Location = new System.Drawing.Point(504, 2);
            this.rbAgregarUsuario.Name = "rbAgregarUsuario";
            this.rbAgregarUsuario.Size = new System.Drawing.Size(118, 21);
            this.rbAgregarUsuario.TabIndex = 4;
            this.rbAgregarUsuario.TabStop = true;
            this.rbAgregarUsuario.Text = "Nuevo usuario";
            this.rbAgregarUsuario.UseVisualStyleBackColor = true;
            this.rbAgregarUsuario.CheckedChanged += new System.EventHandler(this.rbAgregarUsuario_CheckedChanged);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAgregarUsuario.Location = new System.Drawing.Point(520, 97);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(56, 38);
            this.btnAgregarUsuario.TabIndex = 12;
            this.btnAgregarUsuario.Text = "Añadir";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnDesvincular
            // 
            this.btnDesvincular.Location = new System.Drawing.Point(472, 98);
            this.btnDesvincular.Name = "btnDesvincular";
            this.btnDesvincular.Size = new System.Drawing.Size(75, 37);
            this.btnDesvincular.TabIndex = 13;
            this.btnDesvincular.Text = "Desvincular Usuario";
            this.btnDesvincular.UseVisualStyleBackColor = true;
            this.btnDesvincular.Click += new System.EventHandler(this.btnDesvincular_Click);
            // 
            // rbAgregarExistente
            // 
            this.rbAgregarExistente.AutoSize = true;
            this.rbAgregarExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.rbAgregarExistente.Location = new System.Drawing.Point(258, 2);
            this.rbAgregarExistente.Name = "rbAgregarExistente";
            this.rbAgregarExistente.Size = new System.Drawing.Size(130, 21);
            this.rbAgregarExistente.TabIndex = 15;
            this.rbAgregarExistente.TabStop = true;
            this.rbAgregarExistente.Text = "Agregar Usuario";
            this.rbAgregarExistente.UseVisualStyleBackColor = true;
            this.rbAgregarExistente.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // cbxUsuarios
            // 
            this.cbxUsuarios.FormattingEnabled = true;
            this.cbxUsuarios.Location = new System.Drawing.Point(107, 107);
            this.cbxUsuarios.Name = "cbxUsuarios";
            this.cbxUsuarios.Size = new System.Drawing.Size(393, 21);
            this.cbxUsuarios.TabIndex = 16;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(439, 226);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(89, 23);
            this.btnActualizar.TabIndex = 17;
            this.btnActualizar.Text = "Cargar archivo";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // fmrSendUserEmailEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 273);
            this.Controls.Add(this.btnDesvincular);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.cbxUsuarios);
            this.Controls.Add(this.rbAgregarExistente);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.rbAgregarUsuario);
            this.Controls.Add(this.rbdeditarGrupo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNoEmp);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GrupoEmailBoxEx);
            this.Controls.Add(this.ListEmailBoxEx);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmrSendUserEmailEdicion";
            this.Text = "Edicion de correos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNoEmp;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private DevComponents.DotNetBar.Controls.ComboBoxEx GrupoEmailBoxEx;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ListEmailBoxEx;
        private System.Windows.Forms.RadioButton rbdeditarGrupo;
        private System.Windows.Forms.RadioButton rbAgregarUsuario;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnDesvincular;
        private System.Windows.Forms.RadioButton rbAgregarExistente;
        private System.Windows.Forms.ComboBox cbxUsuarios;
        private System.Windows.Forms.Button btnActualizar;
    }
}