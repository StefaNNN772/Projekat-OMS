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
        public ElektricniElement Ele_Element { get; set; }
        public string OpisProblema { get; set; }

        public Kvar(string iD, DateTime vrijemeKreiranja, string status, string kratakOpis, ElektricniElement element, string opisProblema)
        {
            this.IdK = iD;
            this.VrijemeKreiranja = vrijemeKreiranja;
            this.StatusK = status;
            this.KratakOpis = kratakOpis;
            this.Ele_Element = element;
            this.OpisProblema = opisProblema;
        }

        public Kvar(string statusK, string kratakOpis, ElektricniElement element, string opisProblema)
        {
            this.StatusK = statusK;
            this.KratakOpis = kratakOpis;
            this.Ele_Element = element;
            this.OpisProblema = opisProblema;
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0, -20} {1, -20} {2, -20} {3, -20} {4, -20} {5, -20}", "ID kvara", "Datum kreiranja", "Status", "Kratak opis", "ID elementa", "Opis problema");
        }

        public override string ToString()
        {
            return string.Format("{0, -20} {1, -20} {2, -20} {3, -20} {4, -20} {5, -20}", IdK, VrijemeKreiranja.ToString("yyyy-MM-dd"), StatusK, KratakOpis, Ele_Element.IdEE, OpisProblema);
        }
    }
}
