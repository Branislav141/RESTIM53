using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class TipVeze
	{
		public int Id{get;set;}
		public string Naziv{get;set;}
		public TipVeze(int id, string naziv)
		{
			Id = id;
			Naziv = naziv;
		}
    }
}
