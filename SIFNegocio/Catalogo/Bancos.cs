using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Bancos
    {
        public BindingListView<SIFModelo.Banco> CatBancosList;

        private bool Validar(SIFModelo.Banco banco)
        {
            if (string.IsNullOrEmpty(banco.Nombre) || string.IsNullOrWhiteSpace(banco.Nombre))
            {
                MessageBox.Show("El nombre del banco es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un banco en la base de datos
        /// </summary>
        /// <param name="banco">Representa una instancia del banco</param>
        /// <returns>El banco ingresado a la base de datos</returns>
        public SIFModelo.Banco Nuevo(SIFModelo.Banco banco)
        {
            if (Validar(banco))
            {
                if (!SIFDatos.Bancos.Inserta(banco))
                {
                   MessageBox.Show("El banco no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return banco;
        }

        /// <summary>
        /// Modifica el banco en la base de datos
        /// </summary>
        /// <param name="banco">El banco que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Banco banco)
        {
            this.Validar(banco);
            return SIFDatos.Bancos.Actualiza(banco);
        }

        /// <summary>
        /// Elimina la instancia del banco en la base de datos
        /// </summary>
        /// <param name="banco">La instancia del banco a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Banco banco)
        {
            try
            {
                SIFDatos.Bancos.Elimina(banco);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los bancos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de bancos del modelo</returns>
        public BindingListView<SIFModelo.Banco> Buscar(string propiedad, string parametro)
        {
            CatBancosList = new BindingListView<SIFModelo.Banco>(SIFDatos.Bancos.Busca(propiedad, parametro));
            return CatBancosList;
        }


    }
}
