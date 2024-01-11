using OfficeOpenXml;
using Oracle.ManagedDataAccess.Client;
using Projekat_OMS.Connection;
using Projekat_OMS.Services;
using Projekat_OMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_OMS.DAO.Implementation
{
    class KvarDAO : IKvarDAO
    {
        private static readonly IElektricniElementDAO elektricniElementDAO = new ElektricniElementDAO();

        public void Dokument(string idk)
        {
            string query = @"select k.idk as IDKvar, e.nazivee as NazivElektricnogElementa, e.naponskinivoee as NaponskiNivoElektricnogElementa, a.opisa as OpisAkcije " +
                            "from kvar k inner join elektricnielement e on e.idee = k.ele_element left outer join akcija a on a.idk = k.idk " +
                            "where k.idk = :idk";

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Kvarovi.xlsx");

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", idk);

                    using (OracleDataAdapter adapter = new OracleDataAdapter((OracleCommand)command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Kvarovi");

                            worksheet.Cells["A1"].Value = "ID Kvara";
                            worksheet.Cells["B1"].Value = "Naziv EE";
                            worksheet.Cells["C1"].Value = "Naponski Nivo";
                            worksheet.Cells["D1"].Value = "Spisak akcija";

                            int row = 2;

                            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                            {
                                worksheet.Cells[row, 1].Value = dataRow["IDKvar"];
                                worksheet.Cells[row, 2].Value = dataRow["NazivElektricnogElementa"];
                                worksheet.Cells[row, 3].Value = dataRow["NaponskiNivoElektricnogElementa"];
                                worksheet.Cells[row, 4].Value = dataRow["OpisAkcije"];

                                row++;
                            }

                            package.SaveAs(new FileInfo(filePath));
                        }

                        Console.WriteLine("Excel dokument kreiran!");
                    }
                }
            }
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
            string query = "select * " +
                            "from kvar";

            List<Kvar> ret = new List<Kvar>();

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
                            Kvar kv = new Kvar(reader.GetString(0), DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), reader.GetString(2), reader.GetString(3), elektricniElementDAO.FindById(reader.GetInt32(4), connection), reader.GetString(5));

                            ret.Add(kv);
                        }
                    }
                }
            }

            return ret;
        }

        public Kvar FindById(string id)
        {
            string query = "select * " +
                            "from kvar " +
                            "where idk = :idk";

            Kvar ret = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "idk", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idk", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ret = new Kvar(reader.GetString(0), DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), reader.GetString(2), reader.GetString(3), elektricniElementDAO.FindById(reader.GetInt32(4), connection), reader.GetString(5));
                        }
                    }
                }
            }

            return ret;
        }

        public string Save(Kvar entity)
        {
            string query = @"insert into Kvar (statusk, kratakopis, ele_element, opisproblema) " +
                            "values (:statusk, :kratakopis, :ele_element, :opisproblema) " +
                            "returning idk into :idk_out";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "statusk", DbType.String);
                    ParameterUtil.AddParameter(command, "kratakopis", DbType.String);
                    ParameterUtil.AddParameter(command, "ele_element", DbType.Int32);
                    ParameterUtil.AddParameter(command, "opisproblema", DbType.String);
                    ParameterUtil.AddParameter(command, "idk_out", DbType.String, ParameterDirection.Output, 20);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "statusk", entity.StatusK);
                    ParameterUtil.SetParameterValue(command, "kratakopis", entity.KratakOpis);
                    ParameterUtil.SetParameterValue(command, "ele_element", entity.Ele_Element.IdEE);
                    ParameterUtil.SetParameterValue(command, "opisproblema", entity.OpisProblema);

                    command.ExecuteNonQuery();
                    return ParameterUtil.GetParameterValue(command, "idk_out").ToString();
                }
            }
        }

        public List<Kvar> SearchByDate(DateTime ulaz, DateTime izlaz)
        {
            string query = "select * " +
                            "from kvar " +
                            "where vrijemekreiranja BETWEEN :ulaz and :izlaz";

            List<Kvar> ret = new List<Kvar>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "ulaz", DbType.String);
                    ParameterUtil.AddParameter(command, "izlaz", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "ulaz", ulaz.ToString("yyyy-MM-dd"));
                    ParameterUtil.SetParameterValue(command, "izlaz", izlaz.ToString("yyyy-MM-dd"));

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kvar kv = new Kvar(reader.GetString(0),DateTime.ParseExact(reader.GetString(1), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), reader.GetString(2), reader.GetString(3), elektricniElementDAO.FindById(reader.GetInt32(4), connection), reader.GetString(5));

                            ret.Add(kv);
                        }
                    }
                }
            }

            return ret;
        }

        public bool UpdateSave(string idk, string status, string kratakOpis, string opisProblema, int idElektricnogElementa)
        {
            string query = "update kvar " +
                            "set statusk = :statusk, kratakopis = :kratakopis, opisproblema = :opisproblema, ele_element = :ele_element " +
                            "where idk = :idk";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "statusk", DbType.String);
                    ParameterUtil.AddParameter(command, "kratakopis", DbType.String);
                    ParameterUtil.AddParameter(command, "opisproblema", DbType.String);
                    ParameterUtil.AddParameter(command, "ele_element", DbType.Int32);
                    ParameterUtil.AddParameter(command, "idk", DbType.String);

                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "statusk", status);
                    ParameterUtil.SetParameterValue(command, "kratakopis", kratakOpis);
                    ParameterUtil.SetParameterValue(command, "opisproblema", opisProblema);
                    ParameterUtil.SetParameterValue(command, "ele_element", idElektricnogElementa);
                    ParameterUtil.SetParameterValue(command, "idk", idk);

                    return command.ExecuteScalar() != null;
                }
            }
        }
    }
}
