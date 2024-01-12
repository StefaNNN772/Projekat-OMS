using Projekat_OMS.Services;
using Projekat_OMS.UIHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    class InsertAkcija : IInsertAkcija
    {
        private static readonly AkcijaService akcijaService = new AkcijaService();

        private static int max_size = 250;

        public void AddAkcija(string idk, int brojAkcija)
        {
            if (brojAkcija == 0)
            {
                return;
            }

            do
            {
                try
                {
                    string opisAkcije;
                    do
                    {
                        Console.WriteLine("Unesite opis akcije: ");
                        opisAkcije = Console.ReadLine();
                    } while (opisAkcije.Length > max_size || opisAkcije.Length == 0);

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
