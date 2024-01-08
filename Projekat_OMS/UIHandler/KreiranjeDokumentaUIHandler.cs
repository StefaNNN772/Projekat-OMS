using Projekat_OMS.UIHandler.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler
{
    class KreiranjeDokumentaUIHandler
    {
        private static readonly KreiranjeDokumenta kreiranjeDokumenta = new KreiranjeDokumenta();
        public void HandleKreiranjeDokumenta()
        {
            string answer;

            do
            {
                Console.WriteLine("\nIzaberite neku od opcija: ");
                Console.WriteLine("1 - Excel dokument");
                Console.WriteLine("X - Ugasite program");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        kreiranjeDokumenta.Kreiraj();
                        break;
                    default:
                        break;
                }
            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
