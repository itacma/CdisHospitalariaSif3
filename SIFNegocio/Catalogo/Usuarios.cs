using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using SIFNegocio.Helpers;
using Equin.ApplicationFramework;
using System.ComponentModel;


namespace SIFNegocio
{
    public class Usuarios
    {
        public BindingListView<SIFModelo.Usuario> ListaUsuarios;

        /// <summary>
        /// AVM 20-04-2015
        /// Valida el usuario al que se le modificara la contraseña.
        /// solo regresa un true en caso de que el usuario y la contraseña sean validas.
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public Boolean ValidaUsuarioCambioPass(SIFModelo.Usuario usuario, Boolean validarAdmonSuper = false)
        {
            if (string.IsNullOrEmpty(usuario.AccesoID))
            {
               MessageBox.Show("Ingrese el código de Acceso del usuario");
                return false;
            }

            return SIFDatos.Usuarios.ValidaUsuarioCambioPass(usuario,validarAdmonSuper);
        }

        public Boolean ActualizaContrasenha(SIFModelo.Usuario usr)
        {
            return SIFDatos.Usuarios.ActualizaContrasenha(usr);
        }

        public SIFModelo.Usuario ValidaAcceso(SIFModelo.Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.AccesoID))
            {
               MessageBox.Show("Ingrese el código de Acceso del usuario");
                return null;
            }
            
            string outintermedio = "";
            Int32 G = SIFDatos.Seguridad.Privilegios.VerificaAccesoIngreso(usuario.AccesoID, usuario.Contrasena, out outintermedio);
            if (G <= 0) {
               MessageBox.Show(outintermedio, "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;

            }


            return SIFDatos.Usuarios.ValidaAcceso(usuario);
        }

        private bool Validar(SIFModelo.Usuario Usuario)
        {
            if (string.IsNullOrEmpty(Usuario.Nombre) || string.IsNullOrWhiteSpace(Usuario.Nombre))
            {
               MessageBox.Show("El nombre del Usuario es Obligatorio");
                return false;
            }

            if (Usuario.FechaAlta == new DateTime())
            {
                Usuario.FechaAlta = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            if (Usuario.Contrasena == null)
            {
                Usuario.Contrasena = "";
            }

            return true;
        }

        /// <summary>
        /// Crea un Usuario en la base de datos
        /// </summary>
        /// <param name="Usuario">Representa una instancia del Usuario</param>
        /// <returns>El Usuario ingresado a la base de datos</returns>
        public SIFModelo.Usuario Nuevo(SIFModelo.Usuario Usuario)
        {
            if (Validar(Usuario))
            {
                try
                {
                    if (!SIFDatos.Usuarios.Inserta(Usuario))
                    {
                       MessageBox.Show("El Usuario no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Usuario.UsuariosID = 0;
                    }
                }
                catch (Exception ex)
                {

                }

            }
            return Usuario;
        }

        /// <summary>
        /// Modifica el Usuario en la base de datos
        /// </summary>
        /// <param name="Usuario">El Usuario que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Usuario Usuario)
        {
            this.Validar(Usuario);
            return SIFDatos.Usuarios.Actualiza(Usuario);
        }

        /// <summary>
        /// Elimina la instancia del Usuario en la base de datos
        /// </summary>
        /// <param name="Usuario">La instancia del Usuario a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Usuario Usuario)
        {
            try
            {
                SIFDatos.Usuarios.Elimina(Usuario);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Usuarios de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Usuarios del modelo</returns>
        public BindingListView<SIFModelo.Usuario> Buscar(string propiedad, string parametro)
        {
            //listaUsuarios = new BindingList<SIFModelo.Usuario>(SIFDatos.Usuarios.Busca(propiedad, parametro));
            this.ListaUsuarios = new BindingListView<SIFModelo.Usuario>(SIFDatos.Usuarios.Busca(propiedad, parametro));
            return ListaUsuarios;
        }

        /// <summary>
        /// RECUPERA TODOS LOS USUARIOS QUE ESTAN ACTIVOS EN EL SISTEMA
        /// </summary>
        /// <param name="propiedad"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public BindingListView<SIFModelo.Usuario> BuscarActivos(string propiedad, string parametro)
        {
            //listaUsuarios = new BindingList<SIFModelo.Usuario>(SIFDatos.Usuarios.Busca(propiedad, parametro));
            this.ListaUsuarios = new BindingListView<SIFModelo.Usuario>(SIFDatos.Usuarios.Busca(propiedad, parametro));
            return ListaUsuarios;
        }

        public SIFModelo.Usuario UsuarioPorId(int p)
        {
            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario.UsuariosID = p;
            return SIFDatos.Usuarios.UsuarioPorId(usuario);
        }

        public SIFModelo.Usuario UsuarioPorId_cnx(int p, string cnx)
        {
            SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            usuario.UsuariosID = p;
            return SIFDatos.Usuarios.UsuarioPorId_cnx(usuario, cnx);
        }

        public SIFModelo.Usuario UsuarioPorAccesoID(SIFModelo.Usuario usuario)
        {
            //SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            //usuario.UsuariosID = p;
            return SIFDatos.Usuarios.UsuarioPorAccesoId(usuario);
        }

        
        public List<SIFModelo.Usuario> ListaDistribuidores()
        {
            //SIFModelo.Usuario usuario = new SIFModelo.Usuario();
            //usuario.UsuariosID = p;
            return SIFDatos.Usuarios.ListaDistribuidores();
        }
        public string ListaProveedores(SIFModelo.Usuario usuario)
        {
           string lista = SIFDatos.Usuarios.ListaProveedores(usuario).ListaProveedorId;
            if(string.IsNullOrEmpty( lista))
            {
            return string.Empty;
            }


           string[] proveedores = lista.Split(new char[] { '|' });
            string listaProveedores ="";
            foreach(string proveedorID in proveedores)
            {
                listaProveedores += proveedorID + ",";
            }

            return listaProveedores.Trim(',');

        }
        /*<JQM 24032017 Catalogo de compradores*/
        public BindingListView<SIFModelo.Compradores> CatCompradores;
        public BindingListView<SIFModelo.Compradores> BuscarCompradores(string provid)
        {
            CatCompradores = new BindingListView<SIFModelo.Compradores>(SIFDatos.Usuarios.ListaCompradores(provid));
            return CatCompradores;
        }
        //>
    }
}
