using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using Equin.ApplicationFramework;

namespace SIFNegocio
{
    public class Medicos
    {
        public BindingListView<SIFModelo.Especialidad> CaEspecialidades;
        string numString;
        public BindingListView<SIFModelo.Medico> CatMedicosList;

        private bool Validar(SIFModelo.Medico Medico)
        {
            if (string.IsNullOrEmpty(Medico.Nombre) || string.IsNullOrWhiteSpace(Medico.Nombre))
            {
                MessageBox.Show("El nombre del Medico es Obligatorio");
                return false;
            }
          
           

            

            return true;
        }

        /// <summary>
        /// Crea un Medico en la base de datos
        /// </summary>
        /// <param name="Medico">Representa una instancia del Medico</param>
        /// <returns>El Medico ingresado a la base de datos</returns>
        public SIFModelo.Medico Nuevo(SIFModelo.Medico Medico)
        {
            if (Validar(Medico))
            {
                if (!SIFDatos.Medicos.Inserta(Medico))
                {
                   MessageBox.Show("El Medico no se ha insertado", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Medico;
        }
        public BindingListView<SIFModelo.Especialidad> cargaEspecialidades()
        {
            CaEspecialidades = new BindingListView<SIFModelo.Especialidad>(SIFDatos.Especialidades.BuscaTodas());
            return CaEspecialidades;
        }
        public BindingListView<SIFModelo.Especialidad> cargaEspecialidadesid(int id)
        {
            CaEspecialidades = new BindingListView<SIFModelo.Especialidad>(SIFDatos.Especialidades.BuscaTodas_id(id));
            return CaEspecialidades;
        }
        /// <summary>
        /// Modifica el Medico en la base de datos
        /// </summary>
        /// <param name="Medico">El Medico que representa la nueva estructura a guardar</param>
        /// <returns>True si se ha guardado correctamente</returns>
        public bool Modificar(SIFModelo.Medico Medico)
        {
            this.Validar(Medico);
            return SIFDatos.Medicos.Actualiza(Medico);
        }

        /// <summary>
        /// Elimina la instancia del Medico en la base de datos
        /// </summary>
        /// <param name="Medico">La instancia del Medico a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(SIFModelo.Medico Medico)
        {
            try
            {
                SIFDatos.Medicos.Elimina(Medico);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Selecciona los Medicos de la base de datos que coincidan con la estructura enviada
        /// </summary>
        /// <param name="propiedad">La propiedad a comparar, buscar por...</param>
        /// <param name="parametro">El parametro a comparar</param>
        /// <returns>Lista de Medicos del modelo</returns>
        public BindingListView<SIFModelo.Medico> Buscar(string propiedad, string parametro)
        {
            CatMedicosList = new BindingListView<SIFModelo.Medico>(SIFDatos.Medicos.Busca(propiedad, parametro));

           // var especialidades1 = new Especialidads().Buscar("", "");
            //List<SIFModelo.Especialidad> especialidades = new Especialidads().Buscar("", "").DataSource as List<SIFModelo.Especialidad>;

            foreach (var item in CatMedicosList)
            {
                //var especialidad = from e in especialidades where e.ID == ((ObjectView<SIFModelo.Medico>)item).Object.EspecialidadID select e;
               /* var especialidad = from e in especialidades where e.Nombre == ((ObjectView<SIFModelo.Medico>)item).Object.EspecialidadNombre select e;
                if (especialidad.Count() > 0)
                {
                    ((ObjectView<SIFModelo.Medico>)item).Object.EspecialidadNombre = especialidad.First().Nombre;

                    
                }*/
            }

            return CatMedicosList;
        }

        public SIFModelo.Medico BuscarPorID(string MedicoID)
        {
            SIFModelo.Medico medico = SIFDatos.Medicos.BuscaPorID(MedicoID);

            // var especialidades1 = new Especialidads().Buscar("", "");
            //List<SIFModelo.Especialidad> especialidades = new Especialidads().Buscar("", "").DataSource as List<SIFModelo.Especialidad>;

            //foreach (var item in CatMedicosList)
            //{
            //    var especialidad = from e in especialidades where e.ID == ((ObjectView<SIFModelo.Medico>)item).Object.EspecialidadID select e;
            //    if (especialidad.Count() > 0)
            //    {
            //        ((ObjectView<SIFModelo.Medico>)item).Object.EspecialidadNombre = especialidad.First().Nombre;
            //    }
            //}

            //return CatMedicosList;

            return medico;
        }

        public bool NuevoDireccion(SIFModelo.DireccionMedico direccionMedico)
        {
           return SIFDatos.Medicos.InsertaDireccion(direccionMedico);
        }

        public bool ModificarDireccion(SIFModelo.DireccionMedico direccionMedico)
        {
            return SIFDatos.Medicos.ActualizaDireccion(direccionMedico);
        }

        public SIFModelo.DireccionMedico DireccionMedico(SIFModelo.Medico Medico)
        {
            return SIFDatos.Medicos.DireccionMedico(Medico);
        }

        public SIFModelo.DireccionMedico DireccionMedico(SIFModelo.Medico Medico, SIFModelo.Tipos.TipoConsulta tipo)
        {
            return SIFDatos.Medicos.DireccionMedico(Medico, tipo);
        }
    }
}
