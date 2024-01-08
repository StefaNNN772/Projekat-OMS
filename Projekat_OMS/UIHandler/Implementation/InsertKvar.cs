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

        private static int max_size = 250;

        public void AddKvar()
        {
            try
            {
                string kratakOpis;
                do
                {
                    Console.WriteLine("Unesite kratak opis kvara: ");
                    kratakOpis = Console.ReadLine();
                } while (kratakOpis.Length > max_size || kratakOpis.Length == 0);

                int idEle;
                do
                {
                    Console.WriteLine("Unesite ID elektricnog elementa: ");
                    Int32.TryParse(Console.ReadLine(), out idEle);
                    if (!elektricniElementService.FindByIdBool(idEle))
                    {
                        Console.WriteLine("Ne postoji elektricni element sa zadatim ID-em! Pokusajte ponovo!");
                    }
                } while (!elektricniElementService.FindByIdBool(idEle));

                string opisKvara;
                do
                {
                    Console.WriteLine("Unesite opis kvara: ");
                    opisKvara = Console.ReadLine();
                } while (opisKvara.Length > max_size || opisKvara.Length == 0);

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

                int brojAkcija;
                do
                {
                    Console.WriteLine("Unesite broj akcija za unos: ");
                } while (Int32.TryParse(Console.ReadLine(), out brojAkcija) == false);
                insertAkcija.AddAkcija(uneseno, brojAkcija);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
