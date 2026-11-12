using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class TipoClientes
    {
        public BindingListView<SIFModelo.TipoCliente> CatTipoClientesList;

        private bool Validar(SIFModelo.TipoCliente TipoCliente)
        {
            if (string.IsNullOrEmpty(TipoCliente.Nombre) || string.IsNullOrWhiteSpace(TipoCliente.Nombre))
            {
                MessageBox.Show("El nombre del TipoCliente es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un TipoCliente en la base de datos
        /// </summary>
        /// <param name="TipoCliente">Representa una instancia del TipoCliente</param>
        /// <returns>El TipoCliente ingresado a la base de datos</returns>
        public SIFModelo.TipoCliente Nuevo(SIFModelo.TipoCliente TipoCliente)
        {
            if (Validar(TipoCliente))
            {
                if (!SIFDatos.TiposClientes.Inserta(TipoCliente))
                {
                   MessageBox.Show("El TipoCliente no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoCliente;
        }

        /// <summary>
        /// Modifica el TipoCliente en la base de datos
        /// </summary>
        /// <param name="TipoCliente">El TipoCliente que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.TipoCliente TipoCliente)
        {
            this.Validar(TipoCliente);
            return SIFDatos.TiposClientes.Actualiza(TipoCliente);
        }

        /// <summary>
        /// Elimina la instancia del TipoCliente en la base de datos
        /// </summary>
        /// <param name="TipoCliente">La instancia del TipoCliente a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.TipoCliente TipoCliente)
        {
            try
            {
                SIFDatos.TiposClientes.Elimina(TipoCliente);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los TipoClientes de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoClientes del modelo</returns>
        public BindingListView<SIFModelo.TipoCliente> Buscar(string propiedad, string parametro)
        {
            CatTipoClientesList = new BindingListView<SIFModelo.TipoCliente>(SIFDatos.TiposClientes.Busca(propiedad, parametro));
            return CatTipoClientesList;
        }


    }
}
