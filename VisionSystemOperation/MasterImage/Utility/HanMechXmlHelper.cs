using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Inspection.Utility
{
    public class HanMechXmlHelper
    {
        public static void SaveDeclaration(XmlDocument xmlDocument)
        {
            XmlDeclaration xmlDeclaration;
            xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement xmlElementRoot = xmlDocument.DocumentElement;
            xmlDocument.InsertBefore(xmlDeclaration, xmlElementRoot);
        }
        public static void SetValue(XmlElement xmlElement, string keyName, string value)
        {
            XmlElement subElement = xmlElement.OwnerDocument.CreateElement("", keyName, "");
            xmlElement.AppendChild(subElement);

            subElement.InnerText = value;
        }

        public static string GetValue(XmlElement xmlElement, string keyName, string defaultValue)
        {
            XmlElement subElement = xmlElement[keyName];
            if (subElement == null)
                return defaultValue;

            return subElement.InnerText;
        }

        public static string GetValue(XmlNode xmlNode, string keyName, string defaultValue)
        {
            XmlElement subElement = xmlNode[keyName];
            if (subElement == null)
                return defaultValue;

            return subElement.InnerText;
        }

        public static string GetValue(XmlNodeList xmlNodeList, string keyName, string defaultValue)
        {
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == keyName)
                    return xmlNodeList[i].InnerText;
            }
            return defaultValue;
        }

        //Serializer
        public static bool LoadBySerializer<T>(ref T obj, string strPath)
        {
            try
            {
                string strDir = strPath.Substring(0, strPath.LastIndexOf('\\'));
                if (!Directory.Exists(strDir))
                    Directory.CreateDirectory(strDir);

                using (TextReader r = new StreamReader(strPath))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    obj = (T)xml.Deserialize(r);
                }
                return true;
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                //MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static bool SaveBySerializer<T>(T obj, string strPath, bool bBackup = false)
        {
            try
            {
                string strDir = strPath.Substring(0, strPath.LastIndexOf('\\'));
                if (!Directory.Exists(strDir))
                    Directory.CreateDirectory(strDir);

                if (bBackup)
                {
                    string BackupAddr = strPath + ".bak"; // 백업 주소를 만듭니다.

                    if (File.Exists(BackupAddr)) // 백업 파일이 존재할 경우
                    {
                        File.Delete(BackupAddr); // 제거합니다.
                    }
                    File.Move(strPath, BackupAddr); // 현재 세이브 파일을 백업합니다.
                }

                using (TextWriter w = new StreamWriter(strPath)) // 파일을 읽고 저장합니다.
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T)); // 저장할 객체 형식대로 직렬화 합니다.
                    xml.Serialize(w, obj); // 객체를 직렬화하여 파일에 저장합니다.
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
