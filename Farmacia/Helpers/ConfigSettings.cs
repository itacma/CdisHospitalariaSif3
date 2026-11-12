using System;
using System.Xml;
using System.Reflection;
using System.Configuration;

namespace SIF.Helpers
{
    class ConfigSettings
    {
        private ConfigSettings() { }

        public static string ReadSetting(string key)
        {
            //return ConfigurationSettings.AppSettings[key];
            return ConfigurationManager.AppSettings[key];
        }

        public static string ReadDBSetting(string key)
        {
            //return ConfigurationSettings.AppSettings[key];
            return SIFNegocio.Configuracion.Configuraciones.ReadDBSetting(key);
        }

        public static bool WriteDBSetting(string key, string value)
        {
            //return ConfigurationSettings.AppSettings[key];
            return SIFNegocio.Configuracion.Configuraciones.WriteDBSetting(key, value);
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
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                throw;
            }
        }

        public static void WriteEndPoint(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//client");

            if (node == null)
                throw new InvalidOperationException("appSettings sección no encontrada en archivo config.");

            try
            {
                // select the 'add' element that contains the key
                //XmlElement elem = (XmlElement)node.LastChild;
                //XmlAttribute elem = (XmlAttribute)node.LastChild.Attributes["address"];

                foreach (XmlElement elem in node.ChildNodes)
                {
                    var ek = elem.GetAttribute("name");
                    if (ek != key)
                    {
                        continue;
                    }

                    if (elem != null)
                    {
                        // add value for key
                        elem.SetAttribute("address", value);
                    }
                    else
                    {
                        // key was not found so create the 'add' element 
                        // and set it's key/value attributes 
                        XmlElement elemAdd = doc.CreateElement("add");
                        elemAdd.SetAttribute("key", key);
                        elemAdd.SetAttribute("address", value);
                        node.AppendChild(elemAdd);
                    }
                    doc.Save(getConfigFilePath());
                    ConfigurationManager.RefreshSection("client");
                }
            }
            catch
            {
                throw;
            }

        
        }

        public static string ReadEndPoint(string key)
        {
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//client");
            foreach (XmlElement elem in node.ChildNodes)
            {
                //XmlElement elemE = (XmlElement)node.LastChild;
                if (elem.Attributes["name"].Value == key)
                    return elem.Attributes["address"].Value.ToString();
            }

            return null;
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
