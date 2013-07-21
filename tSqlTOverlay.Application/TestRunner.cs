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

        public TestRunner(IConnection connection, IScriptBuilder scriptBuilder)
        {
            _connection = connection;
            _scriptBuilder = scriptBuilder;
        }

        /// <summary>
        /// Runs all the tSqlt tests residing in a database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestResult> RunAllTests()
        {
            var testScript = _scriptBuilder.BuildExecuteAllTestsScript();

            return new List<TestResult>();
        }

        /// <summary>
        /// Runs a single test residing in a database.
        /// </summary>
        /// <param name="testToRun">Dto containing the details on the test to run.</param>
        /// <returns></returns>
        public TestResult RunSingleTest(TestRecord testToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testToRun);

            return new TestResult { Success = true };
        }

        /// <summary>
        /// Runs all the tests in a given schema residing in a database.
        /// </summary>
        /// <param name="testSchemaToRun">Dto containing the details on the test schema to run.</param>
        /// <returns></returns>
        public IEnumerable<TestResult> RunTestsInSchema(TestSchema testSchemaToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testSchemaToRun);

            return new List<TestResult>();
        }
    }
}
