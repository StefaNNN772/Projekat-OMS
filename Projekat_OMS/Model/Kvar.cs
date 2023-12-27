using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    class Kvar
    {
        public string IdK { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public string StatusK { get; set; }
        public string KratakOpis { get; set; }
        public string Ele_Element { get; set; }
        public string OpisProblema { get; set; }

        public Kvar(string iD, DateTime vrijemeKreiranja, string status, string kratakOpis, string element, string opisProblema)
        {
            this.IdK = iD;
            this.VrijemeKreiranja = vrijemeKreiranja;
            this.StatusK = status;
            this.KratakOpis = kratakOpis;
            this.Ele_Element = element;
            this.OpisProblema = opisProblema;
        }
    }
}
