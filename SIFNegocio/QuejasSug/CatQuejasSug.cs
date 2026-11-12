using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equin.ApplicationFramework;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.QuejasSug
{
    public class CatQuejasSug
    {
        public BindingListView<SIFModelo.QuejasSugTipo.CatQuejasSug> CatQuejasSugList;

        private bool Validar(SIFModelo.QuejasSugTipo.CatQuejasSug Especialidad)
        {
            if (string.IsNullOrEmpty(Especialidad.Nombre) || string.IsNullOrWhiteSpace(Especialidad.Nombre))
            {
                MessageBox.Show("El nombre del registro es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Especialidad en la base de datos
        /// </summary>
        /// <param name="QuejaSugerencia">Representa una instancia del Especialidad</param>
        /// <returns>El Especialidad ingresado a la base de datos</returns>
        public SIFModelo.QuejasSugTipo.CatQuejasSug Nuevo(SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSugerencia)
        {
            if (Validar(QuejaSugerencia))
            {
                if (!SIFDatos.CallCenter.CatQuejaSug.Inserta(QuejaSugerencia))
                {
                   MessageBox.Show("El registro no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return QuejaSugerencia;
        }

        /// <summary>
        /// Modifica el Especialidad en la base de datos
        /// </summary>
        /// <param name="QuejaSugerencia">El Especialidad que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSugerencia)
        {
            this.Validar(QuejaSugerencia);
            return SIFDatos.CallCenter.CatQuejaSug.Actualiza(QuejaSugerencia);
        }

        /// <summary>
        /// Elimina la instancia del Especialidad en la base de datos
        /// </summary>
        /// <param name="QuejaSugerencia">La instancia del Especialidad a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.QuejasSugTipo.CatQuejasSug QuejaSugerencia)
        {
            try
            {
                SIFDatos.CallCenter.CatQuejaSug.Elimina(QuejaSugerencia);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Especialidads de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Especialidads del modelo</returns>
        public System.Data.DataSet Buscar(string propiedad, string parametro)
        {
            System.Data.DataSet ds = SIFDatos.CallCenter.CatQuejaSug.Busca(propiedad, parametro);
            return ds;
        }

    }
}
