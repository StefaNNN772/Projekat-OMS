using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    public class KreiranjeDokumenta
    {
        private static readonly KvarService kvarService = new KvarService();

        public void KreirajExcel()
        {
            try
            {
                Console.WriteLine("Lista kvarova:");
                Console.WriteLine(Kvar.GetFormattedHeader());
                foreach (Kvar kvar in kvarService.FindAll())
                {
                    Console.WriteLine(kvar);
                }

                Console.WriteLine("Izaberite ID kvara za koji zelite kreirati Excel dokument: ");
                string idk = Console.ReadLine();

                if (kvarService.FindById(idk) == null)
                {
                    Console.WriteLine("Ne postoji kvar sa zadatim ID-om!");
                }
                else
                {
                    kvarService.Dokument(idk);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
