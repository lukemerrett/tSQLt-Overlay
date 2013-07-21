using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application;

namespace tSqlTOverlay.Console
{
    public class Program
    {
        private const string CONNECTION_STRING_KEY = "DefaultConnectionString";

        public static void Main(string[] args)
        {
            RunAllTests();
        }

        private static void RunAllTests()
        {
            System.Console.WriteLine("Running all tests in the database\n");

            var testRunner = GetTestRunner();

            var testResults = testRunner.RunAllTests();

            foreach (var result in testResults)
            {
                var message = string.Format(
                    "{0}.{1} : {2}",
                    result.Test.Schema.Name,
                    result.Test.TestName,
                    result.Success ? "Success" : "Failed");

                System.Console.WriteLine(message);
            }

            System.Console.ReadLine();
        }

        private static TestRunner GetTestRunner()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString;

            var connection = new Connection(connectionString);

            var scriptBuilder = new ScriptBuilder();

            var resultParser = new ResultParser();

            return new TestRunner(connection, scriptBuilder, resultParser);
        }
    }
}
