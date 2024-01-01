using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    class InsertAkcija
    {
        private static readonly AkcijaService akcijaService = new AkcijaService();

        public void AddAkcija(string idk, int brojAkcija)
        {
            do
            {
                try
                {
                    Console.WriteLine("Unesite opis akcije: ");
                    string opisAkcije = Console.ReadLine();

                    Akcija akcija = new Akcija(idk, opisAkcije);

                    akcijaService.SaveInsert(akcija);
            }
                catch (DbException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while ((--brojAkcija) > 0);
        }
    }
}
