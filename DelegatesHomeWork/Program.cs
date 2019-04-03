using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace DelegatesHomeWork
{
    // 88 people
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            const int MAX_ID = 88;
            Dictionary<int, string> peoplesData = new Dictionary<int, string>();

            while (true)
            {
                Console.WriteLine($"Введите идентификатор персонажа (1-{MAX_ID.ToString()})");
                int id = 0;
                while (true)
                {
                    int.TryParse(Console.ReadLine(), out id);
                    if (id > 0 && id <= MAX_ID)
                        break;
                    Console.WriteLine("Ошибка, попробуйте еще раз!");
                }

                bool isExcists = false;
                foreach (var personsData in peoplesData)
                {
                    if (personsData.Key == id)
                    {
                        isExcists = true;
                    }
                }

                string data;
                if (isExcists)
                {
                    data = peoplesData[id];
                    Person person = JsonConvert.DeserializeObject<Person>(data);
                    Console.WriteLine(person.GetInfo());
                }
                else
                {
                    data = webClient.DownloadString($"https://swapi.co/api/people/{id.ToString()}/");
                    peoplesData.Add(id, data);
                }
                
               

             //   Person person = JsonConvert.DeserializeObject<Person>(data);
                //person.Id = id;

                //XmlDocument xmlObject = JsonConvert.DeserializeXmlNode(data);

              //  Console.WriteLine(person.Name);
            }
        }
    }
}






/*
 string objActivityDetails = JsonConvert.SerializeObject(Activities);
            XmlDocument xmlObject = JsonConvert.DeserializeXmlNode("{\"root\":" + objDetails.ToString() + "}");
     */






/*
 
    // To convert an XML node contained in string xml into a JSON string   
XmlDocument doc = new XmlDocument();
doc.LoadXml(xml);
string jsonText = JsonConvert.SerializeXmlNode(doc);

// To convert JSON text contained in string json into an XML node
XmlDocument doc = JsonConvert.DeserializeXmlNode(json); 
     
     
    */
