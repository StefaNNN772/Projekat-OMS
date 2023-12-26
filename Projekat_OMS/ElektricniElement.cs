using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    public enum NaponNivo { Srednji_napon, Nizak_napon, Visok_napon }
    class ElektricniElement
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Lokacija { get; set; }
        public NaponNivo NaponskiNivo { get; set; } = NaponNivo.Srednji_napon;

        public ElektricniElement() { }
        public ElektricniElement(int iD, string naziv, string tip, string lokacija, NaponNivo naponskiNivo)
        {
            ID = iD;
            Naziv = naziv;
            Tip = tip;
            Lokacija = lokacija;
            NaponskiNivo = naponskiNivo;
        }
    }
}
