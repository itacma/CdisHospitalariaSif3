using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using Equin.ApplicationFramework;
using System.Data;


namespace SIFNegocio
{
    public class Compradores
    {
        public DataTable snProveedores = new DataTable();
        public DataTable dtComprador = new DataTable();
        public BindingListView<SIFModelo.AsignacionCompradores> ListaComprador;
        public SIFModelo.Catalogo.CatalogoDataSet.COMPRADORDataTable compradores;

        public SIFModelo.Catalogo.CatalogoDataSet.COMPRADORDataTable CargaCompradores()
        {
            compradores = SIFDatos.Compradores.CargaCompradores();
            return compradores;
        }


        public bool Actualiza(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow current)
        {
            return SIFDatos.Compradores.ActualizaCompradores(current);
        }

        public bool Nuevo(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow current)
        {
            return SIFDatos.Compradores.InsertaCompradores(current);
        }

        public SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow CompradorPorID(SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow comprador)
        {
            SIFModelo.Catalogo.CatalogoDataSet.COMPRADORRow CompradorEncontrado = SIFDatos.Compradores.CargaCompradoresPorId(comprador);

            if (CompradorEncontrado != null)
            {
                if (CompradorEncontrado.IsAPELLIDOSNull())
                {
                    CompradorEncontrado.APELLIDOS = "";
                }
            }

            return CompradorEncontrado;
        }
        public BindingListView<SIFModelo.AsignacionCompradores> BuscarComprador(string ca)
        {
            ListaComprador = new BindingListView<SIFModelo.AsignacionCompradores>(SIFDatos.Compradores.BuscaCompradoresA( ca));
            return ListaComprador;
        }       
        public BindingListView<SIFModelo.AsignacionCompradores> BuscarComprador(string ca, string us, string ui, string t)
        {
            ListaComprador = new BindingListView<SIFModelo.AsignacionCompradores>(SIFDatos.Compradores.BuscaCompradoresA(ca, us, ui,t));
            return ListaComprador;
        }
        public  Boolean AsigComprador(string codigoProveedor, string UsuarioComprador, string tipom)
        {                
            return SIFDatos.Compradores.AsignacionComprador(codigoProveedor, UsuarioComprador,tipom);
        }
        public Boolean cambiaEstadoP(string cliente, string estado)
        {
            return SIFDatos.Compradores.cambiaEstadoProv(cliente, estado);
        }
        public Boolean buscaExiste(string u, string p) {
            return SIFDatos.Compradores.bucaExistente(u, p);
        
        }
        public DataTable cargaGridProv(string act)
        {
            snProveedores = SIFDatos.Compradores.Carga_grid_Provitc(act);
            return snProveedores;
        }

        public DataTable cargaGridComprador(string compradorid)
        {
            dtComprador = SIFDatos.Compradores.Carga_grid_Compitc(compradorid); 
            return dtComprador;
        }


    }
}
