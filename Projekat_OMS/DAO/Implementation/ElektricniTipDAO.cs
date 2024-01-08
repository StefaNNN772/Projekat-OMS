using Projekat_OMS.Connection;
using Projekat_OMS.Model;
using Projekat_OMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO.Implementation
{
    class ElektricniTipDAO : IElektricniTipDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(ElektricniTip entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElektricniTip> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElektricniTip> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public ElektricniTip FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool FindByIdBool(int id)
        {
            string query = "select * " +
                            "from elektricnitip " +
                            "where idet = :idet";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idet", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idet", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public string Save(ElektricniTip entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<ElektricniTip> entities)
        {
            throw new NotImplementedException();
        }
    }
}
