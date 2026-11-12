using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIFNegocio.Subrogacion
{
    public class Subrogacion
    {
        public SIFModelo.SubRogacion.Sobrogacion Ds = new SIFModelo.SubRogacion.Sobrogacion();


         public static void InsVtaLicitacion(int CltId, double Porc, string NomArchivo, string FactInicio,
                                int[] Sec, String[] ArtId, String[] Concepto,
                                String[] UMedida, String[] Presenta, int[] Cant, double[] PrecioClt,
                                double[] ImpClt, String[] Prov, String[] Marca,
                                double[] PorcFarm, double[] PrecioFarm, double[] ImpFarm, Nullable<int>[] ProvFarm)
        {
             SIFDatos.Subrogacion.Subrogacion.InsVtaLicitacion( CltId, Porc,  NomArchivo,  FactInicio,
                                Sec,  ArtId, Concepto, UMedida,  Presenta, Cant,  PrecioClt,
                                 ImpClt,  Prov, Marca,
                                PorcFarm,  PrecioFarm,  ImpFarm, ProvFarm);
        }

        public static void UpdVtaLicitacion(string NoFolio, double Porc, string FactInicio,
                              int[] Sec, String[] ArtId, String[] Concepto,
                              String[] UMedida, String[] Presenta, int[] Cant, double[] PrecioClt,
                              double[] ImpClt, String[] Prov, String[] Marca,
                              double[] PorcFarm, double[] PrecioFarm, double[] ImpFarm, Nullable<int>[] ProvFarm)
        {
            SIFDatos.Subrogacion.Subrogacion.UpdVtaLicitacion(NoFolio, Porc, FactInicio, Sec, ArtId, Concepto,
                               UMedida, Presenta, Cant, PrecioClt, ImpClt, Prov, Marca,
                               PorcFarm, PrecioFarm, ImpFarm, ProvFarm);
        }
    }
}
