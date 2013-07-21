using System.Collections.Generic;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    public class TestRunner
    {
        private readonly IConnection _connection;

        private readonly IScriptBuilder _scriptBuilder;

        public TestRunner(IConnection connection, IScriptBuilder scriptBuilder)
        {
            _connection = connection;
            _scriptBuilder = scriptBuilder;
        }

        public IEnumerable<TestResult> RunAllTests()
        {
            var testScript = _scriptBuilder.BuildExecuteAllTestsScript();

            return new List<TestResult>();
        }

        public TestResult RunSingleTest(TestRecord testToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testToRun);

            return new TestResult { Success = true };
        }

        public IEnumerable<TestResult> RunTestsInSchema(TestSchema testSchemaToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testSchemaToRun);

            return new List<TestResult>();
        }
    }
}
