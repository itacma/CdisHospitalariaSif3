using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevComponents.DotNetBar;
using System.Windows.Forms;
using Equin.ApplicationFramework;
namespace SIFNegocio
{
    public class Articulo
    {


        public Articulo()
        {
            this.ListaArticulos = new BindingListView<SIFModelo.Articulo>(new List<SIFModelo.Articulo>());
            ListaArticuloBaja = new BindingListView<SIFModelo.ArticuloBaja>(new List<SIFModelo.ArticuloBaja>());
        }

        public static int ProveedorID = 0;
        public static int LaboratorioID = 0;
        public static int CompraConMayorista = 0;
        public static int Tipo1 = 0;
        public static int Tipo2 = 0;
        public static int Tipo3 = 0;
        public static int Tipo4 = 0;
        public static int Tipo7 = 0;


        public BindingListView<SIFModelo.Articulo> ListaArticulos; //= new BindingListView<SIFModelo.Articulo>(new List<SIFModelo.Articulo>());
        public BindingListView<SIFModelo.ArticuloBaja> ListaArticuloBaja;

        private List<SIFModelo.Cliente> proveedores;
        private List<SIFModelo.Cliente> laboratorios;
        //private List<SIFModelo.Cliente> clientesMayorista;

        private bool Validar(SIFModelo.Articulo articulo)
        {
            if (string.IsNullOrEmpty(articulo.NOMBRE1) || string.IsNullOrWhiteSpace(articulo.NOMBRE1))
            {
               MessageBox.Show("El nombre del banco es Obligatorio");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Crea un banco en la base de datos
        /// </summary>
        /// <param name="modelo">Representa una instancia del banco</param>
        /// <returns>El banco ingresado a la base de datos</returns>
        public SIFModelo.Articulo Nuevo(SIFModelo.Articulo modelo)
        {
            if (Validar(modelo))
            {
                if (!SIFDatos.Articulos.Inserta(modelo))
                {
                   MessageBox.Show("El producto no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return modelo;
        }

        /// <summary>
        /// Modifica el banco en la base de datos
        /// </summary>
        /// <param name="banco">El banco que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Articulo modelo)
        {
            this.Validar(modelo);
            return SIFDatos.Articulos.Actualiza(modelo);
        }

        /// <summary>
        /// Elimina la instancia del banco en la base de datos
        /// </summary>
        /// <param name="banco">La instancia del banco a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Articulo banco)
        {
            try
            {
                SIFDatos.Articulos.Elimina(banco);
            }
            catch
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// Selecciona los bancos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de bancos del modelo</returns>
        /// 
        public BindingListView<SIFModelo.ArticuloBaja> buscarV()
        {
            ListaArticuloBaja = new BindingListView<SIFModelo.ArticuloBaja>(SIFDatos.Articulos.BuscaX("", ""));
            return ListaArticuloBaja;
        }
        public BindingListView<SIFModelo.ArticuloBaja> buscarFil(string a, string b)
        {
            ListaArticuloBaja = new BindingListView<SIFModelo.ArticuloBaja>(SIFDatos.Articulos.BuscaX(b, b));
            return ListaArticuloBaja;
        }
        public BindingListView<SIFModelo.Articulo> Buscar(string propiedad, string parametro)
        {
            this.ListaArticulos = new BindingListView<SIFModelo.Articulo>(SIFDatos.Articulos.Busca(propiedad, parametro, false));

            //CARGAMOS LOS NOMBRES DE LOS PROVEEDORES Y LABORATORIOS
            SIFNegocio.Clientes nc = new Clientes();
            if (proveedores == null)
            {
                proveedores = nc.BuscarProveedores("PROVEEDOR", "").DataSource as List<SIFModelo.Cliente>;
            }
            if (laboratorios == null)
            {
                laboratorios = nc.BuscarProveedores("LAB_MAYORISTA", "").DataSource as List<SIFModelo.Cliente>;
            }


            foreach (SIFModelo.Articulo articulo in ListaArticulos.DataSource)
            {
                var proveedorEncontrado = from p in proveedores where p.ID == articulo.PROVEEDOR_ID select p;
                if (proveedorEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente proveedor = proveedorEncontrado.First();
                    articulo.PROVEEDOR_NOMBRE = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
                }

                var laboratorioEncontrado = from p in laboratorios where p.ID == articulo.LABORATORIO_ID select p;
                if (laboratorioEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente laboratorio = laboratorioEncontrado.First();
                    articulo.LABORATORIO_NOMBRE = laboratorio.Nombre + " " + laboratorio.ApellidoPaterno + " " + laboratorio.ApellidoMaterno;
                }
            }

            return ListaArticulos;
        }



        public SIFModelo.Articulo BuscarPorClave(string claveArticulo)
        {
            return SIFDatos.Articulos.ArticuloPorClave(claveArticulo);
        }

       

        public SIFModelo.Articulo BuscarPorClaveSub(string claveArticulo, String ClienteID)
        {
            return SIFDatos.Articulos.ArticuloPorClaveSub(claveArticulo, ClienteID);
        }
        public SIFModelo.Articulo BuscarPorClaveSub(string claveArticulo, string articuloID, String ClienteID)
        {
            return SIFDatos.Articulos.ArticuloPorClaveSub(claveArticulo, articuloID, ClienteID);
        }
       
        public SIFModelo.Inventarios.Inventario InventarioPorArticulo(SIFModelo.Articulo art)
        {
            return SIFDatos.Articulos.InventarioPorArticulo(art);
        }
        public bool MasDeUnoPorClaveSub(string claveArticulo, String ClienteID)
        {
            return SIFDatos.Articulos.MasDeUnoPorClaveSub(claveArticulo, ClienteID);
        }

        public SIFModelo.Inventarios.ListaPrecios ArticuloPrecio(string claveArticulo)
        {
            return SIFDatos.Articulos.PrecioArticulo(claveArticulo);
        }
        public SIFModelo.Inventarios.ListaPrecios ArticuloPrecioSub(string claveArticulo)
        {
            return SIFDatos.Articulos.PrecioArticuloSub(claveArticulo);
        }

        public decimal ArticuloPorClaveSubPrecio(string claveArticulo, string cliente)
        {
            return SIFDatos.Articulos.ArticuloPorClaveSubPrecio(claveArticulo, cliente);
        }

        public static SIFModelo.Inventarios.ListaPrecios PrecioArticulo(SIFModelo.Articulo detalle)
        {
            SIFModelo.Inventarios.ListaPrecios precios = new SIFNegocio.Articulo().ArticuloPrecio(detalle.ARTICULO_ID);
            if (precios == null)
            {
               MessageBox.Show("No hay un precio activo para este producto");
                return null;
            }
            else
            {
                if (precios.PRECIO_VENTA == 0)
                {
                   MessageBox.Show("No hay un precio activo para este producto");
                    //return;
                }
            }

            return precios;
        }

        public SIFModelo.Inventarios.InventarioDataSet InventarioDataSet;
        public SIFModelo.Inventarios.InventarioDataSet BuscarConInventario(string ParametroBusqueda, SIFModelo.Sucursal sucursal, string columna = "")
        {
            InventarioDataSet = SIFDatos.Articulos.BuscaPorNombreCodigo(ParametroBusqueda, sucursal, columna);
            return InventarioDataSet;
        }


        public SIFModelo.Inventarios.InventarioDataSet BuscarPorComprador(SIFModelo.Usuario  comprador)
        {
            string listaComprador = new SIFNegocio.Usuarios().ListaProveedores(comprador);

            InventarioDataSet = SIFDatos.Articulos.BuscarPorComprador(listaComprador);
            return InventarioDataSet;
        }

        public SIFModelo.Inventarios.InventarioDataSet BuscarConInventarioSub(string ParametroBusqueda, SIFModelo.Sucursal sucursal, string columna = "")
        {
            InventarioDataSet = SIFDatos.Articulos.BuscaPorNombreCodigoSub(ParametroBusqueda, sucursal, columna);
            return InventarioDataSet;
        }
        public SIFModelo.Inventarios.InventarioDataSet BuscarConInventarioActivo(string parametroBusqueda, SIFModelo.Sucursal sucursal, string propiedadBusqueda)
        {
            InventarioDataSet = SIFDatos.Articulos.BuscaPorNombreCodigoActivo(propiedadBusqueda, sucursal, parametroBusqueda);
            if (InventarioDataSet.ARTICULO_INVENTARIO == null)
            {
                MessageBox.Show("nuloooo");

            }

            SIFNegocio.Clientes nc = new Clientes();
            if (proveedores == null)
            {
                proveedores = nc.BuscarProveedores("PROVEEDOR", "").DataSource as List<SIFModelo.Cliente>;
            }
            if (laboratorios == null)
            {
                laboratorios = nc.BuscarProveedores("LAB_MAYORISTA", "").DataSource as List<SIFModelo.Cliente>;
            }

            List<SIFModelo.Articulo> articulos = new List<SIFModelo.Articulo>();
            //MessageBox.Show("llenado");
            foreach (SIFModelo.Inventarios.InventarioDataSet.ARTICULO_INVENTARIORow articulo in InventarioDataSet.ARTICULO_INVENTARIO)
            {
                SIFModelo.Articulo articuloItem = new SIFModelo.Articulo();

                articuloItem.ACTIVO = (SIFModelo.Tipos.SiNo)articulo.ACTIVO.ToString()[0];
                articuloItem.ARTICULO_ID = articulo.ARTICULO_ID;
                articuloItem.LABORATORIO_ID = articulo.LABORATORIO_ID;
                articuloItem.LISTA_SUCURSAL_VTA = articulo.LISTA_SUCURSAL_VTA;
                articuloItem.NOMBRE1 = articulo.NOMBRE1;
                articuloItem.NOMBRE2 = articulo.NOMBRE2;
                articuloItem.PAQUETE = (SIFModelo.Tipos.SiNo)articulo.PAQUETE.ToString()[0];
                articuloItem.PROVEEDOR_ID = articulo.PROVEEDOR_ID;
                if (!articulo.IsTIPO_MEDICAMENTO_CVENull())
                    articuloItem.TIPO_MEDICAMENTO_CVE = articulo.TIPO_MEDICAMENTO_CVE;
                articuloItem.TIPO_MONEDA = articulo.TIPO_MONEDA;
                articuloItem.U_COMPRA = articulo.U_COMPRA;
                articuloItem.U_VENTA = articulo.U_VENTA;


                //GENERA LA CLASE DE ARTICULO PARA PODER AGREGARLO A LA LISTA

                var proveedorEncontrado = from p in proveedores where p.ID == articulo.PROVEEDOR_ID select p;

                if (proveedorEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente proveedor = proveedorEncontrado.First();
                    articuloItem.PROVEEDOR_NOMBRE = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
                }

                var laboratorioEncontrado = from p in laboratorios where p.ID == articulo.LABORATORIO_ID select p;
                if (laboratorioEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente laboratorio = laboratorioEncontrado.First();
                    articuloItem.LABORATORIO_NOMBRE = laboratorio.Nombre + " " + laboratorio.ApellidoPaterno + " " + laboratorio.ApellidoMaterno;
                }

                articulos.Add(articuloItem);
            }

            this.ListaArticulos = new BindingListView<SIFModelo.Articulo>(articulos);


            return InventarioDataSet;
        }

        public bool MasDeUnoPorArticuloSub(string claveArticulo, string ClienteID)
        {
            return SIFDatos.Articulos.MasDeUnoPorArticuloSub(claveArticulo, ClienteID);
        }

        public SIFModelo.Inventarios.InventarioDataSet BuscarConInventarioSubActivo(string parametroBusqueda, SIFModelo.Sucursal sucursal, string propiedadBusqueda)
        {
            InventarioDataSet = SIFDatos.Articulos.BuscaPorNombreCodigoSubActivo(parametroBusqueda, sucursal, propiedadBusqueda);
            return InventarioDataSet;
        }

        public static void ActualizaPFleming(SIFModelo.Inventarios.ListaPrecios precio, string pUltUsuarioId)
        {
            SIFDatos.Articulos.ActualizaPFleming(precio,pUltUsuarioId);
        }
                
        public static bool InsertaListaPrecios(SIFModelo.Inventarios.ListaPrecios precio)
        {
            return SIFDatos.Inventario.Inventario.InsertaListaPrecios(precio);
        }
        
        public static bool ActualizaListaPrecios(SIFModelo.Inventarios.ListaPrecios precio)
        {
            return SIFDatos.Inventario.Inventario.ActualizaListaPrecios(precio);
        }

        public static void ActualizaPMP(SIFModelo.Inventarios.ListaPrecios precio, string pUltUsuarioId)
        {
            SIFDatos.Articulos.ActualizaPMP(precio, pUltUsuarioId);
        }

        public void ActualizaCodigo(string ArticuloID, string Clave)
        {
            SIFDatos.Articulos.ActualizaCodigo(ArticuloID, Clave);
        }

        public static void ActualizaPFarmacia(SIFModelo.Inventarios.ListaPrecios precio, string pUltUsuarioId)
        {
            SIFDatos.Articulos.ActualizaPFarmacia(precio, pUltUsuarioId);
        }

        /// <summary>
        /// AVM 20-08-2015
        /// Retorna la existencia actual y la ubicaion del articulo.
        /// </summary>
        /// <param name="idArticulo">identificador del articulo</param>
        /// <returns></returns>
        public static SIFModelo.Inventarios.Inventario ExistencuiaUbicacionArticulo(String idArticulo)
        {
            return SIFDatos.Articulos.ExistencuiaUbicacionArticulo(idArticulo);
        }

        public bool   bucaSiEsArticuloHup(String idArticulo)
        {
            return SIFDatos.Articulos.BuscaSiEsHupSif3(idArticulo);
        }


        public Double maxBytesI() {
            return SIFDatos.Articulos.maxBytesImg();
        }
        public BindingListView<SIFModelo.Articulo> BuscarFcM(string propiedad, string parametro)
        {
            this.ListaArticulos = new BindingListView<SIFModelo.Articulo>(SIFDatos.Articulos.Busca(propiedad, parametro, true));

            //CARGAMOS LOS NOMBRES DE LOS PROVEEDORES Y LABORATORIOS
            SIFNegocio.Clientes nc = new Clientes();
            if (proveedores == null)
            {
                proveedores = nc.BuscarProveedores("PROVEEDOR", "").DataSource as List<SIFModelo.Cliente>;
            }
            if (laboratorios == null)
            {
                laboratorios = nc.BuscarProveedores("LAB_MAYORISTA", "").DataSource as List<SIFModelo.Cliente>;
            }


            foreach (SIFModelo.Articulo articulo in ListaArticulos.DataSource)
            {
                var proveedorEncontrado = from p in proveedores where p.ID == articulo.PROVEEDOR_ID select p;
                if (proveedorEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente proveedor = proveedorEncontrado.First();
                    articulo.PROVEEDOR_NOMBRE = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
                }

                var laboratorioEncontrado = from p in laboratorios where p.ID == articulo.LABORATORIO_ID select p;
                if (laboratorioEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente laboratorio = laboratorioEncontrado.First();
                    articulo.LABORATORIO_NOMBRE = laboratorio.Nombre + " " + laboratorio.ApellidoPaterno + " " + laboratorio.ApellidoMaterno;
                }
            }

            return ListaArticulos;
        }


        public List<SIFModelo.Articulo> BuscarFcMList(string propiedad, string parametro)
        {
            List < SIFModelo.Articulo > ListaArticulos = new List<SIFModelo.Articulo>(SIFDatos.Articulos.Busca(propiedad, parametro, true));

            //CARGAMOS LOS NOMBRES DE LOS PROVEEDORES Y LABORATORIOS
            SIFNegocio.Clientes nc = new Clientes();
            if (proveedores == null)
            {
                proveedores = nc.BuscarProveedores("PROVEEDOR", "").DataSource as List<SIFModelo.Cliente>;
            }
            if (laboratorios == null)
            {
                laboratorios = nc.BuscarProveedores("LAB_MAYORISTA", "").DataSource as List<SIFModelo.Cliente>;
            }

            /*
            foreach (SIFModelo.Articulo articulo in ListaArticulos.DataSource)
            {
                var proveedorEncontrado = from p in proveedores where p.ID == articulo.PROVEEDOR_ID select p;
                if (proveedorEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente proveedor = proveedorEncontrado.First();
                    articulo.PROVEEDOR_NOMBRE = proveedor.Nombre + " " + proveedor.ApellidoPaterno + " " + proveedor.ApellidoMaterno;
                }

                var laboratorioEncontrado = from p in laboratorios where p.ID == articulo.LABORATORIO_ID select p;
                if (laboratorioEncontrado.Count() > 0)
                {
                    SIFModelo.Cliente laboratorio = laboratorioEncontrado.First();
                    articulo.LABORATORIO_NOMBRE = laboratorio.Nombre + " " + laboratorio.ApellidoPaterno + " " + laboratorio.ApellidoMaterno;
                }
            }
            */
            return ListaArticulos;
        }

        public SIFModelo.Articulo BuscarPorClaveActivo(string claveArticulo)
        {
            return SIFDatos.Articulos.ArticuloPorClaveActiva(claveArticulo);
            
        }

        public List<String> clavesNoValidas()
        {
            return SIFDatos.Articulos.ClavesNoValidas();
        }



        public String Actualiza_Sif3(string Usuario_id)
        {
            return SIFDatos.Articulos.Actualiza_Sif3(Usuario_id);
            

        }
        public String ConsumirApi()
        {
            String resultado = SIFDatos.Articulos.ActualizacionTL();
            return resultado;

        }

    }
}

