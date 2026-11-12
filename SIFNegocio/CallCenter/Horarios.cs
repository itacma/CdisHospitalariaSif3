using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.CallCenter
{
    public class Horarios
    {

        public SIFModelo.CallCenter.CallCenterDataSet DsHorarios = new SIFModelo.CallCenter.CallCenterDataSet();


        public SIFModelo.CallCenter.CallCenterDataSet CargaHorarios()
        {
            return SIFDatos.CallCenter.Horarios.CargaHorarios();
        }

    }
}
