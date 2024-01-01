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

                Console.WriteLine("Unesite lokaciju elementa: ");
                string lokacija = Console.ReadLine();

                Console.WriteLine("Unesite naponski nivo: ");
                string naponskinivo=Console.ReadLine();

                ElektricniElement el = new ElektricniElement(naziv, tip, lokacija, naponskinivo);

                string uneseno = elektricniElementService.Save(el);

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
