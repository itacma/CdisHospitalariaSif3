using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Sucursales
    {
        public BindingListView<SIFModelo.Sucursal> SucursalesList;

        private bool Validar(SIFModelo.Sucursal Sucursal)
        {
            if (string.IsNullOrEmpty(Sucursal.Nombre) || string.IsNullOrWhiteSpace(Sucursal.Nombre))
            {
                MessageBox.Show("El nombre del Sucursal es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Sucursal en la base de datos
        /// </summary>
        /// <param name="Sucursal">Representa una instancia del Sucursal</param>
        /// <returns>El Sucursal ingresado a la base de datos</returns>
        public bool Nuevo(SIFModelo.Sucursal Sucursal)
        {
            if (Validar(Sucursal))
            {
                SIFDatos.Sucursales.Inserta(Sucursal);
                if (Sucursal.SucursalesID == 0)
                {
                   MessageBox.Show("El Sucursal no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Modifica el Sucursal en la base de datos
        /// </summary>
        /// <param name="Sucursal">El Sucursal que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Sucursal Sucursal)
        {
            this.Validar(Sucursal);
            return SIFDatos.Sucursales.Actualiza(Sucursal);
        }

        /// <summary>
        /// Elimina la instancia del Sucursal en la base de datos
        /// </summary>
        /// <param name="Sucursal">La instancia del Sucursal a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Sucursal Sucursal)
        {
            try
            {
                SIFDatos.Sucursales.Elimina(Sucursal);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Sucursals de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Sucursals del modelo</returns>
        public BindingListView<SIFModelo.Sucursal> Buscar(string propiedad, string parametro)
        {
            SucursalesList = new BindingListView<SIFModelo.Sucursal>(SIFDatos.Sucursales.Busca(propiedad, parametro));
            if (SucursalesList.DataSource == null)
            {
                SucursalesList = new BindingListView<SIFModelo.Sucursal>(new List<Sucursales>());
                return SucursalesList;
            }

            foreach (var item in SucursalesList)
            {
                SIFModelo.Usuario usuario = new SIFModelo.Usuario() { UsuariosID = ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableID };

                usuario = SIFDatos.Usuarios.UsuarioPorId(usuario);
                if (usuario == null)
                {
                    continue;
                }
                ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableNombre = usuario.Nombre;
            }

            return SucursalesList;
        }


        public BindingListView<SIFModelo.Sucursal> BuscarAlmacenesMandato(string propiedad, string parametro)
        {
            SucursalesList = new BindingListView<SIFModelo.Sucursal>(SIFDatos.Sucursales.BuscaAlmacenMandato(propiedad, "AM"));
            if (SucursalesList.DataSource == null)
            {
                SucursalesList = new BindingListView<SIFModelo.Sucursal>(new List<Sucursales>());
                return SucursalesList;
            }

            foreach (var item in SucursalesList)
            {
                SIFModelo.Usuario usuario = new SIFModelo.Usuario() { UsuariosID = ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableID };

                usuario = SIFDatos.Usuarios.UsuarioPorId(usuario);
                if (usuario == null)
                {
                    continue;
                }
                ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableNombre = usuario.Nombre;
            }

            return SucursalesList;
        }


        public BindingListView<SIFModelo.Sucursal> BuscarAlmacenesNoVirtuales()
        {
            SucursalesList = new BindingListView<SIFModelo.Sucursal>(SIFDatos.Sucursales.BuscaAlmacenNoVirtuales());
            if (SucursalesList.DataSource == null)
            {
                SucursalesList = new BindingListView<SIFModelo.Sucursal>(new List<Sucursales>());
                return SucursalesList;
            }

            foreach (var item in SucursalesList)
            {
                SIFModelo.Usuario usuario = new SIFModelo.Usuario() { UsuariosID = ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableID };

                usuario = SIFDatos.Usuarios.UsuarioPorId(usuario);
                if (usuario == null)
                {
                    continue;
                }
                ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableNombre = usuario.Nombre;
            }

            return SucursalesList;
        }

        public void TestDBLink(string Link)
        {
            SIFDatos.Sucursales.TestDBLink(Link);
        }

        public int ObtenExistencia(string Link, string Articulo_ID,int Suc)
        {
            return SIFDatos.Sucursales.ObtenExistencia(Link, Articulo_ID,Suc);
        }

        public BindingListView<SIFModelo.Sucursal> BuscarLink(string propiedad, string parametro)
        {
            SucursalesList = new BindingListView<SIFModelo.Sucursal>(SIFDatos.Sucursales.Busca(propiedad, parametro));
            if (SucursalesList.DataSource == null)
            {
                SucursalesList = new BindingListView<SIFModelo.Sucursal>(new List<Sucursales>());
                return SucursalesList;
            }

            foreach (var item in SucursalesList)
            {
                SIFModelo.Usuario usuario = new SIFModelo.Usuario() { UsuariosID = ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableID };

                usuario = SIFDatos.Usuarios.UsuarioPorId(usuario);
                if (usuario == null)
                {
                    continue;
                }
                ((ObjectView<SIFModelo.Sucursal>)item).Object.ResponsableNombre = usuario.Nombre;
            }

            return SucursalesList;
        }


        public SIFModelo.Sucursal SucursalPorID(int p)
        {
            return SIFDatos.Sucursales.SucursalPorID(p);
        }

    }
}
