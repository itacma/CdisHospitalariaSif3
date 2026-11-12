using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Equin.ApplicationFramework;

namespace SIFNegocio.Inventario
{
    public class EOQ
    {
        public BindingListView<SIFModelo.Inventarios.filtrosEoq> tipo3;

        public DataTable EOQTable = new DataTable();
        public DataTable CalculoEOQ(SIFModelo.Sucursal sucursal,DateTime fechaInicio, DateTime fechaTermino, int diasEOQ, int diasTranscurridos, out string periodos, string tipoMedicamento = "%%")
        {
            EOQTable = SIFDatos.Inventario.EOQ.Get_VentasEoQ(sucursal.SucursalesID.ToString(), fechaInicio.ToString("dd/MM/yyyy"), fechaTermino.ToString("dd/MM/yyyy"), diasEOQ, diasTranscurridos, out periodos, tipoMedicamento);

            return EOQTable;
        }


        public DataTable FactorEoQ()
        {
            return SIFDatos.Inventario.EOQ.Get_FactorEoQ();
        }

        public void ActualizaFactor(DataRow Rd)
        {
            SIFDatos.Inventario.EOQ.Actualiza(Rd);
        }
        
        public void ActualizaEOQinventario(DataRow Rd, SIFModelo.Sucursal sucursal)
        {
            SIFDatos.Inventario.EOQ.ActualizaEOQinventario(Rd, sucursal);
        }

        public void ActualizaTipoEOQ(DataRow row, SIFModelo.Sucursal sucursal)
        {
            SIFDatos.Inventario.EOQ.ActualizaTipoEOQ(row, sucursal);
        }

        public bool ActualizaEOQinventarioBulk(List<DataRow> rows, SIFModelo.Sucursal sucursal, string periodo_inicio, string periodo_fin, int usuario_id, string peridos)
        {
         return   SIFDatos.Inventario.EOQ.ActualizaEOQinventarioBulk(rows, sucursal, periodo_inicio, periodo_fin, usuario_id, peridos);
        }

        public String insertaEoqImpFile(
                                    String[] _Clave, 
                                    int[] _2,
                                    int[] _3,
                                    int[] _4,
                                    int[] _5,
                                    int[] _6,
                                    int[] _7,
                                    int[] _8,
                                    int[] _9,
                                    int[] _10,
                                    int[] _11,
                                    int[] _12,
                                    int[] _17,
                                    int[] _18,
                                    int[] _20,
                                    int[] _21,
                                    int[] _24,
                                    int[] _25,
                                    int[] _26,

                                    int[] _29,
                                    int[] _31,
                                    int[] _51,
                                    int[] _37
                                    )
        {
            return SIFDatos.Inventario.EOQ.insertaEoqImpFileSdie(_Clave,  _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _17, _18, _20 , _21,_24,_25,_26, _29,_31,_51, _37);
        }                                                                                                                                                
                                                                                                                                                         
        public String spAplicaArchivoImp()
        {
            return SIFDatos.Inventario.EOQ.spAplicaArchivoImp();
        }
        public String spGeneraConcentradoMensual(int usuario_id)
        {
            return SIFDatos.Inventario.EOQ.spGeneraConcentradoMensual(usuario_id);
        }
        public string EditaEoq(int usuario_id, int edit)
        {
            return SIFDatos.Inventario.EOQ.editaEoq(usuario_id, edit);
        }
        public String spProcesaConcentradoEoq()
        {
            return SIFDatos.Inventario.EOQ.spProcesaConcentradoEoq();
        }
        public String spActualizaConcentradoEoq()
        {
            return SIFDatos.Inventario.EOQ.spActualizaConcentradoEoq();
        }
        public System.Data.DataSet get_EoqMes( string cadena )
        {

            System.Data.DataSet ds = SIFDatos.Inventario.EOQ.get_EoqMes(cadena);
            return ds;
        }
        
        public  BindingListView<SIFModelo.Inventarios.filtrosEoq> BuscarfiltrosEoq()
        {
            tipo3 = new BindingListView<SIFModelo.Inventarios.filtrosEoq>(SIFDatos.Inventario.EOQ.buscaFiltroEoq());
            return tipo3;
        }

        public int sp_upd_filtro(int valor, string cadena) {
           return SIFDatos.Inventario.EOQ.sp_upd_filtro_eoq(valor, cadena);
        }

        public bool actualizaModificaciones(List<String> lista )
        {
            return SIFDatos.Inventario.EOQ.actualizaModificaciones(lista);
        }

        public DataTable ExportaEoqXls(bool catalogocompleto)
        {
            return SIFDatos.Inventario.EOQ.ExportaEoqXls(catalogocompleto);
        }




    }
}
