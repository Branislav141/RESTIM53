using Common.Model;
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
        public Zahtev Convert(string stringRequest)
        {
            Zahtev zahtev = new Zahtev();
            string[] delovi = stringRequest.Split('/');

            zahtev.Verb = delovi[0];
            
            if (delovi[0].ToUpper() == "GET")
            {
                //GET/Resurs
                if (delovi.Length == 2) 
                { 
                    zahtev.Noun = "/" + delovi[1]; 
                }
                //get/Resurs/1
                else if (delovi.Length >= 2) 
                { 
                    zahtev.Noun = "/" + delovi[1] + "/" + delovi[2]; 
                }
                //get/Resurs/1/name='pera';type=1/
                if (delovi.Length >= 4) 
                { 
                    zahtev.Query = delovi[3]; 
                }
                //get/Resurs/1/name='pera';type=1/id;name;surname
                if (delovi.Length == 5)
                {
                    zahtev.Fields = delovi[4];
                }
            }
            else if (delovi[0].ToUpper() == "POST")
            {
                zahtev.Noun = "/" + delovi[1];
                zahtev.Query = delovi[2];
            }
            else if (delovi[0].ToUpper() == "PATCH")
            {
                zahtev.Noun = "/" + delovi[1] + "/" + delovi[2];
                if (delovi.Length == 5) 
                { 
                    zahtev.Query = delovi[4]; 
                }
                zahtev.Fields = delovi[3];
            }
            else if (delovi[0].ToUpper() == "DELETE")
            {
                zahtev.Noun = "/" + delovi[1] + "/" + delovi[2];
            }
            else
            {
                return null;
            }

            return zahtev;
        }
    }
}
