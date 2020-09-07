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
            string[] delovi = stringRequest.Split('/');
            if (delovi[0].ToUpper() == "GET")
            {
            }
            else if (delovi[0].ToUpper() == "POST")
            {
            }
            else if (delovi[0].ToUpper() == "PATCH")
            {
            }
            else if (delovi[0].ToUpper() == "DELETE")
            {
            }
            else
            {
                return null;
            }

            Zahtev request = new Zahtev();
            request.Verb = delovi[0];
            request.Noun = delovi[1];

            return request;
        }
    }
}
