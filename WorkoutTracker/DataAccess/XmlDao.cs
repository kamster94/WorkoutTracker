using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WorkoutTracker.DataAccess
{
    class XmlDao : IBaseDao
    {
        public T DeserializeToObject<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    result = (T)serializer.Deserialize(fileStream);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }

        public void SerializeToFile<T>(string path, T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            string xml;
            var document = new XmlDocument();

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    xml = sww.ToString();
                    
                    document.LoadXml(xml);
                    try
                    {
                        document.Save(path);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }
    }
}
