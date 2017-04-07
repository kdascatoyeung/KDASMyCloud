using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace KDTHK_DM_SP.services
{
    public class DataServiceMaster
    {
        private SqlConnection connection;
        private static DataServiceMaster _dataService = null;
        private SqlCommand command;

        private DataServiceMaster()
        {
            string connectionString = "server=KDTHK-INTDB\\KDTHK_DB;database=KDTHK_DB_MASTER;user id=sa;password=Aa123456";
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
            }
        }

        public static DataServiceMaster GetInstance()
        {
            if (_dataService == null)
                _dataService = new DataServiceMaster();

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
            command.CommandText = commandText;
            return command.ExecuteNonQuery();
        }

        public SqlTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}
