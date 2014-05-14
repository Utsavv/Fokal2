using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Model
{
    public class Utility
    {
        public static string Serialize(object serializableObject)
        {
            string result = null;
            StringWriter stream = null;
            XmlWriter writer = null;
            try
            {
                stream = new StringWriter();
                writer = new XmlTextWriter(stream);
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                serializer.Serialize(writer, serializableObject);
                result = stream.ToString();
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
            return result;
        }
    }
}
