using Common.Migrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Common.CommunicationBus
{
    class XMLToSQL
    {
        public string SQL { get; set; }

        public XMLToSQL()
        {
        }

        public XMLToSQL(string sQL)
        {
            SQL = sQL;
        }
        //GET/Resurs/1
        //GET/Tips/1
        //GET/TipVezes/1
        //GET/Vezas/1
        //GET/Resurs/1/Naziv='resurs'/id;Naziv
        //GET/Resurs/1//id;Naziv
        //GET/Resurs/1/Naziv='resurs'
        public string ConvertAndRun(XNode node)
        {
            XElement element = node.Document.Element("Zahtev");
            string metod = element.Element("Verb").Value;
            string verb = element.Element("Noun").Value;
            string[] deo = verb.Split('/');
            string SQL = "";
            if (metod.ToUpper() == "GET")
            {
                SQL = GetSQL(element);
            }
            else if (metod.ToUpper() == "POST")
            {
                SQL = PostSQL(element);
            }
            else if (metod.ToUpper() == "PATCH")
            {
                SQL = PatchSQL(element);
            }
            else if (metod.ToUpper() == "DELETE")
            {
                SQL = DeleteSQL(element);
            }
            else
            {
                SQL = "";
            }
            Console.WriteLine(SQL);
            //RUN SQL
            string result = ExecuteSQLreturnJSON(SQL);

            ////result = dbContext.ResursTabela.SqlQuery(SQL).ToList();
            //XDocument doc = (XDocument)JsonConvert.DeserializeXmlNode("{\"Row\":" + result + "}", "root");

            //XElement xmlEl = xmlNode.Document.Root.Element("Zahtev");
            //Console.WriteLine(xmlEl.ToString());
            var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                Encoding.ASCII.GetBytes(result ), new XmlDictionaryReaderQuotas()));//JSON TO XML

            return xml.ToString();
        }

        private string ExecuteSQLreturnJSON(string sQL)
        {
            DataBaseContext dbContext = new DataBaseContext();
            Console.WriteLine(dbContext.Database.ExecuteSqlCommand(sQL));
            object result = null;
            if (sQL.Contains("Resurs"))
            {
                 result = dbContext.ResursTabela.SqlQuery(sQL).ToList();
            }
            else if (sQL.Contains("Tips"))
            {
                result = dbContext.TipTabela.SqlQuery(sQL).ToList();
            }
            else if (sQL.Contains("TipVezes"))
            {
                result = dbContext.TipVezeTabela.SqlQuery(sQL).ToList();
            }
            else if (sQL.Contains("Vezas"))
            {
                result = dbContext.VezaTabela.SqlQuery(sQL).ToList();
            }
            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
        private string GetSQL(XElement element)
        {
            string SQLZahtev = "";
            string Noun = element.Element("Noun").Value.Substring(1);
            string Querry = element.Element("Query").Value.Replace(";", " AND ");
            string Fields = element.Element("Fields").Value.Replace(";", ",");
            string[] delovi = Noun.Split('/');
            SQLZahtev = "SELECT ";
            if (String.IsNullOrEmpty(Fields))
            {
                SQLZahtev = SQLZahtev + "* ";
            }
            else
            {
                SQLZahtev = SQLZahtev + Fields;
            }
            SQLZahtev += " FROM " + delovi[0];

            if (delovi.Length >= 2 && !String.IsNullOrEmpty(delovi[1])) 
            {
                SQLZahtev += " WHERE Id=" + delovi[1];
            }

            if (!String.IsNullOrEmpty(Querry))
            {
                if (delovi.Length >= 2 && !String.IsNullOrEmpty(delovi[1]))
                {
                    SQLZahtev += " AND ";
                }
                else {
                    SQLZahtev += " WHERE ";
                }
                SQLZahtev += Querry;
            }
            SQLZahtev += ";"; //FOR XML RAW
            return SQLZahtev;
        }
        private string PostSQL(XElement element)
        {
            string Noun = element.Element("Noun").Value;
            Noun = Noun.Substring(1);
            string Kolone = "", Vrednosti = "";
            int i = 0;
            string Querry = element.Element("Query").Value;
            string[] delovi = Querry.Split(';');
            string[] koloneVrednosti = new string[2];

            while (delovi.Length > i)
            {
                if (Kolone != "")
                {
                    Kolone = Kolone + ",";
                    Vrednosti = Kolone + ",";
                }
                koloneVrednosti = delovi[i].Split('=');
                Kolone = Kolone + koloneVrednosti[0];
                Vrednosti = Vrednosti + koloneVrednosti[1];
                i++;
            }

            return "INSERT INTO " + Noun + " (" + Kolone + ") VALUES (" + Vrednosti + ");" ;
        }
        private string PatchSQL(XElement element)
        {
            //Query, fields koje je sta 
            string Noun = element.Element("Noun").Value.Substring(1);
            string Querry = element.Element("Query").Value;
            string Fields = element.Element("Fields").Value.Replace(";", ",");
            string[] NounSplited = Noun.Split('/');

            string SQLZahtev = "";
            SQLZahtev = "UPDATE " + NounSplited[0] + " SET " + Fields + " WHERE Id=" + NounSplited[1] + " ";
            if (Querry != null) 
            {
                Querry = Querry.Replace(";", " AND ");
                SQLZahtev += " AND " + Querry;
            }
            SQLZahtev = SQLZahtev + ";";
            return SQLZahtev;
        }
        private string DeleteSQL(XElement element)
        {
            string Noun = element.Element("Noun").Value.Substring(1);
            string[] delovi = Noun.Split('/');

            return "DELETE FROM " + delovi[0]
                + " WHERE Id=" + delovi[1] + ";";
        }
    }
}
