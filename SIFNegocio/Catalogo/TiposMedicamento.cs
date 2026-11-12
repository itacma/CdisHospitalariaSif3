using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoMedicamento
    {
        public BindingListView<SIFModelo.TipoMedicamento> CatTipoMedicamentoList;
        public BindingListView<SIFModelo.Tipos.tipo6> CatTipo6List;
        public BindingListView<SIFModelo.CatClavesSat> ClavesSat;

        private bool Validar(SIFModelo.TipoMedicamento TipoMedicamento)
        {
            if (string.IsNullOrEmpty(TipoMedicamento.Nombre) || string.IsNullOrWhiteSpace(TipoMedicamento.Nombre))
            {
                MessageBox.Show("El nombre del TipoMedicamento es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoMedicamento en la base de datos
        /// </summary>
        /// <param name="TipoMedicamento">Representa una instancia del TipoMedicamento</param>
        /// <returns>El TipoMedicamento ingresado a la base de datos</returns>
        public SIFModelo.TipoMedicamento Nuevo(SIFModelo.TipoMedicamento TipoMedicamento)
        {
            if (Validar(TipoMedicamento))
            {
                if (!SIFDatos.TiposMedicamento.Inserta(TipoMedicamento))
                {
                   MessageBox.Show("El TipoMedicamento no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoMedicamento;
        }

        /// <summary>
        /// Modifica el TipoMedicamento en la base de datos
        /// </summary>
        /// <param name="TipoMedicamento">El TipoMedicamento que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoMedicamento TipoMedicamento)
        {
            this.Validar(TipoMedicamento);
            return SIFDatos.TiposMedicamento.Actualiza(TipoMedicamento);
        }

        /// <summary>
        /// Elimina la instancia del TipoMedicamento en la base de datos
        /// </summary>
        /// <param name="TipoMedicamento">La instancia del TipoMedicamento a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoMedicamentoCompras TipoMedicamento)
        {
            try
            {
                SIFDatos.TiposMedicamento.Elimina(TipoMedicamento);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoMedicamento de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoMedicamento del modelo</returns>
        public BindingListView<SIFModelo.TipoMedicamento> Buscar(string propiedad, string parametro)
        {
            CatTipoMedicamentoList = new BindingListView<SIFModelo.TipoMedicamento>(SIFDatos.TiposMedicamento.Busca(propiedad, parametro));
            return CatTipoMedicamentoList;
        }
        public BindingListView<SIFModelo.Tipos.tipo6> BuscarTipo6(string propiedad)
        {
            CatTipo6List = new BindingListView<SIFModelo.Tipos.tipo6>(SIFDatos.TiposMedicamento.BuscaTipo6(propiedad));
            return CatTipo6List;
        }

        public List<SIFModelo.Tipos.ClaveTipoMedicamento> ClavesTipoMedicamento()
        {
            return SIFDatos.TiposMedicamento.ClavesTipoMedicamento();
        }


        public List<SIFModelo.TipoMedicamento> Tipos(int tipo)
        {
            return SIFDatos.TiposMedicamento.Tipos(tipo);
        }
        public BindingListView<SIFModelo.CatClavesSat> tipoSat()
            {
            /// obtiene el tipo 5 (Sat) : JMQC 10112017
            ClavesSat = new BindingListView<SIFModelo.CatClavesSat>(SIFDatos.TiposMedicamento.TiposSat());
            return ClavesSat;
            }
    }
}
