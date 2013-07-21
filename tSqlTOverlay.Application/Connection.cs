using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsibe for connecting to an SQL Server instance and executing a given command.
    /// </summary>
    public class Connection : IConnection
    {
        private string _connectionString;

        private string _scriptOutput;

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Executes the provided script against the database and returns a string containing
        /// the textual output of the script.
        /// </summary>
        /// <param name="script">The script to run.</param>
        /// <returns>The output of the script.</returns>
        public string ExecuteScript(string script)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                _scriptOutput = string.Empty;

                sqlConnection.InfoMessage += sqlConnection_InfoMessage;

                using (var sqlCommand = new SqlCommand(script))
                {
                    sqlCommand.ExecuteNonQuery();
                }

                return _scriptOutput;
            }
        }

        private void sqlConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            _scriptOutput += e.Message;
        }
    }
}
