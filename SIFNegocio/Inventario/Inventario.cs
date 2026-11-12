using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace SIFNegocio.Inventario
{
    public class Inventario
    {
        public SIFModelo.Inventarios.InventarioDataSet TraspasoDataSet = new SIFModelo.Inventarios.InventarioDataSet();

        public SIFModelo.Inventarios.InventarioDataSet buscaInventario(string propiedad, string nombre1)
        {
            SIFModelo.Articulo art = new SIFModelo.Articulo();
            art.NOMBRE1 = nombre1;
            ListaArticulos = SIFDatos.Inventario.Inventario.ArticuloInventario(art, Helpers.Sesion.Sucursal);
            return ListaArticulos;
        }

        public bool InventarioArticulo(SIFModelo.Articulo articulo, int cantidad, out int existencias)
        {
            if (articulo.VTA_SIN_EXISTENCIA == SIFModelo.Tipos.SiNo.SI)
            {
                existencias = 99999;
                return true;
            }

            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            if (row == null)
            {
                MessageBox.Show("No hay inventario especificado para el artículo " + articulo.NOMBRE1 + " [" + articulo.ARTICULO_ID + "]");
                existencias = 0;
                return false;
            }
            existencias = row.EXISTENCIAS - row.APARTADO_VTAS;

            if (cantidad > existencias)
            {
                MessageBox.Show("Inventario insuficiente para el artículo " + articulo.NOMBRE1 + " [" + articulo.ARTICULO_ID + "]" + " " + (row.EXISTENCIAS - row.APARTADO_VTAS) + " existencias");
                return false;
            }
            return true;
        }

        public bool InventarioArticuloSinApartado(SIFModelo.Articulo articulo, int cantidad, out int existencias)
        {
            if (articulo.VTA_SIN_EXISTENCIA == SIFModelo.Tipos.SiNo.SI)
            {
                existencias = 99999;
                return true;
            }

            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            if (row == null)
            {
                MessageBox.Show("No hay inventario especificado para el artículo " + articulo.NOMBRE1 + " [" + articulo.ARTICULO_ID + "]");
                existencias = 0;
                return false;
            }
            existencias = row.EXISTENCIAS;

            if (cantidad > existencias)
            {
                MessageBox.Show("Inventario insuficiente para el artículo " + articulo.NOMBRE1 + " [" + articulo.ARTICULO_ID + "]" + " " + (row.EXISTENCIAS - row.APARTADO_VTAS) + " existencias");
                return false;
            }
            return true;
        }

        public bool InventarioArticulo(SIFModelo.Articulo articulo, int cantidad, out int existencias, SIFModelo.ClienteSubrogaccion ClienteSub)
        {
            //if (ClienteSub == null)
            //    return InventarioArticulo(articulo, cantidad, out existencias);
            //else
            //{
            if (ClienteSub != null)
                if (ClienteSub.PRECIO_FIJO == SIFModelo.Tipos.SiNo.NO)
                    return InventarioArticulo(articulo, cantidad, out existencias);

            if (articulo.VTA_SIN_EXISTENCIA == SIFModelo.Tipos.SiNo.SI)
            {
                existencias = 99999;
                return true;
            }

            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            if (row == null)
            {
               MessageBox.Show("No hay inventario especificado para el artículo " + articulo.NOMBRE1 + " [" + articulo.ARTICULO_ID + "]");
                existencias = 0;
                return false;
            }
            existencias = row.EXISTENCIAS - row.APARTADO_VTAS;
            SIFModelo.Articulo ART = new SIFModelo.Articulo();
            SIFNegocio.Articulo ARTICU= new Articulo();
            ART = ARTICU.BuscarPorClave(articulo.ARTICULO_ID);
            if (cantidad > existencias)
            {
               MessageBox.Show("Inventario insuficiente para el artículo " + ART.NOMBRE1 + " [" + articulo.CODIGO_CLI + "]" + " " + (row.EXISTENCIAS - row.APARTADO_VTAS) + " existencias."+Environment.NewLine+" En esta MOVIMIENTO se desea dar salida a: " + cantidad + " piezas. Verifique piezas");
                return false;
            }
            return true;
            //}
        }

        public bool InventarioArticuloAparta(SIFModelo.Articulo articulo, int cantidad)
        {
            //SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);

            //if (row == null)
            //{
            //   MessageBox.Show("No hay inventario para este artículo");
            //    return false;
            //}
            //row.ULT_DOCUMENTO = "";
            //row.ULT_MOV_INV_ID = 0;
            //row.ULT_PARTIDA = 0;
            //row.ULT_USUARIO = "0";
            //row.APARTADO_VTAS += cantidad;

            return SIFDatos.Inventario.Inventario.InventarioApartado(articulo, cantidad, Helpers.Sesion.Sucursal);
        }

        public bool InventarioArticuloApartaCancela(SIFModelo.Articulo articulo, int cantidad)
        {
            //SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            //if (row == null)
            //{
            //    return false;
            //}
            //row.ULT_DOCUMENTO = "";
            //row.ULT_MOV_INV_ID = 0;
            //row.ULT_PARTIDA = 0;
            //row.ULT_USUARIO = "0";
            //row.APARTADO_VTAS -= cantidad;
            //return this.Actualiza(row, 1);
            cantidad = cantidad * -1;
            return SIFDatos.Inventario.Inventario.InventarioApartado(articulo, cantidad, Helpers.Sesion.Sucursal);
        }

        public bool InventarioArticuloAumenta(SIFModelo.Articulo articulo, int cantidad, string Documento, short mov_id, short partida, string UsuarioID)
        {
            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            row.EXISTENCIAS += cantidad;
            row.ULT_DOCUMENTO = Documento;
            row.ULT_MOV_INV_ID = mov_id;
            row.ULT_PARTIDA = partida;
            row.ULT_USUARIO = UsuarioID;
            return this.Actualiza(row, partida);
        }

        public bool InventarioArticuloDisminuye(SIFModelo.Articulo articulo, int cantidad, string Documento, short mov_id, short partida, string UsuarioID)
        {
            if (articulo.VTA_SIN_EXISTENCIA == SIFModelo.Tipos.SiNo.SI)
            {
                return true;
            }

            SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row = SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, Helpers.Sesion.Sucursal);
            if (row == null)
            {
                return false;
            }
            row.EXISTENCIAS -= cantidad;
            row.ULT_DOCUMENTO = Documento;
            row.ULT_MOV_INV_ID = mov_id;
            row.ULT_PARTIDA = partida;
            row.ULT_USUARIO = UsuarioID;
            //if (row.EXISTENCIAS < 0)
            //{
            //   MessageBox.Show("El inventario no puede ser negativo", "Error", System.Windows.Forms.MessageBoxButtons.OK);
            //    return false;
            //}

            return this.Actualiza(row, partida);
        }

        public SIFModelo.Inventarios.InventarioDataSet ListaArticulos = new SIFModelo.Inventarios.InventarioDataSet();

        public bool Actualiza(SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow inventario, int partida)
        {
            SIFModelo.Inventarios.Inventario inventarioM = new SIFModelo.Inventarios.Inventario();
            inventarioM.ArticuloID = inventario.ARTICULO_ID;
            inventarioM.SucursalID = inventario.SUCURSAL_ID;
            inventarioM.Existencias = inventario.EXISTENCIAS;
            inventarioM.ExistenciasMinimas = inventario.EXISTENCIA_MIN;
            inventarioM.ExistenciasMaximas = inventario.EXISTENCIA_MAX;
            inventarioM.PuntoDeReorden = inventario.PUNTO_DE_REORDEN;
            inventarioM.InventarioFisico = inventario.INV_FISICO;
            inventarioM.UltimaModificacion = SIFNegocio.Configuracion.Configuraciones.fechaServidor();
            inventarioM.UltimaEntrada = inventario.FECHA_ULT_ENT;
            inventarioM.UltimaSalida = inventario.FECHA_ULT_SAL;
            inventarioM.UltimoCosto = (decimal)inventario.ULT_COSTO;
            inventarioM.CostoPromedio = (decimal)inventario.COSTO_PROM;
            inventarioM.PEPS = (decimal)inventario.PEPS;
            inventarioM.UEPS = (decimal)inventario.UEPS;
            inventarioM.FechaInventarioFisico = inventario.FECHA_INV_FISICO;
            inventarioM.UsuarioID = int.Parse(inventario.ULT_USUARIO);
            inventarioM.Documento = inventario.ULT_DOCUMENTO;
            inventarioM.Partida = inventario.ULT_PARTIDA;
            inventarioM.MOV_INV_ID = inventario.ULT_MOV_INV_ID;

            if (!inventario.IsUBICACIONNull())
            {
                inventarioM.Ubicacion = inventario.UBICACION;
            }
            else
            {
                inventarioM.Ubicacion = "";
            }

            inventarioM.ApartadoVentas = inventario.APARTADO_VTAS;
            
            return SIFDatos.Inventario.Inventario.Actualiza(inventarioM, 1);
        }


        public SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow InventarioArticulo(SIFModelo.Articulo articulo, SIFModelo.Sucursal sucursal = null)
        {
            if (sucursal == null)
            {
                sucursal = Helpers.Sesion.Sucursal;
            }

            return SIFDatos.Inventario.Inventario.ArticuloInventario(articulo.ARTICULO_ID, sucursal);
        }

        public bool ActualizaUbicacion(SIFModelo.Inventarios.InventarioDataSet.INVENTARIORow row)
        {
            return SIFDatos.Inventario.Inventario.ActualizaUbicacion(row);
        }

        public bool InventarioArticuloActualizaExistencia(List<SIFModelo.RemisionDetalle> detalles, SIFModelo.Sucursal sucursal, SIFModelo.Cajero usuario, SIFModelo.Remision remision)
        {
           int UltMovInd =  1;

           return SIFDatos.Inventario.Inventario.ActualizaExistencia(sucursal, detalles, usuario, remision, UltMovInd);
        }
        /// <summary>
        /// AVM 24-04-2015 
        /// Carga las lineas de inventario para el reporte de ubicacion.
        /// </summary>
        /// <returns></returns>
        public List<String> CargarLineas()
        {
            List<string> ListaLineas = new List<string>();
            return ListaLineas = SIFDatos.Inventario.Inventario.CargarLineas();
        }
    }
}
