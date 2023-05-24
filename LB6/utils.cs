using System;
using System.Collections.Generic;

namespace LB6
{
    public class utils
    {
        public static List<Service> Find(List<Service> list, string value)
        {
            List<Service> result = new List<Service>();

            foreach (var service in list)
            {
                if (service.serviceDate == value)
                {
                    result.Add(service);
                }
            }

            return result;
        }
        
        public List<Service> GetServicesList(int amount)
        {
            List<Service> servicesList = new List<Service>();
            for (int i = 0; i < amount; i++)
            {
                string service = Console.ReadLine();
                servicesList.Add(new Service(service));
            }

            servicesList.Sort();
            return servicesList;
        }

        public void PrintServicesInConsole(List<Service> services)
        {
            if (services.Count == 0)
            {
                Console.WriteLine("There are no cars related to this year");
                return;
            }

            foreach (var service in services)
            {
                Console.WriteLine(service.ToString());
            }
        }
    }
}