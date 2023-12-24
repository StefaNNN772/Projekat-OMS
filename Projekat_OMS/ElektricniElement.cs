using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat_OMS
{
    class ElektricniElement
    {
        public string ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Lokacija { get; set; }
        public string NaponskiNivo { get; set; }

        public ElektricniElement() { }
        public ElektricniElement(string iD, string naziv, string tip, string lokacija, string naponskiNivo)
        {
            ID = iD;
            Naziv = naziv;
            Tip = tip;
            Lokacija = lokacija;
            NaponskiNivo = naponskiNivo;
        }
    }
}
