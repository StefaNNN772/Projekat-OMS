using Projekat_OMS.DAO;
using Projekat_OMS.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.Services
{
    class AkcijaService
    {
        private static readonly IAkcijaDAO akcijaDAO = new AkcijaDAO();

        public bool SaveInsert(Akcija entity)
        {
            return akcijaDAO.SaveInsert(entity);
        }
    }
}
