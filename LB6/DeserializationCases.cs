using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LB6
{
    public class DeserializationCases
    {
        public List<Service> DeserializeTxt(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string lineInfo;
            string serviceInfo = "";
            List<Service> result = new List<Service>();

            while (!sr.EndOfStream)
            {
                lineInfo = sr.ReadLine();
                if (lineInfo == "------")
                {
                    Service service = new Service(serviceInfo);
                    result.Add(service);
                    serviceInfo = "";
                    continue;
                }

                serviceInfo += lineInfo + " ";
            }

            return result;
        }

        [XmlRoot("ArrayOfService")]
        public class ServiceListWrapper
        {
            [XmlElement("Service")]
            public List<Service> Services { get; set; }
        }

        public List<Service> DeserializeXml(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ServiceListWrapper));
    
            using (XmlReader fs = XmlReader.Create(fileName))
            {
                ServiceListWrapper wrapper = (ServiceListWrapper) xs.Deserialize(fs);
                List<Service> serviceList = wrapper.Services;
    
                return serviceList;
            }
        }

        public List<Service> DeserializeJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Service> services = JsonConvert.DeserializeObject<List<Service>>(jsonString);

            return services;
        }
    }
}