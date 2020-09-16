using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Veza
    {
        public int Id { get; set; }
        public int IdPrvogElementa { get; set; }
        public int IdDrugogElementa { get; set; }
        public TipVeze TipV { get; set; }

        public Veza(int id, int id1, int id2, TipVeze tipV)
        {
            Id = id;
            IdPrvogElementa = id1;
            IdDrugogElementa = id2;
            TipV = tipV;
        }
        public Veza()
        {

        }
    }
}
