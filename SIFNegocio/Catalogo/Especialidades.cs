using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Especialidads
    {
        public BindingListView<SIFModelo.Especialidad> CatEspecialidadsList;

        private bool Validar(SIFModelo.Especialidad Especialidad)
        {
            //if (string.IsNullOrEmpty(Especialidad.Nombre) || string.IsNullOrWhiteSpace(Especialidad.Nombre))
            //{
            //    MessageBox.Show("El nombre del Especialidad es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un Especialidad en la base de datos
        /// </summary>
        /// <param name="Especialidad">Representa una instancia del Especialidad</param>
        /// <returns>El Especialidad ingresado a la base de datos</returns>
        public SIFModelo.Especialidad Nuevo(SIFModelo.Especialidad Especialidad)
        {
            if (Validar(Especialidad))
            {
                if (!SIFDatos.Especialidades.Inserta(Especialidad))
                {
                   MessageBox.Show("El Especialidad no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Especialidad;
        }

        /// <summary>
        /// Modifica el Especialidad en la base de datos
        /// </summary>
        /// <param name="Especialidad">El Especialidad que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Especialidad Especialidad)
        {
            this.Validar(Especialidad);
            return SIFDatos.Especialidades.Actualiza(Especialidad);
        }

        /// <summary>
        /// Elimina la instancia del Especialidad en la base de datos
        /// </summary>
        /// <param name="Especialidad">La instancia del Especialidad a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Especialidad Especialidad)
        {
            try
            {
                SIFDatos.Especialidades.Elimina(Especialidad);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Especialidads de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Especialidads del modelo</returns>
        public BindingListView<SIFModelo.Especialidad> Buscar(string propiedad, string parametro)
        {
            CatEspecialidadsList = new BindingListView<SIFModelo.Especialidad>(SIFDatos.Especialidades.Busca(propiedad, parametro));
            return CatEspecialidadsList;
        }


    }
}
