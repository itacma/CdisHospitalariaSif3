using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Devolucion
    {
        public string DevolucionID
        {
            get;
            set;
        }

        public int SucursalID
        {
            get;
            set;
        }

        public int ClienteID
        {
            get;
            set;
        }

        public DateTime FechaDevolucion
        {
            get;
            set;
        }

        public string ReferenciaVenta
        {
            get;
            set;
        }

        public string Comentario
        {
            get;
            set;
        }

        public decimal TotalDevolucion
        {
            get;
            set;
        }

        public SIFModelo.Tipos.ActivoDevolucion Activo
        {
            get;
            set;
        }

        public int UsuarioID
        {
            get;
            set;
        }

        public int AutorizaID
        {
            get;
            set;
        }


        public List<SIFModelo.DevolucionDetalle> Detalles
        {
            get;
            set;
        }

        public decimal Impuesto
        {
        get;set;
        }
        public decimal SubTotal
        {
            get;
            set;
        }

        public string CantidadConLetra
        {
            get;
            set;
        }

        public decimal Descuento { get; set; }
    }           
    }
