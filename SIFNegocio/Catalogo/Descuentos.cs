using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Descuentos
    {
        public BindingListView<SIFModelo.Descuento> CatDescuentosList;

        private bool Validar(SIFModelo.Descuento Descuentos)
        {
            if (string.IsNullOrEmpty(Descuentos.Nombre) || string.IsNullOrWhiteSpace(Descuentos.Nombre))
            {
                MessageBox.Show("El nombre del Descuentos es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un Descuentos en la base de datos
        /// </summary>
        /// <param name="Descuentos">Representa una instancia del Descuentos</param>
        /// <returns>El Descuentos ingresado a la base de datos</returns>
        public SIFModelo.Descuento Nuevo(SIFModelo.Descuento Descuentos)
        {
            if (Validar(Descuentos))
            {
                if (!SIFDatos.Descuentos.Inserta(Descuentos))
                {
                   MessageBox.Show("El Descuentos no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Descuentos;
        }

        /// <summary>
        /// Modifica el Descuentos en la base de datos
        /// </summary>
        /// <param name="Descuentos">El Descuentos que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Descuento Descuentos)
        {
            this.Validar(Descuentos);
            return SIFDatos.Descuentos.Actualiza(Descuentos);
        }

        /// <summary>
        /// Elimina la instancia del Descuentos en la base de datos
        /// </summary>
        /// <param name="Descuentos">La instancia del Descuentos a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Descuento Descuentos)
        {
            try
            {
                SIFDatos.Descuentos.Elimina(Descuentos);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Descuentoss de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Descuentoss del modelo</returns>
        public BindingListView<SIFModelo.Descuento> Buscar(string propiedad, string parametro)
        {
            CatDescuentosList = new BindingListView<SIFModelo.Descuento>(SIFDatos.Descuentos.Busca(propiedad, parametro));
            return CatDescuentosList;
        }



        public  SIFModelo.Descuento DescuentoPorID(decimal p)
        {
            return  SIFDatos.Descuentos.DescuentoPorID(p);
        }
                
        public SIFModelo.Descuento InsertarOActualizarEmpleadoMAPFRE(SIFModelo.Descuento Descuentos)
        {
            bool resultado = SIFDatos.Descuentos.InsertarOActualizarEmpleadoMAPFRE(
                    Descuentos.DescuentoId,
                    Descuentos.Nombre,
                    Descuentos.NoEmpleado,
                    Descuentos.FechaNacimiento,
                    Descuentos.FechaAlta,
                    Descuentos.FechaInicio,
                    Descuentos.FechaFin,
                    Descuentos.UltUsuarioId,
                    Descuentos.ActivoMapfre
                    );
            return Descuentos;
        }

        public void DesactivarEmpleadosMAPFRE(List<string> listaNoEmpleados)
        {
            SIFDatos.Descuentos.DesactivarEmpleadosMAPFRE(listaNoEmpleados);
        }
                
        public bool VerificarExistenciaEmpleado(string noEmpleado)
        {
            return SIFDatos.Descuentos.VerificarExistenciaEmpleado(noEmpleado);
        }

        public void ActualizarFechaEmpleado(string noEmpleado)
        {
            SIFDatos.Descuentos.ActualizarFechaEmpleado(noEmpleado);
        }

    }
}
