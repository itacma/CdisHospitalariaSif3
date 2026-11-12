using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    /// <summary>
    /// AVM 09-04-2015
    /// clase de negocio de MotivoPedido 
    /// </summary>
    public class MotivoPedido
    {
        /// <summary>
        /// lista de MotivoPedido
        /// </summary>
        public List<SIFModelo.MotivoPedido> MotivoPedidoList;

        /// <summary>
        /// consulta los motivos que pueden aparecer como el motivo del pedido
        /// </summary>
        /// <returns></returns>
        public List<SIFModelo.MotivoPedido> Buscar()
        {
            MotivoPedidoList = new List<SIFModelo.MotivoPedido>(SIFDatos.MotivoPedido.Busca());
            return MotivoPedidoList;
        }
    }
}
