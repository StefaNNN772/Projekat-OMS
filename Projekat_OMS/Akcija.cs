using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    class Akcija
    {
        public DateTime VrijemeAkcije { get; set; }
        public string Opis { get; set; }

        public Akcija() { }

        public Akcija(DateTime va, string opis)
        {
            VrijemeAkcije = va;
            Opis = opis;
        }
    }
}
