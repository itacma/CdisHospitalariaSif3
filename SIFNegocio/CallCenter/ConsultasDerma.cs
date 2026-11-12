using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIFNegocio.CallCenter
{
    public class ConsultasDerma
    {
        public SIFModelo.CallCenter.CallCenterDataSet dsConsultas = new SIFModelo.CallCenter.CallCenterDataSet();

        public SIFModelo.CallCenter.CallCenterDataSet CatalogoConsultasActivas()
        {
            dsConsultas = SIFDatos.CallCenter.ConsultasDerma.CargaConsultasDerma();
            return dsConsultas;
        }

        public DataSet ConsultasSuc(int suc)
        {
            DataSet ds;
            return ds = SIFDatos.CallCenter.ConsultasDerma.CargaConsultasDerma(suc);
        }


        public SIFModelo.CallCenter.CallCenterDataSet DataSet = new SIFModelo.CallCenter.CallCenterDataSet();



        public bool NuevaConsulta(SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow Consulta)
        {
            return SIFDatos.CallCenter.ConsultasDerma.InsertaConsulta(Consulta);
        }

        public bool ModificaConsulta(SIFModelo.CallCenter.CallCenterDataSet.CONSULTARow Consulta)
        {
            return SIFDatos.CallCenter.ConsultasDerma.ActualizaConsulta(Consulta);
        }


    }
}
