using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio
{
    public class Controlado
    {
        public SIFModelo.Controlado ControladoPorFolio(SIFModelo.Controlado controlado)
        {
            return SIFDatos.Controlado.ControladoPorfolio(controlado);
        }

        public List<SIFModelo.ControladoDetalle> DetallesControlado(SIFModelo.Controlado controlado)
        {
            return SIFDatos.Controlado.DetallesControlado(controlado);
        }

        public bool ActualizaControlado(SIFModelo.Controlado controlado)
        {
            return SIFDatos.Controlado.ActualizaControlado(controlado);
        }

        public string FolioControlado(SIFModelo.Sucursal sucursal)
        {
            string prefijo = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            int numControlado = SIFDatos.Controlado.FolioControlado(sucursal, prefijo);
            string sb = sucursal.SucursalID.ToString("00") + prefijo + numControlado.ToString().PadLeft(6, '0');
            return sb;
        }

        public string FolioAntibiotico(SIFModelo.Controlado controlado)
        {
            //string prefijo = SIFNegocio.Configuracion.Configuraciones.fechaServidor().ToString("yy");
            //int numControlado = SIFDatos.Controlado.FolioAntibiotico(sucursal, prefijo);
            //string sb = sucursal.SucursalID.ToString("00") + prefijo + numControlado.ToString().PadLeft(6, '0');
            //return sb;

            return SIFDatos.Controlado.FolioAntibiotico(controlado);

        }

        public bool InsertaControlado(SIFModelo.Controlado controlado)
        {
            return SIFDatos.Controlado.InsertaControlado(controlado);
        }

        public bool InsertaDetalle(SIFModelo.ControladoDetalle detalle)
        {
            return SIFDatos.Controlado.InsertaDetalleControlado(detalle);
        }

        public System.Data.DataSet BuscaControlados(SIFModelo.Sucursal sucursal, SIFModelo.Controlado controlado)
        {
            return SIFDatos.Controlado.BuscaControlados(sucursal, controlado);
        }

        public bool InsertaControladoBulk(SIFModelo.Controlado controlado, List<SIFModelo.RemisionDetalle> detalles)
        {
            return SIFDatos.Controlado.InsertaControladoBulk(controlado, detalles);
        }
    }
}
