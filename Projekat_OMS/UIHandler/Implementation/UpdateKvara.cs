﻿using Projekat_OMS.DAO;
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
    class UpdateKvara
    {
        private static readonly KvarService kvarService = new KvarService();
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();

        public void Update()
        {
            try
            {
                Console.WriteLine("Unesite ID kvara za pregled: ");
                string id = Console.ReadLine();

                Kvar kv = kvarService.FindById(id);

                if (kv == null)
                {
                    Console.WriteLine("Kvar sa zadatik ID-em nije pronadjen!");
                    return;
                }

                Console.WriteLine(Kvar.GetFormattedHeader());
                Console.WriteLine(kv);

                if (!kv.StatusK.Equals("Zatvoreno"))
                {
                    string answer;
                    do
                    {
                        Console.WriteLine("Zelite li azurirati kvar (Y/N)?");
                        answer = Console.ReadLine();

                        if (answer.ToUpper() != "Y" && answer.ToUpper() != "N")
                        {
                            Console.WriteLine("Nepravilan unos! Pokusajte ponovo!");
                        }
                    } while (answer.ToUpper() != "Y" && answer.ToUpper() != "N");

                    if (answer.ToUpper() == "N")
                    {
                        return;
                    }

                    Console.WriteLine("Unesite novi ili isti kratak opis kvara: ");
                    string kratakOpis = Console.ReadLine();

                    int idEle;
                    do
                    {
                        Console.WriteLine("Unesite ID elektricnog elementa: ");
                        idEle = Int32.Parse(Console.ReadLine());

                        if (!elektricniElementService.FindByIdBool(idEle))
                        {
                            Console.WriteLine("Ne postoji elektricni element sa tim ID-em! Pokusajte ponovo!");
                        }
                    } while (!elektricniElementService.FindByIdBool(idEle));

                    Console.WriteLine("Unesite novi ili isti opis kvara: ");
                    string opisProblema = Console.ReadLine();

                    string status;
                    do
                    {
                        Console.WriteLine("Unesite novi ili isti status kvara: ");
                        status = Console.ReadLine();

                        if (!status.Equals("Nepotvrdjen") && !status.Equals("U popravci") && !status.Equals("Testiranje") && !status.Equals("Zatvoreno"))
                        {
                            Console.WriteLine("Nepravilan unos kvara!");
                        }
                    } while (!status.Equals("Nepotvrdjen") && !status.Equals("U popravci") && !status.Equals("Testiranje") && !status.Equals("Zatvoreno"));

                    if (!kvarService.UpdateSave(kv.IdK, status, kratakOpis, opisProblema, idEle))
                    {
                        Console.WriteLine("Azuriranje uspijesno obavljeno!");
                    }
                    else
                    {
                        Console.WriteLine("Neuspijesno azuriranje!");
                    }
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
