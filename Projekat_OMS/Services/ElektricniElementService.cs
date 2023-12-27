﻿using Projekat_OMS.DAO;
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
        private static readonly IElektricniElementDAO elektricniElementDAO = new ElektricniElementDAO();

        public List<ElektricniElement> FindAll()
        {
            return elektricniElementDAO.FindAll().ToList();
        }
    }
}
