using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace KDTHK_DM_SP.services
{
    public class LocalDataService
    {
        private SqlCeConnection connection;
        private static LocalDataService _dataService = null;
        private SqlCeCommand command;

        private LocalDataService()
        {
            string connectionString = "Data Source=" + Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "LocalDb.sdf");
            //string connectionString = "Data Source=" + GlobalService.UserAppDataFolder;

            //MessageBox.Show(connectionString);

            connection = new SqlCeConnection(connectionString);
            connection.Open();
            command = new SqlCeCommand();
            command.Connection = connection;
        }

        public static LocalDataService GetInstance()
        {
            if (_dataService == null)
                _dataService = new LocalDataService();

            return _dataService;
        }

        public SqlCeConnection Connection
        {
            get { return connection; }
        }

        public SqlCeDataReader ExecuteReader(string query)
        {
            command.CommandText = query;
            return command.ExecuteReader();
        }

        public object ExecuteScalar(string query)
        {
            command.CommandText = query;
            return command.ExecuteScalar();
        }

        public SqlCeCommand CreateCommand(string query)
        {
            return connection.CreateCommand();
        }

        public int ExecuteNonQuery(string commandText)
        {
            command.CommandText = commandText;
            return command.ExecuteNonQuery();
        }

        public SqlCeTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}
