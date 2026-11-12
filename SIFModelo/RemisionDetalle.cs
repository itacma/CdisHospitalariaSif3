using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class RemisionDetalle
    {

        public int SucursalID
        {
            get;
            set;
        }

        public string NumeroRemision
        {
            get;
            set;
        }

        public int NumeroPartida
        {
            get;
            set;
        }

        public string ArticuloID
        {
            get;
            set;
        }

        public string Nombre1
        {
            get;
            set;
        }

        public string Nombre2
        {
            get;
            set;
        }

        public string FechaEntrega
        {
            get;
            set;
        }

        public int CantidadRemision
        {
            get;
            set;
        }

        /// <summary>
        /// NADRO PRECIO POS
        /// </summary>
        public decimal Precio
        {
            get;
            set;
        }

        public string FolioControlado
        {
            get;
            set;
        }

        public decimal IVA
        {
            get;
            set;
        }

        public decimal PorcentajeIVA
        {
            get;
            set;
        }

        public int ImpuestoID
        {
            get;
            set;
        }

        public int DescuentoID
        {
            get;
            set;
        }

        public decimal PrecioCosto
        {
            get;
            set;
        }

        public int PaqueteID
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public Tipos.SiNo BeneficioProveedor
        {
            get;
            set;
        }


        public string ReferenciaNADRO
        {
            get;
            set;
        }

        public int PiezasPagadas{ get; set; }

        public int PiezasGratis { get; set; }

        public int PiezasAcumuladas { get; set; }

        public decimal PrecioProveedor { get; set; }

        public decimal MontoDescuento { get; set; }

        public decimal PorcentajeDescuento { get; set; }

        public string Mensaje { get; set; }

        public string Lote { get; set; }

        public DateTime? Caducidad { get; set; }

        public long TipoPrecioDescuento { get; set; }

        public bool Validado { get; set; }

        public int PiezasPendientes { get; set; }

        public decimal PrecioDescontado { get; set; }

        public int PiezasPedidas { get; set; }

        public Controlado OFolioControlado { get; set; }

        public int RefOferta { get; set; }

        public string CODIGO_CLI { get; set; }
        public int CODIGO_CLI_ID { get; set; }

        public string TIPO_MEDICAMENTO_CVE { get; set; }

        public string Unidad { get; set; }
    }
}
