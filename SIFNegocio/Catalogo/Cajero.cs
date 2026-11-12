using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Cajeros
    {
        public BindingListView<SIFModelo.Cajero> CatCajerosList;

        private bool Validar(SIFModelo.Cajero Cajero)
        {
            //if (string.IsNullOrEmpty(Cajero.Nombre) || string.IsNullOrWhiteSpace(Cajero.Nombre))
            //{
            //    MessageBox.Show("El nombre del Cajero es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un Cajero en la base de datos
        /// </summary>
        /// <param name="Cajero">Representa una instancia del Cajero</param>
        /// <returns>El Cajero ingresado a la base de datos</returns>
        public SIFModelo.Cajero Nuevo(SIFModelo.Cajero Cajero)
        {
            if (Validar(Cajero))
            {
                if (!SIFDatos.Cajeros.Inserta(Cajero))
                {
                   MessageBox.Show("El Cajero no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Cajero;
        }

        /// <summary>
        /// Modifica el Cajero en la base de datos
        /// </summary>
        /// <param name="Cajero">El Cajero que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Cajero Cajero)
        {
            this.Validar(Cajero);
            return SIFDatos.Cajeros.Actualiza(Cajero);
        }

        /// <summary>
        /// Elimina la instancia del Cajero en la base de datos
        /// </summary>
        /// <param name="Cajero">La instancia del Cajero a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Cajero Cajero)
        {
            try
            {
                SIFDatos.Cajeros.Elimina(Cajero);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Cajeros de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Cajeros del modelo</returns>
        public BindingListView<SIFModelo.Cajero> Buscar(string propiedad, string parametro)
        {
            CatCajerosList = new BindingListView<SIFModelo.Cajero>(SIFDatos.Cajeros.Busca(propiedad, parametro));
            return CatCajerosList;
        }


    }
}
