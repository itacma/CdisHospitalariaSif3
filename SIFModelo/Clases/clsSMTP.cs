using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//Mail
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace SIF3.Clases
{
    public class clsSMTP
    {
        // Envio Correo
        private static SmtpClient client = null;
        private static string Host, Port, UserName, UserPwd, PathImg;
        private static bool SSL;
        private static string txtBody = string.Empty;
        private static string txtMail = string.Empty;
        private static AlternateView htmlView = null;

        public static string SendSMTP(string Server, int Port, string Username, string Password, bool Ssl, string To, string From, string Subject, string Body, string AFile, bool HView)
        {
            //Set up SMTP client
            SmtpClient client = new SmtpClient();
            client.Host = Server;
            client.Port = Port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Username, Password);
            //client.Timeout = 10;
            if (Ssl)
                client.EnableSsl = true;
            else
                client.EnableSsl = false;

            //string PathImg = ConfigSettings.ReadSetting("PathHTMLImages");

            //Set up the email message
            MailMessage message = new MailMessage();
            foreach (string Cta in To.Split())
            {
                //message.To.Add(To);
                message.To.Add(Cta);
            }
            message.From = new MailAddress(From);
            message.Subject = Subject;
            message.IsBodyHtml = true; //HTML email

            if (AFile != null)
            {
                foreach (string Archivo in AFile.Split('|'))
                {
                    Attachment Files = new Attachment(Archivo); //AFile
                    message.Attachments.Add(Files);
                }
            }

            message.Body = @Body;

            if (HView)
            {
                // Alternate View
                SetAlternativeView(@Body);

                if (htmlView != null)
                    message.AlternateViews.Add(htmlView);
            }

            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.Delay;
            // Confirmación de Lectura de Correo
            if (ConfigSettings.ReadSetting("MailNotificacionLectura") == "1")
                message.Headers.Add("Disposition-Notification-To", "<" + UserName + ">");

            //Attempt to send the email
            try
            {
                client.Send(message);
                return "El mensaje se envío satisfactoriamente";
            }
            catch (SmtpException smtpex)
            {
                //return smtpex.Message + Environment.NewLine + smtpex.StatusCode + Environment.NewLine + smtpex.StackTrace;
                throw new System.Exception(smtpex.Message);
            }
            catch (Exception ex)
            {
                //return "Error al enviar el mensaje de correo:\n\n" + ex.ToString();
                throw new System.Exception(ex.Message);

            }
            finally
            {
                //message.Dispose();
            }
        }

        public static void SetAlternativeView(string sFile)
        {
            string[] imgFiles;
            string imgExt = "*.jpg";
            PathImg = ConfigSettings.ReadSetting("PathHTMLImages");

            if (!string.IsNullOrEmpty(PathImg))
            {
                imgFiles = Directory.GetFiles(PathImg, imgExt);
                //htmlView = AlternateView.CreateAlternateViewFromString(txtBody.Text, null, MediaTypeNames.Text.Html);
                htmlView = AlternateView.CreateAlternateViewFromString(sFile, null, MediaTypeNames.Text.Html);

                for (int n = 0; n < imgFiles.Length; n++)
                {
                    LinkedResource LResource = new LinkedResource(PathImg + @"\" + Path.GetFileName(imgFiles[n]), MediaTypeNames.Image.Jpeg);
                    LResource.ContentId = @Path.GetFileNameWithoutExtension(imgFiles[n]);
                    htmlView.LinkedResources.Add(LResource);
                }
            }
        }

    }
}
