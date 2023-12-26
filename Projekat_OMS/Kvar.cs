using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    public enum StatusKvara { Nepotvrdjen, U_popravci, Testiranje, Zatvoreno }
    class Kvar
    {
        public string ID { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public StatusKvara Status { get; set; } = StatusKvara.Nepotvrdjen;
        public string KratakOpis { get; set; }
        public string Element { get; set; }
        public string OpisProblema { get; set; }
        public List<Akcija> Akcije { get; set; } = new List<Akcija>();

        public Kvar() { }
        public Kvar(string iD, DateTime vrijemeKreiranja, StatusKvara status, string kratakOpis, string element, string opisProblema, List<Akcija> akcije)
        {
            ID = iD;
            VrijemeKreiranja = vrijemeKreiranja;
            Status = status;
            KratakOpis = kratakOpis;
            Element = element;
            OpisProblema = opisProblema;
            Akcije = akcije;
        }
    }
}
