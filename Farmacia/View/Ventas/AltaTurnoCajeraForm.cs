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
    public partial class AltaTurnoCajeraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AltaTurnoCajeraForm()
        {
            InitializeComponent();
            this.cargaUsuarios();
            this.CargaCajas();
        }

        public object Owner;
        public SIFModelo.Usuario Usuario;

        private void cargaUsuarios()
        {
            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();

            foreach (SIFModelo.Usuario usuario in new SIFNegocio.Usuarios().Buscar("ACTIVO", "S").DataSource)
            {
                strCol.Add(usuario.AccesoID);
            }
            this.usuarioTextBoxX.AutoCompleteCustomSource = strCol;
        }

        SIFNegocio.Cajas cajasL = new SIFNegocio.Cajas();
        //private void IniciaTurnoCajera()
        //{
        //    decimal monto = System.Convert.ToDecimal(this.montoTextBoxX.Text);

        //    if (!cajasL.IniciaTurno(Helpers.Sesion.Sucursal, Usuario, monto))
        //    {
        //       MessageBox.Show("Ha ocurrido un error al iniciar el turno de caja");
        //        return;
        //    }

        //   MessageBox.Show("Se ha iniciado el turno de caja");

        //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
        //    this.Close();

        //}

        public int CajaID;
        Dictionary<string, SIFModelo.Caja> DicCajas;
        private void CargaCajas()
        {
            AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();
            DicCajas = new Dictionary<string, SIFModelo.Caja>();
            foreach (SIFModelo.Caja modelo in new SIFNegocio.Cajas().Buscar("ACTIVO", "S").DataSource)
            {
                if(!DicCajas.ContainsKey(modelo.Nombre))
                {
                DicCajas.Add(modelo.Nombre, modelo);
                strCol.Add(modelo.Nombre);
                }
            }
            this.cajaTextBoxDropDown.AutoCompleteCustomSource = strCol;
        }

        SIFNegocio.Usuarios logica = new SIFNegocio.Usuarios();
        private bool Validar()
        {
            if (string.IsNullOrEmpty(usuarioTextBoxX.Text))
            {
               MessageBox.Show("Proporcione un número de usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.usuarioTextBoxX.SelectAll();
                usuarioTextBoxX.Focus();
                this.usuarioTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(contrasenaTextBoxX.Text))
            {
               MessageBox.Show("Ingrese la contraseña", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                contrasenaTextBoxX.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(montoTextBoxX.Text))
            {
               MessageBox.Show("Debe ingresar un monto de apetura de caja");
                this.montoTextBoxX.Focus();
                return false;
            }

            if (!montoTextBoxX.Text.IsFloatPositive())
            {
               MessageBox.Show("El monto no es válido, ingrese el monto sin simbolos");
                this.montoTextBoxX.Focus();
                this.montoTextBoxX.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(cajaTextBoxDropDown.Text))
            {
               MessageBox.Show("Ingrese el nombre de la caja", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.contrasenaTextBoxX.SelectAll();
                return false;
            }

            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario.AccesoID = this.usuarioTextBoxX.Text;
            usuario.Contrasena = this.contrasenaTextBoxX.Text;
            usuario = logica.ValidaAcceso(usuario);

            if (usuario != null)
            {
               // this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Usuario = usuario;

                //cajaid 
                if (!DicCajas.ContainsKey(cajaTextBoxDropDown.Text))
                {
                   MessageBox.Show("No se encontró la caja descrita con ese nombre");
                    return false;
                }
                var caja = DicCajas[cajaTextBoxDropDown.Text];

                if (caja == null)
                {
                   MessageBox.Show("No existe una caja con ese nombre");
                    return false;
                }

                //validar si esta abierto o cerrada
               caja.Abierto = new SIFNegocio.Cajas().StatusCaja(Helpers.Sesion.Sucursal, caja);

               if (caja.Abierto == SIFModelo.Tipos.AbiertoCerrado.ABIERTO)
                {
                   MessageBox.Show("Esta caja actualmente se encuentra abierta");
                    return false;
                }

               bool cajaAbierta = new SIFNegocio.Cajas().Caja_abierta(Helpers.Sesion.Sucursal, caja);
              
                    if (cajaAbierta==false)
                {
                   MessageBox.Show("Esta caja ya se ha UTILIZADO este día. Favor de selecccionar otra");
                    return false;
                }


               if (caja.SucursalID != Helpers.Sesion.Sucursal.SucursalesID)
               {
                  MessageBox.Show("La caja no pertenece a esta sucursal");
                   return false;
               }

                this.CajaID = caja.ID;//int.Parse(this.cajaTextBoxDropDown.SelectedValue.ToString());
               // this.Close();
                return true;
            }

         
           MessageBox.Show("Usuario no identificado correctamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void aceptarButtonX_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                decimal monto = System.Convert.ToDecimal(montoTextBoxX.Text);

                SIFModelo.Caja caja = new SIFModelo.Caja();
                caja.ID = this.CajaID;
                caja.SucursalID = Helpers.Sesion.Sucursal.SucursalID;
                caja.CajeroID = Usuario.UsuariosID;
                caja.FechaApertura = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                caja.FechaCierre = null;
                caja.MontoInicial = monto;
                caja.Abierto = SIFModelo.Tipos.AbiertoCerrado.ABIERTO;

                if (!cajasL.IniciaTurno(caja))
                {
                   MessageBox.Show("No se ha conseguido aperturar la caja");
                    return;
                }

                SIFNegocio.Catalogo.Valores ValoresL = new SIFNegocio.Catalogo.Valores();
                SIFModelo.Catalogo.CatalogoDataSet.VALORESRow rowValores = new SIFModelo.Catalogo.CatalogoDataSet.VALORESDataTable().NewVALORESRow();
                rowValores.SEC = ValoresL.SecuenciaNumero(CajaID, caja.SucursalID);
                rowValores.TOTAL = monto;
                rowValores.RECOLECCION_NOMBRE = "APERTURA";
                rowValores.SUCURSAL_ID = caja.SucursalID;
                rowValores.CAJA_ID = CajaID;
                rowValores.CAJERO_ID = caja.CajeroID;
                rowValores.ACTIVO = "S";
                rowValores.CANTIDAD = 1;
                rowValores.DENOMINACIONES_ID = 7;
                rowValores.FECHA = caja.FechaApertura.AddSeconds(5);
                rowValores.IMPORTE = caja.MontoInicial;
                //rowValores.SEC = 1;
                rowValores.TOTAL = caja.MontoInicial;
                rowValores.SUPERVISOR = caja.CajeroID;
                //ValoresL.Inserta(rowValores);

               MessageBox.Show("La caja se aperturó correctamente");
               this.DialogResult = System.Windows.Forms.DialogResult.OK;
               this.Close();
            }

            
        }

        private void VentaUsuarioForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            //this.usuarioTextBoxX.Text = "SIF";
            //this.contrasenaTextBoxX.Text = "FARMACIA";
#endif

            if (Helpers.Sesion.UsuarioSeleccionadoVenta == null)
            {
                // this.usuarioTextBoxX.SelectedItem = Helpers.Sesion.UsuarioSeleccionadoVenta;
                //this.contrasenaTextBoxX.SelectAll();
                this.usuarioTextBoxX.Focus();
            }
        }

        private void CancelarButtonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
