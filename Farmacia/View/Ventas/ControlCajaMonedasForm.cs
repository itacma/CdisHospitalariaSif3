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
    public partial class ControlCajaMonedasForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        SIFModelo.Usuario usuario;
        public ControlCajaMonedasForm(SIFModelo.Caja caja, SIFModelo.Usuario usuario, bool EsCorte = false)
        {
            InitializeComponent();
            this.esCorte = EsCorte;
            //this.caja = caja; 
            SIFModelo.Caja controlCaja = new SIFNegocio.Cajas().ControlCaja(Helpers.Sesion.Sucursal, caja);
            this.caja = controlCaja;
            this.usuario = usuario;
            this.aperturaLabelX.Text = caja.MontoInicial.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            this.CargaValores();
            inicializaCellStyles();



            if (caja.FechaCierre == null)
            {
                caja.FechaCierre = new DateTime(caja.FechaApertura.Year, caja.FechaApertura.Month, caja.FechaApertura.Day, 23, 59, 59);
            }
        }
        SIFModelo.Caja caja;
        bool esCorte = false;
        private void CargaValores()
        {
            this.dataGridViewX1.AutoGenerateColumns = false;



            this.ValoresL.DataSet = ValoresL.CargaValores(caja, caja.FechaApertura, caja.FechaCierre);
            this.dataGridViewX1.DataSource = ValoresL.DataSet.VALORES;
        }


        private void Limpiar(bool valida = true)
        {
            if (valida)
            {
                DialogResult res =MessageBox.Show("¿Limpiar todos los valores ingresados?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            morrallaTextBoxX.Text = "0";
            devolucionTextBoxX.Text = "0";
            creditoTextBoxX.Text = "0";
            tCreditoTextBoxX.Text = "0";
            tDebitoTextBoxX.Text = "0";

            this.numericUpDown20.Value = 0;
            this.numericUpDown50.Value = 0;
            this.numericUpDown100.Value = 0;
            this.numericUpDown200.Value = 0;
            this.numericUpDown500.Value = 0;
            this.numericUpDown1000.Value = 0;
        }

        Decimal MontoTotal = 0;
        private void CalculaTotal()
        {

            ////BILLETES
            //decimal monto20 = this.numericUpDown20.Value * 20m;
            //decimal monto50 = this.numericUpDown50.Value * 50m;
            //decimal monto100 = this.numericUpDown100.Value * 100m;
            //decimal monto200 = this.numericUpDown200.Value * 200m;
            //decimal monto500 = this.numericUpDown500.Value * 500m;
            //decimal monto1000 = this.numericUpDown1000.Value * 1000m;

            //decimal montoBilletes = monto20 +
            //                        monto50 +
            //                        monto100 +
            //                        monto200 +
            //                        monto500 +
            //                        monto1000;

            if (this.NombreRecoleccionItem == null)
            {
                return;
            }

            var vTotal = this.ValoresL.DataSet.VALORES.Compute("SUM (IMPORTE)", " ACTIVO = 'S' ");// "RECOLECCION_NOMBRE = '" + this.NombreRecoleccionItem.Text + "' AND ACTIVO = 'S' ");
            Total = 0;

            if (vTotal.ToString().IsFloat())
            {
                Total = decimal.Parse(vTotal.ToString());
            }


            this.TotalLabel.Text = Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));

            this.MontoTotal = Total; // + caja.MontoInicial;

            vTotal = this.ValoresL.DataSet.VALORES.Compute("SUM (IMPORTE)", "RECOLECCION_NOMBRE = '" + this.NombreRecoleccionItem.Text + "' AND ACTIVO = 'S' OR RECOLECCION_NOMBRE = '" + this.NombreRecoleccionItem.Text + "-CORRECCION' AND ACTIVO = 'S'");
            Total = 0;
            if (vTotal.ToString().IsFloat())
            {
                Total = decimal.Parse(vTotal.ToString());
            }

            this.montoTotalLabelX.Text = Total.ToString("C2", new System.Globalization.CultureInfo("ES-mx"));
            foreach (SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valor in ValoresL.DataSet.VALORES.Select("RECOLECCION_NOMBRE = '" + this.NombreRecoleccionItem.Text + "' "))
            {
                valor.TOTAL = Total;
            }


        }

        private decimal Total = 0;
        private bool Guardar()
        {
            if (!Valida())
            {
                return false;
            }

            var valoresNuevos = this.ValoresL.DataSet.VALORES.Select(null, null, DataViewRowState.Added);
            foreach (SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores in valoresNuevos)
            {
                rowValores.SEC = ValoresL.SecuenciaNumero(caja.ID, caja.SucursalID);
                rowValores.TOTAL = this.Total;
                //if (rowValores.RECOLECCION_NOMBRE.Contains("CORRECCION"))
                //{
                //    rowValores.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                //}
                if (caja.FechaCierre == null)
                {
                    caja.FechaCierre = new DateTime(caja.FechaApertura.Year, caja.FechaApertura.Month, caja.FechaApertura.Day, 23, 59, 59);
                }

                if (rowValores.FECHA > caja.FechaCierre.Value)
                {
                    rowValores.FECHA = caja.FechaApertura.AddMinutes(1);
                    new SIFNegocio.Seguridad.Bitacora().Ins("Valor fuera de fecha CAJA:"  + caja.ID + " CAJERO"+ caja.CajeroID + " FECHA:" + caja.FechaApertura.ToShortDateString() + " MONTO:" + rowValores.TOTAL.ToString() , 63, 2, usuario.UsuariosID.ToString());
                }
                ValoresL.Inserta(rowValores);
            }

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NombreRecoleccionItem.Text))
            {
               MessageBox.Show("Ingrese el nombre de la recolección");
                return;
            }

            if (this.Guardar())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(this.NombreRecoleccionItem.Text))
            {
               MessageBox.Show("Ingrese el nombre de la recoleccion");
                this.nombreRecoleccionComboBoxEx.Focus();
                return false;
            }

            //if (!this.TotalLabel.Text.ToString().IsFloatPositive())
            //{
            //   MessageBox.Show("El monto ingresado no es válido", "Monto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    this.TotalLabel.Focus();
            //    return false;
            //}
            return true;
        }

        SIFNegocio.Catalogo.Valores ValoresL = new SIFNegocio.Catalogo.Valores();

        int numeroRecoleccion = 1;
        private void IngresaValores()
        {
            //Valores.Inserta(rowValores);

            this.Agrega1000();

            this.Agrega500();

            this.Agrega200();

            this.Agrega100();

            this.Agrega50();

            this.Agrega20();

            this.AgregaMorralla();

            this.AgregaDevolucion();


            this.dataGridViewX1.DataSource = ValoresL.DataSet.VALORES;
            this.Limpiar(false);
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }

            this.CalculaTotal();

            //if (this.MontoTotal < this.caja.MontoInicial)
            //{
            //    DialogResult res = MessageBox.Show("La apertura de caja es menor que la inicial, ¿Continuar con el cierre?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //    if (res == System.Windows.Forms.DialogResult.No)
            //    {
            //        return;
            //    }
            //}

            //INSERTAMOS LA DENOMINACION

            this.IngresaValores();
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.Close();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.CalculaTotal();
        }

        DevComponents.Editors.ComboItem NombreRecoleccionItem;
        private void ControlCajaMonedasForm_Load(object sender, EventArgs e)
        {
            this.cajaLabelX.Text = caja.Nombre;
            SIFModelo.Usuario cajero = new SIFNegocio.Usuarios().UsuarioPorId(caja.CajeroID);
            this.cajeroLabelX.Text = cajero.Nombre + " " + cajero.Apellidos;

            this.CargaValores();
            this.nombreRecoleccionComboBoxEx.TabIndex = 0;
            nombreRecoleccionComboBoxEx.Focus();

            //var nombres = from nombre in  ValoresL.DataSet.VALORES select nombre.RECOLECCION_NOMBRE;  // ValoresL.DataSet.VALORES.Compute("COUNT(DISTINCT(RECOLECCION_NOMBRE))", "");
            //var numero = nombres.Distinct().Count();
            var numero = ValoresL.DataSet.VALORES.Select(i => i.RECOLECCION_NOMBRE).Distinct().Count();
            var VnumeroCorrecciones = from v in ValoresL.DataSet.VALORES where v.RECOLECCION_NOMBRE.Contains("CORRECCION") select v;
            var numeroCorrecciones = VnumeroCorrecciones.Select(i => i.RECOLECCION_NOMBRE).Distinct().Count();
            if (numero.ToString().IsFloat())
            {
                if (numeroCorrecciones.ToString().IsInteger())
                {
                    numero -= numeroCorrecciones;
                }

                var vApertura = from v in ValoresL.DataSet.VALORES where v.RECOLECCION_NOMBRE == "APERTURA" select v;
                int cuenta = vApertura.Count();
                if (vApertura.Count() > 0)
                {
                    numero -= 1;
                }


                nombreRecoleccionComboBoxEx.SelectedItem = nombreRecoleccionComboBoxEx.Items[int.Parse(numero.ToString())];
                //DevComponents.Editors.ComboItem 
                NombreRecoleccionItem = (DevComponents.Editors.ComboItem)nombreRecoleccionComboBoxEx.SelectedItem;
                nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
            }

            if (esCorte)
            {
                this.nombreRecoleccionComboBoxEx.SelectedItem = nombreRecoleccionComboBoxEx.Items[nombreRecoleccionComboBoxEx.Items.Count - 1];
                NombreRecoleccionItem = (DevComponents.Editors.ComboItem)nombreRecoleccionComboBoxEx.SelectedItem;
                nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                // this.nombreRecoleccionComboBoxEx.SelectedIndex = nombreRecoleccionComboBoxEx.Items.Count -1;
            }

            numeroRecoleccion = ValoresL.SecuenciaNumero(caja.ID, caja.SucursalID);

            this.CalculaTotal();
        }

        private void limpiarButtonX_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void numericUpDown1000_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega1000();
            }
        }

        private void Agrega1000()
        {
            if (numericUpDown1000.Value > 0)
            {

                //1000
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores1000 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores1000.ACTIVO = "S";
                rowValores1000.CAJA_ID = caja.ID;
                rowValores1000.CAJERO_ID = caja.CajeroID;
                rowValores1000.SEC = numeroRecoleccion;
                rowValores1000.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores1000.CANTIDAD = numericUpDown1000.Value;
                rowValores1000.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                rowValores1000.SUCURSAL_ID = caja.SucursalID;
                rowValores1000.SUPERVISOR = this.usuario.UsuariosID;
                rowValores1000.TOTAL = this.MontoTotal;
                rowValores1000.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion1000 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown1000.Tag.ToString()));
                rowValores1000.DENOMINACIONES_NOMBRE = denominacion1000.NOMBRE;
                rowValores1000.DENOMINACIONES_ID = denominacion1000.DENOMINACIONES_ID;
                rowValores1000.IMPORTE = denominacion1000.VALOR * numericUpDown1000.Value;

                rowValores1000.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores1000.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores1000);

                numericUpDown1000.Value = 0;
                numericUpDown1000.Select(0, numericUpDown1000.Value.ToString().Length);

                this.CalculaTotal();
            }
        }


        private void Agrega500()
        {
            if (numericUpDown500.Value > 0)
            {

                //500
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores500 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores500.ACTIVO = "S";
                rowValores500.CAJA_ID = caja.ID;
                rowValores500.CAJERO_ID = caja.CajeroID;
                rowValores500.SEC = numeroRecoleccion;
                rowValores500.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores500.IMPORTE = 500 * numericUpDown500.Value;
                rowValores500.CANTIDAD = numericUpDown500.Value;
                rowValores500.RECOLECCION_NOMBRE = NombreRecoleccionItem.Text;
                rowValores500.SUCURSAL_ID = caja.SucursalID;
                rowValores500.SUPERVISOR = this.usuario.UsuariosID;
                rowValores500.TOTAL = this.MontoTotal;
                rowValores500.DENOMINACIONES_NOMBRE = "BILLETES DE 500";
                rowValores500.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion500 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown500.Tag.ToString()));
                rowValores500.DENOMINACIONES_NOMBRE = denominacion500.NOMBRE;
                rowValores500.DENOMINACIONES_ID = denominacion500.DENOMINACIONES_ID;
                rowValores500.IMPORTE = denominacion500.VALOR * numericUpDown500.Value;

                rowValores500.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores500.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores500);

                numericUpDown500.Value = 0;
                numericUpDown500.Select(0, numericUpDown500.Value.ToString().Length);

                this.CalculaTotal();
            }
        }

        private void Agrega200()
        {
            if (numericUpDown200.Value > 0)
            {

                //200
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores200 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores200.ACTIVO = "S";
                rowValores200.CAJA_ID = caja.ID;
                rowValores200.CAJERO_ID = caja.CajeroID;
                rowValores200.SEC = numeroRecoleccion;
                rowValores200.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores200.CANTIDAD = numericUpDown200.Value;
                rowValores200.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                rowValores200.SUCURSAL_ID = caja.SucursalID;
                rowValores200.SUPERVISOR = this.usuario.UsuariosID;
                rowValores200.TOTAL = this.MontoTotal;
                rowValores200.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion200 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown200.Tag.ToString()));
                rowValores200.DENOMINACIONES_NOMBRE = denominacion200.NOMBRE;
                rowValores200.DENOMINACIONES_ID = denominacion200.DENOMINACIONES_ID;
                rowValores200.IMPORTE = denominacion200.VALOR * numericUpDown200.Value;

                rowValores200.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores200.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores200);

                numericUpDown200.Value = 0;

                numericUpDown200.Value = 0;
                numericUpDown200.Select(0, numericUpDown200.Value.ToString().Length);

                this.CalculaTotal();
            }
        }

        private void Agrega100()
        {
            if (numericUpDown100.Value > 0)
            {

                //100
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores100 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores100.ACTIVO = "S";
                rowValores100.CAJA_ID = caja.ID;
                rowValores100.CAJERO_ID = caja.CajeroID;
                rowValores100.SEC = numeroRecoleccion;
                rowValores100.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores100.CANTIDAD = numericUpDown100.Value;
                rowValores100.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                rowValores100.SUCURSAL_ID = caja.SucursalID;
                rowValores100.SUPERVISOR = this.usuario.UsuariosID;
                rowValores100.TOTAL = this.MontoTotal;
                rowValores100.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion100 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown100.Tag.ToString()));
                rowValores100.DENOMINACIONES_NOMBRE = denominacion100.NOMBRE;
                rowValores100.DENOMINACIONES_ID = denominacion100.DENOMINACIONES_ID;
                rowValores100.IMPORTE = denominacion100.VALOR * numericUpDown100.Value;

                rowValores100.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores100.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";//"CORRECCION";

                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores100);

                numericUpDown100.Value = 0;

                numericUpDown100.Value = 0;
                numericUpDown100.Select(0, numericUpDown100.Value.ToString().Length);

                this.CalculaTotal();
            }
        }

        private void Agrega50()
        {
            if (numericUpDown50.Value > 0)
            {

                //50
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores50 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores50.ACTIVO = "S";
                rowValores50.CAJA_ID = caja.ID;
                rowValores50.CAJERO_ID = caja.CajeroID;
                rowValores50.SEC = numeroRecoleccion;
                rowValores50.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores50.CANTIDAD = numericUpDown50.Value;
                rowValores50.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                rowValores50.SUCURSAL_ID = caja.SucursalID;
                rowValores50.SUPERVISOR = this.usuario.UsuariosID;
                rowValores50.TOTAL = this.MontoTotal;
                rowValores50.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion50 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown50.Tag.ToString()));
                rowValores50.DENOMINACIONES_NOMBRE = denominacion50.NOMBRE;
                rowValores50.DENOMINACIONES_ID = denominacion50.DENOMINACIONES_ID;
                rowValores50.IMPORTE = denominacion50.VALOR * numericUpDown50.Value;

                rowValores50.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores50.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores50);


                numericUpDown50.Value = 0;
                numericUpDown50.Select(0, numericUpDown50.Value.ToString().Length);

                this.CalculaTotal();
            }
        }

        private void Agrega20()
        {
            if (numericUpDown20.Value > 0)
            {

                //20
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores20 = ValoresL.DataSet.VALORES.NewVALORESRow();
                rowValores20.ACTIVO = "S";
                rowValores20.CAJA_ID = caja.ID;
                rowValores20.CAJERO_ID = caja.CajeroID;
                rowValores20.SEC = numeroRecoleccion;
                rowValores20.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                rowValores20.CANTIDAD = numericUpDown20.Value;
                rowValores20.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                rowValores20.SUCURSAL_ID = caja.SucursalID;
                rowValores20.SUPERVISOR = this.usuario.UsuariosID;
                rowValores20.TOTAL = this.MontoTotal;
                rowValores20.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacion20 = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(numericUpDown20.Tag.ToString()));
                rowValores20.DENOMINACIONES_NOMBRE = denominacion20.NOMBRE;
                rowValores20.DENOMINACIONES_ID = denominacion20.DENOMINACIONES_ID;
                rowValores20.IMPORTE = denominacion20.VALOR * numericUpDown20.Value;

                rowValores20.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    rowValores20.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(rowValores20);

                numericUpDown20.Value = 0;
                numericUpDown20.Select(0, numericUpDown20.Value.ToString().Length);

                this.CalculaTotal();
            }
        }

        private void AgregaMorralla()
        {
            if (!morrallaTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("Debe ingresar un número válido", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(morrallaTextBoxX.Text) > 0)
            {

                //MORRALLA
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow morralla = ValoresL.DataSet.VALORES.NewVALORESRow();
                morralla.ACTIVO = "S";
                morralla.CAJA_ID = caja.ID;
                morralla.CAJERO_ID = caja.CajeroID;
                morralla.SEC = numeroRecoleccion;
                morralla.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                morralla.CANTIDAD = 1;
                morralla.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                morralla.SUCURSAL_ID = caja.SucursalID;
                morralla.SUPERVISOR = this.usuario.UsuariosID;
                morralla.TOTAL = this.MontoTotal;
                morralla.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacionMorralla = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(morrallaTextBoxX.Tag.ToString()));
                morralla.DENOMINACIONES_NOMBRE = denominacionMorralla.NOMBRE;
                morralla.DENOMINACIONES_ID = denominacionMorralla.DENOMINACIONES_ID;
                morralla.IMPORTE = decimal.Parse(morrallaTextBoxX.Text);

                morralla.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    morralla.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(morralla);

                morrallaTextBoxX.Text = "0";
                morrallaTextBoxX.SelectAll();

                this.CalculaTotal();
            }
        }

        private void AgregaDevolucion()
        {
            if (!devolucionTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("Debe ingresar un número válido", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(devolucionTextBoxX.Text) > 0)
            {

                //DEVOLUCION
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow devolucion = ValoresL.DataSet.VALORES.NewVALORESRow();
                devolucion.ACTIVO = "S";
                devolucion.CAJA_ID = caja.ID;
                devolucion.CAJERO_ID = caja.CajeroID;
                devolucion.SEC = numeroRecoleccion;
                devolucion.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                devolucion.CANTIDAD = 1;
                devolucion.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                devolucion.SUCURSAL_ID = caja.SucursalID;
                devolucion.SUPERVISOR = this.usuario.UsuariosID;
                devolucion.TOTAL = this.MontoTotal;
                devolucion.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacionDevolucion = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(devolucionTextBoxX.Tag.ToString()));
                devolucion.DENOMINACIONES_NOMBRE = denominacionDevolucion.NOMBRE;
                devolucion.DENOMINACIONES_ID = denominacionDevolucion.DENOMINACIONES_ID;
                devolucion.IMPORTE = decimal.Parse(devolucionTextBoxX.Text);

                devolucion.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    devolucion.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(devolucion);

                devolucionTextBoxX.Text = "0";
                devolucionTextBoxX.SelectAll();

                this.CalculaTotal();
            }
        }

        private void AgregaCredito()
        {
            if (!creditoTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("Debe ingresar un número válido", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(creditoTextBoxX.Text) > 0)
            {

                //CREDITO
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow credito = ValoresL.DataSet.VALORES.NewVALORESRow();
                credito.ACTIVO = "S";
                credito.CAJA_ID = caja.ID;
                credito.CAJERO_ID = caja.CajeroID;
                credito.SEC = numeroRecoleccion;
                credito.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                credito.CANTIDAD = 1;
                credito.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                credito.SUCURSAL_ID = caja.SucursalID;
                credito.SUPERVISOR = this.usuario.UsuariosID;
                credito.TOTAL = this.MontoTotal;
                credito.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacionCredito = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(creditoTextBoxX.Tag.ToString()));
                credito.DENOMINACIONES_NOMBRE = denominacionCredito.NOMBRE;
                credito.DENOMINACIONES_ID = denominacionCredito.DENOMINACIONES_ID;
                credito.IMPORTE = decimal.Parse(creditoTextBoxX.Text);

                credito.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    credito.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(credito);

                creditoTextBoxX.Text = "0";
                creditoTextBoxX.SelectAll();

                this.CalculaTotal();
            }
        }

        private void AgregaTCredito()
        {
            if (!tCreditoTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("Debe ingresar un número válido", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(tCreditoTextBoxX.Text) > 0)
            {

                //T.CREDITO
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow tCredito = ValoresL.DataSet.VALORES.NewVALORESRow();
                tCredito.ACTIVO = "S";
                tCredito.CAJA_ID = caja.ID;
                tCredito.CAJERO_ID = caja.CajeroID;
                tCredito.SEC = numeroRecoleccion;
                tCredito.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                tCredito.CANTIDAD = 1;
                tCredito.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                tCredito.SUCURSAL_ID = caja.SucursalID;
                tCredito.SUPERVISOR = this.usuario.UsuariosID;
                tCredito.TOTAL = this.MontoTotal;
                tCredito.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacionTCredito = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(tCreditoTextBoxX.Tag.ToString()));
                tCredito.DENOMINACIONES_NOMBRE = denominacionTCredito.NOMBRE;
                tCredito.DENOMINACIONES_ID = denominacionTCredito.DENOMINACIONES_ID;
                tCredito.IMPORTE = decimal.Parse(tCreditoTextBoxX.Text);

                tCredito.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    tCredito.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(tCredito);

                tCreditoTextBoxX.Text = "0";
                tCreditoTextBoxX.SelectAll();

                this.CalculaTotal();
            }
        }

        private void AgregaTdebito()
        {
            if (!tDebitoTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("Debe ingresar un número válido", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.Parse(tDebitoTextBoxX.Text) > 0)
            {

                //T.DEBITO
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow tDebito = ValoresL.DataSet.VALORES.NewVALORESRow();
                tDebito.ACTIVO = "S";
                tDebito.CAJA_ID = caja.ID;
                tDebito.CAJERO_ID = caja.CajeroID;
                tDebito.SEC = numeroRecoleccion;
                tDebito.FECHA = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                tDebito.CANTIDAD = 1;
                tDebito.RECOLECCION_NOMBRE = this.NombreRecoleccionItem.Text;
                tDebito.SUCURSAL_ID = caja.SucursalID;
                tDebito.SUPERVISOR = this.usuario.UsuariosID;
                tDebito.TOTAL = this.MontoTotal;
                tDebito.SUPERVISOR_NOMBRE = "";

                SIFModelo.Catalogo.CatalogoDataSet.DENOMINACIONESRow denominacionTDebito = new SIFNegocio.Catalogo.Denominaciones().DenominacionPorID(int.Parse(tDebitoTextBoxX.Tag.ToString()));
                tDebito.DENOMINACIONES_NOMBRE = denominacionTDebito.NOMBRE;
                tDebito.DENOMINACIONES_ID = denominacionTDebito.DENOMINACIONES_ID;
                tDebito.IMPORTE = decimal.Parse(tDebitoTextBoxX.Text);

                tDebito.SEC = numeroRecoleccion++;

                if (esCorreccion)
                {
                    this.nombreRecoleccionComboBoxEx.Text = NombreRecoleccionItem.Text;
                    tDebito.RECOLECCION_NOMBRE = valoresCorrigiendo.RECOLECCION_NOMBRE + "-CORRECCION";
                    esCorreccion = false;
                }

                ValoresL.DataSet.VALORES.AddVALORESRow(tDebito);

                tDebitoTextBoxX.Text = "0";
                tDebitoTextBoxX.SelectAll();

                this.CalculaTotal();
            }
        }

        private void numericUpDown500_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega500();
            }
        }

        private void numericUpDown200_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega200();
            }

        }

        private void numericUpDown100_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega100();
            }
        }

        private void numericUpDown50_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega50();
            }
        }

        private void numericUpDown20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Agrega20();
            }
        }

        private void morrallaTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaMorralla();
            }
        }

        private void devolucionTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaDevolucion();
            }
        }

        private void creditoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaCredito();
            }
        }

        private void tCreditoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaTCredito();
            }
        }

        private void tDebitoTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AgregaTdebito();
            }
        }

        private void dataGridViewX1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalculaTotal();
        }


        private bool esCorreccion = false;
        SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valoresCorrigiendo;
        private void Corregir()
        {
            if (this.dataGridViewX1.CurrentRow == null)
            {
               MessageBox.Show("Seleccione el valor a corregir");
                return;
            }

            SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valoresRow = ((DataRowView)dataGridViewX1.CurrentRow.DataBoundItem).Row as SIFModelo.Catalogo.CatalogoDataSet.VALORESRow;


            if (MessageBoxEx.Show("¿Corregir la denominación " + valoresRow.DENOMINACIONES_NOMBRE + " de la recolección " + valoresRow.RECOLECCION_NOMBRE + "?", "Corrección", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.nombreRecoleccionComboBoxEx.Text = "CORRECCION";
            esCorreccion = true;
            valoresCorrigiendo = valoresRow;
            //CorreccionValoresForm frmCorreccion = new CorreccionValoresForm(valoresRow);

            //if (frmCorreccion.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //{
            //    return;
            //}

            valoresRow.ACTIVO = "N";
            ValoresL.Actualiza(valoresRow);

            switch (valoresRow.DENOMINACIONES_NOMBRE)
            {
                case ("BILLETE MIL PESOS"):
                    numericUpDown1000.Focus();
                    numericUpDown1000.ResetText();
                    break;
                case ("BILLETE QUINIENTOS PESOS"):
                    numericUpDown500.Focus();
                    numericUpDown500.ResetText();
                    break;
                case ("BILLETE DOSCIENTOS PESOS"):
                    numericUpDown200.Focus();
                    numericUpDown200.ResetText();
                    break;
                case ("BILLETE CIEN PESOS"):
                    numericUpDown100.Focus();
                    numericUpDown100.ResetText();
                    break;
                case ("BILLETE CINCUENTA PESOS"):
                    numericUpDown50.Focus();
                    numericUpDown50.ResetText();
                    break;
                case ("BILLETE VEINTE PESOS"):
                    numericUpDown20.Focus();
                    numericUpDown20.ResetText();
                    break;
                case ("MORRALLA"):
                    morrallaTextBoxX.Focus();
                    morrallaTextBoxX.SelectAll();
                    break;
                case ("DEVOLUCION"):
                    devolucionTextBoxX.Focus();
                    devolucionTextBoxX.SelectAll();
                    break;
                case ("CREDITO"):
                    creditoTextBoxX.Focus();
                    creditoTextBoxX.SelectAll();
                    break;
                case ("T_CREDITO"):
                    tCreditoTextBoxX.Focus();
                    tCreditoTextBoxX.SelectAll();
                    break;
                case ("T_DEBITO"):
                    tDebitoTextBoxX.Focus();
                    tDebitoTextBoxX.SelectAll();
                    break;
            }

            //SIFModelo.Catalogo.CatalogoDataSet.VALORESRow correccion = this.ValoresL.DataSet.VALORES.NewVALORESRow();
            //correccion.ACTIVO = "S";
            //correccion.CAJA_ID = valoresRow.CAJA_ID;
            //correccion.CAJERO_ID = valoresRow.CAJERO_ID;
            //correccion.CANTIDAD = frmCorreccion.NuevaCantidad;
            //correccion.DENOMINACIONES_ID = valoresRow.DENOMINACIONES_ID;
            //correccion.DENOMINACIONES_NOMBRE = valoresRow.DENOMINACIONES_NOMBRE;
            //correccion.FECHA = valoresRow.FECHA;
            //correccion.IMPORTE = frmCorreccion.NuevoValor;
            //correccion.RECOLECCION_NOMBRE = "CORRECCION";
            //correccion.SUCURSAL_ID = valoresRow.SUCURSAL_ID;
            //correccion.SUPERVISOR = this.usuario.UsuariosID;
            //correccion.SUPERVISOR_NOMBRE = this.usuario.Nombre;
            //correccion.SEC = ValoresL.SecuenciaNumero(correccion.CAJA_ID, correccion.SUCURSAL_ID);

            //this.ValoresL.DataSet.VALORES.AddVALORESRow(correccion);

            //var valor = correccion.Table.Compute("SUM(IMPORTE)", "RECOLECCION_NOMBRE = '" + correccion.RECOLECCION_NOMBRE + "' OR RECOLECCION_NOMBRE = '" + this.NombreRecoleccionItem.Text + "'");

            //if (valor.ToString().IsFloat())
            //{
            //    correccion.TOTAL = System.Convert.ToDecimal(valor.ToString());
            //}

            //ValoresL.Inserta(correccion);
            CalculaTotal();
        }

        private void corregirButtonX_Click(object sender, EventArgs e)
        {
            this.Corregir();
        }


        DataGridViewCellStyle beneficioRowStyle = new DataGridViewCellStyle();//superGridControl1.DefaultVisualStyles.RowStyles;
        private void inicializaCellStyles()
        {
            beneficioRowStyle.BackColor = Color.FromArgb(255, 221, 227);
            beneficioRowStyle.SelectionBackColor = Color.FromArgb(255, 221, 227);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewX1.Rows[e.RowIndex].DataBoundItem;

                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valor = ((DataRowView)row).Row as SIFModelo.Catalogo.CatalogoDataSet.VALORESRow;


                if (valor.ACTIVO == "N")
                {
                    dataGridViewX1.Rows[e.RowIndex].DefaultCellStyle = beneficioRowStyle;
                    dataGridViewX1.Rows[e.RowIndex].DefaultCellStyle.ApplyStyle(beneficioRowStyle);
                }

            }
        }

        private void ControlCajaMonedasForm_Activated(object sender, EventArgs e)
        {
            this.numericUpDown1000.Focus();
        }

        private void numericUpDown1000_Enter(object sender, EventArgs e)
        {
            (sender as NumericUpDown).ResetText();
        }

    }
}
