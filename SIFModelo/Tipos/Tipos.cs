using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Tipos
{
    /// <summary>
    /// Clave utilizada al momento de facturar o realizar una consulta a FEL
    /// </summary>
    public enum ClaveCFDI : sbyte { FAC, HON, ARR, PAG, CAR, CRE, DEV, POR }

    /// <summary>
    /// Contiene si un valor es Si o No y en base de datos con el valor ascii 'S' o 'N'
    /// </summary>
    public enum SiNo : sbyte { NO = (sbyte)'N', SI = (sbyte)'S', GLOBAL = (sbyte)'G' }

    public enum ComprarConMayorista : sbyte { MAYORISTA = (sbyte)'M', DIRECTO = (sbyte)'D', OTRO = (sbyte)'O' }

    public enum SiNoNadro : sbyte { NO = (sbyte)'N', SI = (sbyte)'S', CERRADA = (sbyte)'C' }

    public enum QuejaSug : sbyte { Queja = (sbyte)'Q', Sugerencia = (sbyte)'S' }

    public enum AbiertoCerrado : sbyte { ABIERTO = (sbyte)'A', CERRADO = (sbyte)'C' }

    public enum StatusVenta : sbyte { GENERADA = (sbyte)'G', PAGADA = (sbyte)'P', CANCELADA = (sbyte)'C', TODAS = (sbyte)'T', ERROR = (sbyte)'E', DEVUELTA = (sbyte)'D' }

    /// <summary>
    /// Lista los tipos de usuarios que puede haber en el sistema
    /// </summary>
    public enum TipoUsuario : sbyte { ADMINISTRATIVO = (sbyte)'A', VENDENDOR = (sbyte)'V', CAJERO = (sbyte)'C', SUPERVISOR = (sbyte)'S', ALMACENISTA = (sbyte)'M', DISTRIBUIDOR = (sbyte)'D' }

    /// <summary>
    /// Genero de persona o sexo
    /// </summary>
    public enum Genero : sbyte { MASCULINO = (sbyte)'M', FEMENIMO = (sbyte)'F' }

    /// <summary>
    /// Tipos de transacciones en devoluciones
    /// </summary>
    public enum CompraVenta : sbyte { COMPRA = (sbyte)'C', VENTA = (sbyte)'V', AMBOS = (sbyte)'A', TRASPASO = (sbyte)'T' }

    /// <summary>
    /// Turnos de laborales
    /// </summary>
    public enum Turno : sbyte { MATUTINO = (sbyte)'M', VESPERTINO = (sbyte)'V', NOCTURNO = (sbyte)'N' }

    /// <summary>
    /// Tipo de Movimiento de inventario
    /// </summary>
    public enum Movimiento : sbyte { ENTRADA = (sbyte)'E', SALIDA = (sbyte)'S', CONVERSION = (sbyte)'C' }

    /// <summary>
    /// Tipos de consulta que realiza el médico 'CA' 'OF' 'HO' 'CE' 'NX'
    /// </summary>
    //public enum Consulta : sbyte { CASA = (sbyte)'C', OFICINA = (sbyte)'O', HOSPITAL = (sbyte)'H', CELULAR = (sbyte)'E', NEXTEL = (sbyte)'N' }

    /// <summary>
    /// Condiciones de venta
    /// </summary>
    public enum CondicionVenta : sbyte { CREDITO = (sbyte)'C', EFECTIVO = (sbyte)'E', AMBOS = (sbyte)'A' }

    /// <summary>
    /// TIPO DE CLIENTE FISCAL
    /// </summary>
    public enum TipoCliente : sbyte { FISICA = (sbyte)'F', MORAL = (sbyte)'M' }

    /// <summary>
    /// Establece el tipo de cliente
    /// </summary>
    public enum LaboratorioMayorista : sbyte { LABORATORIO = (sbyte)'L', MAYORISTA = (sbyte)'M', NINGUNO = (sbyte)'N' }

    public enum TipoCotizacion : sbyte { CONVENIO = (sbyte)'M', VENTA = (sbyte)'V', CALLCENTER = (sbyte)'C', SUBRROGACION = (sbyte)'S' }

    public enum TipoActivoControlado : sbyte { CANCELADA = (sbyte)'C', ESCANEADA_EN_MOSTRADOR = (sbyte)'M', PAGADA = (sbyte)'P', GENERADA = (sbyte)'S' }

    public enum ActivoDevolucion : sbyte { ABIERTA = (sbyte)'A', CERRADA = (sbyte)'C', NO_PROCEDE = (sbyte)'X' }

    public enum TipoClienteSub : sbyte { Licitacion= (sbyte)'1', Licitacion_Vta_directa = (sbyte)'2', Venta_Subrogacion = (sbyte)'3' }

    public enum TipoAplicadoA : sbyte { COSTO = (sbyte)'C', FLEMING = (sbyte)'F' }

    public enum TipoStatusMayorista : sbyte { FALTANTE = (sbyte)'F', SIN_EXISTENCIA = (sbyte)'E', DESCONTINUADO = (sbyte)'D', COMPRA = (sbyte)'C', NO_COMPRAR = (sbyte)'X', AGOTADO = (sbyte)'A', CODIGO = (sbyte)'N', TRANSFER = (sbyte)'T' } 
}
