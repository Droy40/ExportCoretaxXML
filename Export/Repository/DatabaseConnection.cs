using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Repository
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private readonly string connectionString = "Server=localhost;Database=coretaxexportapp;Uid=root;pwd=;";
        private MySqlConnection _connection;
        private DatabaseConnection()
        {
            _connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                    return _instance;
                }
            }
        }

        public MySqlConnection GetConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
