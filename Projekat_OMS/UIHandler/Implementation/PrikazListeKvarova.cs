using Projekat_OMS.DAO;
using Projekat_OMS.DAO.Implementation;
using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    class PrikazListeKvarova
    {
        private static readonly KvarService kvarService = new KvarService();

        public void Prikaz()
        {
            DateTime ulazniDatum;
            DateTime izlazniDatum;
            try
            {
                do
                {
                    Console.WriteLine("Unesite pocetni datum u formatu yyyy-MM-dd: ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out ulazniDatum));

                do
                {
                    Console.WriteLine("Unesite krajnji datum u formatu yyyy-MM-dd: ");
                } while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out izlazniDatum));

                Console.WriteLine(string.Format("{0, -20} {1, -14} {2, -20} {3, -20}", "ID kvara", "Datum", "Kratak opis kvara", "Status kvara"));
                foreach (Kvar kv in kvarService.SearchByDate(ulazniDatum, izlazniDatum))
                {
                    Console.WriteLine(string.Format("{0, -20} {1, -14} {2, -20} {3, -20}", kv.IdK, kv.VrijemeKreiranja.ToString("yyyy-MM-dd"), kv.KratakOpis, kv.StatusK));
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
