using Projekat_OMS.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.UIHandler.Implementation
{
    internal class ShowElektricniElementi
    {
        private static readonly ElektricniElementService elektricniElementService = new ElektricniElementService();

        public void ShowElementi()
        {
            Console.WriteLine(ElektricniElement.GetFormattedHeader());
            try
            {
                foreach(ElektricniElement el in elektricniElementService.FindAll())
                {
                    Console.WriteLine(el);
                }
            }
            catch(DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
