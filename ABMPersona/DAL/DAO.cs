using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    internal class DAO
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-BEA1EQV\\SQLEXPRESS;Initial Catalog=BDPersona;Integrated Security=True");

        public static DataSet ExecuteDataSet(string sql)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static int ObtenerSiguienteId(string tabla)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT ISNULL(MAX({tabla}_Id),0) FROM {tabla}", connection);
                connection.Open();
                return int.Parse(command.ExecuteScalar().ToString()) + 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
    }
}
