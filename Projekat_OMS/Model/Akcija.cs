using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    class Akcija
    {
        public int IdA { get; set; }
        public string IdK { get; set; }
        public string DatumAkcije { get; set; }
        public string OpisA { get; set; }

        public Akcija(int idA, string idK, string datumAkcije, string opisA)
        {
            this.IdA = idA;
            this.IdK = idK;
            this.DatumAkcije = datumAkcije;
            this.OpisA = opisA;
        }

        public Akcija(string idK, string opisA)
        {
            this.IdK = idK;
            this.OpisA = opisA;
        }
    }
}
