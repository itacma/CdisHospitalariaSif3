using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class ListDerechohabientes
    {
        public BindingListView<SIFModelo.hupBnf> CatDerechohabientes;

        SIFModelo.hupBnf Derechohabiente;// = new SIFModelo.hupBnf();
        SIFModelo.hupMed medico;
        SIFModelo.hupDReceta datosreceta;
        SIFModelo.hupEmp empleado;

        /*private bool Validar(SIFModelo.hupBnf Derechohabiente)
        {
            if (string.IsNullOrEmpty(TipoDevolucion.Nombre) || string.IsNullOrWhiteSpace(TipoDevolucion.Nombre))
            {
                MessageBox.Show("El nombre del TipoDevolucion es Obligatorio");
                return false;
            }


            return true;
        }*/

        /// <summary>
        /// Crea un TipoDevolucion en la base de datos
        /// </summary>
        /// <param name="TipoDevolucion">Representa una instancia del TipoDevolucion</param>
        /// <returns>El TipoDevolucion ingresado a la base de datos</returns>
       /* public SIFModelo.TipoDevolucion Nuevo(SIFModelo.TipoDevolucion TipoDevolucion)
        {
            if (Validar(TipoDevolucion))
            {
                if (!SIFDatos.TipoDevolucions.Inserta(TipoDevolucion))
                {
                   MessageBox.Show("El TipoDevolucion no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return TipoDevolucion;
        }*/

        /// <summary>
        /// Modifica el TipoDevolucion en la base de datos
        /// </summary>
        /// <param name="TipoDevolucion">El TipoDevolucion que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
       /* public bool Modificar(SIFModelo.TipoDevolucion TipoDevolucion)
        {
            this.Validar(TipoDevolucion);
            return SIFDatos.TipoDevolucions.Actualiza(TipoDevolucion);
        }
        */
        /// <summary>
        /// Elimina la instancia del TipoDevolucion en la base de datos
        /// </summary>
        /// <param name="TipoDevolucion">La instancia del TipoDevolucion a eliminar</param>
        /// <returns></returns>
       /* public bool Eliminar(SIFModelo.TipoDevolucion TipoDevolucion)
        {
            try
            {
                SIFDatos.TipoDevolucions.Elimina(TipoDevolucion);
            }
            catch
            {
                return false;
            }
            return true;
        }*/

        /// <summary>
        /// Selecciona los TipoDevolucions de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de TipoDevolucions del modelo</returns>
      /*  public BindingListView<SIFModelo.TipoDevolucion> Buscar(string propiedad, string parametro)
        {
            CatTipoDevolucionsList = new BindingListView<SIFModelo.TipoDevolucion>(SIFDatos.TipoDevolucions.Busca(propiedad, parametro));
            return CatTipoDevolucionsList;
        }*/
        public BindingListView<SIFModelo.hupBnf> Buscar(string id)
        {
            CatDerechohabientes = new BindingListView<SIFModelo.hupBnf>(SIFDatos.Derechohabientes.Busca(id));
            return CatDerechohabientes;
        }
        public SIFModelo.hupMed BuscarM(string id)
        {
            //Derechohabiente = new SIFModelo.hupBnf(SIFDatos.Derechohabientes.BuscaB(id));
            medico = SIFDatos.Derechohabientes.BuscaM(id);
            return medico;
        }

        public SIFModelo.hupDReceta BuscarRecet(string receta)
        {
            //Derechohabiente = new SIFModelo.hupBnf(SIFDatos.Derechohabientes.BuscaB(id));
            datosreceta = SIFDatos.Derechohabientes.BuscaReceta(receta);
            return datosreceta;
        }
        public SIFModelo.hupEmp Buscarempleado(string empl)
        {
            //Derechohabiente = new SIFModelo.hupBnf(SIFDatos.Derechohabientes.BuscaB(id));
            empleado = SIFDatos.Derechohabientes.BuscaEmpleado(empl);
            return empleado;
        }

        public SIFModelo.hupBnf BuscarB(string id)
        {
            //Derechohabiente = new SIFModelo.hupBnf(SIFDatos.Derechohabientes.BuscaB(id));
            Derechohabiente =  SIFDatos.Derechohabientes.BuscaB(id);
            return Derechohabiente;
        }

        public void guardaR(SIFModelo.hupDReceta receta)
        {
            //Derechohabiente = new SIFModelo.hupBnf(SIFDatos.Derechohabientes.BuscaB(id));
            datosreceta =  SIFDatos.Derechohabientes.guardaReceta(receta);
           // return datosreceta;
        }


     /*   public BindingListView<SIFModelo.TipoDevolucion> BuscarCompras()
        {
            CatTipoDevolucionsList = new BindingListView<SIFModelo.TipoDevolucion>(SIFDatos.TipoDevolucions.BuscaCompra());
            return CatTipoDevolucionsList;
        }

        public BindingListView<SIFModelo.TipoDevolucion> BuscarTraspasos()
        {
            CatTipoDevolucionsList = new BindingListView<SIFModelo.TipoDevolucion>(SIFDatos.TipoDevolucions.BuscaTraspaso());
            return CatTipoDevolucionsList;
        }

        public BindingListView<SIFModelo.TipoDevolucion> BuscarVentas()
        {
            CatTipoDevolucionsList = new BindingListView<SIFModelo.TipoDevolucion>(SIFDatos.TipoDevolucions.BuscaVenta());
            return CatTipoDevolucionsList;
        }*/
    }
}
