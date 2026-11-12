using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Inventarios
{
    public class MovimientoInventario
    {
        public int ID
        {
            get;
            set;
        }

        public string ArticuloID
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public int Existencias
        {
            get;
            set;
        }

        public int ExistenciasMinimas
        {
            get;
            set;
        }

        public int ExistenciasMaximas
        {
            get;
            set;
        }

        public int PuntoDeReorden
        {
            get;
            set;
        }

        public int InventarioFisico
        {
            get;
            set;
        }

        public DateTime UltimaModificacion
        {
            get;
            set;
        }

        public DateTime UltimaEntrada
        {
            get;
            set;
        }

        public DateTime UltimaSalida
        {
            get;
            set;
        }

        public decimal UltimoCosto
        {
            get;
            set;
        }

        public decimal CostoPromedio
        {
            get;
            set;
        }

        public decimal PEPS
        {
            get;
            set;
        }

        public decimal UEPS
        {
            get;
            set;
        }

        public DateTime FechaInventarioFisico
        {
            get;
            set;
        }

        public string Ubicacion
        {
            get;
            set;
        }

        public int ApartadoVentas
        {
            get;
            set;
        }

        public char TipoMovimiento
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }

        public int Cantidad
        {
            get;
            set;
        }

    }
}
