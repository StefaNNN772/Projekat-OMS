using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO
{
	public interface ICRUDDao<T, ID>
	{

		bool ExistsById(ID id);

		IEnumerable<T> FindAll();

		T FindById(ID id);

		string Save(T entity);
	}
}
