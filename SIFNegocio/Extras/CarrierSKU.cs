using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.Extras
{
    public class CarrierSKU
    {
        public BindingListView<SIFModelo.Extras.CarrierSKU> CatCarriersSKUList;

        private bool Validar(SIFModelo.Extras.CarrierSKU carrier)
        {
            if (string.IsNullOrEmpty(carrier.SKU) || string.IsNullOrWhiteSpace(carrier.SKU))
            {
               MessageBox.Show("El nombre del Extras.Carrier es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Extras.Carrier en la base de datos
        /// </summary>
        /// <param name="Extras.Carrier">Representa una instancia del Extras.Carrier</param>
        /// <returns>El Extras.Carrier ingresado a la base de datos</returns>
        public SIFModelo.Extras.CarrierSKU Nuevo(SIFModelo.Extras.CarrierSKU carrier)
        {
            if (Validar(carrier))
            {
                if (!SIFDatos.Extras.CarrierSKU.Inserta(carrier))
                {
                   MessageBox.Show("El Extras.Carrier no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return carrier;
        }

        /// <summary>
        /// Modifica el Extras.Carrier en la base de datos
        /// </summary>
        /// <param name="Extras.Carrier">El Extras.Carrier que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Extras.CarrierSKU carrier)
        {
            this.Validar(carrier);
            return SIFDatos.Extras.CarrierSKU.Actualiza(carrier);
        }

        /// <summary>
        /// Elimina la instancia del Extras.Carrier en la base de datos
        /// </summary>
        /// <param name="Extras.Carrier">La instancia del Extras.Carrier a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Extras.CarrierSKU carrier)
        {
            try
            {
                //SIFModelo.Extras.CarrierSKU.Elimina(carrier);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Extras.Carriers de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Extras.Carriers del modelo</returns>
        public BindingListView<SIFModelo.Extras.CarrierSKU> Buscar(string propiedad, string parametro)
        {
            CatCarriersSKUList = new BindingListView<SIFModelo.Extras.CarrierSKU>(SIFDatos.Extras.CarrierSKU.Busca(propiedad, parametro));
            return CatCarriersSKUList;
        }
    }
}
