using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Resurs> ResursTabela { get; set; }
        public DbSet<Tip> TipTabela { get; set; }
        public DbSet<TipVeze> TipVezeTabela { get; set; }
        public DbSet<Veza> VezaTabela { get; set; }

        public DataBaseContext() : base("RES_Baza")
        {

        }
    }
}
