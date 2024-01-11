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

        public bool ExistsById(int id)
        {
            string query = "select * " +
                            "from akcija " +
                            "where ida = :ida";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "ida", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "ida", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Akcija> FindAll()
        {
            string query = "select * " +
                            "from akcija";

            List<Akcija> ret = new List<Akcija>();

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
                            Akcija ak = new Akcija(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

                            ret.Add(ak);
                        }
                    }
                }
            }

            return ret;
        }

        public Akcija FindById(int id)
        {
            string query = "select * " +
                            "from akcija " +
                            "where ida = :ida";

            Akcija ret = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "ida", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "ida", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ret = new Akcija(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        }
                    }
                }
            }

            return ret;
        }

        public string Save(Akcija entity)
        {
            string query = @"insert into Akcija (idk, datumakcije, opisa) " +
                            "values (:idk, :datumakcije, :opisa) " +
                            "returning ida into :ida_out";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);
                    ParameterUtil.AddParameter(command, "datumakcije", DbType.String);
                    ParameterUtil.AddParameter(command, "opisa", DbType.String);
                    ParameterUtil.AddParameter(command, "ida_out", DbType.Int32, ParameterDirection.Output, 20);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", entity.IdK);
                    ParameterUtil.SetParameterValue(command, "datumakcije", entity.DatumAkcije);
                    ParameterUtil.SetParameterValue(command, "opisa", entity.OpisA);

                    command.ExecuteNonQuery();
                    return ParameterUtil.GetParameterValue(command, "ida_out").ToString();
                }
            }
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

        public int CountById(string idK)
        {
            int broj = 0;
            string query = "select count(ida) from akcija where idk =: idk";

            using(IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", idK);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Čitanje rezultata upita
                            broj = reader.GetInt32(0);
                        }
                    }
                }
            }
            return broj;
        }
    }
}
