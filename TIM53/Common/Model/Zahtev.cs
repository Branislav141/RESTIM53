using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Zahtev
    {
        public string Verb { get; set; }
        public string Noun { get; set; }
        public string Query { get; set; }
        public string Fields { get; set; }

        public Zahtev(string verb, string noun, string query, string fields)
        {
            Verb = verb;
            Noun = noun;
            Query = query;
            Fields = fields;
        }

        public override string ToString()
        {
            return "Verb: " + Verb + System.Environment.NewLine
                + "Noun: " + Noun + System.Environment.NewLine
                + "Query: " + Query + System.Environment.NewLine
                + "Fields: " + Fields + System.Environment.NewLine;

        }

        public Zahtev()
        {

        }
    }
}
