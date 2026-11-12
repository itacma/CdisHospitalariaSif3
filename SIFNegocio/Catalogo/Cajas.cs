using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Cajas
    {
        public BindingListView<SIFModelo.Caja> CatCajasList;

        private bool Validar(SIFModelo.Caja Caja)
        {
            //if (string.IsNullOrEmpty(Caja.Nombre) || string.IsNullOrWhiteSpace(Caja.Nombre))
            //{
            //    MessageBox.Show("El nombre del Caja es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un Caja en la base de datos
        /// </summary>
        /// <param name="Caja">Representa una instancia del Caja</param>
        /// <returns>El Caja ingresado a la base de datos</returns>
        public SIFModelo.Caja Nuevo(SIFModelo.Caja Caja)
        {
            if (Validar(Caja))
            {
                if (!SIFDatos.Cajas.Inserta(Caja))
                {
                   MessageBox.Show("El Caja no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Caja;
        }

        /// <summary>
        /// Modifica el Caja en la base de datos
        /// </summary>
        /// <param name="Caja">El Caja que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Caja Caja)
        {
            this.Validar(Caja);
            return SIFDatos.Cajas.Actualiza(Caja);
        }

        /// <summary>
        /// Elimina la instancia del Caja en la base de datos
        /// </summary>
        /// <param name="Caja">La instancia del Caja a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Caja Caja)
        {
            try
            {
                SIFDatos.Cajas.Elimina(Caja);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Cajas de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Cajas del modelo</returns>
        public BindingListView<SIFModelo.Caja> Buscar(string propiedad, string parametro)
        {
            List<SIFModelo.Caja> cajas = SIFDatos.Cajas.Busca(propiedad, parametro);
            SIFNegocio.Sucursales sucursalN = new Sucursales();

            foreach (SIFModelo.Caja caja in cajas)
            {
                SIFModelo.Sucursal sucursalM = sucursalN.SucursalPorID(caja.SucursalID);

                if (sucursalM != null)
                {
                    caja.SucursalNombre = sucursalM.Nombre;
                }
            }

            CatCajasList = new BindingListView<SIFModelo.Caja>(cajas);
            return CatCajasList;
        }

        public BindingListView<SIFModelo.Caja> BuscarPorSucursal( SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Caja> cajas = SIFDatos.Cajas.BuscarPorSucursalActivo(sucursal);
            SIFNegocio.Sucursales sucursalN = new Sucursales();

            foreach (SIFModelo.Caja caja in cajas)
            {
                SIFModelo.Sucursal sucursalM = sucursalN.SucursalPorID(caja.SucursalID);

                if (sucursalM != null)
                {
                    caja.SucursalNombre = sucursalM.Nombre;
                }
            }

            CatCajasList = new BindingListView<SIFModelo.Caja>(cajas);
            return CatCajasList;
        }

        public bool IniciaTurno(SIFModelo.Caja caja)
        {
            //if (!SIFDatos.TurnoIniciado(caja))
            //{
            return SIFDatos.Cajas.IniciaTurno(caja);
            //}
        }

        public BindingListView<SIFModelo.Caja> ControlBuscar(SIFModelo.Sucursal sucursal, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SIFModelo.Caja> cajas = SIFDatos.Cajas.BuscaControl(sucursal, fechaInicio, fechaFin);

            this.CatCajasList = new BindingListView<SIFModelo.Caja>(cajas);
            return CatCajasList;
        }

        public SIFModelo.Caja ControlCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.ControlControlCaja(sucursal, caja);
        }

        public BindingListView<SIFModelo.Caja> BuscarPorSucursalActivo(SIFModelo.Sucursal sucursal)
        {
            List<SIFModelo.Caja> cajas = SIFDatos.Cajas.BuscarPorSucursalActivo(sucursal);

            this.CatCajasList = new BindingListView<SIFModelo.Caja>(cajas);
            return CatCajasList;
        }
        public SIFModelo.Tipos.AbiertoCerrado StatusCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.StatusCaja(sucursal, caja);
        }
        public bool Caja_abierta(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.CajaAbierta(sucursal, caja);
        }
        
        public SIFModelo.Caja CajaPorID(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.CajaPorID(sucursal, caja);
        }

        public int UsuarioCaja(SIFModelo.Sucursal sucursal, SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.UsuarioCaja(sucursal, caja);
        }
        public bool ModificarControlCaja(SIFModelo.Caja Caja)
        {
            Caja.FechaCierre = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            Caja.Abierto = SIFModelo.Tipos.AbiertoCerrado.CERRADO;
            return SIFDatos.Cajas.ActualizaControl(Caja);
        }

      public  SIFModelo.Ventas.CorteCajaDataSet DataSet = new SIFModelo.Ventas.CorteCajaDataSet();

        public SIFModelo.Ventas.CorteCajaDataSet.V_VALORESDataTable BuscaValores(SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.BuscaValores(caja, caja.FechaApertura.ToString("dd/MM/yyyy HH:mm:ss"), caja.FechaCierre.Value.ToString("dd/MM/yyyy HH:mm:ss"), DataSet);
        }

        public object BuscaValoresCondensado(SIFModelo.Caja caja)
        {
            return SIFDatos.Cajas.BuscaValoresCondensado(caja, caja.FechaApertura.ToString("dd/MM/yyyy HH:mm:ss"),caja.FechaCierre.Value.ToString("dd/MM/yyyy HH:mm:ss"), DataSet);
        }


    }
}
