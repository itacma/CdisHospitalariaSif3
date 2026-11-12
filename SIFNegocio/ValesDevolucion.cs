using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class ValesDevolucion
    {
        public SIFModelo.ValeDevolucion Nuevo(SIFModelo.ValeDevolucion modelo)
        {
            return SIFDatos.ValesDevolucions.InsertaValeDevolucion(modelo);
        }

        public bool Modificar(SIFModelo.ValeDevolucion modelo)
        {
            return SIFDatos.ValesDevolucions.ActualizaValeDevolucion(modelo);
        }

        public List<ValesDevolucion> CatValesList { get; set; }

        public List<SIFModelo.ValeDevolucion> ListValesDevolucion { get; set; }

        public void Buscar(string propiedadBusqueda, string parametro)
        {
            this.ListValesDevolucion = SIFDatos.ValesDevolucions.BuscaVales(propiedadBusqueda, parametro);
        }

        public bool Eliminar(SIFModelo.Banco modelo)
        {
            throw new NotImplementedException();
        }

        public SIFModelo.ValeDevolucion BuscarPorRemisionSucursal(string remision, SIFModelo.Sucursal sucursal)
        { 
        return SIFDatos.ValesDevolucions.BuscarPorRemisionSucursal(remision, sucursal);
        }

        public bool Modificar(SIFModelo.Devolucion vale)
        {
            return SIFDatos.ValesDevolucions.Actualiza(vale);
        }

    }
}
