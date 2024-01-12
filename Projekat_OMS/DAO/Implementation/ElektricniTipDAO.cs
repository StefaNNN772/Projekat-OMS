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

        public bool ExistsById(int id)
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

        public IEnumerable<ElektricniTip> FindAll()
        {
            string query = "select * " +
                            "from elektricnitip";

            List<ElektricniTip> ret = new List<ElektricniTip>();

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
                            ElektricniTip et = new ElektricniTip(reader.GetInt32(0), reader.GetString(1));

                            ret.Add(et);
                        }
                    }
                }
            }

            return ret;
        }

        public ElektricniTip FindById(int id)
        {
            string query = "select * " +
                            "from elektricnitip " +
                            "where idet = :idet";

            ElektricniTip ret = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idet", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idet", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ret = new ElektricniTip(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }

            return ret;
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
            string query = @"insert into elektricnitip (nazivet) " +
                            "values (:nazivet) " +
                            "returning idet into :idet_out";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "nazivet", DbType.String);
                    ParameterUtil.AddParameter(command, "idet_out", DbType.Int32, ParameterDirection.Output, 20);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "nazivet", entity.NazivET);

                    command.ExecuteNonQuery();
                    return ParameterUtil.GetParameterValue(command, "idet_out").ToString();
                }
            }
        }
    }
}
