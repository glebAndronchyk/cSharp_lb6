using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LB6
{
    public class SerializationCases
    {
        
        public void WriteDataInTxt(List<Service> services)
        {
            string fileName = "data.txt";
            FileStream fs = File.Create(fileName);
            fs.Close();
            StreamWriter sw = new StreamWriter(fileName, true);

            foreach (var service in services)
            {
                sw.Write(service.ToString());
            }
            
            sw.Close();
        }
        

        public void XmlSerialization(List<Service> services)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Service>));
            string fileName = "data.xml";
            TextWriter sw = new StreamWriter(fileName);

            serializer.Serialize(sw, services);

            sw.Close();
        }

        public void JsonSerialization(List<Service> services)
        {
            string jsonString = JsonConvert.SerializeObject(services);
            Console.WriteLine(jsonString);
            File.WriteAllText("data.json", jsonString);
        }
        // private string MakeRandomName(string ext)
        // {
        //     Random rnd = new Random();
        //     return $"{rnd.Next()}.{ext}";
        // }
    }
}