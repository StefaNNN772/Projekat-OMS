﻿using Projekat_OMS.Services;
using Projekat_OMS.UIHandler.Implementation;
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
        private static readonly InsertKvar insertKvar = new InsertKvar();
        private static readonly EvidencijaElektricnihElemenataUIHandler evidencija = new EvidencijaElektricnihElemenataUIHandler();
        private static readonly ListaKvarova listaKvarova = new ListaKvarova();
        private static readonly KreiranjeDokumentaUIHandler kreiranjeDokumentaUIHandler = new KreiranjeDokumentaUIHandler();
        public void HandleMainMenu()
        {
            string answer;

            do
            {
                Console.WriteLine("\nIzaberite neku od opcija: ");
                Console.WriteLine("1 - Unesite kvar");
                Console.WriteLine("2 - Prikaz liste kvarova");
                Console.WriteLine("3 - Evidencija elektricnih elemenata");
                Console.WriteLine("4 - Kreiranje dokumenta");
                Console.WriteLine("X - Ugasite program");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        insertKvar.AddKvar();
                        break;
                    case "2":
                        listaKvarova.SecondMenu();
                        break;
                    case "3":
                        evidencija.HandleEvidencijaElemenata();
                        break;
                    case "4":
                        kreiranjeDokumentaUIHandler.HandleKreiranjeDokumenta();
                        break;
                    default:
                        break;
                }
            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
