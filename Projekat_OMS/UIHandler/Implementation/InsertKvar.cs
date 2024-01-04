using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    class InsertKvar
    {
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();
        private static readonly KvarService kvarService = new KvarService();

        private static readonly InsertAkcija insertAkcija = new InsertAkcija();

        public void AddKvar()
        {
            try
            {
                Console.WriteLine("Unesite kratak opis kvara: ");
                string kratakOpis = Console.ReadLine();

                Console.WriteLine("Unesite ID elektricnog elementa: ");
                int idEle = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Unesite opis kvara: ");
                string opisKvara = Console.ReadLine();

                string status;
                do
                {
                    Console.WriteLine("Unesite status kvara: ");
                    status = Console.ReadLine();

                    if (!status.Equals("Nepotvrdjen") && !status.Equals("U popravci") && !status.Equals("Testiranje") && !status.Equals("Zatvoreno"))
                    {
                        Console.WriteLine("Nepravilan unos kvara!");
                    }
                } while (!status.Equals("Nepotvrdjen") && !status.Equals("U popravci") && !status.Equals("Testiranje") && !status.Equals("Zatvoreno"));

                Kvar kvar = new Kvar(status, kratakOpis, elektricniElementService.FindById(idEle), opisKvara);

                string uneseno = kvarService.Save(kvar);

                Console.WriteLine("Unesite broj akcija za unos: ");
                int brojAkcija = Int32.Parse(Console.ReadLine());
                insertAkcija.AddAkcija(uneseno, brojAkcija);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
