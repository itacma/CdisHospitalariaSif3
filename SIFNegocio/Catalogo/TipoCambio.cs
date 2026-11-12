using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoCambios
    {
        public BindingListView<SIFModelo.TipoCambio> CatTipoCambiosList;

        private bool Validar(SIFModelo.TipoCambio TipoCambio)
        {
            if (string.IsNullOrEmpty(TipoCambio.Nombre) || string.IsNullOrWhiteSpace(TipoCambio.Nombre))
            {
                MessageBox.Show("El nombre del TipoCambio es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoCambio en la base de datos
        /// </summary>
        /// <param name="TipoCambio">Representa una instancia del TipoCambio</param>
        /// <returns>El TipoCambio ingresado a la base de datos</returns>
        public SIFModelo.TipoCambio Nuevo(SIFModelo.TipoCambio TipoCambio)
        {
            if (Validar(TipoCambio))
            {
                if (!SIFDatos.TiposCambio.Inserta(TipoCambio))
                {
                   MessageBox.Show("El TipoCambio no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoCambio;
        }

        /// <summary>
        /// Modifica el TipoCambio en la base de datos
        /// </summary>
        /// <param name="TipoCambio">El TipoCambio que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoCambio TipoCambio)
        {
            this.Validar(TipoCambio);
            return SIFDatos.TiposCambio.Actualiza(TipoCambio);
        }

        /// <summary>
        /// Elimina la instancia del TipoCambio en la base de datos
        /// </summary>
        /// <param name="TipoCambio">La instancia del TipoCambio a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoCambio TipoCambio)
        {
            try
            {
                SIFDatos.TiposCambio.Elimina(TipoCambio);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoCambios de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoCambios del modelo</returns>
        public BindingListView<SIFModelo.TipoCambio> Buscar(string propiedad, string parametro)
        {
            CatTipoCambiosList = new BindingListView<SIFModelo.TipoCambio>(SIFDatos.TiposCambio.Busca(propiedad, parametro));
            return CatTipoCambiosList;
        }



        internal SIFModelo.TipoCambio BuscarPorID(int p)
        {
            return SIFDatos.TiposCambio.BuscaPorID(p);
        }
    }
}
