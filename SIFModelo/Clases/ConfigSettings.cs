using System;
using System.Xml;
using System.Reflection;
using System.Configuration;

namespace SIF3.Clases
{
    class ConfigSettings
    {
        private ConfigSettings() { }

        public static string ReadSetting(string key)
        {
            //return ConfigurationSettings.AppSettings[key];
            return ConfigurationManager.AppSettings[key];
        }

        public static void WriteSetting(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            if (node == null)
                throw new InvalidOperationException("appSettings sección no encontrada en archivo config.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));

                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", value);
                }
                else
                {
                    // key was not found so create the 'add' element 
                    // and set it's key/value attributes 
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(getConfigFilePath());
            }
            catch
            {
                throw;
            }
        }

        public static void RemoveSetting(string key)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");

            try
            {
                if (node == null)
                    throw new InvalidOperationException("appSettings sección no encontrada en archivo config.");
                else
                {
                    // remove 'add' element with coresponding key
                    node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", key)));
                    doc.Save(getConfigFilePath());
                }
            }
            catch (NullReferenceException e)
            {
                throw new Exception(string.Format("The key {0} does not exist.", key), e);
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
            // return AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString();
        }
    }
}
