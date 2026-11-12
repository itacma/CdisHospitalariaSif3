using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.WebServices
{
    public class PFIZER
    {
        WS_PFIZER.WSPrepagoSoapClient wsPfizer = new WS_PFIZER.WSPrepagoSoapClient();

        public List<SIFModelo.RemisionDetalle> ProcesaVenta(SIFModelo.WebServices.TarjetaPfizer tarjeta, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Remision remision)
        {
            if (detalles.Count == 0)
            {
               MessageBox.Show("Debe proporcionar la información de al menos un articulo", "Pfizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (string.IsNullOrWhiteSpace(Configuracion.Configuraciones.Pfizer.Cadena.ToString()) ||
                string.IsNullOrWhiteSpace(Configuracion.Configuraciones.Pfizer.ProgramaID.ToString()) ||
                string.IsNullOrWhiteSpace(Configuracion.Configuraciones.Pfizer.Sucursal.ToString()))
            {
               MessageBox.Show("Error en la configuración del servicio" + Environment.NewLine +
                                  "Configure el servicio antes de usuarlo", "Pfizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Cursor.Current = Cursors.WaitCursor;

            int NumArt = detalles.Count;
            int iPed = 0;

            // Mensajes de Error
            string MsgErr = string.Empty;
            string MsgFol = string.Empty;

            // Ticket
            string Cotizacion = string.Empty;

            // Instance Service
            WS_PFIZER.WSPrepagoSoapClient ServicioPfizer = new WS_PFIZER.WSPrepagoSoapClient("WSPrepagoSoap");
            WS_PFIZER.Ticket Respuesta = new WS_PFIZER.Ticket();

            // Instance Compra
            WS_PFIZER.Compra Compra = new WS_PFIZER.Compra();
            WS_PFIZER.Pedido[] Pedidos = new WS_PFIZER.Pedido[NumArt];

            Compra.Programa_intId = Convert.ToInt16(Configuracion.Configuraciones.Pfizer.ProgramaID); //1;
            Compra.Cadena_intId = Convert.ToInt16(Configuracion.Configuraciones.Pfizer.Cadena); //999;
            Compra.Sucursal_intId = Convert.ToInt16(Configuracion.Configuraciones.Pfizer.Sucursal); //999;
            Compra.Terminal_intId = 1;
            Compra.Usuario_strId =Configuracion.Configuraciones.Pfizer.Usuario;
            Compra.Tarjeta = tarjeta.TarjetaID; // 1129999999

            foreach (SIFModelo.RemisionDetalle row in detalles)
            {
                Pedidos[iPed] = new WS_PFIZER.Pedido();
                Pedidos[iPed].SKU = row.ArticuloID;
                Pedidos[iPed].Cantidad = row.CantidadRemision;
                iPed += 1;
            }

            try
            {
                Compra.Pedido = Pedidos;

                Respuesta = ServicioPfizer.ProcesarCompra(Compra);

                // Id Cotización
                tarjeta.SesionID = Respuesta.CotizacionId;
                if (tarjeta.SesionID == "0")
                {
                    if (Respuesta.CodigoExcepcion == 0)
                    {
                       MessageBox.Show("No hay una sesión que otorgue beneficios al cliente");

                        return new List<SIFModelo.RemisionDetalle>();
                    }
                }
                //tb_CotizacionId.Text = Cotizacion;

                // Valida Errores
                if (!Respuesta.ExisteCadenaId)
                    MsgErr += Respuesta.DescripcionErrorCadenaId + Environment.NewLine;
                if (!Respuesta.ExisteProgramaId)
                    MsgErr += Respuesta.DescripcionErrorProgramaId + Environment.NewLine;
                if (!Respuesta.ExisteSucursalId)
                    MsgErr += Respuesta.DescripcionErrorSucursalId + Environment.NewLine;
                if (!Respuesta.ExisteTarjeta)
                    MsgErr += Respuesta.DescripcionErrorTarjeta + Environment.NewLine;
                if (!Respuesta.ExisteTerminalId)
                    MsgErr += Respuesta.DescripcionErrorTerminalId + Environment.NewLine;
                if (!Respuesta.ExisteUsuarioId)
                    MsgErr += Respuesta.DescripcionErrorUsuarioId + Environment.NewLine;

                if (Respuesta.CodigoExcepcion != 0)
                {
                    MsgErr = Respuesta.DescripcionExcepcion + " " + Respuesta.CodigoExcepcion.ToString();
                }

                if (!string.IsNullOrEmpty(MsgErr))
                   MessageBox.Show("Error(es):" + Environment.NewLine + MsgErr);
                else // Valida Lista Folio
                {
                    // Recorre la lista
                    foreach(WS_PFIZER.Folio folio in Respuesta.Folio)
                    {
                        // Buscar articulo
                        foreach (SIFModelo.RemisionDetalle row in detalles)
                        {
                            if (row.ArticuloID.ToString().Contains(folio.SKU))
                            {
                                if (folio.ExisteSKU && folio.ValidoSKU)
                                {
                                    row.PiezasPagadas = folio.Compras;
                                    row.PiezasGratis = folio.Beneficios;
                                    row.PiezasAcumuladas = folio.Sugeridos;
                                    row.Mensaje = "";
                                }
                                else
                                {
                                    row.PiezasPagadas = row.CantidadRemision;
                                    row.PiezasGratis = 0;
                                    row.PiezasAcumuladas = 0;
                                    row.Mensaje = folio.ErrorSKU + " - " + folio.DescripcionErrorSKU;
                                }
                                break;
                            }
                        } // foreach
                    }// for
                  
                 }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
                detalles = null;
            }
            finally
            {
                ServicioPfizer.Close();
                Cursor.Current = Cursors.Default;
            }
            return detalles;

        }

        public Boolean Cancela(SIFModelo.WebServices.PfizerControl cotizacion)
        {
            if (string.IsNullOrEmpty(cotizacion.COTIZACION_ID))
            {
               MessageBox.Show("Debe proporcionar la información de la Cotización", "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Cursor.Current = Cursors.WaitCursor;


            // Mensajes de Error
            string MsgErr = string.Empty;
            string MsgFol = string.Empty;

            // Ticket
            string Cotizacion = string.Empty;

            // Instance Service
            WS_PFIZER.WSPrepagoSoapClient ServicioPfizer = new WS_PFIZER.WSPrepagoSoapClient("WSPrepagoSoap");

            // Instance Cerrar Compra
            WS_PFIZER.Token CCompra = new WS_PFIZER.Token();

            // Instance Comprobante
            WS_PFIZER.Comprobante Respuesta = new WS_PFIZER.Comprobante();

            try
            {
                CCompra.CotizacionId = cotizacion.COTIZACION_ID;
                CCompra.Tarjeta = cotizacion.NO_TARJETA;

                Respuesta = ServicioPfizer.CancelarCompra(CCompra);

                switch (Respuesta.CodigoError)
                {
                    //case "0":
                    //   MessageBox.Show("No. Tarjeta: " + Respuesta.Tarjeta + Environment.NewLine +
                    //                      "Id Autorización: " + Respuesta.Llave + Environment.NewLine +
                    //                      "Error: " + Respuesta.CodigoError + " - " + Respuesta.DescripcionError, 
                    //        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    break;
                    case "1":
                       MessageBox.Show("Error: " + Respuesta.CodigoError + " - " + Respuesta.DescripcionError,
                            "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("La compra PFIZER se Canceló correctamente");

                            //+ Environment.NewLine +
                            //              "No. Tarjeta: " + Respuesta.Tarjeta + Environment.NewLine +
                            //              "Id Autorización: " + Respuesta.Llave,
                            //"PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SIFDatos.WebServices.PFIZER.UpdPfizer("C", cotizacion.COTIZACION_ID, Respuesta.Llave);
                        break;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ServicioPfizer.Close();
                Cursor.Current = Cursors.Default;
            }
            
            return true;
        }

        public bool Cerrar( SIFModelo.WebServices.PfizerControl pfizer, SIFModelo.Remision remision)
        {
            if (string.IsNullOrEmpty(pfizer.COTIZACION_ID))
            {
               MessageBox.Show("Debe proporcionar la información de la Cotización", "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            Cursor.Current = Cursors.WaitCursor;

            // Mensajes de Error
            string MsgErr = string.Empty;
            string MsgFol = string.Empty;

            // Ticket
            string Cotizacion = string.Empty;

            // Instance Service
            WS_PFIZER.WSPrepagoSoapClient ServicioPfizer = new WS_PFIZER.WSPrepagoSoapClient("WSPrepagoSoap");

            // Instance Cerrar Compra
            WS_PFIZER.Token CCompra = new WS_PFIZER.Token();

            // Instance Comprobante
            WS_PFIZER.Comprobante Respuesta = new WS_PFIZER.Comprobante();
            



            try
            {
                CCompra.CotizacionId = pfizer.COTIZACION_ID;
                CCompra.Tarjeta = pfizer.NO_TARJETA;

                Respuesta = ServicioPfizer.CerrarCompra(CCompra);

                switch (Respuesta.CodigoError)
                {
                    //case "0":
                    //   MessageBox.Show("No. Tarjeta: " + Respuesta.Tarjeta + Environment.NewLine +
                    //                      "Id Autorización: " + Respuesta.Llave + Environment.NewLine +
                    //                      "Error: " + Respuesta.CodigoError + " - " + Respuesta.DescripcionError, 
                    //        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    break;
                    case "1":
                       MessageBox.Show("Error: " + Respuesta.CodigoError + " - " + Respuesta.DescripcionError,
                            "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                       MessageBox.Show("La compra PFIZER se Cerro!" + Environment.NewLine +
                                          "No. Tarjeta: " + Respuesta.Tarjeta + Environment.NewLine +
                                          "Id Autorización: " + Respuesta.Llave,
                            "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       SIFDatos.WebServices.PFIZER.UpdPfizer("C", CCompra.CotizacionId, Respuesta.Llave);
                        break;
                }
                //return false;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "PFIZER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ServicioPfizer.Close();
                Cursor.Current = Cursors.Default;
            }

      
            return true;
        }

        public SIFModelo.WebServices.PfizerControl Control(SIFModelo.Remision remision)
        {
            return SIFDatos.WebServices.PFIZER.ControlPfizer(remision);
        }

        public void InsertaPfizer(SIFModelo.WebServices.TarjetaPfizer tarjeta, List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Remision remision)
        {
            SIFDatos.WebServices.PFIZER.InsPfizer(tarjeta, detalles, remision, Configuracion.Configuraciones.Pfizer);
        }

        public void ControlDetalles(SIFModelo.WebServices.PfizerControl control)
        {
            throw new NotImplementedException();
        }
    }
}
