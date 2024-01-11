using Projekat_OMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    internal class ElektricniElement : AbstractModel
    {
        public int IdEE { get; set; }
        public string NazivEE { get; set; }
        public int TipEE { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string NaponskiNivoEE { get; set; }

        public ElektricniElement(int iD, string naziv, int tip, int x, int y, string naponskiNivo)
        {
            this.IdEE = iD;
            this.NazivEE = naziv;
            this.TipEE = tip;
            this.X = x;
            this.Y = y;
            this.NaponskiNivoEE = naponskiNivo;
        }

        public ElektricniElement(string naziv, int tip, int x, int y, string naponskiNivo)
        {
            this.NazivEE = naziv;
            this.TipEE = tip;
            this.X = x;
            this.Y = y;
            this.NaponskiNivoEE = naponskiNivo;
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0, -8} {1, -20} {2, -10} {3, -5} {4, -5} {5, -20}", "IDEE", "NazivEE", "TipEE_ID", "X", "Y", "NaponskiNivoEE");
        }

        public override string ToString()
        {
            return string.Format("{0, -8} {1, -20} {2, -10} {3, -5} {4, -5} {5, -20}", IdEE, NazivEE, TipEE, X, Y, NaponskiNivoEE);
        }
    }
}
