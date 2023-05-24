using System;
using System.Collections.Generic;
using System.IO;
using LB6.Models;
using Newtonsoft.Json;

namespace LB6
{
    internal class Program
    {
        private static SerializationCases sc = new SerializationCases();
        private static DeserializationCases dsc = new DeserializationCases();
        private static StarWarsApi api = new StarWarsApi();
        private static utils utility = new utils();

        private static void FindCarsRelatedToYear()
        {
            Console.WriteLine("Enter year:");
            string year = Console.ReadLine();
            int choice;
            
            do
            {
                Console.WriteLine("Select:\nEnter 1 to deserialize data from .txt file");
                Console.WriteLine("Enter 2 to deserialize data from .xml format");
                Console.WriteLine("Enter 3 to deserialize data from .json format");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        List<Service> servicesTxt = dsc.DeserializeTxt("data.txt");
                        List<Service> foundValuesTxt = utils.Find(servicesTxt, year);
                        utility.PrintServicesInConsole(foundValuesTxt);
                        break;
                    case 2:
                        List<Service> servicesXml = dsc.DeserializeXml("data.xml");
                        List<Service> foundValuesXml = utils.Find(servicesXml, year);
                        utility.PrintServicesInConsole(foundValuesXml);
                        break;
                    case 3:
                        List<Service> servicesJSON = dsc.DeserializeJson("data.json");
                        List<Service> foundValuesJSON = utils.Find(servicesJSON, year);
                        utility.PrintServicesInConsole(foundValuesJSON);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Команда не розпiзнана!");
                        Console.ResetColor();
                        break;
                }
            } while (choice != 0);
        }

        private static void RunSerializationMenu(List<Service> services)
        {
            int choice;

            do
            {
                Console.WriteLine("Select:\nEnter 1 to write data in .txt file");
                Console.WriteLine("Enter 2 to serialize data into .xml format");
                Console.WriteLine("Enter 3 to serialize data into JSON format");
                Console.WriteLine("Enter 4 to find a service by year");
                Console.WriteLine("|______________| 5 - request random Star Wars character (*_*)");
                Console.WriteLine("Enter 0 to exit the program!");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        sc.WriteDataInTxt(services);
                        break;
                    case 2:
                        sc.XmlSerialization(services);
                        break;
                    case 3:
                        sc.JsonSerialization(services);
                        break;
                    case 4:
                        FindCarsRelatedToYear();
                        break;
                    case 5:
                        api.GetRandomSwCharacter();
                        string fileData = File.ReadAllText("character.json");
                        SwapiChar character = JsonConvert.DeserializeObject<SwapiChar>(fileData);
                        Console.WriteLine(character.ToString());
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Команда не розпiзнана!");
                        Console.ResetColor();
                        break;
                }
            } while (choice != 0);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter amount of services");
            int servicesAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Write service data.\nFormat:\n\t 1.service date. \n\t 2.car model. \n\t 3. release date. \n\t 4.task name.");
            List<Service> servicesList = utility.GetServicesList(servicesAmount);
            RunSerializationMenu(servicesList);
        }
    }
}