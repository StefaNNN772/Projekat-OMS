using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    class InsertElektricniElement
    {
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();
        private static readonly ElektricniTipService elektricniTipService = new ElektricniTipService();

        private static int max_size = 30;

        public void Insert()
        {
            try
            {
                string naziv;
                do
                {
                    Console.WriteLine("Unesite naziv elementa: ");
                    naziv = Console.ReadLine();
                } while (naziv.Length > max_size || naziv.Length == 0);

                int tip;
                do
                {
                    Console.WriteLine("Unesite ID tipa elementa: ");
                    Int32.TryParse(Console.ReadLine(), out tip);

                    if (!elektricniTipService.FindByIdBool(tip))
                    {
                        Console.WriteLine("Ne postoji tip elektricnog elementa sa zadatim ID-em! Pokusajte ponovo!");
                    }
                } while (!elektricniTipService.FindByIdBool(tip));

                int x;
                do
                {
                    Console.WriteLine("Unesite X koordinatu elementa: ");
                } while (Int32.TryParse(Console.ReadLine(), out x) == false);

                int y;
                do
                {
                    Console.WriteLine("Unesite Y koordinatu elementa: ");
                } while (Int32.TryParse(Console.ReadLine(), out y) == false);

                string naponskinivo;
                do
                {
                    Console.WriteLine("Unesite naponski nivo: ");
                    naponskinivo = Console.ReadLine();

                    if (!naponskinivo.Equals("Visok napon") && !naponskinivo.Equals("Srednji napon") && !naponskinivo.Equals("Nizak napon"))
                    {
                        Console.WriteLine("Nepravilan unos naponskog nivoa: ");
                    }
                } while (!naponskinivo.Equals("Visok napon") && !naponskinivo.Equals("Srednji napon") && !naponskinivo.Equals("Nizak napon"));

                ElektricniElement el = new ElektricniElement(naziv, tip, x, y, naponskinivo);

                string uneseno = elektricniElementService.Save(el);

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
