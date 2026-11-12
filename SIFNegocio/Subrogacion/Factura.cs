using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Subrogacion
{
    public class Factura
    {
       
        public SIFModelo.SubRogacion.Sobrogacion Ds = new SIFModelo.SubRogacion.Sobrogacion();

        public SIFModelo.SubRogacion.Sobrogacion GetFacturas(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones, bool PrecioFijo, bool Lote, bool esIsstep = false, SIFModelo.ClienteSubrogaccion cliente = null, DateTime? fechaini = null, DateTime? fechafin = null)
        {
            if (PrecioFijo)
            {
                if (esIsstep)
                {
                    return SIFDatos.Subrogacion.Facturas.GetPF_isstep(ds, Separa, Concepto, Clave, LisRemisiones, cliente, fechaini.Value, fechafin.Value);
                }
                else
                {
                    return SIFDatos.Subrogacion.Facturas.GetPF(ds, Separa, Concepto, Clave, LisRemisiones);
                }
            }
            else if (esIsstep)
                {
                    return SIFDatos.Subrogacion.Facturas.GetPF_isstep(ds, Separa, Concepto, Clave, LisRemisiones, cliente, fechaini.Value, fechafin.Value);
                }
                else
                {
                    return SIFDatos.Subrogacion.Facturas.Get(ds, Separa, Concepto, Clave, LisRemisiones, Lote);
                }
        }

        public SIFModelo.SubRogacion.Sobrogacion GetFacturasNumber(SIFModelo.SubRogacion.Sobrogacion ds, String Separa, String Concepto, String Clave, String LisRemisiones, bool PrecioFijo, bool Lote, int ini, int fin, string Anexo, string TipoVale, SIFModelo.ClienteSubrogaccion cliente = null, DateTime? fechaini = null, DateTime? fechafin = null)
        {
            return SIFDatos.Subrogacion.Facturas.GetPF_isstep(ds, Separa, Concepto, Clave, LisRemisiones, cliente, fechaini.Value, fechafin.Value, ini, fin, Anexo, TipoVale);
        }
        public bool InsertaFacturas(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            return SIFDatos.Subrogacion.Facturas.Insert(ds);
        }

        private const int RenglonesFactura = 39;
        public bool TimbraFacturas(SIFModelo.SubRogacion.Sobrogacion ds, SIFModelo.Cliente cliente, SIFModelo.Sucursal sucursal, DateTime fechaInicio, DateTime fechaFin, DateTime periodo, String ListaRemisiones, bool es5AlMillar = false)
        {
            WebServices.FEL wsFel = new WebServices.FEL();
            /*LGS 24/03/2014 Agregado para que facture aunque no sea cliente ISSSTEP lineas 51 -54*/
            if (!Ds.FACTURA.Columns.Contains("ANEXO"))
                ds.FACTURA.Columns.Add("ANEXO", Type.GetType("System.String"));
            if (!Ds.FACTURA.Columns.Contains("TIPO_VALE"))
                ds.FACTURA.Columns.Add("TIPO_VALE", Type.GetType("System.String"));

            foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow factura in ds.FACTURA.Rows)
            {
                
                string anexo = factura["ANEXO"].ToString();
                string tipo = factura["TIPO_VALE"].ToString();
                string noFactura = factura["NUM_FACTURA"].ToString();

                /*LGS 24/03/2014 en caso de que no haya anexo ni vale (Siguientes 4 lineas) */
                if (anexo == "")
                    anexo = "1";
                if (tipo == "")
                    tipo = "A";

                int numfacturas = new SIFNegocio.Subrogacion.Factura().NumeroFacturas(fechaInicio, fechaFin, anexo, tipo, cliente.ID.ToString());

                int numRenglon = 1;
                int finRenglon = 0;

                for (int f = 1; f <= numfacturas; f++)
                {
                    finRenglon += RenglonesFactura;
                    SIFModelo.SubRogacion.Sobrogacion fSubDS = new SIFModelo.SubRogacion.Sobrogacion();
                    SIFModelo.ClienteSubrogaccion sub = new SIFNegocio.ClienteSubrogacion().ClientePorID(System.Convert.ToInt32(cliente.ID));
                    
                    //this.GetFacturasNumber(fSubDS, "", "", "", "", false, false, numRenglon, finRenglon, anexo, tipo, sub, fechaInicio, fechaFin);
                    this.GetFacturasNumber(fSubDS, "", "", "", ListaRemisiones, false, false, numRenglon, finRenglon, anexo, tipo, sub, fechaInicio, fechaFin);

                    foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow fds in fSubDS.FACTURA.Rows)
                    {
                        fds.REFERENCIA = factura.REFERENCIA + "-" + f;
                    }
                    wsFel.numeroU(Helpers.Sesion.Usuario.UsuariosID.ToString());
                 
                    wsFel.Invocar(Configuracion.Configuraciones.Factura, Configuracion.Configuraciones.Aplicacion, cliente, fSubDS, sucursal, null, es5AlMillar, periodo);

                    numRenglon = 1 + finRenglon;
                }


            }
            return true;
        }

        public bool TimbraFacturasISSTEP(SIFModelo.SubRogacion.Sobrogacion ds, SIFModelo.Cliente cliente, SIFModelo.Sucursal sucursal, DateTime fechaInicio, DateTime fechaFin, DateTime periodo, string Anexo, string TipoVale, bool es5AlMillar = false)
        {
            WebServices.FEL wsFel = new WebServices.FEL();

            //foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow factura in ds.FACTURA.Rows)
            //{
                //string anexo = factura["ANEXO"].ToString();
                //string tipo = factura["TIPO_VALE"].ToString();
                //string noFactura = factura["NUM_FACTURA"].ToString();

            ////int numfacturas = new SIFNegocio.Subrogacion.Factura().NumeroFacturas(fechaInicio, fechaFin, Anexo, TipoVale);
            // ROMA 02SEP2013
            int numfacturas = new SIFNegocio.Subrogacion.Factura().NumeroFacturas(fechaInicio, fechaFin, Anexo, TipoVale, cliente.ID.ToString()); 
            if (numfacturas == 0)
                {
                    return false;
                }

                int numRenglon = 1;
                int finRenglon = 0;

                for (int f = 1; f <= numfacturas; f++)
                {
                    finRenglon += RenglonesFactura;
                    SIFModelo.SubRogacion.Sobrogacion fSubDS = new SIFModelo.SubRogacion.Sobrogacion();
                    SIFModelo.ClienteSubrogaccion sub = new SIFNegocio.ClienteSubrogacion().ClientePorID(System.Convert.ToInt32(cliente.ID));
                    this.GetFacturasNumber(fSubDS, "", "", "", "", false, false, numRenglon, finRenglon, Anexo, TipoVale, sub, fechaInicio, fechaFin);

                    foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow fds in fSubDS.FACTURA.Rows)
                    {
                        fds.REFERENCIA = DateTime.Now.ToString("ddMMyyy") + "-" + f;
                    }

                    wsFel.Invocar(Configuracion.Configuraciones.Factura, Configuracion.Configuraciones.Aplicacion, cliente, fSubDS, sucursal, null, es5AlMillar, periodo);

                    numRenglon = 1 + finRenglon;
                    //finRenglon += RenglonesFactura;

                }


            //}
            return true;
        }

        #region ROMA 02SEP2013
        public bool TimbraFacturasISSTEP(SIFModelo.SubRogacion.Sobrogacion ds, SIFModelo.Cliente cliente, SIFModelo.Sucursal sucursal, DateTime fechaInicio, DateTime fechaFin, DateTime periodo, string Anexo, string TipoVale, string IdCliente, bool es5AlMillar = false)
        {
            WebServices.FEL wsFel = new WebServices.FEL();

            //foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow factura in ds.FACTURA.Rows)
            //{
            //string anexo = factura["ANEXO"].ToString();
            //string tipo = factura["TIPO_VALE"].ToString();
            //string noFactura = factura["NUM_FACTURA"].ToString();

            int numfacturas = new SIFNegocio.Subrogacion.Factura().NumeroFacturas(fechaInicio, fechaFin, Anexo, TipoVale, IdCliente);
            if (numfacturas == 0)
            {
                return false;
            }

            int numRenglon = 1;
            int finRenglon = 0;

            for (int f = 1; f <= numfacturas; f++)
            {
                finRenglon += RenglonesFactura;
                SIFModelo.SubRogacion.Sobrogacion fSubDS = new SIFModelo.SubRogacion.Sobrogacion();
                SIFModelo.ClienteSubrogaccion sub = new SIFNegocio.ClienteSubrogacion().ClientePorID(System.Convert.ToInt32(cliente.ID));
                this.GetFacturasNumber(fSubDS, "", "", "", "", false, false, numRenglon, finRenglon, Anexo, TipoVale, sub, fechaInicio, fechaFin);

                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow fds in fSubDS.FACTURA.Rows)
                {
                    fds.REFERENCIA = DateTime.Now.ToString("ddMMyyy") + "-" + f;
                }

                wsFel.Invocar(Configuracion.Configuraciones.Factura, Configuracion.Configuraciones.Aplicacion, cliente, fSubDS, sucursal, null, es5AlMillar, periodo);

                numRenglon = 1 + finRenglon;
                //finRenglon += RenglonesFactura;

            }


            //}
            return true;
        }

        #endregion ROMA 02SEP2013

        public SIFModelo.SubRogacion.Sobrogacion.CAMPOSCLIENTEFACTRow GetCampos(String ClienteID)
        {
            return SIFDatos.Subrogacion.Facturas.GetCampos(ClienteID);
        }
        public bool ActualizaDatosFijos(String Separa, String Concepto, String Clave, String TipoPagoID, String NumCta, String cincoMillar, String LoteSerie, String Detalle, String ClienteID)
        {
            return SIFDatos.Subrogacion.Facturas.ActualizaDatosFijos(Separa, Concepto, Clave, TipoPagoID, NumCta, cincoMillar, LoteSerie, Detalle, ClienteID);
        }

        public bool ActualizaRemisiones(String Remisiones, String NoFolio, String UccID)
        {
            return SIFDatos.Subrogacion.Facturas.ActualizaRemisiones(Remisiones, NoFolio, UccID);
        }


        public SIFModelo.SubRogacion.Sobrogacion Update(SIFModelo.SubRogacion.Sobrogacion ds)
        {
            return SIFDatos.Subrogacion.Facturas.Update(ds);
        }

        #region ROMA 02SEP2013
        public int NumeroFacturas(DateTime dateTime, DateTime dateTime_2, string anexo, string vale, string IdCliente)
        {
            return SIFDatos.Subrogacion.Facturas.NumeroFacturas(dateTime, dateTime_2, vale, System.Convert.ToInt32(anexo), IdCliente);
        }

        public DataSet GetReportes(DateTime dateTime, DateTime dateTime_2, string anexo, string vale, int rowIni, int rowFin, string IdCliente)
        {
            return SIFDatos.Subrogacion.Facturas.sp_get_Reportes(dateTime, dateTime_2, IdCliente, vale, System.Convert.ToInt32(anexo), rowIni, rowFin);
        }

        #endregion ROMA 02SEP2013

        public int NumeroFacturas(DateTime dateTime, DateTime dateTime_2, string anexo, string vale)
        {
            return SIFDatos.Subrogacion.Facturas.NumeroFacturas(dateTime, dateTime_2, vale, System.Convert.ToInt32(anexo));
        }

        public DataSet GetReportes(DateTime dateTime, DateTime dateTime_2, string anexo, string vale, int rowIni, int rowFin)
        {
            return SIFDatos.Subrogacion.Facturas.sp_get_Reportes(dateTime, dateTime_2, vale, System.Convert.ToInt32(anexo), rowIni,rowFin);
        }
        public String insertaDatosParaFactura(
                       //  int proveedorId,                    
                         String[] Clavedelproducto,
                         Decimal[] Piezas,
                         String[] Descripcion,
                         Decimal[] Costounitario,
                         Decimal[] Iva,                       
                         Decimal[] Precio_vta_unitario
            )
        {
            return SIFDatos.Subrogacion.Facturas.insertaDatosParaFactura(
                           // proveedorId,                         
                            Clavedelproducto,
                            Piezas,
                            Descripcion,
                            Costounitario,
                            Iva,
                            Precio_vta_unitario);
        }


        public String procesaGenCompratrasp_c(int proveedorId, string usuarioid)
        {
            return SIFDatos.Subrogacion.Facturas.procesaGenCompratrasp_c(proveedorId, usuarioid);
        }



    }

}
