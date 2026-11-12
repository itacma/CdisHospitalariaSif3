using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SIFNegocio.OrdenCompra
{
    public class ArchivoOfertas
    {
        public SIFModelo.OrdenCompra.OrdenCompraDataSet ds = new SIFModelo.OrdenCompra.OrdenCompraDataSet();

        public SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORDataTable ArchivosProveedores()
        {
            return SIFDatos.OrdenCompra.OrdenCompra.ArchivosProveedores(ds);
        }

        /// <summary>
        /// APLICA LAS OFERTAS DEPENDIENDO DEL PROVEEDOR, ESTA PARTE ESTA EN CODIGO DURO, SI SE AGREGAN PROVEEDORES CAMBIAR LAS CONDICIONES DE ESTE PROCEDIMIENTO
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool Aplicar(SIFModelo.OrdenCompra.OrdenCompraDataSet.CTL_ARCHIVOS_PROVEEDORRow row)
        {
            System.IO.DirectoryInfo directorio = new System.IO.DirectoryInfo(row.PATH_ARCHIVO);
            string dir = directorio.Name.ToUpper();
            if (dir == "DROG")
            {
                dir = "DROGUEROS";
            }

            bool activado = false;
            switch (dir.ToUpper())
            {
                case "SABA":
                    if (row.TIPO_ARCHIVO == "OFE")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaOfertasSABA(row);
                    }
                    if (row.TIPO_ARCHIVO == "FAC")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaFacturasSABA(row);
                    }

                    break;
                case "DROGUEROS":
                    //DROGUEROS
                    if (row.TIPO_ARCHIVO == "OFE")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaOfertasDROGUEROS(row);
                    }
                    if (row.TIPO_ARCHIVO == "FAC")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaFacturasDROGUEROS(row);
                    }
                    break;
                case "MARZAM":
                    if (row.TIPO_ARCHIVO == "OFE")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaOfertasMARZAM(row);
                    }
                    if (row.TIPO_ARCHIVO == "FAC")
                    {
                        //MessageBoxEx.Show("El archivo de facturas se aplica automáticamente");
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaFacturasMARZAM(row);
                    }
                    break;

                case "NADRO":
                    if (row.TIPO_ARCHIVO == "OFE")
                    {
                        activado = SIFDatos.OrdenCompra.OrdenCompra.ExportaOfertasNADRO(row);
                    }
                    if (row.TIPO_ARCHIVO == "FAC")
                    {
                       MessageBox.Show("El archivo de facturas se aplica automáticamente");
                        activado = true;
                        //return SIFDatos.OrdenCompra.OrdenCompra.ExportaFacturasSABA(row);
                    }

                    break;
            }

            if (activado)
            {
                SIFDatos.OrdenCompra.OrdenCompra.ActivaArchivoOFertas(row);
            }

            return activado;
        }

        public object ArchivosFacturasProveedores()
        {
            return SIFDatos.OrdenCompra.OrdenCompra.ArchivosFacturasProveedores(ds);
        }
    }
}
