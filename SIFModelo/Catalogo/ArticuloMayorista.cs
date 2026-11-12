using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Catalogo
{
    public class ArticuloMayorista
    {
        public string ArticuloID
        {
            get;
            set;
        }

        public string CodigoNadro
        {
            get;
            set;
        }

        public string CodigoSaba
        {
            get;
            set;
        }

        public string CodigoDrogueros
        {
            get;
            set;
        }

        public string Tipo1
        {
            get;
            set;
        }

        public string Tipo2
        {
            get;
            set;
        }

        public string Tipo3
        {
            get;
            set;
        }

        public string TipoMedicamento
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int ProveedorID
        {
            get;
            set;
        }

        public char Pedit
        {
            get;
            set;
        }

        public DateTime FechaActualizacion
        {
            get;
            set;
        }

        public char EstadoCompraSABA
        {
            get;
            set;
        }

        public char EstadoCompraNadro
        {
            get;
            set;
        }

        public char EstadoCompraDrogueros
        {
            get;
            set;
        }

        public decimal DescuentoSABA
        {
            get;
            set;
        }

        public decimal DescuentoNADRO
        {
            get;
            set;
        }

        public decimal DescuentoDrogueros
        {
            get;
            set;
        }

        public decimal DescuentoAdicionalSABA
        {
            get;
            set;
        }

        public decimal DescuentoAdicionalNadro
        {
            get;
            set;
        }

        public decimal DescuentoAdicionalDrogueros
        {
            get;
            set;
        }

        public int CantidadMinimaCompra
        {
            get;
            set;
        }

        public int CantidadComprar
        {
            get;
            set;
        }


        public decimal PorcentajeIESPS
        {
            get;
            set;
        }

        public decimal PrecioFarmacia
        {
            get;
            set;
        }

        public decimal PrecioPublico
        {
            get;
            set;
        }


    }
}
