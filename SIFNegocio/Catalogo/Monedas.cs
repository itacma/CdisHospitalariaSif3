using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Monedas
    {
        public BindingListView<SIFModelo.Moneda> CatMonedasList;

        private bool Validar(SIFModelo.Moneda Moneda)
        {
            if (string.IsNullOrEmpty(Moneda.Nombre) || string.IsNullOrWhiteSpace(Moneda.Nombre))
            {
                MessageBox.Show("El nombre del Moneda es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Moneda en la base de datos
        /// </summary>
        /// <param name="Moneda">Representa una instancia del Moneda</param>
        /// <returns>El Moneda ingresado a la base de datos</returns>
        public SIFModelo.Moneda Nuevo(SIFModelo.Moneda Moneda)
        {
            if (Validar(Moneda))
            {
                if (!SIFDatos.Monedas.Inserta(Moneda))
                {
                   MessageBox.Show("El Moneda no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Moneda;
        }

        /// <summary>
        /// Modifica el Moneda en la base de datos
        /// </summary>
        /// <param name="Moneda">El Moneda que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Moneda Moneda)
        {
            this.Validar(Moneda);
            return SIFDatos.Monedas.Actualiza(Moneda);
        }

        /// <summary>
        /// Elimina la instancia del Moneda en la base de datos
        /// </summary>
        /// <param name="Moneda">La instancia del Moneda a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Moneda Moneda)
        {
            try
            {
                SIFDatos.Monedas.Elimina(Moneda);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Monedas de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Monedas del modelo</returns>
        public BindingListView<SIFModelo.Moneda> Buscar(string propiedad, string parametro)
        {
            CatMonedasList = new BindingListView<SIFModelo.Moneda>(SIFDatos.Monedas.Busca(propiedad, parametro));
            return CatMonedasList;
        }



        internal SIFModelo.Moneda MonedaPorID(int monedaID)
        {
            return SIFDatos.Monedas.MonedaPorID(monedaID);
        }
    }
}
