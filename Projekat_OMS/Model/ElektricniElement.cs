using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    class ElektricniElement
    {
        public int IdEE { get; set; }
        public string NazivEE { get; set; }
        public int TipEE { get; set; }
        public string LokacijaEE { get; set; }
        public string NaponskiNivoEE { get; set; }

        public ElektricniElement(int iD, string naziv, int tip, string lokacija, string naponskiNivo)
        {
            this.IdEE = iD;
            this.NazivEE = naziv;
            this.TipEE = tip;
            this.LokacijaEE = lokacija;
            this.NaponskiNivoEE = naponskiNivo;
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0, -8} {1, -20} {2, -10} {3, -20} {4, -20}", "IDEE", "NazivEE", "TipEE_ID", "LokacijaEE", "NaponskiNivoEE");
        }

        public override string ToString()
        {
            return string.Format("{0, -8} {1, -20} {2, -10} {3, -20} {4, -20}", IdEE, NazivEE, TipEE, LokacijaEE, NaponskiNivoEE);
        }
    }
}
