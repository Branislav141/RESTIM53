using Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationBus
{
    public class StringToJSONConverter
    {
        public StringToJSONConverter()
        {

        }
        public string Convert(string stringRequest)
        {
            Zahtev zahtev = new Zahtev();
            string[] delovi = stringRequest.Split('/');
            String metod = delovi[0].ToUpper().Trim();

            zahtev.Verb = delovi[0];
            
            if (metod == "GET")
            {
                //GET/Resurs
                zahtev.Noun = "/" + delovi[1];
                //GET/Resurs/1
                if (delovi.Length > 2 && !String.IsNullOrEmpty(delovi[2]))
                {
                    zahtev.Noun = "/" + delovi[1] + "/" + delovi[2];
                }

                //get/Resurs/1/Naziv='pera'/
                //get/Resurs/1/Naziv='pera'
                if (delovi.Length >= 4) 
                { 
                    zahtev.Query = delovi[3]; 
                }
                //get/Resurs/1/Naziv='resurs'/Id;Naziv
                //get/Resurs//Naziv='resurs'/Id;Naziv;Opis
                //get/Resurs/1//Id;Naziv;surname
                if (delovi.Length == 5)
                {
                    zahtev.Fields = delovi[4];
                }
            }
            else if (metod == "POST")
            {
                zahtev.Noun = "/" + delovi[1];
                zahtev.Query = delovi[2];
            }
            else if (metod == "PATCH")
            {
                zahtev.Noun = "/" + delovi[1] + "/" + delovi[2];
                if (delovi.Length == 5) 
                { 
                    zahtev.Fields = delovi[4];
                }
                zahtev.Query = delovi[3]; 
            }
            else if (metod == "DELETE")
            {
                zahtev.Noun = "/" + delovi[1] + "/" + delovi[2];
            }
            else
            {
                return null;
            }

            return JsonConvert.SerializeObject(zahtev, Formatting.Indented);
        }
    }
}
