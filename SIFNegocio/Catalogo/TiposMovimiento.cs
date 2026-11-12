using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoMovimientos
    {
        public BindingListView<SIFModelo.TipoMovimiento> CatTipoMovimientosList;

        private bool Validar(SIFModelo.TipoMovimiento TipoMovimiento)
        {
            if (string.IsNullOrEmpty(TipoMovimiento.Nombre) || string.IsNullOrWhiteSpace(TipoMovimiento.Nombre))
            {
                MessageBox.Show("El nombre del TipoMovimiento es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoMovimiento en la base de datos
        /// </summary>
        /// <param name="TipoMovimiento">Representa una instancia del TipoMovimiento</param>
        /// <returns>El TipoMovimiento ingresado a la base de datos</returns>
        public SIFModelo.TipoMovimiento Nuevo(SIFModelo.TipoMovimiento TipoMovimiento)
        {
            if (Validar(TipoMovimiento))
            {
                if (!SIFDatos.TipoMovimientos.Inserta(TipoMovimiento))
                {
                   MessageBox.Show("El TipoMovimiento no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoMovimiento;
        }

        /// <summary>
        /// Modifica el TipoMovimiento en la base de datos
        /// </summary>
        /// <param name="TipoMovimiento">El TipoMovimiento que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoMovimiento TipoMovimiento)
        {
            this.Validar(TipoMovimiento);
            return SIFDatos.TipoMovimientos.Actualiza(TipoMovimiento);
        }

        /// <summary>
        /// Elimina la instancia del TipoMovimiento en la base de datos
        /// </summary>
        /// <param name="TipoMovimiento">La instancia del TipoMovimiento a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoMovimiento TipoMovimiento)
        {
            try
            {
                SIFDatos.TipoMovimientos.Elimina(TipoMovimiento);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoMovimientos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoMovimientos del modelo</returns>
        public BindingListView<SIFModelo.TipoMovimiento> Buscar(string propiedad, string parametro)
        {
            CatTipoMovimientosList = new BindingListView<SIFModelo.TipoMovimiento>(SIFDatos.TipoMovimientos.Busca(propiedad, parametro));
            return CatTipoMovimientosList;
        }

        public List<SIFModelo.TipoMovimiento> BuscarActivos()
        {
            return SIFDatos.TipoMovimientos.BuscaActivo();
        }

    }
}
