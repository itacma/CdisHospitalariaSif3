using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Paquete
    {
        public BindingListView<SIFModelo.Paquete> CatPaqueteList;

        private bool Validar(SIFModelo.Paquete Paquete)
        {
            //if (string.IsNullOrEmpty(Paquete.Nombre) || string.IsNullOrWhiteSpace(Paquete.Nombre))
            //{
            //    MessageBox.Show("El nombre del Paquete es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un Paquete en la base de datos
        /// </summary>
        /// <param name="Paquete">Representa una instancia del Paquete</param>
        /// <returns>El Paquete ingresado a la base de datos</returns>
        public SIFModelo.Paquete Nuevo(SIFModelo.Paquete Paquete)
        {
            if (Validar(Paquete))
            {
                if (!SIFDatos.Paquetes.Inserta(Paquete))
                {
                   MessageBox.Show("El Paquete no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Paquete;
        }

        /// <summary>
        /// Modifica el Paquete en la base de datos
        /// </summary>
        /// <param name="Paquete">El Paquete que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Paquete Paquete)
        {
            this.Validar(Paquete);
            return SIFDatos.Paquetes.Actualiza(Paquete);
        }

        /// <summary>
        /// Elimina la instancia del Paquete en la base de datos
        /// </summary>
        /// <param name="Paquete">La instancia del Paquete a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Paquete Paquete)
        {
            try
            {
                SIFDatos.Paquetes.Elimina(Paquete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Paquete de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Paquete del modelo</returns>
        public BindingListView<SIFModelo.Paquete> Buscar(string propiedad, string parametro)
        {
            CatPaqueteList = new BindingListView<SIFModelo.Paquete>(SIFDatos.Paquetes.Busca(propiedad, parametro));
            return CatPaqueteList;
        }


    }
}
