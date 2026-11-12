using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoMedicamentoCompras
    {
        public BindingListView<SIFModelo.TipoMedicamentoCompras> CatTipoMedicamentoList;

        private bool Validar(SIFModelo.TipoMedicamentoCompras TipoMedicamentoCompras)
        {
            if (string.IsNullOrEmpty(TipoMedicamentoCompras.Nombre) || string.IsNullOrWhiteSpace(TipoMedicamentoCompras.Nombre))
            {
                MessageBox.Show("El nombre del TipoMedicamentoCompras es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoMedicamentoCompras en la base de datos
        /// </summary>
        /// <param name="TipoMedicamentoCompras">Representa una instancia del TipoMedicamentoCompras</param>
        /// <returns>El TipoMedicamentoCompras ingresado a la base de datos</returns>
        public SIFModelo.TipoMedicamentoCompras Nuevo(SIFModelo.TipoMedicamentoCompras TipoMedicamentoCompras)
        {
            if (Validar(TipoMedicamentoCompras))
            {
                if (!SIFDatos.TiposMedicamentoCompras.Inserta(TipoMedicamentoCompras))
                {
                   MessageBox.Show("El TipoMedicamentoCompras no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoMedicamentoCompras;
        }

        /// <summary>
        /// Modifica el TipoMedicamentoCompras en la base de datos
        /// </summary>
        /// <param name="TipoMedicamentoCompras">El TipoMedicamentoCompras que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoMedicamentoCompras TipoMedicamentoCompras)
        {
            this.Validar(TipoMedicamentoCompras);
            return SIFDatos.TiposMedicamentoCompras.Actualiza(TipoMedicamentoCompras);
        }

        /// <summary>
        /// Elimina la instancia del TipoMedicamentoCompras en la base de datos
        /// </summary>
        /// <param name="TipoMedicamentoCompras">La instancia del TipoMedicamentoCompras a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoMedicamentoCompras TipoMedicamentoCompras)
        {
            try
            {
                SIFDatos.TiposMedicamentoCompras.Elimina(TipoMedicamentoCompras);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoMedicamentoCompras de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoMedicamentoCompras del modelo</returns>
        public BindingListView<SIFModelo.TipoMedicamentoCompras> Buscar(string propiedad, string parametro)
        {
            CatTipoMedicamentoList = new BindingListView<SIFModelo.TipoMedicamentoCompras>(SIFDatos.TiposMedicamentoCompras.Busca(propiedad, parametro));
            return CatTipoMedicamentoList;
        }
        
        public List<SIFModelo.TipoMedicamentoCompras> Tipos(int tipo)
        {
            return SIFDatos.TiposMedicamentoCompras.Tipos(tipo);
        }
    }
}
