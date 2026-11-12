using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class ClasificacionSSAs
    {
        public BindingListView<SIFModelo.ClasificacionSSA> CatClasificacionSSAsList;

        private bool Validar(SIFModelo.ClasificacionSSA ClasificacionSSA)
        {
            if (string.IsNullOrEmpty(ClasificacionSSA.Nombre) || string.IsNullOrWhiteSpace(ClasificacionSSA.Nombre))
            {
                MessageBox.Show("El nombre del ClasificacionSSA es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un ClasificacionSSA en la base de datos
        /// </summary>
        /// <param name="ClasificacionSSA">Representa una instancia del ClasificacionSSA</param>
        /// <returns>El ClasificacionSSA ingresado a la base de datos</returns>
        public SIFModelo.ClasificacionSSA Nuevo(SIFModelo.ClasificacionSSA ClasificacionSSA)
        {
            if (Validar(ClasificacionSSA))
            {
                if (!SIFDatos.ClasificacionSSAs.Inserta(ClasificacionSSA))
                {
                   MessageBox.Show("El ClasificacionSSA no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ClasificacionSSA;
        }

        /// <summary>
        /// Modifica el ClasificacionSSA en la base de datos
        /// </summary>
        /// <param name="ClasificacionSSA">El ClasificacionSSA que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.ClasificacionSSA ClasificacionSSA)
        {
            this.Validar(ClasificacionSSA);
            return SIFDatos.ClasificacionSSAs.Actualiza(ClasificacionSSA);
        }

        /// <summary>
        /// Elimina la instancia del ClasificacionSSA en la base de datos
        /// </summary>
        /// <param name="ClasificacionSSA">La instancia del ClasificacionSSA a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.ClasificacionSSA ClasificacionSSA)
        {
            try
            {
                SIFDatos.ClasificacionSSAs.Elimina(ClasificacionSSA);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los ClasificacionSSAs de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de ClasificacionSSAs del modelo</returns>
        public BindingListView<SIFModelo.ClasificacionSSA> Buscar(string propiedad, string parametro)
        {
            CatClasificacionSSAsList = new BindingListView<SIFModelo.ClasificacionSSA>(SIFDatos.ClasificacionSSAs.Busca(propiedad, parametro));
            return CatClasificacionSSAsList;
        }


    }
}
