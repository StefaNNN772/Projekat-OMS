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
        public string VrijemeKreiranja { get; set; }
        public string StatusK { get; set; }
        public string KratakOpis { get; set; }
        public ElektricniElement Ele_Element { get; set; }
        public string OpisProblema { get; set; }

        public Kvar(string iD, string vrijemeKreiranja, string status, string kratakOpis, ElektricniElement element, string opisProblema)
        {
            this.IdK = iD;
            this.VrijemeKreiranja = vrijemeKreiranja;
            this.StatusK = status;
            this.KratakOpis = kratakOpis;
            this.Ele_Element = element;
            this.OpisProblema = opisProblema;
        }

        public Kvar(string kratakOpis, ElektricniElement element, string opisProblema)
        {
            this.KratakOpis = kratakOpis;
            this.Ele_Element = element;
            this.OpisProblema = opisProblema;
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0, -18} {1, -14} {2, -12} {3, -20} {4, -20} {5, -20}", "IDK", "Vrijeme kreiranja", "Status", "Kratak opis", "Element", "Opis problema");
        }

        public override string ToString()
        {
            return string.Format("{0, -18} {1, -14} {2, -12} {3, -20} {4, -20} {5, -20}", IdK, VrijemeKreiranja, StatusK, KratakOpis, Ele_Element, OpisProblema);
        }
    }
}
