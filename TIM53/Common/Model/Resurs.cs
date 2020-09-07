using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Resurs
    {
        public int Id {get; set;}
        public string Naziv { get; set; }
        public string Opis{get; set;}
        public Tip TipResursa{get; set;}

        public Resurs(int id, string naziv, string opis, Tip tip_resursa)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            TipResursa = tip_resursa;
        }
    }
}
