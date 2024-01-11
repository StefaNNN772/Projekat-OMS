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

        public bool ExistsById(int id)
        {
            string query = "select * " +
                            "from elektricnielement " +
                            "where idee = :idee";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idee", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idee", id);

                    return command.ExecuteScalar() != null;
                }
            }
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
                            ElektricniElement elektricniElement = new ElektricniElement(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5));

                            elektricniElementList.Add(elektricniElement);
                        }
                    }
                }
            }

            return elektricniElementList;
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
                            ele_element = new ElektricniElement(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5));
                        }
                    }
                }
            }

            return ele_element;
        }

        public ElektricniElement FindById(int id, IDbConnection connection)
        {
            string query = "select * " +
                            "from elektricnielement " +
                            "where idee = :idee";

            ElektricniElement ele_element = null;

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
                        ele_element = new ElektricniElement(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5));
                    }
                }
            }

            return ele_element;
        }

        public bool FindByIdBool(int id)
        {
            string query = "select * " +
                            "from elektricnielement " +
                            "where idee = :idee";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idee", DbType.Int32);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idee", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public string Save(ElektricniElement entity)
        {
            string query = "insert into ElektricniElement (nazivee, tipee, x, y, naponskinivoee) " +
                            "values (:nazivee, :tipee, :x, :y, :naponskinivoee) ";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "nazivee", DbType.String);
                    ParameterUtil.AddParameter(command, "tipee", DbType.Int32);
                    ParameterUtil.AddParameter(command, "x", DbType.Int32);
                    ParameterUtil.AddParameter(command, "y", DbType.Int32);
                    ParameterUtil.AddParameter(command, "naponskinivoee", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "nazivee", entity.NazivEE);
                    ParameterUtil.SetParameterValue(command, "tipee", entity.TipEE);
                    ParameterUtil.SetParameterValue(command, "x", entity.X);
                    ParameterUtil.SetParameterValue(command, "y", entity.Y);
                    ParameterUtil.SetParameterValue(command, "naponskinivoee", entity.NaponskiNivoEE);


                    command.ExecuteNonQuery();
                    return "";
                }
            }
        }
    }
}
