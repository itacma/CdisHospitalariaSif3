using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class PaqueteDetalles
    {
        public BindingListView<SIFModelo.PaqueteDetalle> CatPaqueteDetallesList;

        private bool Validar(SIFModelo.PaqueteDetalle PaqueteDetalle)
        {
            //if (string.IsNullOrEmpty(PaqueteDetalle.Nombre) || string.IsNullOrWhiteSpace(PaqueteDetalle.Nombre))
            //{
            //    MessageBox.Show("El nombre del PaqueteDetalle es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un PaqueteDetalle en la base de datos
        /// </summary>
        /// <param name="PaqueteDetalle">Representa una instancia del PaqueteDetalle</param>
        /// <returns>El PaqueteDetalle ingresado a la base de datos</returns>
        public SIFModelo.PaqueteDetalle Nuevo(SIFModelo.PaqueteDetalle PaqueteDetalle)
        {
            if (Validar(PaqueteDetalle))
            {
                if (!SIFDatos.PaqueteDetalles.Inserta(PaqueteDetalle))
                {
                   MessageBox.Show("El PaqueteDetalle no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return PaqueteDetalle;
        }

        /// <summary>
        /// Modifica el PaqueteDetalle en la base de datos
        /// </summary>
        /// <param name="PaqueteDetalle">El PaqueteDetalle que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.PaqueteDetalle PaqueteDetalle)
        {
            this.Validar(PaqueteDetalle);
            return SIFDatos.PaqueteDetalles.Actualiza(PaqueteDetalle);
        }

        /// <summary>
        /// Elimina la instancia del PaqueteDetalle en la base de datos
        /// </summary>
        /// <param name="PaqueteDetalle">La instancia del PaqueteDetalle a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.PaqueteDetalle PaqueteDetalle)
        {
            try
            {
                SIFDatos.PaqueteDetalles.Elimina(PaqueteDetalle);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los PaqueteDetalles de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de PaqueteDetalles del modelo</returns>
        public BindingListView<SIFModelo.PaqueteDetalle> Buscar(string propiedad, string parametro)
        {
            CatPaqueteDetallesList = new BindingListView<SIFModelo.PaqueteDetalle>(SIFDatos.PaqueteDetalles.Busca(propiedad, parametro));
            return CatPaqueteDetallesList;
        }


    }
}
