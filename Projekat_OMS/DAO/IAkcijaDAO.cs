using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO
{
    interface IAkcijaDAO : ICRUDDao<Akcija, int>
    {
        bool SaveInsert(Akcija entity);

        int CountById(string idK);
    }
}
