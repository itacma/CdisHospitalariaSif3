using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class ClienteConvenios
    {
        public BindingListView<SIFModelo.ClienteConvenio> CatClienteConveniosList;

        private bool Validar(SIFModelo.ClienteConvenio ClienteConvenio)
        {
            //if (string.IsNullOrEmpty(ClienteConvenio.Nombre) || string.IsNullOrWhiteSpace(ClienteConvenio.Nombre))
            //{
            //    MessageBox.Show("El nombre del ClienteConvenio es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un ClienteConvenio en la base de datos
        /// </summary>
        /// <param name="ClienteConvenio">Representa una instancia del ClienteConvenio</param>
        /// <returns>El ClienteConvenio ingresado a la base de datos</returns>
        public SIFModelo.ClienteConvenio Nuevo(SIFModelo.ClienteConvenio ClienteConvenio)
        {
            if (Validar(ClienteConvenio))
            {
                if (!SIFDatos.ClienteConvenios.Inserta(ClienteConvenio))
                {
                   MessageBox.Show("El ClienteConvenio no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ClienteConvenio;
        }

        /// <summary>
        /// Modifica el ClienteConvenio en la base de datos
        /// </summary>
        /// <param name="ClienteConvenio">El ClienteConvenio que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.ClienteConvenio ClienteConvenio)
        {
            this.Validar(ClienteConvenio);
            return SIFDatos.ClienteConvenios.Actualiza(ClienteConvenio);
        }

        /// <summary>
        /// Elimina la instancia del ClienteConvenio en la base de datos
        /// </summary>
        /// <param name="ClienteConvenio">La instancia del ClienteConvenio a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.ClienteConvenio ClienteConvenio)
        {
            try
            {
                SIFDatos.ClienteConvenios.Elimina(ClienteConvenio);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los ClienteConvenios de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de ClienteConvenios del modelo</returns>
        public BindingListView<SIFModelo.ClienteConvenio> Buscar(string propiedad, string parametro)
        {
            CatClienteConveniosList = new BindingListView<SIFModelo.ClienteConvenio>(SIFDatos.ClienteConvenios.Busca(propiedad, parametro));
            return CatClienteConveniosList;
        }



        public SIFModelo.ClienteConvenio ClientePorID(int p)
        {
            return SIFDatos.ClienteConvenios.ClienteConvenioPorID(p);
        }
    }
}
