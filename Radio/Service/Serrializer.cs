﻿using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Radio.Service
{
    class Serrializer
    {
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(List<RadioStation>));

        public void Write(string fileName, List<RadioStation> list)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, list);
            }
        }

        public List<RadioStation> Read(string fileName)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    return serializer.Deserialize(stream) as List<RadioStation>;
                }
            }
            catch (Exception) { }
            return new List<RadioStation>();
        }
    }
}