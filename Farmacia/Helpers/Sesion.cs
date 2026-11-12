using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIF.Helpers
{
    public static class Sesion
    {


        public static SIFModelo.Usuario Usuario
        {
            get;
            set;
        }

        public static SIFModelo.Sucursal Sucursal
        {
            get;
            set;
        }

        public static System.Drawing.Bitmap Foto
        {
            get
            {
                if (Usuario.Genero ==  SIFModelo.Tipos.Genero.MASCULINO)
                {
                    return global::SIF.Properties.Resources.PharmacistMale;
                }
                return global::SIF.Properties.Resources.PharmacistFemale;
            }
        }

        public static SIFModelo.Usuario UsuarioSeleccionadoVenta { get; set; }
        public static SIFModelo.Usuario UsuarioSeleccionadoControlado { get; set; }
    }
}
