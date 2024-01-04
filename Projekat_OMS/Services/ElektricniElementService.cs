using Projekat_OMS.DAO;
using Projekat_OMS.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.Services
{
    class ElektricniElementService
    {
        private static IElektricniElementDAO elektricniElementDAO = new ElektricniElementDAO();

        public List<ElektricniElement> FindAll()
        {
            return elektricniElementDAO.FindAll().ToList();
        }

        public ElektricniElement FindById(int id)
        {
            return elektricniElementDAO.FindById(id);
        }

        public string Save(ElektricniElement entity)
        {
            return elektricniElementDAO.Save(entity);
        }

        public bool FindByIdBool(int id)
        {
            return elektricniElementDAO.FindByIdBool(id);
        }
    }
}
