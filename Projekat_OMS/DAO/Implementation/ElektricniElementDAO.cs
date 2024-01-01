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
    class ElektricniElementDAO : IElektricniElementDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(ElektricniElement entity)
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

        public IEnumerable<ElektricniElement> FindAll()
        {
            string query = "select * " +
                            "from elektricnielement";

            List<ElektricniElement> elektricniElementList = new List<ElektricniElement>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ElektricniElement elektricniElement = new ElektricniElement(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));

                            elektricniElementList.Add(elektricniElement);
                        }
                    }
                }
            }

            return elektricniElementList;
        }

        public IEnumerable<ElektricniElement> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public ElektricniElement FindById(int id)
        {
            string query = "select * " +
                            "from elektricnielement " +
                            "where idee = :idee";

            ElektricniElement ele_element = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idee", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idee", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ele_element = new ElektricniElement(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                        }
                    }
                }
            }

            return ele_element;
        }

        public string Save(ElektricniElement entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<ElektricniElement> entities)
        {
            throw new NotImplementedException();
        }
    }
}
