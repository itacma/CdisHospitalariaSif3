using Equin.ApplicationFramework;
using System;

namespace SIFNegocio.Marketing
{
    public class SendEmail
    {
        public BindingListView<SIFModelo.Marketing.modelPersona> personaList;
        public BindingListView<SIFModelo.Marketing.MGrupoSendEmail> personaListGrup;
        public BindingListView<SIFModelo.Marketing.modelPersona> Listpersonas;
        public BindingListView<SIFModelo.Marketing.GuardarEmail> ListPsw;
                
        public BindingListView<SIFModelo.Marketing.modelPersona> Buscar(string activo, int grupo)
        {
            personaList = new BindingListView<SIFModelo.Marketing.modelPersona>(SIFDatos.Marketing.SendEmail.BuscaListaemails(activo, grupo));
            return personaList;
        }

        public BindingListView<SIFModelo.Marketing.MGrupoSendEmail> BuscarListGrupo()
        {
            personaListGrup = new BindingListView<SIFModelo.Marketing.MGrupoSendEmail>(SIFDatos.Marketing.SendEmail.BuscaListaGrupos());
            return personaListGrup;
        }
        

        public void LogEmail(string userId, string fecha, string tieneAdjuntos, string descripcionAdjuntos, string nombreEquipo, string asunto, string grupo, string mensajeRespuesta, string estadoEnvio)
        {
            SIFDatos.Marketing.SendEmail.InsertEmailLog(userId, fecha, tieneAdjuntos, descripcionAdjuntos, nombreEquipo, asunto, grupo, mensajeRespuesta, estadoEnvio);
        }

        public void DesactivarEmail(string name)
        {
            SIFDatos.Marketing.SendEmail.ActualizarCampoActivo(name, "N");
            OnDataUpdated(EventArgs.Empty); // Notificar que los datos han cambiado
        }
                
        public event EventHandler DataUpdated;

        protected virtual void OnDataUpdated(EventArgs e)
        {
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AgregarCliente( string email, string nombre, string apellidos, int numeroEmpleado)
        {
            SIFDatos.Marketing.SendEmail.InsertarNuevoCliente( email, nombre, apellidos, numeroEmpleado);
        }
                
        public void EliminarDeGrupo(int idGrupo, string email)
        {
            SIFDatos.Marketing.SendEmail.EliminarDeGrupo(idGrupo, email);
        }

        public void AgregarClienteAlGrupo(int idGrupo, string email)
        {
            SIFDatos.Marketing.SendEmail.AgregarClienteAlGrupo(idGrupo, email);
        }

        public bool IsEmailDuplicated(string email)
        {
            return SIFDatos.Marketing.SendEmail.IsEmailDuplicated(email);
        }

        public BindingListView<SIFModelo.Marketing.modelPersona> BuscarUsuariosNoEnGrupo()
        {
            Listpersonas = new BindingListView<SIFModelo.Marketing.modelPersona>(SIFDatos.Marketing.SendEmail.BuscarUsuariosNoEnGrupo());
            return Listpersonas;
        }

        public void SaveEmail(string email)
        {
            SIFDatos.Marketing.SendEmail.SaveEmail(email);
        }

        public void SaveEncryptedPassword(string plainPassword)
        {
            SIFDatos.Marketing.SendEmail.SaveEncryptedPassword(plainPassword);
        }

        public string GetEmail()
        {
            string email = SIFDatos.Marketing.SendEmail.GetEmail();
            return email;
        }

        public string GetDecryptedPassword()
        {
            return SIFDatos.Marketing.SendEmail.GetDecryptedPassword();
        }
    }
}