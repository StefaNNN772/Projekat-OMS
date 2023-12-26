﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler
{
    class MainUIHandler
    {
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
    }
}
