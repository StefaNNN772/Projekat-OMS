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

        public void Insert()
        {
            try
            {
                Console.WriteLine("Unesite naziv elementa: ");
                string naziv = Console.ReadLine();

                Console.WriteLine("Unesite ID tipa elementa: ");
                int tip = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Unesite X koordinatu elementa: ");
                int x = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Unesite Y koordinatu elementa: ");
                int y = Int32.Parse(Console.ReadLine());

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
