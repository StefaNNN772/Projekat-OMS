using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler
{
    class MainUIHandler
    {
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();
        public void HandleMainMenu()
        {
            string answer;

            do
            {
                Console.WriteLine("\nIzaberite neku od opcija: ");
                Console.WriteLine("1 - Unesite kvar");
                Console.WriteLine("2 - Prikaz liste kvarova");
                Console.WriteLine("3 - Evidencija elektricnih elemenata");
                Console.WriteLine("X - Ugasite program");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        //testiranje baze - nema veze sa zadatkom projekta
                        ShowAll();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
            } while (!answer.ToUpper().Equals("X"));
        }

        //testiranje baze - nema veze sa zadatkom projekta
        private void ShowAll()
        {
            Console.WriteLine(ElektricniElement.GetFormattedHeader());

            try
            {
                foreach (ElektricniElement scene in elektricniElementService.FindAll())
                {
                    Console.WriteLine(scene);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
