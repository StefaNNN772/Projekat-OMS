using Projekat_OMS.Connection;
using Projekat_OMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO.Implementation
{
    class AkcijaDAO : IAkcijaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Akcija entity)
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

        public IEnumerable<Akcija> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Akcija> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Akcija FindById(int id)
        {
            throw new NotImplementedException();
        }

        public string Save(Akcija entity)
        {
            throw new NotImplementedException();
        }

        public bool SaveInsert(Akcija entity)
        {
            string query = "insert into Akcija (idk, opisa) " +
                            "values (:idk, :opisa)";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);
                    ParameterUtil.AddParameter(command, "opisa", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", entity.IdK);
                    ParameterUtil.SetParameterValue(command, "opisa", entity.OpisA);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public int SaveAll(IEnumerable<Akcija> entities)
        {
            throw new NotImplementedException();
        }
    }
}
