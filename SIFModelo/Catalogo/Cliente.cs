using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo
{
    public class Cliente
    {
        public int ID
        { 
            get; 
            set; 
        }

        public string Nombre
        {
            get;
            set;
        }

        public string ApellidoPaterno
        {
            get;
            set;
        }

        public string ApellidoMaterno
        {
            get;
            set;
        }

        public Tipos.TipoCliente TipoCliente
        {
            get;
            set;
        }

        /// <summary>
        /// TIPO_DIR
        /// </summary>
        public Tipos.TipoDireccion TipoDireccion
        {
            get;
            set;
        }

        public Tipos.SiNo Convenio
        {
            get;
            set;
        }

        public DateTime? FechaUltimaCompra
        {
            get;
            set;
        }

        public decimal Descuento
        {
            get;
            set;
        }

        public Tipos.SiNo Boletinado
        {
            get;
            set;
        }

        public DateTime FechaAlta
        {
            get;
            set;
        }

        public DateTime? FechaBaja
        {
            get;
            set;
        }

        public Tipos.SiNo Activo
        {
            get;
            set;
        }

        public Tipos.SiNo LoteCaducidad
        {
            get;
            set;
        }

        public Tipos.SiNo Proveedor
        {
            get;
            set;
        }

        public Tipos.LaboratorioMayorista LaboratorioMayorista
        {
            get;
            set;
        }

        public string ReferenciaBeneficio
        {
            get;
            set;
        }

        public Tipos.SiNo SUBROGACION
        {
            get;
            set;
        }

    }
}
