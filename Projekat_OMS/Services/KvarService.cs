using Projekat_OMS.DAO;
using Projekat_OMS.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.Services
{
    class KvarService
    {
        private static readonly IKvarDAO kvarDAO = new KvarDAO();

        public string Save(Kvar entity)
        {
            return kvarDAO.Save(entity);
        }
    }
}
