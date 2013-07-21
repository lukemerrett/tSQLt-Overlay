using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsible for parsing the outputted result of an executed set of tests into TestResult objects.
    /// </summary>
    public interface IResultParser
    {
        /// <summary>
        /// Parses the given tSQLt result string into a collection of TestResult objcts.
        /// </summary>
        /// <param name="result">The result string to parse.</param>
        /// <returns>A collection of TestResult objects.</returns>
        IEnumerable<TestResult> Parse(string result);
    }
}
