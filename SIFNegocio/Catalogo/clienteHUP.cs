using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class clienteHUP
    {
        public SIFModelo.cliente_Hup Buscar(string id)
        {
            return SIFDatos.Derechohabientes.BuscaCliente(id);
        }
    }
}
