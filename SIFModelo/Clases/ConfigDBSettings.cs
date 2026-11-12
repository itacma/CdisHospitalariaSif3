using System;
using System.Xml;
using System.Configuration;
using System.Reflection;

namespace SIF3.Clases
{
    class ConfigDBSettings
    {
        private ConfigDBSettings() { }

        public static string ReadDBSetting(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public static void WriteDBSetting(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//connectionStrings");

            if (node == null)
                throw new InvalidOperationException("connectionStrings sección no encontrada en archivo config.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@name='{0}']", key));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("connectionString", value);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("name", key);
                    elem.SetAttribute("connectionString", value);
                    elem.SetAttribute("providerName", "System.Data.OracleClient");
                    node.AppendChild(elem);
                }
                doc.Save(getConfigFilePath());
            }
            catch
            {
                throw;
            }
        }

        public static void RemoveDBSetting(string key)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//connectionStrings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("connectionStrings sección no encontrada en archivo config.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@name='{0}']", key)));
                    doc.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("La llave {0} no existe.", key), e);
            }
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("Archivo de configuración no encontrado.", e);
            }
        }

        private static string getConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }

    }
}
