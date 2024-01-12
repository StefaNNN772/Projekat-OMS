using Projekat_OMS.UIHandler.Implementation;
using Projekat_OMS.UIHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler
{
    class ListaKvarova : IListaKvarova
    {
        private static readonly PrikazListeKvarova prikazListeKvarova = new PrikazListeKvarova();
        private static readonly UpdateKvara updateKvara = new UpdateKvara();

        public void SecondMenu()
        {
            string answer;

            do
            {
                Console.WriteLine("\nIzaberite neku od opcija: ");
                Console.WriteLine("1 - Kvarovi izmedju datuma");
                Console.WriteLine("2 - Biranje odredjenog kvara");
                Console.WriteLine("X - Ugasite program");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        prikazListeKvarova.Prikaz();
                        break;
                    case "2":
                        updateKvara.Update();
                        break;
                    case "3":
                    default:
                        break;
                }
            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
