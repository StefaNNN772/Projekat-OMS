using Oracle.ManagedDataAccess.Client;
using Projekat_OMS.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS
{
    class Program
    {
        private static readonly MainUIHandler mainUIHandler = new MainUIHandler();
        static void Main(string[] args)
        {
            mainUIHandler.HandleMainMenu();
        }
    }
}
