using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoPagos
    {
        public BindingListView<SIFModelo.TipoPago> CatTipoPagosList;

        private bool Validar(SIFModelo.TipoPago TipoPago)
        {
            if (string.IsNullOrEmpty(TipoPago.Nombre) || string.IsNullOrWhiteSpace(TipoPago.Nombre))
            {
                MessageBox.Show("El nombre del TipoPago es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoPago en la base de datos
        /// </summary>
        /// <param name="TipoPago">Representa una instancia del TipoPago</param>
        /// <returns>El TipoPago ingresado a la base de datos</returns>
        public SIFModelo.TipoPago Nuevo(SIFModelo.TipoPago TipoPago)
        {
            if (Validar(TipoPago))
            {
                if (!SIFDatos.TipoPagos.Inserta(TipoPago))
                {
                   MessageBox.Show("El TipoPago no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoPago;
        }

        /// <summary>
        /// Modifica el TipoPago en la base de datos
        /// </summary>
        /// <param name="TipoPago">El TipoPago que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoPago TipoPago)
        {
            this.Validar(TipoPago);
            return SIFDatos.TipoPagos.Actualiza(TipoPago);
        }

        /// <summary>
        /// Elimina la instancia del TipoPago en la base de datos
        /// </summary>
        /// <param name="TipoPago">La instancia del TipoPago a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoPago TipoPago)
        {
            try
            {
                SIFDatos.TipoPagos.Elimina(TipoPago);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoPagos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoPagos del modelo</returns>
        public BindingListView<SIFModelo.TipoPago> Buscar(string propiedad, string parametro)
        {
            CatTipoPagosList = new BindingListView<SIFModelo.TipoPago>(SIFDatos.TipoPagos.Busca(propiedad, parametro));
            return CatTipoPagosList;
        }

        public List<SIFModelo.Tipos.TipoPago> TiposPago()
        {
            return SIFDatos.TipoPagos.TiposPago();
        }



        public SIFModelo.TipoPago TipoPagoPorID(int p)
        {
            return SIFDatos.TipoPagos.TipoPagoPorID(p);
        }
    }
}
