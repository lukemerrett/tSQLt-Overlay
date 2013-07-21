using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsible for parsing the outputted result of an executed set of tests into TestResult objects.
    /// </summary>
    public class ResultParser : IResultParser
    {
        /// <summary>
        /// Parses the given tSQLt result string into a collection of TestResult objcts.
        /// </summary>
        /// <param name="result">The result string to parse.</param>
        /// <returns>A collection of TestResult objects.</returns>
        public IEnumerable<TestResult> Parse(string result)
        {
            var testResults = new List<TestResult>();

            var regex = new Regex(@"\|[0-9]*\s*\|(.*?)\|(.*?)\|");

            var matches = regex.Matches(result);

            foreach (Match match in matches)
            {
                var fullTestName = match.Groups[1].Value;
                var success = match.Groups[2].Value;

                var testParts = fullTestName.Split('.');

                testResults.Add(new TestResult
                {
                    Success = success == "Success",
                    Test = new TestRecord
                    {
                        Schema = new TestSchema
                        {
                            Name = testParts[0],
                        },
                        TestName = testParts[1]
                    }
                });
            }

            return testResults;
        }
    }
}
