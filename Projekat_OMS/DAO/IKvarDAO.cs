using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO
{
    interface IKvarDAO : ICRUDDao<Kvar, string>
    {
        List<Kvar> SearchByDate(DateTime ulaz, DateTime izlaz);

        bool UpdateSave(string idk, string status, string kratakOpis, string opisProblema, int idElektricnogElementa);

        void Dokument(string idk);
    }
}
