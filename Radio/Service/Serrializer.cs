using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Radio.Service
{
    class Serrializer
    {
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(List<RadioStation>));

        public void WriteToFile(string fileName, List<RadioStation> list)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, list);
            }
        }

        public List<RadioStation> ReadFromFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        return serializer.Deserialize(stream) as List<RadioStation>;
                    }
                }
            }
            catch (Exception) { }
            return new List<RadioStation>();
        }
    }
}