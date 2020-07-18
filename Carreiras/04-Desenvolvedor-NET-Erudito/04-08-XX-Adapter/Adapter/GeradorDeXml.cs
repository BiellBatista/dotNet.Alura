using System;
using System.IO;
using System.Xml.Serialization;

namespace _04_08_XX_Adapter.Adapter
{
    public class GeradorDeXml
    {
        public String GeraXml(Object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, o);

            return writer.ToString();
        }s
    }
}
