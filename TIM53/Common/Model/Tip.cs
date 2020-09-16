using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Tip
	{
		public int Id {get; set;}
		public string Naziv {get; set;}
		public Tip(int id, string naziv)
		{
			Id = id;
			Naziv = naziv;
		}

        public Tip()
        {

        }
    }
}
