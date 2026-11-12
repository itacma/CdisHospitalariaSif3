using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class ValeSubrogacion
    {
        public List<SIFModelo.Valesubrogacion> ValesSubrogacionList;

        private bool Validar(SIFModelo.Valesubrogacion Valesubrogacion)
        {
            //if (string.IsNullOrEmpty(Valesubrogacion.Nombre) || string.IsNullOrWhiteSpace(Valesubrogacion.Nombre))
            //{
            //    MessageBox.Show("El nombre del Valesubrogacion es Obligatorio");
            //    return false;
            //}
            DateTime now = SIFDatos.Configuracion.FechaServidor();
            TimeSpan ts = now.Date - Valesubrogacion.FechaVale;
            int differenceInDays = ts.Hours;
            if (ts.Days >= 2)
            {
                MessageBoxButtons button = MessageBoxButtons.YesNoCancel;

                DialogResult result = MessageBox.Show("Vale próximo a caducar. El vale es de hace " + ts.Days + " dias. ¿Seguro que desea generar la venta?", "Vale próximo a caducar", button, MessageBoxIcon.Warning);

                if (result == System.Windows.Forms.DialogResult.No || result == System.Windows.Forms.DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha generado la nota de venta");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Crea un Valesubrogacion en la base de datos
        /// </summary>
        /// <param name="Valesubrogacion">Representa una instancia del Valesubrogacion</param>
        /// <returns>El Valesubrogacion ingresado a la base de datos</returns>
        public SIFModelo.Valesubrogacion Nuevo(SIFModelo.Valesubrogacion Valesubrogacion)
        {
            if (Validar(Valesubrogacion))
            {
                Valesubrogacion.SucursalId = Helpers.Sesion.Sucursal.SucursalesID;
                if (!SIFDatos.ValesSubrogacion.Inserta(Valesubrogacion))
                {
                   MessageBox.Show("El Valesubrogacion no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Valesubrogacion;
        }

        /// <summary>
        /// Modifica el Valesubrogacion en la base de datos
        /// </summary>
        /// <param name="Valesubrogacion">El Valesubrogacion que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Valesubrogacion Valesubrogacion)
        {
            this.Validar(Valesubrogacion);
            return SIFDatos.ValesSubrogacion.Actualiza(Valesubrogacion);
        }











        public SIFModelo.Valesubrogacion ValePorNumRemision(SIFModelo.Valesubrogacion vale)
        {
            return SIFDatos.ValesSubrogacion.BuscarPorRemisionActivo(vale);
        }

        public List<SIFModelo.Valesubrogacion> Buscar(string propiedadBusqueda, string parametros)
        {
            this.ValesSubrogacionList = SIFDatos.ValesSubrogacion.Buscar(parametros);
            return ValesSubrogacionList;
        }
    }
}
