using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Clientes
    {
        public BindingListView<SIFModelo.Cliente> CatClientesList;

        public static List<SIFModelo.Cliente> LaboratoriosList = new List<SIFModelo.Cliente>();
        public static List<SIFModelo.Cliente> ProveedoresList = new List<SIFModelo.Cliente>();
        public static List<SIFModelo.Cliente> MayoristasList = new List<SIFModelo.Cliente>();

        private bool Validar(SIFModelo.Cliente Cliente)
        {
            //if (string.IsNullOrEmpty(Cliente.Nombre) || string.IsNullOrWhiteSpace(Cliente.Nombre))
            //{
            //    MessageBox.Show("El nombre del Cliente es Obligatorio");
            //    return false;
            //}


            return true;
        }

        /// <summary>
        /// Crea un Cliente en la base de datos
        /// </summary>
        /// <param name="Cliente">Representa una instancia del Cliente</param>
        /// <returns>El Cliente ingresado a la base de datos</returns>
        public SIFModelo.Cliente Nuevo(SIFModelo.Cliente Cliente)
        {
            if (Validar(Cliente))
            {
                if (!SIFDatos.Clientes.Inserta(Cliente))
                {
                   MessageBox.Show("El Cliente no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Cliente;
        }

        /// <summary>
        /// Modifica el Cliente en la base de datos
        /// </summary>
        /// <param name="Cliente">El Cliente que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Cliente Cliente)
        {
            this.Validar(Cliente);
            return SIFDatos.Clientes.Actualiza(Cliente);
        }

        /// <summary>
        /// Elimina la instancia del Cliente en la base de datos
        /// </summary>
        /// <param name="Cliente">La instancia del Cliente a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Cliente Cliente)
        {
            try
            {
                SIFDatos.Clientes.Elimina(Cliente);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Clientes de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Clientes del modelo</returns>
        public BindingListView<SIFModelo.Cliente> Buscar(string propiedad, string parametro)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.Busca(propiedad, parametro));
            return CatClientesList;
        }


        public List<SIFModelo.Tipos.TipoDireccion> Direcciones()
        {
            List<SIFModelo.Tipos.TipoDireccion> direcciones = new List<SIFModelo.Tipos.TipoDireccion>();

            SIFModelo.Tipos.TipoDireccion casa = new SIFModelo.Tipos.TipoDireccion() { Tipo = "CASA", Valor = "CA" };
            SIFModelo.Tipos.TipoDireccion fiscal = new SIFModelo.Tipos.TipoDireccion() { Tipo = "FISCAL", Valor = "FI" };
            SIFModelo.Tipos.TipoDireccion email = new SIFModelo.Tipos.TipoDireccion() { Tipo = "TRABAJO", Valor = "EM" };

            direcciones.Add(casa);
            direcciones.Add(fiscal);
            direcciones.Add(email);


            return direcciones;
        }

        public SIFModelo.DireccionCliente DireccionCliente(SIFModelo.Cliente cliente)
        {
            return SIFDatos.Clientes.DireccionCliente(cliente);
        }

        public SIFModelo.DireccionCliente DireccionCliente(SIFModelo.Cliente cliente, SIFModelo.Tipos.TipoDireccion tipoDir)
        {
            return SIFDatos.Clientes.DireccionCliente(cliente, tipoDir);
        }

        public bool NuevoDireccion(SIFModelo.DireccionCliente direccionCliente)
        {
            return SIFDatos.Clientes.InsertaDireccion(direccionCliente);
        }

        public bool ModificarDireccion(SIFModelo.DireccionCliente direccionCliente)
        {
            return SIFDatos.Clientes.ActualizaDireccion(direccionCliente);
        }

        public SIFModelo.Cliente ClientePorID(int clienteID)
        {
            return SIFDatos.Clientes.ClientePorID(clienteID);
        }

        public BindingListView<SIFModelo.Cliente> BuscarProveedores(string propiedad, string parametro)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaProveedores(propiedad, parametro));
            return CatClientesList;
        }

        public BindingListView<SIFModelo.Cliente> BuscarClientes(string propiedad, string parametro)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaClientes(propiedad, parametro));
            return CatClientesList;
        }
        public BindingListView<SIFModelo.Cliente> BuscarClientesC(string propiedad, string parametro,String Tipo,int CUAL)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaClientesC(propiedad, parametro,Tipo,1));
            return CatClientesList;
        }

        public BindingListView<SIFModelo.Cliente> BuscarClientesS(string propiedad, string parametro)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaClientesS(propiedad, parametro));
            return CatClientesList;
        }
        public BindingListView<SIFModelo.Cliente> BuscarClientesSub(string propiedad, string parametro)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaClientesSub(propiedad, parametro));
            return CatClientesList;
        }
        public BindingListView<SIFModelo.Cliente> BuscarClientesC(string propiedad, string parametro, string listaProveedores)
        {
            CatClientesList = new BindingListView<SIFModelo.Cliente>(SIFDatos.Clientes.BuscaClientesC(propiedad, parametro, listaProveedores));
            return CatClientesList;
        }

        public List<SIFModelo.Cliente> Laboratorios(string parametros)
        {
            List<SIFModelo.Cliente> laboratorios = SIFDatos.Clientes.BuscaLaboratorios(parametros);
            return laboratorios;
        }

        public List<SIFModelo.Cliente> BuscarProveedoresMayoristas(string propiedad, string parametro, bool esCompleto = true)
        {
            List<SIFModelo.Cliente> proveedoresMayoristas = SIFDatos.Clientes.BuscarProveedoresMayoristas(propiedad, parametro, esCompleto);
            return proveedoresMayoristas;
        }
        public List<SIFModelo.Cliente> BuscarProveedoresMayoristasVendedor(string propiedad, string parametro, SIFModelo.Usuario usuario)
        {
            List<SIFModelo.Cliente> proveedoresMayoristas = SIFDatos.Clientes.BuscarProveedoresMayoristasVendedor(propiedad, parametro, usuario);
            return proveedoresMayoristas;
        }


        internal List<SIFModelo.Cliente> BuscarProveedoresDirectos(string p, string p_2)
        {
            throw new NotImplementedException();
        }

        public List<SIFModelo.Cliente> clientesMayoristas(string parametros)///JOMAQC 26/09/2018
        {
            List<SIFModelo.Cliente> clienteM = SIFDatos.Clientes.BuscaclientesMayorista(parametros);
            return clienteM;
        }

        public List<SIFModelo.Cliente> BuscaClientesLista(string parametros)
        {
            List<SIFModelo.Cliente> clienteLista = SIFDatos.Clientes.BuscaClientesLista(parametros);
            return clienteLista;
        }

        //--BuscaInstituciones
        public List<SIFModelo.Catalogo.Institucion> BuscaInstituciones(SIFModelo.Cliente cliente)
        {
            List<SIFModelo.Catalogo.Institucion> instituciones = SIFDatos.Clientes.BuscaInstituciones(cliente);
            return instituciones;
        }
    }
}
