using Common.CommunicationBus;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunicationBus;
using Newtonsoft.Json;

namespace CommunicationBus
{
    class Program
    {
        static void Main(string[] args)
        {
            StringToJSONConverter stringToJSON = new StringToJSONConverter();
            char exit = 'a';
            string URL = "";
            bool urlValid = false;
            string zahtev = "";

            while (exit.ToString().ToUpper() != "X")
            {
                while (!urlValid)
                {
                    Console.WriteLine("Unesite URL: ");
                    URL = Console.ReadLine();
                    zahtev = stringToJSON.Convert(URL);
                    urlValid = true;
                }
                string jsonZahtev = stringToJSON.Convert(URL);
                Console.WriteLine(jsonZahtev);

                
                XNode xmlNode = JsonConvert.DeserializeXNode(jsonZahtev, "Zahtev");

                CommunicationBusService CBService = new CommunicationBusService(xmlNode);
                Console.WriteLine(CBService.Run(xmlNode));

                XElement element = xmlNode.Document.Element("Zahtev");
                Console.WriteLine(element.ToString());

                //Console.WriteLine(XMLToDBAdapter.XMLToSql(xmlNode));

                urlValid = false;
                //Izlaz
                Console.WriteLine("Unesite 'X' da izadjete iz aplikacije" + System.Environment.NewLine);
                exit = Console.ReadKey().KeyChar;
            }

        }
        
    }
}
