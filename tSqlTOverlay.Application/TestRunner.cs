using System.Linq;
using System.Collections.Generic;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsible for co-ordinating the building, execution and result parsing of tests.
    /// </summary>
    public class TestRunner
    {
        private readonly IConnection _connection;

        private readonly IScriptBuilder _scriptBuilder;

        private readonly IResultParser _resultParser;

        public TestRunner(IConnection connection, IScriptBuilder scriptBuilder, IResultParser resultParser)
        {
            _connection = connection;
            _scriptBuilder = scriptBuilder;
            _resultParser = resultParser;
        }

        /// <summary>
        /// Runs all the tSqlt tests residing in a database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestResult> RunAllTests()
        {
            var testScript = _scriptBuilder.BuildExecuteAllTestsScript();

            var output = _connection.ExecuteScript(testScript);

            return _resultParser.Parse(output);
        }

        /// <summary>
        /// Runs a single test residing in a database.
        /// </summary>
        /// <param name="testToRun">Dto containing the details on the test to run.</param>
        /// <returns></returns>
        public TestResult RunSingleTest(TestRecord testToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testToRun);

            var output = _connection.ExecuteScript(testScript);

            return _resultParser.Parse(output).SingleOrDefault();
        }

        /// <summary>
        /// Runs all the tests in a given schema residing in a database.
        /// </summary>
        /// <param name="testSchemaToRun">Dto containing the details on the test schema to run.</param>
        /// <returns></returns>
        public IEnumerable<TestResult> RunTestsInSchema(TestSchema testSchemaToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testSchemaToRun);

            var output = _connection.ExecuteScript(testScript);

            return _resultParser.Parse(output);
        }
    }
}
