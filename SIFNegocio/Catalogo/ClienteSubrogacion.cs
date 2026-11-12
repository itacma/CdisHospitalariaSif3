using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class ClienteSubrogacion
    {
        public BindingListView<SIFModelo.ClienteSubrogaccion> CatClienteSubrogaccionsList;

        private bool Validar(SIFModelo.ClienteSubrogaccion ClienteSubrogaccion)
        {
            //if (string.IsNullOrEmpty(ClienteSubrogaccion.Nombre) || string.IsNullOrWhiteSpace(ClienteSubrogaccion.Nombre))
            //{
            //    MessageBox.Show("El nombre del ClienteSubrogaccion es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un ClienteSubrogaccion en la base de datos
        /// </summary>
        /// <param name="ClienteSubrogaccion">Representa una instancia del ClienteSubrogaccion</param>
        /// <returns>El ClienteSubrogaccion ingresado a la base de datos</returns>
        public SIFModelo.ClienteSubrogaccion Nuevo(SIFModelo.ClienteSubrogaccion ClienteSubrogaccion)
        {
            if (Validar(ClienteSubrogaccion))
            {
                if (!SIFDatos.ClienteSubrogacion.Inserta(ClienteSubrogaccion))
                {
                   MessageBox.Show("El ClienteSubrogaccion no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ClienteSubrogaccion;
        }

        /// <summary>
        /// Modifica el ClienteSubrogaccion en la base de datos
        /// </summary>
        /// <param name="ClienteSubrogaccion">El ClienteSubrogaccion que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.ClienteSubrogaccion ClienteSubrogaccion)
        {
            this.Validar(ClienteSubrogaccion);
            return SIFDatos.ClienteSubrogacion.Actualiza(ClienteSubrogaccion);
        }

        /// <summary>
        /// Elimina la instancia del ClienteSubrogaccion en la base de datos
        /// </summary>
        /// <param name="ClienteSubrogaccion">La instancia del ClienteSubrogaccion a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.ClienteSubrogaccion ClienteSubrogaccion)
        {
            try
            {
                SIFDatos.ClienteSubrogacion.Elimina(ClienteSubrogaccion);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los ClienteSubrogacion de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de ClienteSubrogacion del modelo</returns>
        public BindingListView<SIFModelo.ClienteSubrogaccion> Buscar(string propiedad, string parametro)
        {
            CatClienteSubrogaccionsList = new BindingListView<SIFModelo.ClienteSubrogaccion>(SIFDatos.ClienteSubrogacion.Busca(propiedad, parametro));
            return CatClienteSubrogaccionsList;
        }



        public SIFModelo.ClienteSubrogaccion ClientePorID(int p)
        {
            return SIFDatos.ClienteSubrogacion.ClienteSubrogaccionPorID(p);
        }
    }
}
