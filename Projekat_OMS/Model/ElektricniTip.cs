using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.Model
{
    public class ElektricniTip
    {
        public int IdET { get; set; }
        public string NazivET { get; set; }

        public ElektricniTip(int idET, string nazivET)
        {
            this.IdET = idET;
            this.NazivET = nazivET;
        }
    }
}
