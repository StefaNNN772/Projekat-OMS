using Projekat_OMS.DAO;
using Projekat_OMS.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.Services
{
    class ElektricniTipService
    {
        private static readonly IElektricniTipDAO elektricniTipDAO = new ElektricniTipDAO();

        public bool FindByIdBool(int id)
        {
            return elektricniTipDAO.FindByIdBool(id);
        }
    }
}
