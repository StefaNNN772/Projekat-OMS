using Projekat_OMS.UIHandler.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler
{
    internal class EvidencijaElektricnihElemenataUIHandler
    {
        private static readonly ShowElektricniElementi show = new ShowElektricniElementi();
        private static readonly InsertElektricniElement insert = new InsertElektricniElement();
            public void HandleEvidencijaElemenata()
            {
                string answer;

                do
                {
                    Console.WriteLine("\nIzaberite neku od opcija: ");
                    Console.WriteLine("1 - Unesite elektricni element");
                    Console.WriteLine("2 - Prikazi elektricne elemente");
                    Console.WriteLine("X - Ugasite program");

                    answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "1":
                        insert.Insert();
                            break;
                        case "2":
                        show.ShowElementi();
                            break;
                        default:
                            break;
                    }
                } while (!answer.ToUpper().Equals("X"));
            }
        }
}
