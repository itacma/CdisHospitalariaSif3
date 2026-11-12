using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFModelo.Tipos
{
    public class parmFac
    {

        //SIFModelo.Remision remision, int usuarioId , int tipoPagoId, string usoCfdi, string lugarExpedicion 
        public string id
        {
            get;
            set;
        }

        public string remision // numero de remision
        {
            get;
            set;
        }

        public int usuarioId    // usuario  que genera la Factura
        {
            get;
            set;
        }
        public int tipoPagoId   //tipo de pago para la facturacion
        {
            get;
            set;
        }

        public string usoCfdi   //uso que se la dara a la factura
        {
            get;
            set;
        }

        public string lExp      //Lugar de Expedicion de la factura
        {
            get;
            set;
        }

        public string nombreCliente // nombre de el cliente al que se le realizara la factura
        {
            get;
            set;
        }
        public string rfcCliente  // rfc  del cliente  que se le realizara la factura
        {
            get;
            set;
        }

        public string leyendaDisposicion    //Leyenda de disposicion que corresponde al sat solo en caso de que se solicite un leyenda para el cliente
        {
            get;
            set;
        }
        public string leyendaNorma          // leyenda de la norma que corresponde al sat 
        {
            get;
            set;
        }
        public string leyendaTexto          // leyenda que solicita el cliente
        {
            get;
            set;
        }

        public string respuesta              // respuesta que nos propociona el servicio de facturacion 
        {
            get;
            set;
        }
        public string uuid                    //Uiid de la factura creada o asociada a la nota(s) de remision.
        {
            get;
            set;
        }
        public string folioFac
        {                //folio de factura 
            get;
            set;
        }

        public string mailCorreo                      //direccion de correo electronico del cliente  para el envio de correo electronico
        {
            get;
            set;
        }
        public string mailAsunto                      // Asunto de el correo electronico
        {
            get;
            set;
        }
        public string mailCuerpo                      //cuerpo de el correo electronico
        {
            get;
            set;
        }
        public string leyenda1                        // leyenda que  se solicite que tenga la factura (a difenrecia de "leyendaTexto" esta no es regida por ninguna norma)
        {
            get;
            set;
        }
        public string leyenda2                            // leyenda que  se solicite que tenga la factura (a difenrecia de "leyendaTexto" esta no es regida por ninguna norma)
        {
            get;
            set;
        }
        public string uuidRelacionado                     //uuid relacionado se utiliza en las notas de credito para relacionar auna factura a su nota de creito
        {
            get;
            set;
        }
        public DateTime fechaIni { get; set; }     //fecha de Inicio  de la factura solo en caso de global o subrogacuion
        public DateTime fechaFin { get; set; }     //fecha de Inicio  de la factura solo en caso de global o subrogacuion
        //<Div> Para Traspasos
        public string folioTraspaso                            // folio del traspaso a timbrar
        {
            get;
            set;
        }
        public int loteTraspaso                      //Lote del traspaso a timbrar
        {
            get;
            set;
        }

        //</Div>
    }
}
