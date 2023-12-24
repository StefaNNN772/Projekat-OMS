using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat_OMS
{
    class Kvar
    {
        public string ID { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public string Status { get; set; }
        public string KratakOpis { get; set; }
        public string Element { get; set; }
        public string OpisProblema { get; set; }
        public List<Akcija> Akcije { get; set; }
    }
}
