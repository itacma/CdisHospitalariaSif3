using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFNegocio.Catalogo
{
    public class Valores
    {
        public bool Inserta(SIFModelo.Catalogo.CatalogoDataSet.VALORESRow modelo)
        {
            return SIFDatos.Valores.Inserta(modelo);
        }

        public SIFModelo.Catalogo.CatalogoDataSet DataSet = new SIFModelo.Catalogo.CatalogoDataSet();

        public SIFModelo.Catalogo.CatalogoDataSet CargaValores(SIFModelo.Caja caja, DateTime dateTime, DateTime? fechaCierre)
        {
            if (fechaCierre == null)
            {
                fechaCierre = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            }
            this.DataSet = SIFDatos.Valores.CargaDatosFecha(caja, dateTime, fechaCierre.Value);
            return DataSet;
        }

        public int SecuenciaNumero(int caja, int sucursal)
        {
            return SIFDatos.Valores.NumeroSecuencia(caja, sucursal);
        }

        public bool Actualiza(SIFModelo.Catalogo.CatalogoDataSet.VALORESRow valoresRow)
        {
            return SIFDatos.Valores.Actualiza(valoresRow);
        }
    }
}
