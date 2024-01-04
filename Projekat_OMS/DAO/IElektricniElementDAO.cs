using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO
{
    interface IElektricniElementDAO : ICRUDDao<ElektricniElement, int>
    {
        ElektricniElement FindById(int id, IDbConnection connection);

        bool FindByIdBool(int id);
    }
}
