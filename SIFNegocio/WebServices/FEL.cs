using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using System.Xml.XPath;
using DevComponents.DotNetBar;
using System.Data;
using System.Windows.Forms;

namespace SIFNegocio.WebServices
{
    public class FEL
    {
        public string usuarioInvoca = "";

        public void numeroU(string num)
        {
            usuarioInvoca = num;
        }
        //public bool Invocar(SIFModelo.Configuracion.Factura configuracion, SIFModelo.Configuracion.Aplicacion email, SIFModelo.Cliente cliente, SIFModelo.SubRogacion.Sobrogacion Facturas, SIFModelo.Sucursal sucursal)
        //{
        //    WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
        //    WS_FEL.ArrayOfString Respuesta = new WS_FEL.ArrayOfString();

        //    string XMLFile = remision.NumeroRemision + " " + remision.FechaVenta.ToString("ddMMyy") + " - " + sucursal.SucursalID;

        //    //SrvCFDI. (Usuario, Receptor, CFDI, Etiqueta, Concepto, Aduana, ImpRet, ImpTra, ImpRetL, ImpTraL);
        //    SIFNegocio.Clientes LogicaCli;
        //    SIFModelo.DireccionCliente Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);



        //    SIFModelo.Moneda moneda = new SIFNegocio.Monedas().MonedaPorID(0);

        //    SIFModelo.Impuesto impuesto = new SIFModelo.Impuesto(); // new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);


        //    WS_FEL.ArrayOfString Usuario = new WS_FEL.ArrayOfString();
        //    Usuario.Add(configuracion.RFCEmisor);
        //    Usuario.Add(configuracion.UsuarioFEL);
        //    Usuario.Add(configuracion.PasswordFEL);


        //    // Receptor
        //    WS_FEL.ArrayOfString Receptor = new WS_FEL.ArrayOfString();

        //    Receptor.Add(cliente.Nombre);
        //    Receptor.Add(""); // OPCIONAL
        //    Receptor.Add(Direccion.Telefono);
        //    Receptor.Add(Direccion.Email);
        //    Receptor.Add(Direccion.RFC); //"XAXX010101000"
        //    Receptor.Add(cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno);
        //    Receptor.Add(Direccion.Calle); // CALLE
        //    Receptor.Add(Direccion.NumeroExterior); // NO EXTERIOR
        //    Receptor.Add(Direccion.NumeroInterior); // NO. INTERIOR
        //    Receptor.Add(Direccion.Colonia); // COLONIA
        //    Receptor.Add(""); // LOCALIDAD
        //    Receptor.Add(""); // REFERENCIA
        //    Receptor.Add(Direccion.Municipio); // MPIO
        //    System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("ES-mx").TextInfo;
        //    var estadoLetraCapital = ti.ToTitleCase(Direccion.Ciudad.ToLower());
        //    Receptor.Add(estadoLetraCapital); // EDO DE LA REP
        //    Receptor.Add("México"); // PAIS
        //    Receptor.Add(Direccion.CodigoPostal); // CP

        //    // DATOS GENERALES CFDI
        //    WS_FEL.ArrayOfString CFDI = new WS_FEL.ArrayOfString();
        //    SIFModelo.TipoCambio cambio = new SIFNegocio.TipoCambios().BuscarPorID(pago.TipoCambioID);

        //    if (cambio == null)
        //    {
        //        cambio = new SIFModelo.TipoCambio();
        //        cambio.Factor = 1;
        //        cambio.VigenciaInicio = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
        //    }

        //    CFDI.Add("FAC");
        //    CFDI.Add(configuracion.TipoPago);//Forma de pago
        //    CFDI.Add(""); // PARCIALIDADES
        //    CFDI.Add(""); // CONDICIONES DE PAGO
        //    CFDI.Add(tipoPago.Nombre); // METODO PAGO
        //    CFDI.Add(remision.Descuento.ToString("0.00")); // DESCUENTO
        //    CFDI.Add("0.00"); // PORCENTAJE DESCTO
        //    CFDI.Add(""); // MOTIVO DESCTO
        //    CFDI.Add("MXN"); //MONEDA
        //    CFDI.Add(""); // TIPO CAMBIO
        //    CFDI.Add(""); // FECHA TIPO CAMBIO
        //    CFDI.Add("0.00"); // TOTAL IMPUESTO RETENIDO
        //    CFDI.Add(SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.Impuesto, 2).ToString("0.00")); // TOTAL IMPUESTO TRASLADADO
        //    CFDI.Add(SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.SubTotal, 2).ToString("0.00")); // SUBTOTAL
        //    CFDI.Add(SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.Total, 2).ToString("0.00")); // TOTAL COMPROBANTE
        //    CFDI.Add(remision.ImporteLetra); // TOTAL CON LETRA
        //    CFDI.Add(sucursal.Ciudad); // LUGAR DE EXPEDICION
        //    CFDI.Add(pago.DocumentoPago); // NUM CTA PAGO
        //    CFDI.Add(""); // FOLIO FISCAL ORIGINAL
        //    CFDI.Add(""); // SERIE FOLIOI FISCAL
        //    CFDI.Add(""); // FECHA FOLIO FISCAL
        //    CFDI.Add(""); // MONTO FOLIO FISCAL

        //    //NUMERO DE REMISION
        //    string NoRemision = remision.NumeroRemision;
        //    if (NoRemision == null)
        //    {
        //        //if (esFacturaGlobal)
        //        //{
        //        //    //SIFModelo.RemisionDetalle detallePrimero = Detalles.First();
        //        //    //SIFModelo.RemisionDetalle detalleUltimo = Detalles.Last();
        //        //    //string numRem = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
        //        //    //if (detallePrimero != null)
        //        //    //{ 
        //        //    //numRem = detallePrimero.
        //        //    //}
        //        //    //NoRemision = Detalles.First();
        //        //}
        //        //else
        //        //{
        //        NoRemision = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
        //        //}
        //    }
        //    // EMISOR INFO COMERCIAL
        //    WS_FEL.ArrayOfString Etiqueta = new WS_FEL.ArrayOfString();
        //    Etiqueta.Add("|" + NoRemision + "|Servicio a domicilio sin costo|");
        //    Etiqueta.Add("|m2|Concentrados 100% en tu salud|");

        //    // CONCEPTOS
        //    WS_FEL.ArrayOfString Concepto = new WS_FEL.ArrayOfString();
        //    foreach (SIFModelo.RemisionDetalle rconcepto in Detalles)
        //    {
        //        string unidad = "PIEZA";
        //        if (rconcepto.ArticuloID == "")
        //        {
        //            unidad = "NO APLICA";
        //        }
        //        string concepto = "|" + rconcepto.CantidadRemision.ToString() + "|" + unidad + "|" + rconcepto.ArticuloID + "|" + rconcepto.Nombre1 + "|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(rconcepto.Precio, 2) + "|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(rconcepto.Total, 2) + "|";
        //        //Concepto.Add("|1|TA||TELCEL 100|86.21|86.21|");
        //        Concepto.Add(concepto);
        //    }

        //    // INFO ADUANERA
        //    WS_FEL.ArrayOfString Aduana = new WS_FEL.ArrayOfString();
        //    foreach (SIFModelo.RemisionDetalle rconcepto in Detalles)
        //    {
        //        Aduana.Add(""); // na
        //    }
        //    // IMPUESTOS RETENIDOS FEDERALES
        //    WS_FEL.ArrayOfString ImpRet = new WS_FEL.ArrayOfString();
        //    //ImpRet.Add("|IVA (IVA 10%)|IVA|0.0|");

        //    // IMPUESTOS TRASLADADOS FEDERALES
        //    WS_FEL.ArrayOfString ImpTra = new WS_FEL.ArrayOfString();
        //    foreach (SIFModelo.RemisionDetalle detalle in Detalles)
        //    {
        //        //GENERAMOS EL IMPUESTO
        //        SIFModelo.Impuesto impuestoC;
        //        impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(detalle.ImpuestoID);
        //        if (impuestoC == null)
        //        {
        //            impuestoC = new SIFModelo.Impuesto();
        //        }
        //        //impuestoC.Porcentaje = 16;

        //        //impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);

        //        //ImpTra.Add("|IVA (IVA " + impuestoC.Porcentaje.ToString("0.00") + "%)|IVA|" + impuestoC.Porcentaje.ToString("0.00") + "|" + detalle.IVA + "|");
        //    }

        //    if (esFacturaGlobal)
        //    {
        //        Impuestos impuestosL = new Impuestos();
        //        //impuestosL.Buscar("Activo", "S");
        //        foreach (var rd in Detalles)
        //        {
        //            SIFModelo.Impuesto impuestoC = impuestosL.ImpuestoPorID(rd.ImpuestoID);
        //            ImpTra.Add("|" + impuestoC.Nombre + " (IVA " + impuestoC.Porcentaje + "%)|IVA|" + impuestoC.Porcentaje + "|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(rd.IVA, 2) + "|");
        //        }
        //    }
        //    else
        //    {
        //        ImpTra.Add("|IVA (IVA 16%)|IVA|16|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.Impuesto, 2) + "|");
        //    }
        //    // IMPUESTOS RETENIDOS LOCALES
        //    WS_FEL.ArrayOfString ImpRetL = new WS_FEL.ArrayOfString();
        //    //ImpRetL.Add("|IVA (Local 10.00%)|IVA|10.00|0.00|");
        //    // IMPUESTOS TRASLADADOS LOCALES
        //    WS_FEL.ArrayOfString ImpTraL = new WS_FEL.ArrayOfString();
        //    //ImpTraL.Add("|IVA (Local 16.00%)|IVA|16.00|0.00|");

        //    Respuesta = SrvCFDI.GenerarCFDIv32(Usuario, Receptor, CFDI, Etiqueta, Concepto, Aduana, ImpRet, ImpTra, ImpRetL, ImpTraL);

        //    //for (int ind = 0; ind < Respuesta.Count - 1; ind++)
        //    //{
        //    //    rtb_FEL.AppendText("Respuesta (" + ind.ToString() + ") : " + Respuesta[ind] + Environment.NewLine);
        //    //}

        //    // Exito
        //    if (Respuesta[0].Contains("True"))
        //    {
        //        // Guardar XML
        //        XmlDocument Factura = new XmlDocument();
        //        Factura.LoadXml(Respuesta[3]);

        //        /*
        //         * Get atributos FEL
        //         */

        //        XPathNavigator nav = Factura.CreateNavigator();

        //        // UUID XPath
        //        string UUID = string.Empty;
        //        string NoFact = string.Empty;
        //        string FecFact = string.Empty;
        //        string PathXml = configuracion.DirectorioFacturas;

        //        XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
        //        xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
        //        xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
        //        xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

        //        try
        //        {
        //            XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);

        //            FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
        //            NoFact = Comprobante.Attributes.GetNamedItem("folio").Value;

        //            if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
        //                UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;

        //            // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
        //            XMLFile = XMLFile.Replace("NoFact", NoFact);
        //            XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";
        //            remision.NumeroFactura = UUID;

        //            if (!string.IsNullOrEmpty(PathXml))
        //                XMLFile = Path.Combine(PathXml, XMLFile);

        //            Factura.Save(@XMLFile);

        //            // Remision
        //            Random r = new Random();

        //            // Salva Inf. en la BD                    
        //            SIFDatos.Factura.Factura.InsertaFactura(NoRemision, Respuesta[3], XMLFile, UUID);
        //            remision.NumeroFactura = UUID;
        //            new SIFNegocio.Remision().ActualizaRemision(remision);
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //       MessageBox.Show(Respuesta[1]);
        //        return false;
        //    }

        //    SrvCFDI.Close();

        //    return true;
        //}

        public bool Invocar(SIFModelo.Configuracion.Factura configuracion, SIFModelo.Configuracion.Aplicacion email, SIFModelo.Cliente cliente, SIFModelo.SubRogacion.Sobrogacion ds, SIFModelo.Sucursal sucursal, SIFModelo.DireccionCliente direccionCliente = null, bool es5AlMillar = false, DateTime? periodo = null)
        {
            if (!System.IO.Directory.Exists(configuracion.DirectorioFacturas))
            {
               MessageBox.Show("Configure el directorio de facturas");
                return false;
            }

            WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
            WS_FEL.RespuestaOperacion Respuesta = new WS_FEL.RespuestaOperacion();
            foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow factura in ds.FACTURA)
            {
                string XMLFile = factura.REFERENCIA + " " + factura.FECHA.ToString("ddMMyy") + " - " + sucursal.SucursalID;

                SIFModelo.DireccionCliente Direccion = direccionCliente;

                if (Direccion == null)
                {
                    Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente, SIFModelo.Tipos.TipoDireccion.fiscal);
                }

                DataRow[] Detalles = ds.FACTURA_DETALLE.Select("NUM_FACTURA= '" + factura.NUM_FACTURA + "'");
                //var subtotal = ds.FACTURA_DETALLE.Compute("SUM(TOTAL)", "NUM_FACTURA=" + factura.NUM_FACTURA);
                //factura.SUBTOTAL = System.Convert.ToDouble(subtotal.ToString());

                SIFModelo.Impuesto impuesto = new SIFModelo.Impuesto(); // new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);

                ClienteConvenios LogicaCon = new ClienteConvenios();
                SIFModelo.ClienteConvenio ClienteConv = LogicaCon.ClientePorID(cliente.ID);
                SIFModelo.TipoPago tipoPago = new SIFNegocio.TipoPagos().TipoPagoPorID(ClienteConv.TipoPagoID);

                if (tipoPago == null)
                {
                    tipoPago = new SIFModelo.TipoPago();
                    tipoPago.Nombre = configuracion.TipoPago;
                }

                WS_FEL.Credenciales Usuario = new WS_FEL.Credenciales();
                Usuario.Usuario = configuracion.RFCEmisor;
                Usuario.Cuenta = configuracion.UsuarioFEL;
                Usuario.Password = configuracion.PasswordFEL;


                // Receptor
                WS_FEL.ReceptorR Receptor = new WS_FEL.ReceptorR();

                Receptor.Nombre = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
                //Receptor.Add(""); // OPCIONAL
                //Receptor.Add(""); //Receptor.Add(Direccion.Telefono);
                Receptor.emailContacto = (Direccion.Email).Trim();
                Receptor.RFC = (Direccion.RFC).Trim(); //"XAXX010101000"
                Receptor.NombreCliente = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
                Receptor.calle = (Direccion.Calle); // CALLE
                Receptor.noExterior = (Direccion.NumeroExterior).Trim(); // NO EXTERIOR
                Receptor.noInterior = (Direccion.NumeroInterior).Trim(); // NO. INTERIOR
                Receptor.colonia = (Direccion.Colonia).Trim(); // COLONIA
                //Receptor.Add(""); // LOCALIDAD
                //Receptor.Add(""); // REFERENCIA
                Receptor.municipio = (Direccion.Municipio).Trim(); // MPIO
                System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("ES-mx").TextInfo;
                var estadoLetraCapital = ti.ToTitleCase(Direccion.Ciudad.ToLower()).Trim();
                Receptor.estado = (estadoLetraCapital).Trim(); // EDO DE LA REP
                Receptor.pais = ("México"); // PAIS

                String Cp = Direccion.CodigoPostal.ToString();
                if (Cp.Length < 5)
                    Cp = Cp.PadLeft(5, '0');
                Receptor.codigoPostal = (Cp); // CP


                // DATOS GENERALES CFDI
                WS_FEL.ComprobanteRemota CFDI = new WS_FEL.ComprobanteRemota();

                CFDI.Receptor = Receptor;

                SIFModelo.TipoCambio cambio = null;

                if (cambio == null)
                {
                    cambio = new SIFModelo.TipoCambio();
                    cambio.Factor = 1;
                    cambio.VigenciaInicio = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                }

                string tipoCFDI = "FAC";
                CFDI.ClaveCFDI = (tipoCFDI);
                CFDI.formaDePago = configuracion.TipoPago; //("UNA SOLA EXHIBICION");//Forma de pago
                //CFDI.Add(""); // PARCIALIDADES
                //CFDI.Add(""); // CONDICIONES DE PAGO
                CFDI.metodoDePago = (tipoPago.Nombre); //CFDI.Add(tipoPago.Nombre); // METODO PAGO
                CFDI.descuento = factura.DESCUENTO; // DESCUENTO
                CFDI.PorcentajeDescuento = 0; // PORCENTAJE DESCTO
                CFDI.motivoDescuento = (""); // MOTIVO DESCTO
                CFDI.Moneda = ("MXN"); //MONEDA
                CFDI.TipoCambio = (""); // TIPO CAMBIO
                CFDI.FechaTipoCambio = null; // FECHA TIPO CAMBIO
                CFDI.Impuestos = new WS_FEL.ImpuestosR();
                CFDI.Impuestos.totalImpuestosRetenidos = 0;
                CFDI.Impuestos.totalImpuestosTrasladados = factura.IMPUESTO_IVA;

                //WS_FEL.ImpuestosR impuestosRetenidos = new WS_FEL.ImpuestosR();
                //impuestosRetenidos.totalImpuestosRetenidos = 0; // CFDI.rete("0.00"); // TOTAL IMPUESTO RETENIDO


                List<WS_FEL.TrasladoR> listaImpuestosTraslados = new List<WS_FEL.TrasladoR>();
                WS_FEL.TrasladoR impuestosTraslados = new WS_FEL.TrasladoR();
                impuestosTraslados.NombreImpuesto = "IVA 16%";
                impuestosTraslados.Tasa = 16;
                impuestosTraslados.Impuesto = "IVA";
                impuestosTraslados.Importe = factura.IMPUESTO_IVA; // TOTAL IMPUESTO TRASLADADO
                listaImpuestosTraslados.Add(impuestosTraslados);
                CFDI.Impuestos.Traslados = listaImpuestosTraslados.ToArray();



                decimal retencionAlMillar = 0;
                if (es5AlMillar)
                {
                    //retencionAlMillar = ((factura.SUBTOTAL- factura.IMPUESTO_IVA) / 1000) * 5;
                    decimal res = 0M;
                    decimal val = (factura.SUBTOTAL);
                    decimal fact = 0.005M;
                    res = decimal.Round(val * fact, 2);

                    //res = TruncateToDecimalPlace(res, 4);

                    //decimal totalDesc = TruncateToDecimalPlace(val - res, 4);
                    factura.TOTAL = (val + factura.IMPUESTO_IVA) - res;

                    retencionAlMillar = res;
                }

                CFDI.subTotal = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(factura.SUBTOTAL); // SUBTOTAL
                CFDI.total = SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(factura.TOTAL); // TOTAL COMPROBANTE
                factura.IMPORTE_LETRA = sif_tools.NumberToLetters.NumToLetter((double)factura.TOTAL, "Decimal");
                CFDI.ImporteConLetra = (factura.IMPORTE_LETRA); // TOTAL CON LETRA
                CFDI.LugarExpedicion = (sucursal.Ciudad); // LUGAR DE EXPEDICION
                if (ClienteConv.numCta == null)
                    CFDI.NumCtaPago = (""); // NUM CTA PAGO
                else
                    CFDI.NumCtaPago = (ClienteConv.numCta); // NUM CTA PAGO
                CFDI.FolioFiscalOrig = (""); // FOLIO FISCAL ORIGINAL
                CFDI.SerieFolioFiscalOrig = (""); // SERIE FOLIOI FISCAL
                CFDI.FechaFolioFiscalOrig = null; // FECHA FOLIO FISCAL
                CFDI.MontoFolioFiscalOrig = 0; // MONTO FOLIO FISCAL


                //NUMERO DE REMISION
                string NoFactura = factura.NUM_FACTURA;
                // EMISOR INFO COMERCIAL
                List<WS_FEL.EtiquetaPersonalizadaR> etiquetas = new List<WS_FEL.EtiquetaPersonalizadaR>();
                //WS_FEL.ArrayOfString Etiqueta = new WS_FEL.ArrayOfString();
                etiquetas.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "Referencia: ", Valor = NoFactura });   
                etiquetas.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m1", Valor = "Servicio a domicilio sin costo" });   
                etiquetas.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m2", Valor = "Concentrados 100% en tu salud" });

                CFDI.Etiquetas = etiquetas.ToArray();

                // CONCEPTOS
                List<WS_FEL.DetalleTraslado> traslado_Partida = new List<WS_FEL.DetalleTraslado>();
                List<WS_FEL.ConceptoR> Conceptos = new List<WS_FEL.ConceptoR>();
                foreach (DataRow rconcepto in Detalles)
                {
                    if (System.Convert.ToDecimal(rconcepto["Cantidad"]) <= 0)
                    {
                        continue;
                    }

                    string unidad = "PIEZA";
                    if (rconcepto["Clave"].ToString() == "")
                    {
                        unidad = "NO APLICA";
                    }

                    WS_FEL.ConceptoR concepto = new WS_FEL.ConceptoR();
                    concepto.DetalleConcepto = new WS_FEL.DetallesConcepto();

                    concepto.cantidad = System.Convert.ToDecimal(rconcepto["CAntidad"]);
                    concepto.unidad = unidad;
                    concepto.noIdentificacion = rconcepto["CLAVE"].ToString();
                    concepto.descripcion = rconcepto["DESCRIPCION"].ToString();
                    concepto.valorUnitario = System.Convert.ToDecimal(rconcepto["PRECIO_UNITARIO"]);
                    concepto.importe = System.Convert.ToDecimal(rconcepto["SubTotal"]);

                    concepto.DetalleConcepto.TipoCalculo = WS_FEL.TipoCalculoPartida.PARTIDA;

                    //IMPUESTOS
                    SIFModelo.Impuesto impuestoC;
                    if (System.Convert.ToDecimal(rconcepto["IMPUESTO"]) == 0)
                    {
                        rconcepto["IMPUESTO_ID"] = 1;
                    }
                    else
                    {
                        rconcepto["IMPUESTO_ID"] = 2;
                    }

                    impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(int.Parse(rconcepto["IMPUESTO_ID"].ToString()));

                    WS_FEL.DetalleTraslado traslado = new WS_FEL.DetalleTraslado();
                    traslado.Nombre = impuestoC.Nombre + " " + impuestoC.Porcentaje + "%";
                    traslado.impuesto = impuestoC.Nombre;
                    traslado.tasa = impuestoC.Porcentaje;

                    traslado.importe = System.Convert.ToDecimal(rconcepto["IMPUESTO"]);
                    traslado_Partida.Add(traslado);

                    Conceptos.Add(concepto);
                }

                CFDI.Conceptos = Conceptos.ToArray();
                CFDI.Referencia = factura.REFERENCIA;

                if (es5AlMillar)
                {
                    List<WS_FEL.RetencionLocalR> listaImpuestosLocalesRetenidos = new List<WS_FEL.RetencionLocalR>();
                    WS_FEL.RetencionLocalR ImpuestoLocalRetenido = new WS_FEL.RetencionLocalR();

                    ImpuestoLocalRetenido.NombreImpuesto = "Retención 5 al millar (Local 0.50%)";
                    ImpuestoLocalRetenido.ImpLocRetenido = "Retención 5 al millar";
                    ImpuestoLocalRetenido.TasadeRetencion = 0.5m;
                    ImpuestoLocalRetenido.Importe = retencionAlMillar;
                    listaImpuestosLocalesRetenidos.Add(ImpuestoLocalRetenido);

                    CFDI.ComplementoImpuestosLocales = new WS_FEL.ImpuestosLocalesR();
                    CFDI.ComplementoImpuestosLocales.RetencionesLocales = listaImpuestosLocalesRetenidos.ToArray();
                }

                List<WS_FEL.RegimenFiscalR> listaRegimenFiscales = new List<WS_FEL.RegimenFiscalR>();
                WS_FEL.RegimenFiscalR Regimen = new WS_FEL.RegimenFiscalR();
                Regimen.Regimen = configuracion.ActividadEmpresarial;
                listaRegimenFiscales.Add(Regimen);
                CFDI.RegimenesFiscales = listaRegimenFiscales.ToArray();
                /*Invertimos cuenta(cuenta sucursal)  con usuario (RFC)*/
                String RFC;
                RFC = Usuario.Cuenta;
                Usuario.Cuenta = Usuario.Usuario;
                Usuario.Usuario = RFC;

//#if !RELEASE
                Respuesta = SrvCFDI.GenerarCFDIv32(Usuario, CFDI); // Receptor, CFDI, Etiqueta, Conceptos, Aduana, ImpRet, ImpTra, ImpRetL, ImpTraL);
//#else
//                Respuesta = new WS_FEL.RespuestaOperacion();
//#endif

                if (Respuesta.OperacionExitosa)
                {
                    // Guardar XML
                    XmlDocument Factura = new XmlDocument();
                    Factura.LoadXml(Respuesta.XML);

                    /*
                     * Get atributos FEL
                     */

                    XPathNavigator nav = Factura.CreateNavigator();

                    // UUID XPath
                    string UUID = string.Empty;
                    string NoFact = string.Empty;
                    string FecFact = string.Empty;
                    string PathXml = configuracion.DirectorioFacturas;

                    XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
                    xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                    xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                    xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                    try
                    {
                        XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);

                        
                        FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
                        NoFact = Comprobante.Attributes.GetNamedItem("folio").Value;
                        
                       MessageBox.Show("Se ha generado la factura " + NoFact.ToString());

                      //  if (Comprobante["cfdi:Complemento"].ChildNodes[1].Attributes.GetNamedItem("UUID") != null)
                        //    UUID = Comprobante["cfdi:Complemento"].ChildNodes[1].Attributes.GetNamedItem("UUID").Value;

                        // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
                        XMLFile = XMLFile.Replace("NoFact", NoFact);
                        XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";
                        NoFact = Comprobante.Attributes.GetNamedItem("serie").Value + "-" + Comprobante.Attributes.GetNamedItem("folio").Value;
                        if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
                            UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;
                        else
                            UUID = "FACTURA GENERADA NO: "+NoFact+" ::::UUID NO DISPONIBLE::::";

                        
                        SIFDatos.Factura.Factura.RemsionFacturas(usuarioInvoca, CFDI.Referencia, DateTime.Now, NoFact, UUID, "SUB");


                        if (periodo == null)
                        {
                            periodo = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                        }

                        string NoRemision = cliente.ID.ToString() + "-" + periodo.Value.ToString("ddMMyyyy") + "-A" + factura.NUM_FACTURA + "-" + sucursal.SucursalID;
                        SIFDatos.Factura.Factura.InsertaFactura(NoRemision, Respuesta.XML, XMLFile, UUID, tipoCFDI);
                       
                        if (!string.IsNullOrEmpty(PathXml))
                            XMLFile = Path.Combine(PathXml, XMLFile);

                        Factura.Save(@XMLFile);
                        factura.REFERENCIA = UUID;
                        SIFDatos.Subrogacion.Facturas.Update(ds);
                        /*VMJA04032015*/
                      /* Respuesta = SrvCFDI.ObtenerPDF(Usuario, UUID);
                        if (Respuesta.OperacionExitosa && !String.IsNullOrEmpty(Respuesta.PDF))
                        {
                            System.IO.File.WriteAllBytes(configuracion.DirectorioFacturas + "/Facturas/" + "FAC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + CFDI.Referencia + ".pdf", Convert.FromBase64String(Respuesta.PDF));

                            if (MessageBoxEx.Show("¿Desea enviar la Factura al correo: " + Receptor.emailContacto + " ?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, Receptor.emailContacto);
                                //MessageBoxEx.Show("FACTURA ENVIADA AL CORREO ELECTRONICO: " + Receptor.emailContacto);
                            }
                            
                        }*/
                        
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                else
                {
                    if(Respuesta.ErrorGeneral == null)
                    {
                        Respuesta.ErrorGeneral = "ERROR GENERAL: "+ Respuesta.ErrorGeneral.ToString();
                    }
                   MessageBox.Show(Respuesta.ErrorGeneral);
                    return false;
                }

            }
            SrvCFDI.Close();
            return true;

        }

        private static decimal TruncateToDecimalPlace(decimal numberToTruncate, int decimalPlaces)
        {
            decimal power = (decimal)(Math.Pow(10.0, (double)decimalPlaces));

            return Math.Truncate((power * numberToTruncate)) / power;
        }

        public bool Invocar(SIFModelo.Configuracion.Factura configuracion, SIFModelo.Configuracion.Aplicacion email, SIFModelo.Cliente cliente, SIFModelo.Remision remision, SIFModelo.Sucursal sucursal, SIFModelo.DireccionCliente direccionCliente = null, bool esFacturaGlobal = false)
        {
            if (!System.IO.Directory.Exists(configuracion.DirectorioFacturas))
            {
               MessageBox.Show("Configure el directorio de facturas");
                return false;
            }

            WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
            WS_FEL.RespuestaOperacion Respuesta = new WS_FEL.RespuestaOperacion();
            string XMLFile = remision.NumeroRemision + " - " + sucursal.SucursalID;


            //CHECAMOS SI LA REMISION ES EN CREDITO GUARDAMOS FACTURA PARA CXC

            //COLOCAR EL UUID GENERICO
            remision.NumeroFactura = "********* UUID POR ASIGNAR *********";
            new SIFNegocio.Remision().ActualizaUUIDRemision(remision);

            //SrvCFDI. (Usuario, Receptor, CFDI, Etiqueta, Concepto, Aduana, ImpRet, ImpTra, ImpRetL, ImpTraL);

            SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
            SIFModelo.DireccionCliente Direccion = direccionCliente;

            

            if (Direccion == null)
            {
                Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente, cliente.TipoDireccion);
            }

            List<SIFModelo.RemisionDetalle> Detalles = remision.Detalles;
            if (Detalles == null || Detalles.Count == 0)
            {
                Detalles = remisionL.CargaRemisionDetallesF(remision);
            }

            SIFModelo.Moneda moneda = new SIFNegocio.Monedas().MonedaPorID(remision.MonedaID);

            SIFModelo.Impuesto impuesto = new SIFModelo.Impuesto(); // new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);
            SIFModelo.Pagos pago = new SIFNegocio.Pagos().PagoPorRemision(remision);

            if (pago == null)
            {
                pago = new SIFModelo.Pagos();
                pago.Activo = SIFModelo.Tipos.SiNo.SI;
                pago.BancoID = 1;
                pago.CajaID = 1;
                pago.CajeroID = 1;
                pago.ClienteID = 1;
                pago.DocumentoPago = "NO IDENTIFICADO";
                pago.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                pago.ImporteIVA = 0;
                pago.ImporteTotal = remision.Total;
                pago.ImporteVenta = remision.Total;
                pago.MonedaID = 1;
                pago.NumeroPago = 1;
                //pago.RemisionID = remision.NumeroRemision;
                pago.SucursalID = 1;
                pago.TipoCambioID = 1;
                pago.TipoPagoID = 1;
            }


            SIFModelo.TipoPago tipoPago = new SIFNegocio.TipoPagos().TipoPagoPorID(pago.TipoPagoFacID);

            if (tipoPago == null)
            {
                tipoPago = new SIFModelo.TipoPago();
                tipoPago.Nombre = configuracion.TipoPago;
            }

            if (remision.TipoCambio == 1)
            {
                SIFNegocio.Subrogacion.Factura LogicaFactura = new SIFNegocio.Subrogacion.Factura();
                LogicaFactura.GetFacturas(LogicaFactura.Ds, "", "{Nombre Producto}", "{Codigo Articulo}", remision.NumeroRemision, false, false);
                foreach (SIFModelo.SubRogacion.Sobrogacion.FACTURARow Factura in LogicaFactura.Ds.FACTURA)
                {
                    Factura.TIPO_PAGO_ID = tipoPago.ID;
                    Factura.CLIENTE_ID = remision.ClienteID;
                    Factura.IMPORTE_LETRA = sif_tools.NumberToLetters.NumToLetter((double)remision.Total, remision.Total.GetType().ToString());
                    Factura.REFERENCIA = "";
                    Factura.NUM_CUENTA = "";
                }

                //foreach (SIFModelo.RemisionDetalle detalleF in Detalles)
                //{
                //    SIFModelo.SubRogacion.Sobrogacion.FACTURA_DETALLERow fDetalle = LogicaFactura.Ds.FACTURA_DETALLE.NewFACTURA_DETALLERow();

                //    fDetalle.CLAVE = detalleF.ArticuloID;
                //    fDetalle.DESCRIPCION = detalleF.Nombre1;
                //    fDetalle.UNIDAD = detalleF.Unidad;
                //    fDetalle.PRECIO_UNITARIO = detalleF.Precio;
                //    fDetalle.CANTIDAD = detalleF.CantidadRemision;
                //    fDetalle.DESCUENTO = detalleF.MontoDescuento;
                //    fDetalle.TOTAL = detalleF.Total;
                //    fDetalle.UNIDAD = detalleF.Unidad;
                //    fDetalle.NUM_FACTURA = factura
                //    LogicaFactura.Ds.FACTURA_DETALLE.AddFACTURA_DETALLERow(fDetalle);
                //}

                LogicaFactura.InsertaFacturas(LogicaFactura.Ds);
            }

            WS_FEL.Credenciales Usuario = new WS_FEL.Credenciales();
            Usuario.Cuenta = (configuracion.RFCEmisor);
            Usuario.Usuario = (configuracion.UsuarioFEL);
            Usuario.Password = (configuracion.PasswordFEL);


            // Receptor
            WS_FEL.ReceptorR Receptor = new WS_FEL.ReceptorR();


            Receptor.Nombre = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            //Receptor.Add(""); // OPCIONAL
            //Receptor.Add(""); //Receptor.Add(Direccion.Telefono);
            Receptor.emailContacto = (Direccion.Email).Trim();
            Receptor.RFC = (Direccion.RFC).Trim(); //"XAXX010101000"
            Receptor.NombreCliente = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            Receptor.calle = (Direccion.Calle).Trim(); // CALLE
            Receptor.noExterior = (Direccion.NumeroExterior).Trim(); // NO EXTERIOR
            Receptor.noInterior = (Direccion.NumeroInterior).Trim(); // NO. INTERIOR
            Receptor.colonia = (Direccion.Colonia).Trim(); // COLONIA
            Receptor.localidad = (""); // LOCALIDAD
            Receptor.referencia = (""); // REFERENCIA
            Receptor.municipio = (Direccion.Municipio).Trim(); // MPIO
            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("ES-mx").TextInfo;
            var estadoLetraCapital = ti.ToTitleCase(Direccion.Ciudad.ToLower()).Trim();
            Receptor.estado = (estadoLetraCapital).Trim(); // EDO DE LA REP
            Receptor.pais = ("México").Trim(); // PAIS

            String Cp = Direccion.CodigoPostal.ToString();
            if (Cp.Length < 5)
                Cp = Cp.PadLeft(5, '0');
            Receptor.codigoPostal = (Cp).Trim(); // CP

            // DATOS GENERALES CFDI
            WS_FEL.ComprobanteRemota CFDI = new WS_FEL.ComprobanteRemota();

            CFDI.Receptor = Receptor;

            SIFModelo.TipoCambio cambio = new SIFNegocio.TipoCambios().BuscarPorID(pago.TipoCambioID);

            if (cambio == null)
            {
                cambio = new SIFModelo.TipoCambio();
                cambio.Factor = 1;
                cambio.VigenciaInicio = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            string tipoFac = "FAC";
            CFDI.ClaveCFDI = (tipoFac);
            CFDI.formaDePago = configuracion.TipoPago.Trim(); // ("UNA SOLA EXHIBICION");//Forma de pago
            //CFDI.Add(""); // PARCIALIDADES
            //CFDI.Add(""); // CONDICIONES DE PAGO
            CFDI.metodoDePago = (tipoPago.Nombre).Trim(); // METODO PAGO
            CFDI.descuento = (remision.Descuento); // DESCUENTO
            CFDI.PorcentajeDescuento = 0; // PORCENTAJE DESCTO
            CFDI.motivoDescuento = (""); // MOTIVO DESCTO
            CFDI.Moneda = ("MXN"); //MONEDA
            CFDI.TipoCambio = (""); // TIPO CAMBIO
            CFDI.FechaTipoCambio = null;
            CFDI.Impuestos = new WS_FEL.ImpuestosR();
            CFDI.Impuestos.totalImpuestosRetenidos = 0m; // TOTAL IMPUESTO RETENIDO
            CFDI.Impuestos.totalImpuestosTrasladados = remision.Impuesto; // TOTAL IMPUESTO TRASLADADO

            List<WS_FEL.TrasladoR> listaImpuestosTraslados = new List<WS_FEL.TrasladoR>();
            WS_FEL.TrasladoR impuestosTraslados = new WS_FEL.TrasladoR();
            impuestosTraslados.NombreImpuesto = "IVA 16%";
            impuestosTraslados.Tasa = 16;
            impuestosTraslados.Impuesto = "IVA";
            impuestosTraslados.Importe = remision.Impuesto; // TOTAL IMPUESTO TRASLADADO
            listaImpuestosTraslados.Add(impuestosTraslados);
            CFDI.Impuestos.Traslados = listaImpuestosTraslados.ToArray();


            CFDI.subTotal = remision.SubTotal; // SUBTOTAL
            CFDI.total = remision.Total; // TOTAL COMPROBANTE
            CFDI.ImporteConLetra = (remision.ImporteLetra).Trim(); // TOTAL CON LETRA
            CFDI.LugarExpedicion = (sucursal.Ciudad); // LUGAR DE EXPEDICION
            CFDI.NumCtaPago = (pago.DocumentoPago); // NUM CTA PAGO
            CFDI.FolioFiscalOrig = (""); // FOLIO FISCAL ORIGINAL
            CFDI.SerieFolioFiscalOrig = (""); // SERIE FOLIOI FISCAL
            CFDI.FechaFolioFiscalOrig = null; // FECHA FOLIO FISCAL
            CFDI.MontoFolioFiscalOrig = 0; // MONTO FOLIO FISCAL

            //NUMERO DE REMISION
            string NoRemision = remision.NumeroRemision;
            if (string.IsNullOrEmpty(NoRemision))
            {
                //if (esFacturaGlobal)
                //{
                //    //SIFModelo.RemisionDetalle detallePrimero = Detalles.First();
                //    //SIFModelo.RemisionDetalle detalleUltimo = Detalles.Last();
                //    //string numRem = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
                //    //if (detallePrimero != null)
                //    //{ 
                //    //numRem = detallePrimero.
                //    //}
                //    //NoRemision = Detalles.First();
                //}
                //else
                //{
                NoRemision = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
                //}
            }
            // EMISOR INFO COMERCIAL
            List<WS_FEL.EtiquetaPersonalizadaR> Etiqueta = new List<WS_FEL.EtiquetaPersonalizadaR>();
            Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "Referencia: ", Valor = NoRemision });
            if (remision.ClienteID == 18)
            {
                SIFModelo.Cliente18 cliente18 = SIFNegocio.Remision.cliente18(remision);
                Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "Nombre ", Valor = cliente18.nombre_asegurado });
                Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "No. Siniestro ", Valor = cliente18.no_siniestro });
                Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "No. Autorizacion ", Valor = cliente18.no_autorizacion });
            }
            else
            {
                Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m1", Valor = "Servicio a domicilio sin costo" });
                Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m2", Valor = "Concentrados 100% en tu salud" });
            }

            CFDI.Etiquetas = Etiqueta.ToArray();

            // CONCEPTOS
            List<WS_FEL.DetalleTraslado> traslado_Partida = new List<WS_FEL.DetalleTraslado>();
            List<WS_FEL.ConceptoR> Conceptos = new List<WS_FEL.ConceptoR>();
            foreach (SIFModelo.RemisionDetalle rconcepto in Detalles)
            {

                if (rconcepto.CantidadRemision <= 0)
                {
                    continue;
                }

                string unidad = "PIEZA";
                if (rconcepto.ArticuloID == "")
                {
                    unidad = "NO APLICA";
                }

                WS_FEL.ConceptoR concepto = new WS_FEL.ConceptoR();
                concepto.DetalleConcepto = new WS_FEL.DetallesConcepto();

                concepto.cantidad = rconcepto.CantidadRemision;
                concepto.noIdentificacion = rconcepto.ArticuloID;
                concepto.unidad = unidad;
                concepto.descripcion = rconcepto.Nombre1;
                concepto.valorUnitario = rconcepto.Precio;
                concepto.importe = rconcepto.Total;

                concepto.DetalleConcepto.TipoCalculo = WS_FEL.TipoCalculoPartida.PARTIDA;

                List<WS_FEL.DetalleTraslado> traslados = new List<WS_FEL.DetalleTraslado>();
                WS_FEL.DetalleTraslado traslado = new WS_FEL.DetalleTraslado();
                SIFModelo.Impuesto impuestoC;
                impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(rconcepto.ImpuestoID);
                if (impuestoC == null)
                {
                    impuestoC = new SIFModelo.Impuesto();
                    impuestoC.Nombre = "I.V.A.";
                    impuestoC.Porcentaje = 0;
                }


                traslado.Nombre = impuestoC.Nombre + " " + impuestoC.Porcentaje + "%";
                traslado.impuesto = impuestoC.Nombre;
                traslado.tasa = impuestoC.Porcentaje;
                traslado.importe = rconcepto.IVA;
                traslados.Add(traslado);
                concepto.DetalleConcepto.Traslados = traslados.ToArray();

                Conceptos.Add(concepto);
            }

            CFDI.Conceptos = Conceptos.ToArray();
            CFDI.Referencia = NoRemision;

            List<WS_FEL.RegimenFiscalR> listaRegimenFiscales = new List<WS_FEL.RegimenFiscalR>();
            WS_FEL.RegimenFiscalR Regimen = new WS_FEL.RegimenFiscalR();
            Regimen.Regimen = configuracion.ActividadEmpresarial;
            listaRegimenFiscales.Add(Regimen);
            CFDI.RegimenesFiscales = listaRegimenFiscales.ToArray();

            //if (esFacturaGlobal)
            //{
            //    Impuestos impuestosL = new Impuestos();
            //    //impuestosL.Buscar("Activo", "S");
            //    foreach (var rd in Detalles)
            //    {
            //        SIFModelo.Impuesto impuestoC = impuestosL.ImpuestoPorID(rd.ImpuestoID);
            //        ImpTra.Add("|" + impuestoC.Nombre + " (IVA " + impuestoC.Porcentaje + "%)|IVA|" + impuestoC.Porcentaje + "|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(rd.IVA) + "|");
            //    }
            //}
            //else
            //{
            //    ImpTra.Add("|IVA (IVA 16%)|IVA|16|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.Impuesto) + "|");
            //}

            Respuesta = new WS_FEL.RespuestaOperacion();

            //#if DEBUG
            //            Random random = new Random();
            //            int randomNumber = random.Next(0, 9999);

            //            Respuesta = new WS_FEL.ArrayOfString(){ 
            //                "True",
            //                "",
            //                "",
            //                "<?xml version=\"1.0\" encoding=\"utf-8\"?> <cfdi:Comprobante xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" xmlns:implocal=\"http://www.sat.gob.mx/implocal\" version=\"3.2\" serie=\"AS\" folio=\"57098\" fecha=\"2013-04-23T10:54:40\" sello=\"AMJxCsBnxcLJLUHQ3PEuItfsqeIbAolGSiIYq3bOKgJIJZJaOK/Mo7ipSsbkLM3+LxFRHx87rvDIBNsqgr5vjanaDwyd1Ldbj0lQr6+mcBLzEVIFdvmsGBEz8rq2w5Ht3tXu7Z8bRd6oJ+A2v16itIxJt3xweJgREr8CH72GEDs=\" formaDePago=\"NO IDENTIFICADO\" noCertificado=\"00001000000103398424\" certificado=\"MIIEczCCA1ugAwIBAgIUMDAwMDEwMDAwMDAxMDMzOTg0MjQwDQYJKoZIhvcNAQEFBQAwggE2MTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExHzAdBgkqhkiG9w0BCQEWEGFjb2RzQHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxEzARBgNVBAcMCkN1YXVodGVtb2MxMzAxBgkqhkiG9w0BCQIMJFJlc3BvbnNhYmxlOiBGZXJuYW5kbyBNYXJ0w61uZXogQ29zczAeFw0xMTA0MjYxOTEzMjhaFw0xMzA0MjUxOTEzMjhaMIIBEjE8MDoGA1UEAxMzT1BFUkFET1IgREUgRkFSTUFDSUFTIEEuRi4gREVMIENFTlRSTyBTIERFIFJMIERFIENWMTwwOgYDVQQpEzNPUEVSQURPUiBERSBGQVJNQUNJQVMgQS5GLiBERUwgQ0VOVFJPIFMgREUgUkwgREUgQ1YxPDA6BgNVBAoTM09QRVJBRE9SIERFIEZBUk1BQ0lBUyBBLkYuIERFTCBDRU5UUk8gUyBERSBSTCBERSBDVjElMCMGA1UELRMcT0ZBMDgwMTI5VTY5IC8gQUFIQjU3MDMxNDVKODEeMBwGA1UEBRMVIC8gQUFIQjU3MDMxNE1QTExEUjA4MQ8wDQYDVQQLEwZNYXRyaXowgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALPENAfTz1HE5TJuPTyO2uIQ9C9n/tv5iTW+jMj0cYgnlTDOYk9oefPM9pbd23DUiIVm+kfdFspmbH24J8LUMAf6CLJunbDsaJxCtsv6T95FeC0QjOhmLHUBzbLKLEZ24h+Mzk8jaPwXxMbGlajlj1yCIWQpzogOiKedMJs/2Wo7AgMBAAGjHTAbMAwGA1UdEwEB/wQCMAAwCwYDVR0PBAQDAgbAMA0GCSqGSIb3DQEBBQUAA4IBAQAvQ4RHJlDXdf7Z4VhxirzYxul+xgyWmlJmvXSha4+lnePkpKAADKhgABlmsb1CUH98p3iGMLO3FNrMO2DXsUWcdQ/hFWp40GoMjLZomBFxY5oT+E686DkWZjN4s+6EjL/yeqA6i2WiF3l0RiSz/JRAEdmRCTdR4zDsfNhZLvYAKk4kLtKs0y2p0rFfmMkvRL5gqiE9c4c6y+1UJ5aFIggSVhlcBg2d1rRP0j5jwUusEWvLKpBHg9PFB58D7FOTdDwn+P45Vfhp5Ys2BKINcWLKu2FJmhQcca3om5PZCSDeNLGpBXmbp505Si4tBIJWXVKJMdaqCA4vKd26PRoHQ9Au\" subTotal=\"8953.00\" Moneda=\"MXN\" total=\"8953.00\" tipoDeComprobante=\"ingreso\" metodoDePago=\"NO IDENTIFICADO\" LugarExpedicion=\"PUEBLA, Puebla\" xsi:schemaLocation=\"http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/TimbreFiscalDigital/TimbreFiscalDigital.xsd http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd\" xmlns:cfdi=\"http://www.sat.gob.mx/cfd/3\">   <cfdi:Emisor rfc=\"OFA080129U69\" nombre=\"OPERADOR DE FARMACIAS A.F. DEL CENTRO S. DE R.L. DE C.V.\">     <cfdi:DomicilioFiscal calle=\"13 SUR\" noExterior=\"2701\" colonia=\"VOLCANES\" localidad=\"PUEBLA\" municipio=\"PUEBLA\" estado=\"PUEBLA\" pais=\"MEXICO\" codigoPostal=\"72410\" />     <cfdi:RegimenFiscal Regimen=\"Régimen General de Ley Personas Morales\" />    </cfdi:Emisor>    <cfdi:Receptor rfc=\"ISS810211CA0\" nombre=\"INSTITUTO DE SEGURIDAD Y SERVICIOS SOCIALES DE LOS TRABAJADORES AL SERVICIO DEL EDO PUEBLA   \">     <cfdi:Domicilio calle=\"VENUSTIANO CARRANZA\" noExterior=\"810\" noInterior=\" \" colonia=\"SAN BALTAZAR CAMPECHE\" municipio=\"Puebla\" estado=\"PUEBLA\" pais=\"MEXICO\" codigoPostal=\"72550\" />    </cfdi:Receptor>   <cfdi:Conceptos>     <cfdi:Concepto cantidad=\"4.0000\" unidad=\"PIEZA\" noIdentificacion=\"60228\" descripcion=\"PREGABALINA 150 MGCAJA CON 28 CAPSULAS\" valorUnitario=\"590.0000\" importe=\"2360.0000\" />     <cfdi:Concepto cantidad=\"3.0000\" unidad=\"PIEZA\" noIdentificacion=\"60289\" descripcion=\"RASAGILINA MESILATO1 MG.CAJA CON 10 TABLETAS\" valorUnitario=\"981.0000\" importe=\"2943.0000\" />     <cfdi:Concepto cantidad=\"5.0000\" unidad=\"PIEZA\" noIdentificacion=\"60360\" descripcion=\"SITAGLIPTINA100 MGCAJA CON 28 TABLETAS\" valorUnitario=\"730.0000\" importe=\"3650.0000\" />   </cfdi:Conceptos>   <cfdi:Impuestos totalImpuestosRetenidos=\"0.00\" totalImpuestosTrasladados=\"0.00\">     <cfdi:Traslados>       <cfdi:Traslado impuesto=\"IVA\" tasa=\"16.0000\" importe=\"0.0000\" />     </cfdi:Traslados>   </cfdi:Impuestos>   <cfdi:Complemento>     <tfd:TimbreFiscalDigital version=\"1.0\" UUID=\"6176A608-36E2-49C2-B79A-1F815BD"+ randomNumber + "\" FechaTimbrado=\"2013-04-23T10:54:41\" selloCFD=\"AMJxCsBnxcLJLUHQ3PEuItfsqeIbAolGSiIYq3bOKgJIJZJaOK/Mo7ipSsbkLM3+LxFRHx87rvDIBNsqgr5vjanaDwyd1Ldbj0lQr6+mcBLzEVIFdvmsGBEz8rq2w5Ht3tXu7Z8bRd6oJ+A2v16itIxJt3xweJgREr8CH72GEDs=\" noCertificadoSAT=\"00001000000203220546\" selloSAT=\"hww48LdeRjT/ACsirgMDt8gHkoZ7bXT2MNqjpid8C6z3QiJ9QM8IpwAyp6xpzG6Tk4BDnQNR+WQAGIb8yI+JzjLLOrpboQj8d5pcVvJx9A1F8mAioPWYUE/dgPWOzX4/PGx6GpHqspYTAyaXm2aIm6NuDbHzt6xoUJ0y5xRC598=\" />     <implocal:ImpuestosLocales version=\"1.0\" TotaldeRetenciones=\"44.77\" TotaldeTraslados=\"0\">       <implocal:RetencionesLocales ImpLocRetenido=\"Retención\" TasadeRetencion=\"0.00\" Importe=\"44.77\" />     </implocal:ImpuestosLocales>   </cfdi:Complemento> </cfdi:Comprobante>"
            //            };

            //#else
//#if DEBUG
            Respuesta = new WS_FEL.RespuestaOperacion(); // SrvCFDI.GenerarCFDIv32(Usuario, CFDI);
//else
            Respuesta = SrvCFDI.GenerarCFDIv32(Usuario, CFDI);
//#endif
            //#endif

            //for (int ind = 0; ind < Respuesta.Count - 1; ind++)
            //{
            //    rtb_FEL.AppendText("Respuesta (" + ind.ToString() + ") : " + Respuesta[ind] + Environment.NewLine);
            //}
          //  Respuesta.OperacionExitosa = false;
            // Exito
            if (Respuesta.OperacionExitosa==true)
            {
                // Guardar XML
                XmlDocument Factura = new XmlDocument();
                Factura.LoadXml(Respuesta.XML);
                
                /*
                 * Get atributos FEL
                 */

                XPathNavigator nav = Factura.CreateNavigator();

                // UUID XPath
                string UUID = string.Empty;
                string NoFact = string.Empty;
                string FecFact = string.Empty;
                string PathXml = configuracion.DirectorioFacturas;

                XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
                xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                try
                {
                    XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);
                    FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
                    NoFact = Comprobante.Attributes.GetNamedItem("serie").Value + "-" + Comprobante.Attributes.GetNamedItem("folio").Value;

                    if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
                        UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;

                    // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
                    XMLFile = XMLFile.Replace("NoFact", NoFact);
                    XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";

                    string uuidAnterior = remision.NumeroFactura;
                    remision.NumeroFactura = UUID;

                    if (!string.IsNullOrEmpty(PathXml))
                        XMLFile = Path.Combine(PathXml, XMLFile);

                    Factura.Save(@XMLFile);

                    // Remision
                    Random r = new Random();

                    // Salva Inf. en la BD                    
                    
                    if (uuidAnterior != string.Empty && uuidAnterior != "N")
                    {
                        SIFDatos.Factura.Factura.RemsionFacturas(usuarioInvoca, CFDI.Referencia, DateTime.Now, NoFact, UUID, tipoFac);
                        SIFDatos.Factura.Factura.ReFactura(remision.SucursalID, NoRemision, Respuesta.XML, XMLFile, uuidAnterior, UUID, tipoFac);
                        /*VMJA04032015*/
                        /*Respuesta = SrvCFDI.ObtenerPDF(Usuario, UUID);
                        if (Respuesta.OperacionExitosa && !String.IsNullOrEmpty(Respuesta.PDF))
                        {
                            System.IO.File.WriteAllBytes(configuracion.DirectorioFacturas + "/Facturas/" + "FAC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + CFDI.Referencia + ".pdf", Convert.FromBase64String(Respuesta.PDF));

                            if (MessageBoxEx.Show("¿Desea enviar la Factura al correo: " + Receptor.emailContacto + " ?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, Receptor.emailContacto);
                                //MessageBoxEx.Show("FACTURA ENVIADA AL CORREO ELECTRONICO: " + Receptor.emailContacto);
                            }
                           
                        }*/
                   //aqui k se haga carnal

                        
                    }
                    else
                    {
                        SIFDatos.Factura.Factura.InsertaFactura(NoRemision, Respuesta.XML, XMLFile, UUID, tipoFac);
                        /*VMJA04032015*/
                        /*Respuesta = SrvCFDI.ObtenerPDF(Usuario, UUID);
                        if (Respuesta.OperacionExitosa && !String.IsNullOrEmpty(Respuesta.PDF))
                        {
                            System.IO.File.WriteAllBytes(configuracion.DirectorioFacturas + "/Facturas/" + "FAC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + CFDI.Referencia + ".pdf", Convert.FromBase64String(Respuesta.PDF));

                            if (MessageBoxEx.Show("¿Desea enviar la Factura al correo: " + Receptor.emailContacto + " ?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, Receptor.emailContacto);
                               //MessageBox.Show("FACTURA ENVIADA AL CORREO ELECTRONICO: " + Receptor.emailContacto);
                            }
                            
                        }*/
                    }
                    remision.NumeroFactura = UUID;
                    new SIFNegocio.Remision().ActualizaUUIDRemision(remision);

                    

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            else
            {
                if (Respuesta.ErrorGeneral == null)
                {
                    Respuesta.ErrorGeneral = "WS_FEL NO INICIALIZADO";
                }
               MessageBox.Show(Respuesta.ErrorGeneral);
                return false;
            }

            SrvCFDI.Close();

            return true;
        }

        //**********************************************//
        //            Generacion del CBB.		      //
        //**********************************************//

        //public bool CodigoBidimensional(SIFModelo.Remision remision, SIFModelo.Configuracion.Factura configuracion)
        //{
        //    SIFModelo.Cliente cliente = new SIFNegocio.Clientes().ClientePorID(remision.ClienteID);
        //    SIFModelo.DireccionCliente direccion = new SIFNegocio.Clientes().DireccionCliente(cliente);

        //    //**********************************************
        //    // Instanciar al Web Service de Conexión Remota.
        //    //**********************************************
        //    WS_FEL.ConexionRemotaSoapClient conexionRemota = new WS_FEL.ConexionRemotaSoapClient();

        //    //**************************************************************
        //    // Sección de variables para la autenticación del usuario remoto.
        //    //**************************************************************
        //    // Vector para envío de datos de usuario.
        //    WS_FEL.ArrayOfString datosUsuario = new WS_FEL.ArrayOfString();
        //    // RFC del emisor (REQUERIDO). Posición 0.
        //    datosUsuario.Add(configuracion.RFCEmisor);
        //    // Cuenta del usuario (REQUERIDO). Posición 1.
        //    datosUsuario.Add(configuracion.UsuarioFEL);
        //    // Password del usuario (REQUERIDO). Posición 2.
        //    datosUsuario.Add(configuracion.PasswordFEL);

        //    // Respuesta del servicio.
        //    WS_FEL.ArrayOfString respuesta = new WS_FEL.ArrayOfString();
        //    // Consumir el servicio (En este caso es el de prueba).
        //    respuesta = conexionRemota.GenerarCodigoBidimensional(datosUsuario, remision.NumeroFactura);
        //    // Imprimir en pantalla cada uno de los valores develtos por el web service.
        //    //For i = 0 To respuesta.Count - 1
        //    //    // Respuesta(0) -> "True" en caso de éxito, "False" en caso opuesto.
        //    //    // Respuesta(1) -> "" (vacío) en caso de éxito, mensaje de error en caso opuesto.
        //    //    // Respuesta(2) -> la imagen en formato string base64 en caso de éxito, "" (vacío) en caso opuesto.
        //    //    // Ver valor de respuesta en pantalla.
        //    //    Response.Write("<br>Respuesta(" & i & ");: " + respuesta(i) + "<br><br>");
        //    //Next
        //    // Obtener el string base64.
        //    String codigoBase64 = respuesta[2];
        //    // Para capturar posible mensaje de error.
        //    String mensajeError = "";
        //    // Obtener la imagen del código bidimensional a partir del string en base64.
        //    Image codigoBidimensional = Base64ToImage(codigoBase64, mensajeError);
        //    // Checar que no haya mensaje de error.
        //    if (mensajeError == "")
        //    {
        //        // Guardar el código bidimensioanl en la carpeta deseada.
        //        codigoBidimensional.Save(configuracion.DirectorioFacturas);
        //        return true;
        //    }
        //    return false;
        //}


        #region " Funciones privadas para uso de imágenes "

        // Convertir de string en base64 a Imagen.
        public Image Base64ToImage(string ImagenBase64, string mensajeError)
        {
            Byte[] ArregloByte;
            Image Imagen;
            try
            {
                ArregloByte = Base64ToBytes(ImagenBase64);
                Imagen = BytesToImage(ArregloByte);
                mensajeError = "";
                return Imagen;
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return null;
            }
        }

        // De string base64 a bytes.
        private byte[] Base64ToBytes(string ImagenBase64)
        {
            Byte[] ArregloByte = Convert.FromBase64String(ImagenBase64);
            return ArregloByte;
        }

        // De bytes a imagen.
        private Image BytesToImage(Byte[] ImagenBytes)
        {
            MemoryStream ms = new MemoryStream(ImagenBytes);
            Image imagen = Image.FromStream(ms);
            return imagen;
        }

        #endregion



        //**********************************************//
        //            Cancelacion de un CFDI.	         //
        //**********************************************//

        //        public bool Cancelar(SIFModelo.Remision remision, SIFModelo.Configuracion.Factura configuracion)
        //        {
        //            //SIFModelo.WebServices.FelControl 

        //            //**********************************************
        //            // Instanciar al Web Service de Conexión Remota.
        //            //**********************************************
        //            WS_FEL.ConexionRemotaSoapClient conexionRemota = new WS_FEL.ConexionRemotaSoapClient();

        //            //**************************************************************
        //            // Sección de variables para la autenticación del usuario remoto.
        //            //**************************************************************
        //            // Vector para envío de datos de usuario.
        //            WS_FEL.ArrayOfString datosUsuario = new WS_FEL.ArrayOfString();
        //            // RFC del emisor (REQUERIDO). Posición 0.
        //            datosUsuario.Add(configuracion.RFCEmisor);
        //            // Cuenta del usuario (REQUERIDO). Posición 1.
        //            datosUsuario.Add(configuracion.UsuarioFEL);
        //            // Password del usuario (REQUERIDO). Posición 2.
        //            datosUsuario.Add(configuracion.PasswordFEL);


        //            //**************************************************************
        //            // Sección de lista de UUID a Cancelar.
        //            //**************************************************************
        //            // Vector para envío de los UUID a cancelar.
        //            WS_FEL.ArrayOfString listaUUID = new WS_FEL.ArrayOfString();

        //            // UUID a Cancelar
        //            listaUUID.Add(remision.NumeroFactura);
        //            // El vector listaUUID puede variar conforme a los CFDI que se desean cancelar.
        //            // 1 Posicion por UUID a cancelar.

        //            // Respuesta del servicio.
        //            WS_FEL.ArrayOfString respuesta = new WS_FEL.ArrayOfString();
        //            // Consumir el servicio.
        //            respuesta = conexionRemota.CancelarCFDI(datosUsuario, listaUUID);
        //            // Imprimir en pantalla cada uno de los valores develtos por el web service.
        //            //For i = 0 To respuesta.Count - 1
        //            //    // Respuesta(0) -> "True" en caso de éxito, "False" en caso opuesto.
        //            //    // Respuesta(1) -> Resultado de la operación del UUID
        //            //// Respuesta(N) -> Acuse de Cancelacion de la operación de los UUID.
        //            //    // Ver valor de respuesta en pantalla.
        //            //    Response.Write("<br>Respuesta(" & i & ");: " + respuesta(i) + "<br><br>");
        //            //Next
        //            //ACTUALIZAR EL CONTROL DE FACTURAS

        //            if (respuesta.Count == 0)
        //            {
        //               MessageBox.Show("No hay respuesta del servicio FEL ");

        //                return false;
        //            }

        //            if (respuesta[0].ToUpper() == "FALSE")
        //            {
        //               MessageBox.Show("Hubo un error al cancelar la factura " + respuesta[0]);
        //                return false;
        //            }

        //#if DEBUG
        //            respuesta[1] = "CANCELADO";
        //            respuesta[2] = "<?xml version=\"1.0\"?>" +
        //"<configuration> " +
        //"  <configSections>" +
        //"  </configSections>" +
        //"  <appSettings>" +
        //"    <add key=\"ACUSE\" value=\"acuse de cancelacion prueba\" />" +
        //"  </appSettings>" +
        //"</configuration> ";

        //#endif

        //            SIFDatos.Factura.Factura.ActualizaFactura(remision, respuesta[2], respuesta[1], remision.NumeroFactura);

        //            if ((respuesta[0] != "False"))
        //                return true;
        //            else
        //                return false;

        //        }

        //**********************************************//
        //            Envio CFDI por EMAIL	         //
        //**********************************************//

        //private bool EnviarPorMail(SIFModelo.Configuracion.Email email, SIFModelo.Remision remision, SIFModelo.Cliente cliente)
        //{
        //    SIFModelo.DireccionCliente Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente);

        //    // Checar que haya datos de autenticación.
        //    if (!(email.Usuario != "" && email.Usuario != "" && email.Contrasena != ""))
        //    {
        //        //Response.Write("Faltan datos para proceder...<br><br>");
        //        return false;
        //    }
        //    //**********************************************
        //    // Instanciar al Web Service de Conexión Remota.
        //    //**********************************************
        //    WS_FEL.ConexionRemotaSoapClient conexionRemota = new WS_FEL.ConexionRemotaSoapClient();

        //    //**************************************************************
        //    // Sección de variables para la autenticación del usuario remoto.
        //    //**************************************************************
        //    // Vector para envío de datos de usuario.
        //    WS_FEL.ArrayOfString datosUsuario = new WS_FEL.ArrayOfString();
        //    // RFC del emisor (REQUERIDO). Posición 0.
        //    datosUsuario.Add(email.Usuario);
        //    // Cuenta del usuario (REQUERIDO). Posición 1.
        //    datosUsuario.Add(email.Servidor);
        //    // Password del usuario (REQUERIDO). Posición 2.
        //    datosUsuario.Add(email.Contrasena);

        //    // Respuesta del servicio.
        //    WS_FEL.ArrayOfString respuesta = new WS_FEL.ArrayOfString();
        //    // Consumir el servicio (En este caso es el de prueba).
        //    respuesta = conexionRemota.EnviarCFDI(datosUsuario, remision.NumeroFactura, Direccion.Email);
        //    if (respuesta[0] == "True")
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        public bool NotaCredito(SIFModelo.Devolucion devolucion, SIFModelo.Remision remision, List<SIFModelo.DevolucionDetalle> detalles, SIFModelo.Configuracion.Factura configuracion, SIFModelo.Sucursal sucursal, SIFModelo.Cliente cliente)
        {
            if (!System.IO.Directory.Exists(configuracion.DirectorioFacturas))
            {
               MessageBox.Show("Configure el directorio de facturas");
                return false;
            }

            WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
            WS_FEL.RespuestaOperacion Respuesta = new WS_FEL.RespuestaOperacion();
            string XMLFile = devolucion.DevolucionID + "D " + devolucion.FechaDevolucion.ToString("ddMMyy") + " - " + sucursal.SucursalID;

            SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
            SIFModelo.DireccionCliente direccionCliente = null;
            SIFModelo.DireccionCliente Direccion = direccionCliente;

            if (Direccion == null)
            {
                Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente);
            }

            if (Direccion == null)
            {
                Direccion = new SIFModelo.DireccionCliente();
                Direccion.Calle = "-";
                Direccion.Celular = "";
                Direccion.Ciudad = "PUEBLA";
                Direccion.ClienteID = 0;
                Direccion.CodigoPostal = "72000";
                Direccion.Colonia = "-";
                Direccion.Email = "";
                Direccion.EntreCalles = "";
                Direccion.ID = 0;
                Direccion.Municipio = "PUEBLA";
                Direccion.NumeroExterior = "0";
                Direccion.NumeroInterior = "0";
                Direccion.RFC = "XAXX010101000";
                Direccion.Telefono = "";
                Direccion.TipoDireccion = SIFModelo.Tipos.TipoDireccion.fiscal;
            }

            //List<SIFModelo.RemisionDetalle> Detalles = remision.Detalles;
            //if (Detalles == null || Detalles.Count == 0)
            //{
            //    Detalles = remisionL.CargaRemisionDetalles(remision);
            //}

            SIFModelo.Moneda moneda = new SIFNegocio.Monedas().MonedaPorID(remision.MonedaID);

            SIFModelo.Impuesto impuesto = new SIFModelo.Impuesto(); // new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);
            SIFModelo.Pagos pago = new SIFNegocio.Pagos().PagoPorRemision(remision);

            if (pago == null)
            {
                pago = new SIFModelo.Pagos();
                pago.Activo = SIFModelo.Tipos.SiNo.SI;
                pago.BancoID = 1;
                pago.CajaID = 1;
                pago.CajeroID = 1;
                pago.ClienteID = 1;
                pago.DocumentoPago = "NO IDENTIFICADO";
                pago.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                pago.ImporteIVA = 0;
                pago.ImporteTotal = remision.Total;
                pago.ImporteVenta = remision.Total;
                pago.MonedaID = 1;
                pago.NumeroPago = 1;
                //pago.RemisionID = remision.NumeroRemision;
                pago.SucursalID = 1;
                pago.TipoCambioID = 1;
                pago.TipoPagoID = 1;
            }


            SIFModelo.TipoPago tipoPago = new SIFNegocio.TipoPagos().TipoPagoPorID(pago.TipoPagoID);

            if (tipoPago == null)
            {
                tipoPago = new SIFModelo.TipoPago();
                tipoPago.Nombre = configuracion.TipoPago;
            }

            WS_FEL.Credenciales Usuario = new WS_FEL.Credenciales();
            Usuario.Cuenta = (configuracion.RFCEmisor);
            Usuario.Usuario = (configuracion.UsuarioFEL);
            Usuario.Password = (configuracion.PasswordFEL);


            // Receptor
            WS_FEL.ReceptorR Receptor = new WS_FEL.ReceptorR();

            Receptor.Nombre = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            //Receptor.Add(""); // OPCIONAL
            //Receptor.Add(""); 
            Receptor.TelefonoContacto = (Direccion.Telefono).Trim();
            Receptor.emailContacto = (Direccion.Email).Trim();
            Receptor.RFC = (Direccion.RFC).Trim();
            Receptor.NombreCliente = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            Receptor.calle = (Direccion.Calle).Trim(); // CALLE
            Receptor.noExterior = (Direccion.NumeroExterior).Trim(); // NO EXTERIOR
            Receptor.noInterior = (Direccion.NumeroInterior).Trim(); // NO. INTERIOR
            Receptor.colonia = (Direccion.Colonia).Trim(); // COLONIA
            //Receptor.Add(""); // LOCALIDAD
            //Receptor.Add(""); // REFERENCIA
            Receptor.municipio = (Direccion.Municipio).Trim(); // MPIO
            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("ES-mx").TextInfo;
            var estadoLetraCapital = ti.ToTitleCase(Direccion.Ciudad.ToLower()).Trim();
            Receptor.estado = (estadoLetraCapital).Trim(); // EDO DE LA REP
            Receptor.pais = ("México"); // PAIS


            String Cp = Direccion.CodigoPostal.ToString();
            if (Cp.Length < 5)
                Cp = Cp.PadLeft(5, '0');
            Receptor.codigoPostal = (Cp); // CP

            // DATOS GENERALES CFDI
            WS_FEL.ComprobanteRemota CFDI = new WS_FEL.ComprobanteRemota();
            SIFModelo.TipoCambio cambio = new SIFNegocio.TipoCambios().BuscarPorID(pago.TipoCambioID);

            if (cambio == null)
            {
                cambio = new SIFModelo.TipoCambio();
                cambio.Factor = 1;
                cambio.VigenciaInicio = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            //
            devolucion.Impuesto = detalles.Sum(d => d.IVA);
            devolucion.SubTotal = devolucion.TotalDevolucion - devolucion.Impuesto;
            devolucion.CantidadConLetra = sif_tools.NumberToLetters.NumToLetter((double)devolucion.TotalDevolucion, "Decimal");
            devolucion.Impuesto = detalles.Sum(d => d.IVA);

            string TipoCFDI = "CRE";
            CFDI.ClaveCFDI = (TipoCFDI);
            CFDI.formaDePago = (configuracion.TipoPago);//Forma de pago
            //CFDI.Add(""); // PARCIALIDADES
            //CFDI.Add(""); // CONDICIONES DE PAGO
            CFDI.metodoDePago = (tipoPago.Nombre); // METODO PAGO
            CFDI.descuento = (remision.Descuento); // DESCUENTO
            CFDI.PorcentajeDescuento = 0m; // PORCENTAJE DESCTO
            //CFDI.Add(""); // MOTIVO DESCTO
            CFDI.Moneda = ("MXN"); //MONEDA
            //CFDI.Add(""); // TIPO CAMBIO
            //CFDI.Add(""); // FECHA TIPO CAMBIO
            CFDI.Impuestos = new WS_FEL.ImpuestosR();
            CFDI.Impuestos.totalImpuestosRetenidos = 0m; // TOTAL IMPUESTO RETENIDO
            CFDI.Impuestos.totalImpuestosTrasladados = (devolucion.Impuesto); // TOTAL IMPUESTO TRASLADADO
            CFDI.subTotal = (devolucion.SubTotal); // SUBTOTAL
            CFDI.total = devolucion.TotalDevolucion; // TOTAL COMPROBANTE
            CFDI.ImporteConLetra = (remision.ImporteLetra); // TOTAL CON LETRA
            CFDI.LugarExpedicion = (sucursal.Ciudad); // LUGAR DE EXPEDICION
            CFDI.NumCtaPago = (pago.DocumentoPago); // NUM CTA PAGO
            //CFDI.Add(""); // FOLIO FISCAL ORIGINAL
            //CFDI.Add(""); // SERIE FOLIOI FISCAL
            //CFDI.Add(""); // FECHA FOLIO FISCAL
            //CFDI.Add(""); // MONTO FOLIO FISCAL

            //NUMERO DE REMISION
            string NoRemision = remision.NumeroRemision;
            if (string.IsNullOrEmpty(NoRemision))
            {
                NoRemision = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
            }
            // EMISOR INFO COMERCIAL
            List<WS_FEL.EtiquetaPersonalizadaR> Etiquetas = new List<WS_FEL.EtiquetaPersonalizadaR>();
            Etiquetas.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = NoRemision, Valor = "Servicio a domicilio sin costo" });   
            Etiquetas.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m2", Valor = "Concentrados 100% en tu salud" });

            // CONCEPTOS
            List<WS_FEL.ConceptoR> Conceptos = new List<WS_FEL.ConceptoR>();
            foreach (SIFModelo.DevolucionDetalle rconcepto in detalles)
            {
                SIFModelo.Impuesto impuestoC;
                impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(1);//detalle.IVA);
                if (impuestoC == null)
                {
                    impuestoC = new SIFModelo.Impuesto();
                }

                WS_FEL.ConceptoR concepto = new WS_FEL.ConceptoR();
                concepto.DetalleConcepto = new WS_FEL.DetallesConcepto();

                concepto.cantidad = rconcepto.Cantidad;
                concepto.noIdentificacion = rconcepto.ArticuloID;
                concepto.unidad = "PIEZA";
                concepto.descripcion = rconcepto.Nombre1;
                concepto.valorUnitario = rconcepto.Precio;
                concepto.importe = rconcepto.Total;

                concepto.DetalleConcepto.TipoCalculo = WS_FEL.TipoCalculoPartida.PARTIDA;
                List<WS_FEL.DetalleTraslado> traslados = new List<WS_FEL.DetalleTraslado>();
                WS_FEL.DetalleTraslado traslado = new WS_FEL.DetalleTraslado();
                traslado.Nombre = impuestoC.Nombre + " " + impuestoC.Porcentaje + "%";
                traslado.impuesto = impuestoC.Nombre;
                traslado.tasa = impuestoC.Porcentaje;
                traslado.importe = rconcepto.IVA;
                traslados.Add(traslado);

                Conceptos.Add(concepto);
            }

            CFDI.Conceptos = Conceptos.ToArray();
            CFDI.Referencia = NoRemision;

            //// IMPUESTOS RETENIDOS LOCALES
            //WS_FEL.ArrayOfString ImpRetL = new WS_FEL.ArrayOfString();
            ////ImpRetL.Add("|IVA (Local 10.00%)|IVA|10.00|0.00|");
            //// IMPUESTOS TRASLADADOS LOCALES
            //WS_FEL.ArrayOfString ImpTraL = new WS_FEL.ArrayOfString();
            ////ImpTraL.Add("|IVA (Local 16.00%)|IVA|16.00|0.00|");

            List<WS_FEL.RegimenFiscalR> listaRegimenFiscales = new List<WS_FEL.RegimenFiscalR>();
            WS_FEL.RegimenFiscalR Regimen = new WS_FEL.RegimenFiscalR();
            Regimen.Regimen = configuracion.ActividadEmpresarial;
            listaRegimenFiscales.Add(Regimen);
            CFDI.RegimenesFiscales = listaRegimenFiscales.ToArray();

            Respuesta = SrvCFDI.GenerarCFDIv32(Usuario, CFDI);

            //for (int ind = 0; ind < Respuesta.Count - 1; ind++)
            //{
            //    rtb_FEL.AppendText("Respuesta (" + ind.ToString() + ") : " + Respuesta[ind] + Environment.NewLine);
            //}

            // Exito
            if (Respuesta.OperacionExitosa)
            {
                // Guardar XML
                XmlDocument Factura = new XmlDocument();
                Factura.LoadXml(Respuesta.XML);

                /*
                 * Get atributos FEL
                 */

                XPathNavigator nav = Factura.CreateNavigator();

                // UUID XPath
                string UUID = string.Empty;
                string NoFact = string.Empty;
                string FecFact = string.Empty;
                string PathXml = configuracion.DirectorioFacturas;

                XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
                xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                try
                {
                    XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);

                    FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
                    NoFact = Comprobante.Attributes.GetNamedItem("folio").Value;

                    if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
                        UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;

                    // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
                    XMLFile = XMLFile.Replace("NoFact", NoFact);
                    XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";
                    remision.NumeroFactura = UUID;

                    if (!string.IsNullOrEmpty(PathXml))
                        XMLFile = Path.Combine(PathXml, XMLFile);

                    Factura.Save(@XMLFile);

                    // Remision
                    Random r = new Random();

                    // Salva Inf. en la BD                    
                    SIFDatos.Factura.Factura.InsertaFactura(devolucion.DevolucionID, Respuesta.XML, XMLFile, UUID, TipoCFDI);
                    remision.NumeroFactura = UUID;
                    new SIFNegocio.Remision().ActualizaUUIDRemision(remision);
                    /*VMJA04032015*/
                    /*Respuesta = SrvCFDI.ObtenerPDF(Usuario, UUID);
                    if (Respuesta.OperacionExitosa && !String.IsNullOrEmpty(Respuesta.PDF))
                    {
                        System.IO.File.WriteAllBytes(configuracion.DirectorioFacturas + "/Facturas/" + "NC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + CFDI.Referencia + ".pdf", Convert.FromBase64String(Respuesta.PDF));

                        if (MessageBoxEx.Show("¿Desea enviar la  Nota de Credito al correo: " + Receptor.emailContacto + " ?", "Nota de credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, Receptor.emailContacto);
                           ///MessageBox.Show("NOTA DE CREDITO ENVIADA A EL E-MAIL: " + Receptor.emailContacto);
                        }
                      
                    }*/
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            else
            {
               MessageBox.Show(Respuesta.ErrorGeneral);
                return false;
            }

            SrvCFDI.Close();

            return true;
        }

        public  bool NotaCredito(out SIFModelo.WebServices.FelControl fc, SIFModelo.Configuracion.Factura configuracion, SIFModelo.Configuracion.Aplicacion email, SIFModelo.Cliente cliente, SIFModelo.Remision remision, SIFModelo.Sucursal sucursal, SIFModelo.DireccionCliente direccionCliente = null, bool esFacturaGlobal = false)
        {
            if (!System.IO.Directory.Exists(configuracion.DirectorioFacturas))
            {
                fc = new SIFModelo.WebServices.FelControl();
               MessageBox.Show("Configure el directorio de facturas");
                return false;
            }

            fc = new SIFModelo.WebServices.FelControl();
            WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
          //  WS_FEL.ConexionRemotaSoapClient SrvPDF = new WS_FEL.ConexionRemotaSoapClient();
            WS_FEL.RespuestaOperacion Respuesta = new WS_FEL.RespuestaOperacion();
           // WS_FEL.RespuestaOperacion ObtPDF = new WS_FEL.RespuestaOperacion();
            string XMLFile = remision.NumeroRemision + " " + remision.FechaVenta.ToString("ddMMyy") + " - " + sucursal.SucursalID;

            //SrvCFDI. (Usuario, Receptor, CFDI, Etiqueta, Concepto, Aduana, ImpRet, ImpTra, ImpRetL, ImpTraL);

            SIFNegocio.Remision remisionL = new SIFNegocio.Remision();
            SIFModelo.DireccionCliente Direccion = direccionCliente;

            if (Direccion == null)
            {
                Direccion = new SIFNegocio.Clientes().DireccionCliente(cliente);
            }

            List<SIFModelo.RemisionDetalle> Detalles = remision.Detalles;
            if (Detalles == null || Detalles.Count == 0)
            {
                Detalles = remisionL.CargaRemisionDetalles(remision);
            }

            SIFModelo.Moneda moneda = new SIFNegocio.Monedas().MonedaPorID(remision.MonedaID);

            SIFModelo.Impuesto impuesto = new SIFModelo.Impuesto(); // new SIFNegocio.Impuestos().ImpuestoPorID(remision.Impuesto);
            SIFModelo.Pagos pago = new SIFNegocio.Pagos().PagoPorRemision(remision);

            if (pago == null)
            {
                pago = new SIFModelo.Pagos();
                pago.Activo = SIFModelo.Tipos.SiNo.SI;
                pago.BancoID = 1;
                pago.CajaID = 1;
                pago.CajeroID = 1;
                pago.ClienteID = 1;
                pago.DocumentoPago = "NO IDENTIFICADO";
                pago.Fecha = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
                pago.ImporteIVA = 0;
                pago.ImporteTotal = remision.Total;
                pago.ImporteVenta = remision.Total;
                pago.MonedaID = 1;
                pago.NumeroPago = 1;
                //pago.RemisionID = remision.NumeroRemision;
                pago.SucursalID = 1;
                pago.TipoCambioID = 1;
                pago.TipoPagoID = 1;
            }


            SIFModelo.TipoPago tipoPago = new SIFNegocio.TipoPagos().TipoPagoPorID(pago.TipoPagoID);

            if (tipoPago == null)
            {
                tipoPago = new SIFModelo.TipoPago();
                tipoPago.Nombre = configuracion.TipoPago;
            }

            WS_FEL.Credenciales Usuario = new WS_FEL.Credenciales();
            Usuario.Cuenta = (configuracion.RFCEmisor);
            Usuario.Usuario = (configuracion.UsuarioFEL);
            Usuario.Password = (configuracion.PasswordFEL);


            // Receptor
            WS_FEL.ReceptorR Receptor = new WS_FEL.ReceptorR();

            Receptor.Nombre = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            //Receptor.Add(""); // OPCIONAL
            //Receptor.Add(""); // Receptor.Add(Direccion.Telefono);
            Receptor.emailContacto = (Direccion.Email).Trim();
            Receptor.RFC = (Direccion.RFC).Trim(); //"XAXX010101000"
            Receptor.NombreCliente = (cliente.Nombre + " " + cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno).Trim();
            Receptor.calle = (Direccion.Calle).Trim(); // CALLE
            Receptor.noExterior = (Direccion.NumeroExterior).Trim(); // NO EXTERIOR
            Receptor.noInterior = (Direccion.NumeroInterior).Trim(); // NO. INTERIOR
            Receptor.colonia = (Direccion.Colonia).Trim(); // COLONIA
            //Receptor.Add(""); // LOCALIDAD
            //Receptor.Add(""); // REFERENCIA
            Receptor.municipio = (Direccion.Municipio).Trim(); // MPIO
            System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("ES-mx").TextInfo;
            var estadoLetraCapital = ti.ToTitleCase(Direccion.Ciudad.ToLower()).Trim();
            Receptor.estado = (estadoLetraCapital).Trim(); // EDO DE LA REP
            Receptor.pais = ("México"); // PAIS

            String Cp = Direccion.CodigoPostal.ToString();
            if (Cp.Length < 5)
                Cp = Cp.PadLeft(5, '0');
            Receptor.codigoPostal = (Cp); // CP

            // DATOS GENERALES CFDI
            WS_FEL.ComprobanteRemota CFDI = new WS_FEL.ComprobanteRemota();
            CFDI.Receptor = Receptor;
            SIFModelo.TipoCambio cambio = new SIFNegocio.TipoCambios().BuscarPorID(pago.TipoCambioID);

            if (cambio == null)
            {
                cambio = new SIFModelo.TipoCambio();
                cambio.Factor = 1;
                cambio.VigenciaInicio = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            }

            string TipoCFDI = "CRE";
            CFDI.ClaveCFDI = (TipoCFDI);
            CFDI.formaDePago = (configuracion.TipoPago);//Forma de pago
            //CFDI.Add(""); // PARCIALIDADES
            //CFDI.Add(""); // CONDICIONES DE PAGO
            CFDI.metodoDePago = (tipoPago.Nombre); // METODO PAGO
            CFDI.descuento = remision.Descuento; // DESCUENTO
            CFDI.PorcentajeDescuento = 0m; // PORCENTAJE DESCTO
            //CFDI.Add(""); // MOTIVO DESCTO
            CFDI.Moneda = ("MXN"); //MONEDA
            //CFDI.Add(""); // TIPO CAMBIO
            //CFDI.Add(""); // FECHA TIPO CAMBIO
            //CFDI.Add("0.00"); // TOTAL IMPUESTO RETENIDO

            CFDI.Impuestos = new WS_FEL.ImpuestosR();
            CFDI.Impuestos.totalImpuestosTrasladados = remision.Impuesto; // TOTAL IMPUESTO TRASLADADO
            CFDI.subTotal = remision.SubTotal; // SUBTOTAL
            CFDI.total = remision.Total; // TOTAL COMPROBANTE
            string importeLetra = sif_tools.NumberToLetters.NumToLetter((double)remision.Total, remision.Total.GetType().Name);
            CFDI.ImporteConLetra = (importeLetra); // TOTAL CON LETRA
            CFDI.LugarExpedicion = (sucursal.Ciudad); // LUGAR DE EXPEDICION
            CFDI.NumCtaPago = (pago.DocumentoPago); // NUM CTA PAGO
            //CFDI.Add(""); // FOLIO FISCAL ORIGINAL
            //CFDI.Add(""); // SERIE FOLIOI FISCAL
            //CFDI.Add(""); // FECHA FOLIO FISCAL
            //CFDI.Add(""); // MONTO FOLIO FISCAL


            List<WS_FEL.TrasladoR> listaImpuestosTraslados = new List<WS_FEL.TrasladoR>();
            WS_FEL.TrasladoR impuestosTraslados = new WS_FEL.TrasladoR();
            impuestosTraslados.NombreImpuesto = "IVA 16%";
            impuestosTraslados.Tasa = 16;
            impuestosTraslados.Impuesto = "IVA";
            impuestosTraslados.Importe = remision.Impuesto; // TOTAL IMPUESTO TRASLADADO
            listaImpuestosTraslados.Add(impuestosTraslados);
            CFDI.Impuestos.Traslados = listaImpuestosTraslados.ToArray();

            //NUMERO DE REMISION
            string NoRemision = remision.NumeroRemision;
            if (NoRemision == null)
            {
                NoRemision = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString(sucursal.SucursalesID.ToString("00") + "ddMMyyyy");
            }
            CFDI.Referencia = NoRemision;

            // EMISOR INFO COMERCIAL
            List<WS_FEL.EtiquetaPersonalizadaR> Etiqueta = new List<WS_FEL.EtiquetaPersonalizadaR>();
            Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "NoRemision", Valor = remision.NumeroRemision });
            Etiqueta.Add(new WS_FEL.EtiquetaPersonalizadaR() { Nombre = "m2", Valor = "Concentrados 100% en tu salud" });
            CFDI.Etiquetas = Etiqueta.ToArray();

            // CONCEPTOS
            List<WS_FEL.ConceptoR> Conceptos = new List<WS_FEL.ConceptoR>();
            double impuestoIVA = 0;
            foreach (SIFModelo.RemisionDetalle rconcepto in Detalles)
            {
                string unidad = "PIEZA";
                                
                if (rconcepto.ArticuloID == "")
                {
                    unidad = "NO APLICA";
                }

                if (rconcepto.ImpuestoID > 1)
                    //impuestoIVA += (double)rconcepto.Precio*(double)rconcepto.CantidadRemision*((double)rconcepto.PorcentajeDescuento/100);
                    impuestoIVA += (double)rconcepto.MontoDescuento;
                

                WS_FEL.ConceptoR concepto = new WS_FEL.ConceptoR();
                concepto.DetalleConcepto = new WS_FEL.DetallesConcepto();

                concepto.cantidad = rconcepto.CantidadRemision;
                concepto.noIdentificacion = rconcepto.ArticuloID;
                concepto.unidad = unidad;
                concepto.descripcion = rconcepto.Nombre1;
                concepto.valorUnitario = rconcepto.Precio;
                concepto.importe = rconcepto.Total;

                concepto.DetalleConcepto.TipoCalculo = WS_FEL.TipoCalculoPartida.PARTIDA;

                List<WS_FEL.DetalleTraslado> traslado_Partida = new List<WS_FEL.DetalleTraslado>();
                SIFModelo.Impuesto impuestoC = new SIFNegocio.Impuestos().ImpuestoPorID(rconcepto.ImpuestoID);
                if (impuestoC == null)
                    impuestoC = new SIFModelo.Impuesto();

                WS_FEL.DetalleTraslado traslado = new WS_FEL.DetalleTraslado();
                traslado.Nombre = impuestoC.Nombre + " " + impuestoC.Porcentaje + "%";
                traslado.impuesto = impuestoC.Nombre;
                traslado.tasa = impuestoC.Porcentaje;
                traslado.importe = rconcepto.IVA;
                traslado_Partida.Add(traslado);
                concepto.DetalleConcepto.Traslados = traslado_Partida.ToArray();

                Conceptos.Add(concepto);
            }
            impuestoIVA = impuestoIVA/1.16*.16;
            CFDI.Conceptos = Conceptos.ToArray();
            CFDI.Referencia = NoRemision;

            //if (esFacturaGlobal)
            //{
            //    Impuestos impuestosL = new Impuestos();
            //    //impuestosL.Buscar("Activo", "S");
            //    foreach (var rd in Detalles)
            //    {
            //        SIFModelo.Impuesto impuestoC = impuestosL.ImpuestoPorID(rd.ImpuestoID);
            //        ImpTra.Add("|" + impuestoC.Nombre + " (IVA " + impuestoC.Porcentaje + "%)|IVA|" + impuestoC.Porcentaje + "|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(rd.IVA) + "|");
            //    }
            //}
            //else
            //{
            //    ImpTra.Add("|IVA (IVA 16%)|IVA|16|" + SIFNegocio.Configuracion.Configuraciones.TruncateToDecimalPlace(remision.Impuesto).ToString("0.00") + "|");
            //}

            //#if DEBUG


            //            Random random = new Random();
            //            int randomNumber = random.Next(0, 9999);

            //            Respuesta = new WS_FEL.ArrayOfString()
            //            {
            //                "True",
            //                "",
            //                "",
            //                "<?xml version=\"1.0\" encoding=\"utf-8\"?><cfdi:Comprobante xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" version=\"3.2\" serie=\"AS\" folio=\"57661\" fecha=\"2013-04-27T18:33:31\" sello=\"2Crit3aTKQIO+U1/3TDs6C2dkPNqQtIhWYt3Txe0Igsj5XdeFIgQglcI3h3j79t7HdP30FEhdGG6CVD/aNKj9p344Yc55wPiAaF8SrSmsPQkSiV28pdEntrpRUAZhCNr5JWIF9oPOwzkWETjtISYwElk7FxeSWUAzcP8P2u8JcQ=\" formaDePago=\"NO IDENTIFICADO\" noCertificado=\"00001000000203558833\" certificado=\"MIIE0jCCA7qgAwIBAgIUMDAwMDEwMDAwMDAyMDM1NTg4MzMwDQYJKoZIhvcNAQEFBQAwggGVMTgwNgYDVQQDDC9BLkMuIGRlbCBTZXJ2aWNpbyBkZSBBZG1pbmlzdHJhY2nDs24gVHJpYnV0YXJpYTEvMC0GA1UECgwmU2VydmljaW8gZGUgQWRtaW5pc3RyYWNpw7NuIFRyaWJ1dGFyaWExODA2BgNVBAsML0FkbWluaXN0cmFjacOzbiBkZSBTZWd1cmlkYWQgZGUgbGEgSW5mb3JtYWNpw7NuMSEwHwYJKoZIhvcNAQkBFhJhc2lzbmV0QHNhdC5nb2IubXgxJjAkBgNVBAkMHUF2LiBIaWRhbGdvIDc3LCBDb2wuIEd1ZXJyZXJvMQ4wDAYDVQQRDAUwNjMwMDELMAkGA1UEBhMCTVgxGTAXBgNVBAgMEERpc3RyaXRvIEZlZGVyYWwxFDASBgNVBAcMC0N1YXVodMOpbW9jMRUwEwYDVQQtEwxTQVQ5NzA3MDFOTjMxPjA8BgkqhkiG9w0BCQIML1Jlc3BvbnNhYmxlOiBDZWNpbGlhIEd1aWxsZXJtaW5hIEdhcmPDrWEgR3VlcnJhMB4XDTEzMDQyNDAxNTgwMloXDTE3MDQyNDAxNTgwMlowggESMTwwOgYDVQQDEzNPUEVSQURPUiBERSBGQVJNQUNJQVMgQS5GLiBERUwgQ0VOVFJPIFMgREUgUkwgREUgQ1YxPDA6BgNVBCkTM09QRVJBRE9SIERFIEZBUk1BQ0lBUyBBLkYuIERFTCBDRU5UUk8gUyBERSBSTCBERSBDVjE8MDoGA1UEChMzT1BFUkFET1IgREUgRkFSTUFDSUFTIEEuRi4gREVMIENFTlRSTyBTIERFIFJMIERFIENWMSUwIwYDVQQtExxPRkEwODAxMjlVNjkgLyBRVU9HNjEwMzI3N05BMR4wHAYDVQQFExUgLyBRVU9HNjEwMzI3SFBMUlJEMDkxDzANBgNVBAsTBlVuaWRhZDCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEA6eWS8DAX5baewvlbaNt3dfZp+XETyZ6M6Wfv+wQxo9BKh0k+tQ9c4z0Uq9Kf5uBaBppiL4Qoqf/v/+0m8abaVj5oGeFfByiUY07hxI3x0IFiigmyMiZru6xHHbsg1SI9h+4w8dkKRSaDiYqnGsv7jizDrWRe0bANtaSHXAvlCDcCAwEAAaMdMBswDAYDVR0TAQH/BAIwADALBgNVHQ8EBAMCBsAwDQYJKoZIhvcNAQEFBQADggEBAH0FGeHlosopsdYxYcraljTO5/8n260w4M/wNGZL2vPO7j1ncFQ4OnbFgyKp5DArKQYzs3Y9LLltS/Jm89ECPmZU3pzHPUulx0PftGu8UTSBkIUegQJOZkuo4QVXlHloWfGWc5LGHNFAVAvHc6GTh1Qb0tqyAIsosG4nptRYTr3etS2CvjY2FsFNIGXoMa7+RwPv335IRediICnRsM91mWuRjNHOwUodu21j5xSvuyW2zVoddf4v/Vs8DbMInh28mfM8fiKKWsno24Z3GvNLyLs+5QNXMvcQ+SFtXD+eIzFXtmu6uN3S54vUZxqpneG4rPgtUSGiPefuxKYqeqLGeck=\" subTotal=\"768.72\" descuento=\"23.06\" Moneda=\"MXN\" total=\"757.08\" tipoDeComprobante=\"egreso\" metodoDePago=\"TARJETA DE DEBITO\" LugarExpedicion=\"PUEBLA, Puebla\" xsi:schemaLocation=\"http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd\" xmlns:cfdi=\"http://www.sat.gob.mx/cfd/3\"><cfdi:Emisor rfc=\"OFA080129U69\" nombre=\"OPERADOR DE FARMACIAS A.F. DEL CENTRO S. DE R.L. DE C.V.\"><cfdi:DomicilioFiscal calle=\"13 SUR\" noExterior=\"2701\" colonia=\"VOLCANES\" localidad=\"PUEBLA\" municipio=\"PUEBLA\" estado=\"PUEBLA\" pais=\"MEXICO\" codigoPostal=\"72410\" /><cfdi:RegimenFiscal Regimen=\"Régimen General de Ley Personas Morales\" /></cfdi:Emisor><cfdi:Receptor rfc=\"COMC630822XXX\" nombre=\"CINDY ALEJANDRA CONTRERAS MORENO\"><cfdi:Domicilio calle=\"AV. SAN JOSE XILOTZINGO\" noExterior=\"10315\" colonia=\"GAVILANES XILOTZINGO\" municipio=\"PUEBLA\" estado=\"PUEBLA\" pais=\"MEXICO\" codigoPostal=\"72593\" /></cfdi:Receptor><cfdi:Conceptos><cfdi:Concepto cantidad=\"2.00\" unidad=\"PIEZA\" noIdentificacion=\"7501073025554\" descripcion=\"JERINGA BD 10 ML 20 X 32\" valorUnitario=\"4.31\" importe=\"8.62\" /><cfdi:Concepto cantidad=\"2.00\" unidad=\"PIEZA\" noIdentificacion=\"KCL\" descripcion=\"KELEFUSIN (CLORURO POTASIO) 5 ML\" valorUnitario=\"13.00\" importe=\"26.00\" /><cfdi:Concepto cantidad=\"10.00\" unidad=\"PIEZA\" noIdentificacion=\"0382903017300\" descripcion=\"AGUJA BD PG 20 X 32 MM (PZA)\" valorUnitario=\"1.72\" importe=\"17.20\" /><cfdi:Concepto cantidad=\"3.00\" unidad=\"PIEZA\" noIdentificacion=\"7501125101601\" descripcion=\"G.I. OMEPRAZOL PIS 40 MG SOL INY^\" valorUnitario=\"110.50\" importe=\"331.50\" /><cfdi:Concepto cantidad=\"1.00\" unidad=\"PIEZA\" noIdentificacion=\"7501300407030\" descripcion=\"DOLAC 30 MG C/3 AMP 1 ML^\" valorUnitario=\"200.00\" importe=\"200.00\" /><cfdi:Concepto cantidad=\"1.00\" unidad=\"PIEZA\" noIdentificacion=\"7501125124549\" descripcion=\"PRAMOTIL 10 MG C/6 AMP\" valorUnitario=\"24.00\" importe=\"24.00\" /><cfdi:Concepto cantidad=\"2.00\" unidad=\"PIEZA\" noIdentificacion=\"7501088505003\" descripcion=\"ALIN AMP 2 ML^^\" valorUnitario=\"32.50\" importe=\"65.00\" /><cfdi:Concepto cantidad=\"2.00\" unidad=\"PIEZA\" noIdentificacion=\"7501125100130\" descripcion=\"SOL CS 0.9% 1000 ML^^\" valorUnitario=\"16.50\" importe=\"33.00\" /><cfdi:Concepto cantidad=\"1.00\" unidad=\"PIEZA\" noIdentificacion=\"7501125100192\" descripcion=\"SOL MIXTA (DX-CS) 1000 ML\" valorUnitario=\"16.00\" importe=\"16.00\" /><cfdi:Concepto cantidad=\"10.00\" unidad=\"PIEZA\" noIdentificacion=\"7501073025622\" descripcion=\"JERINGA BD 20 ML S/AGUJA\" valorUnitario=\"4.74\" importe=\"47.40\" /></cfdi:Conceptos><cfdi:Impuestos totalImpuestosRetenidos=\"0.00\" totalImpuestosTrasladados=\"11.37\"><cfdi:Traslados><cfdi:Traslado impuesto=\"IVA\" tasa=\"16.00\" importe=\"11.37\" /></cfdi:Traslados></cfdi:Impuestos><cfdi:Complemento><tfd:TimbreFiscalDigital xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" xsi:schemaLocation=\"http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd\" version=\"1.0\" UUID=\"9473840F-27E8-4ECD-9332-A0122EF49"+ randomNumber.ToString().PadLeft(3,'0') + "\" FechaTimbrado=\"2013-04-27T18:33:32\" selloCFD=\"2Crit3aTKQIO+U1/3TDs6C2dkPNqQtIhWYt3Txe0Igsj5XdeFIgQglcI3h3j79t7HdP30FEhdGG6CVD/aNKj9p344Yc55wPiAaF8SrSmsPQkSiV28pdEntrpRUAZhCNr5JWIF9oPOwzkWETjtISYwElk7FxeSWUAzcP8P2u8JcQ=\" noCertificadoSAT=\"00001000000203220546\" selloSAT=\"V2/tUoh5Vyvvdfx+Mgt7iYDs4Cje/+WGz+peXR0Nzq4km6Y5iyDrAVACLoG93E1rsbsNCIVHgqXNZt8lgC6rQGV5ybc9SbBSkVVTdlvmMhXeRQM71nPFx0LK8pQWyctz5/QSHlohErWuXhoTloaMBlG7YWHDBotmIlT9Q0mK5L4=\" /></cfdi:Complemento></cfdi:Comprobante>"
            //            };

            //#else

            List<WS_FEL.RegimenFiscalR> listaRegimenFiscales = new List<WS_FEL.RegimenFiscalR>();
            WS_FEL.RegimenFiscalR Regimen = new WS_FEL.RegimenFiscalR();
            Regimen.Regimen = configuracion.ActividadEmpresarial;
            listaRegimenFiscales.Add(Regimen);
            CFDI.RegimenesFiscales = listaRegimenFiscales.ToArray();

            Respuesta = SrvCFDI.GenerarCFDIv32(Usuario, CFDI);
            //#endif
            //for (int ind = 0; ind < Respuesta.Count - 1; ind++)
            //{
            //    rtb_FEL.AppendText("Respuesta (" + ind.ToString() + ") : " + Respuesta[ind] + Environment.NewLine);
            //}

            // Exito
           

            if (Respuesta.OperacionExitosa)
            {
                
                // Guardar XML
                XmlDocument Factura = new XmlDocument();
                Factura.LoadXml(Respuesta.XML);

                /*
                 * Get atributos FEL
                 */

                XPathNavigator nav = Factura.CreateNavigator();

                // UUID XPath
                string UUID = string.Empty;
                string NoFact = string.Empty;
                string FecFact = string.Empty;
                string PathXml = configuracion.DirectorioFacturas;

                XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
                xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
                xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                try
                {
                    XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);

                    FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
                    NoFact = Comprobante.Attributes.GetNamedItem("folio").Value;

                    if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
                        UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;

                    // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
                    XMLFile = XMLFile.Replace("NoFact", NoFact);
                    XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";
                    remision.NumeroFactura = UUID;

                    if (!string.IsNullOrEmpty(PathXml))
                        XMLFile = Path.Combine(PathXml, XMLFile);

                    Factura.Save(@XMLFile);

                    // Remision
                    Random r = new Random();

                    // Salva Inf. en la BD                    
                    //SIFDatos.Factura.Factura.InsertaFactura(NoRemision, Respuesta[3], XMLFile, UUID, TipoCFDI);
                    //remision.NumeroFactura = UUID;
                    //new SIFNegocio.Remision().ActualizaRemision(remision);


                    fc.UUID = UUID;
                    fc.FACTURA = Respuesta.XML;
                    fc.PATH_FACTURA = XMLFile;
                    fc.TIPO_CFDI = TipoCFDI;
                    NoFact = Comprobante.Attributes.GetNamedItem("serie").Value + "-" + Comprobante.Attributes.GetNamedItem("folio").Value;
                    SIFDatos.Factura.Factura.RemsionFacturas(usuarioInvoca, CFDI.Referencia, DateTime.Now, NoFact, UUID, CFDI.ClaveCFDI);

                    /*Respuesta = SrvCFDI.ObtenerPDF(Usuario, UUID);
                    if (Respuesta.OperacionExitosa && !String.IsNullOrEmpty(Respuesta.PDF))
                    {
                        System.IO.File.WriteAllBytes(configuracion.DirectorioFacturas + "/Facturas/" + "NC_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + CFDI.Referencia + ".pdf", Convert.FromBase64String(Respuesta.PDF));
                        //Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, "vmja@outlook.com");
                        if (MessageBoxEx.Show("¿Desea enviar la Nota de Credito al correo: " + Receptor.emailContacto + " ?", "Nota de Credito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Respuesta = SrvCFDI.EnviarCFDI(Usuario, UUID, Receptor.emailContacto);
                            //MessageBoxEx.Show("NOTA DE CREDITO ENVIADA AL CORREO ELECTRONICO: " + Receptor.emailContacto);
                        }
                    }*/
                    

                    return true;
                }
                catch (Exception ex)
                {
                   MessageBox.Show(Respuesta.ErrorGeneral);
                   MessageBox.Show(Respuesta.ErrorDetallado);
                    return false;
                }
                finally
                {
                    SrvCFDI.Close();
                }

            }
            else
            {
               MessageBox.Show(Respuesta.ErrorGeneral);
                return false;
            }

            SrvCFDI.Close();

            return true;
        }


        public SIFModelo.WebServices.FelControl DevolucionPorRemision(SIFModelo.Remision remision)
        {
            return SIFDatos.Factura.Factura.DevolucionPorRemision(remision);
        }


        public bool FacturaPorReferencia(SIFModelo.Remision remision, SIFModelo.Configuracion.Factura configuracion)
        {
            SIFModelo.WebServices.FelControl fc = null;
            if (!System.IO.Directory.Exists(configuracion.DirectorioFacturas))
            {
                fc = new SIFModelo.WebServices.FelControl();
               MessageBox.Show("Configure el directorio de facturas");
                return false;
            }

            fc = new SIFModelo.WebServices.FelControl();
            WS_FEL.ConexionRemotaSoapClient SrvCFDI = new WS_FEL.ConexionRemotaSoapClient();
            WS_FEL.RespuestaOperacion Respuesta = new WS_FEL.RespuestaOperacion();
            string XMLFile = remision.NumeroRemision + " " + remision.FechaVenta.ToString("ddMMyy") + " - " + remision.SucursalID;


            WS_FEL.Credenciales Usuario = new WS_FEL.Credenciales();
            Usuario.Cuenta = (configuracion.RFCEmisor);
            Usuario.Usuario = (configuracion.UsuarioFEL);
            Usuario.Password = (configuracion.PasswordFEL);

            WS_FEL.RespuestaOperacion res = SrvCFDI.ObtenerXMLPorReferencia(Usuario, remision.NumeroRemision);

            if (!res.OperacionExitosa)
            {
               MessageBox.Show(res.ErrorGeneral);
                return false;
            }


            // Guardar XML
            XmlDocument Factura = new XmlDocument();
            Factura.LoadXml(Respuesta.XML);

            /*
             * Get atributos FEL
             */

            XPathNavigator nav = Factura.CreateNavigator();

            // UUID XPath
            string UUID = string.Empty;
            string NoFact = string.Empty;
            string FecFact = string.Empty;
            string PathXml = configuracion.DirectorioFacturas;

            XmlNamespaceManager xmlns = new XmlNamespaceManager(nav.NameTable);
            xmlns.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlns.AddNamespace("implocal", "http://www.sat.gob.mx/implocal");
            xmlns.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

            try
            {
                XmlNode Comprobante = Factura.SelectSingleNode("cfdi:Comprobante", xmlns);

                FecFact = Comprobante.Attributes.GetNamedItem("fecha").Value;
                NoFact = Comprobante.Attributes.GetNamedItem("folio").Value;

                if (Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID") != null)
                    UUID = Comprobante["cfdi:Complemento"].ChildNodes[0].Attributes.GetNamedItem("UUID").Value;

                // Crear archivo OFA080129U69_AS_NoFact_Fecha.xml
                XMLFile = XMLFile.Replace("NoFact", NoFact);
                XMLFile = XMLFile.Replace("Fecha", FecFact.Split('T')[0].Replace("-", "")) + ".XML";
                remision.NumeroFactura = UUID;

                if (!string.IsNullOrEmpty(PathXml))
                    XMLFile = Path.Combine(PathXml, XMLFile);

                Factura.Save(@XMLFile);

                // Remision
                Random r = new Random();

                // Salva Inf. en la BD                    
                //SIFDatos.Factura.Factura.InsertaFactura(NoRemision, Respuesta[3], XMLFile, UUID, TipoCFDI);
                //remision.NumeroFactura = UUID;
                //new SIFNegocio.Remision().ActualizaRemision(remision);


                fc.UUID = UUID;
                fc.FACTURA = Respuesta.XML;
                fc.PATH_FACTURA = XMLFile;
                fc.TIPO_CFDI = "FAC";

                if (remision.NumeroFactura == "********* UUID POR ASIGNAR *********")
                {
                    remision.NumeroFactura = UUID;
                    new SIFNegocio.Remision().ActualizaUUIDRemision(remision);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                SrvCFDI.Close();
            }




            return true;
        }

    }
}
