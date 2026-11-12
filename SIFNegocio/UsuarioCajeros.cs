using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class UsuarioCajeros
    {
        public BindingListView<SIFModelo.UsuarioCajero> CatUsuarioCajerosList;

        private bool Validar(SIFModelo.UsuarioCajero UsuarioCajero)
        {
            //if (string.IsNullOrEmpty(UsuarioCajero.) || string.IsNullOrWhiteSpace(UsuarioCajero.Nombre))
            //{
            //    MessageBox.Show("El nombre del UsuarioCajero es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un UsuarioCajero en la base de datos
        /// </summary>
        /// <param name="UsuarioCajero">Representa una instancia del UsuarioCajero</param>
        /// <returns>El UsuarioCajero ingresado a la base de datos</returns>
        public bool Nuevo(SIFModelo.UsuarioCajero UsuarioCajero)
        {
            if (Validar(UsuarioCajero))
            {
                if (!SIFDatos.UsuarioCajero.Inserta(UsuarioCajero))
                {
                   MessageBox.Show("El UsuarioCajero no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Modifica el UsuarioCajero en la base de datos
        /// </summary>
        /// <param name="UsuarioCajero">El UsuarioCajero que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.UsuarioCajero UsuarioCajero)
        {
            this.Validar(UsuarioCajero);
            return SIFDatos.UsuarioCajero.Actualiza(UsuarioCajero);
        }

        /// <summary>
        /// Elimina la instancia del UsuarioCajero en la base de datos
        /// </summary>
        /// <param name="UsuarioCajero">La instancia del UsuarioCajero a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.UsuarioCajero UsuarioCajero)
        {
            try
            {
                SIFDatos.UsuarioCajero.Elimina(UsuarioCajero);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los UsuarioCajeros de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de UsuarioCajeros del modelo</returns>
        public BindingListView<SIFModelo.UsuarioCajero> Buscar(string propiedad, string parametro)
        {
            CatUsuarioCajerosList = new BindingListView<SIFModelo.UsuarioCajero>(SIFDatos.UsuarioCajero.Busca(propiedad, parametro));
            return CatUsuarioCajerosList;
        }


    }
}
