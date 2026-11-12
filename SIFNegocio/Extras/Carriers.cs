using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using Equin.ApplicationFramework;
using System.Windows.Forms;

namespace SIFNegocio.Extras
{
    public class Carriers
    {
        public BindingListView<SIFModelo.Extras.Carrier> CatCarriersList;

        private bool Validar(SIFModelo.Extras.Carrier carrier)
        {
            if (string.IsNullOrEmpty(carrier.Nombre) || string.IsNullOrWhiteSpace(carrier.Nombre))
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
        public SIFModelo.Extras.Carrier Nuevo(SIFModelo.Extras.Carrier carrier)
        {
            if (Validar(carrier))
            {
                if (!SIFDatos.Extras.Carriers.Inserta(carrier))
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
        public bool Modificar(SIFModelo.Extras.Carrier carrier)
        {
            this.Validar(carrier);
            return SIFDatos.Extras.Carriers.Actualiza(carrier);
        }

        /// <summary>
        /// Elimina la instancia del Extras.Carrier en la base de datos
        /// </summary>
        /// <param name="Extras.Carrier">La instancia del Extras.Carrier a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Extras.Carrier carrier)
        {
            try
            {
                SIFDatos.Extras.Carriers.Elimina(carrier);
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
        public BindingListView<SIFModelo.Extras.Carrier> Buscar(string propiedad, string parametro)
        {
            CatCarriersList = new BindingListView<SIFModelo.Extras.Carrier>(SIFDatos.Extras.Carriers.Busca(propiedad, parametro));
            return CatCarriersList;
        }


        public SIFModelo.WebServices.Carrier CarrierPorID(int carrierID)
        {
            SIFModelo.WebServices.Carrier Mcarrier = SIFDatos.Extras.Carriers.CarrierPorID(carrierID);
            return Mcarrier;
        }


    }
}
