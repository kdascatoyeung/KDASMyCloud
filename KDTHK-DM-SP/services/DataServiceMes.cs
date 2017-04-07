using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace KDTHK_DM_SP.services
{
    public class DataServiceMes
    {
        private SqlConnection connection;
        private static DataServiceMes _dataService = null;
        private SqlCommand command;

        private DataServiceMes()
        {
            /*string connectionString = "server=hkbipcsvr;database=MASTERMNG;Integrated Security=SSPI";
            //string connectionString = "server=HSP1DB01\\KM_SQUARE;database=KDTHK_DMV2;user id=general;password=JLgj2007";
            connection = new SqlConnection(connectionString);
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch
            {
                connection.Close();
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }*/
        }

        public static DataServiceMes GetInstance()
        {
            if (_dataService == null)
                _dataService = new DataServiceMes();

            return _dataService;
        }

        public SqlConnection Connection
        {
            get { return connection; }
        }

        public SqlDataReader ExecuteReader(string query)
        {
            command.CommandText = query;
            return command.ExecuteReader();
        }

        public object ExecuteScalar(string query)
        {
            command.CommandText = query;
            return command.ExecuteScalar();
        }

        public SqlCommand CreateCommand(string query)
        {
            return connection.CreateCommand();
        }

        public int ExecuteNonQuery(string commandText)
        {
            return 1; /* Commented by Cato Yeung */
            command.CommandText = commandText;
            return command.ExecuteNonQuery();
        }

        public SqlTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}
