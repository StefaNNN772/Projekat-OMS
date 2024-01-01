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
    class KvarDAO : IKvarDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Kvar entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            string query = "select * " +
                            "from kvar " +
                            "where idk = :idk";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Kvar> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kvar> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Kvar FindById(string id)
        {
            throw new NotImplementedException();
        }

        public string Save(Kvar entity)
        {
            string query = @"insert into Kvar (kratakopis, ele_element, opisproblema) " +
                            "values (:kratakopis, :ele_element, :opisproblema) " +
                            "returning idk into :idk_out";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "kratakopis", DbType.String);
                    ParameterUtil.AddParameter(command, "ele_element", DbType.Int32);
                    ParameterUtil.AddParameter(command, "opisproblema", DbType.String);
                    ParameterUtil.AddParameter(command, "idk_out", DbType.String, ParameterDirection.Output, 20);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "kratakopis", entity.KratakOpis);
                    ParameterUtil.SetParameterValue(command, "ele_element", entity.Ele_Element.IdEE);
                    ParameterUtil.SetParameterValue(command, "opisproblema", entity.OpisProblema);

                    command.ExecuteNonQuery();
                    return ParameterUtil.GetParameterValue(command, "idk_out").ToString();
                }
            }
        }

        public int SaveAll(IEnumerable<Kvar> entities)
        {
            throw new NotImplementedException();
        }
    }
}
