using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Impuestos
    {
        public BindingListView<SIFModelo.Impuesto> CatImpuestosList;

        private bool Validar(SIFModelo.Impuesto Impuesto)
        {
            if (string.IsNullOrEmpty(Impuesto.Nombre) || string.IsNullOrWhiteSpace(Impuesto.Nombre))
            {
                MessageBox.Show("El nombre del Impuesto es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Impuesto en la base de datos
        /// </summary>
        /// <param name="Impuesto">Representa una instancia del Impuesto</param>
        /// <returns>El Impuesto ingresado a la base de datos</returns>
        public SIFModelo.Impuesto Nuevo(SIFModelo.Impuesto Impuesto)
        {
            if (Validar(Impuesto))
            {
                if (!SIFDatos.Impuestos.Inserta(Impuesto))
                {
                   MessageBox.Show("El Impuesto no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Impuesto;
        }

        /// <summary>
        /// Modifica el Impuesto en la base de datos
        /// </summary>
        /// <param name="Impuesto">El Impuesto que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Impuesto Impuesto)
        {
            this.Validar(Impuesto);
            return SIFDatos.Impuestos.Actualiza(Impuesto);
        }

        /// <summary>
        /// Elimina la instancia del Impuesto en la base de datos
        /// </summary>
        /// <param name="Impuesto">La instancia del Impuesto a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Impuesto Impuesto)
        {
            try
            {
                SIFDatos.Impuestos.Elimina(Impuesto);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Impuestos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Impuestos del modelo</returns>
        public BindingListView<SIFModelo.Impuesto> Buscar(string propiedad, string parametro)
        {
            CatImpuestosList = new BindingListView<SIFModelo.Impuesto>(SIFDatos.Impuestos.Busca(propiedad, parametro));
            return CatImpuestosList;
        }



        public SIFModelo.Impuesto ImpuestoPorID(int p)
        {
            return SIFDatos.Impuestos.ImpuestoPorID(p);
        }
        public SIFModelo.CatClavesSat buscarClaveSat(string clave)
            {
        return SIFDatos.Impuestos.buscarporClaveSat(clave);
       }
    }
}
