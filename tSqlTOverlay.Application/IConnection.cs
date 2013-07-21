using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsibe for connecting to an SQL Server instance and executing a given command.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Executes the provided script against the database and returns a string containing
        /// the textual output of the script.
        /// </summary>
        /// <param name="script">The script to run.</param>
        /// <returns>The output of the script.</returns>
        string ExecuteScript(string script);
    }
}
