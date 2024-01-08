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
        private static readonly IAkcijaDAO akcijaDAO= new AkcijaDAO();

        public string Save(Kvar entity)
        {
            return kvarDAO.Save(entity);
        }

        public List<Kvar> SearchByDate(DateTime ulaz, DateTime izlaz)
        {
            return kvarDAO.SearchByDate(ulaz, izlaz).ToList();
        }

        public Kvar FindById(string id)
        {
            return kvarDAO.FindById(id);
        }

        public bool UpdateSave(string idk, string status, string kratakOpis, string opisProblema, int idElektricnogElementa)
        {
            return kvarDAO.UpdateSave(idk, status, kratakOpis, opisProblema, idElektricnogElementa);
        }

        public int CountById(string idK)
        {
            return akcijaDAO.CountById(idK);
        }

        public List<Kvar> FindAll()
        {
            return kvarDAO.FindAll().ToList();
        }

        public void Dokument(string idk)
        {
            kvarDAO.Dokument(idk);
        }
    }
}
