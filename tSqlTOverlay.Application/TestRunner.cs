using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    public class TestRunner
    {
        private readonly IScriptBuilder _scriptBuilder;

        public TestRunner(IScriptBuilder scriptBuilder)
        {
            _scriptBuilder = scriptBuilder;
        }

        public TestResult RunAllTests()
        {
            var testScript = _scriptBuilder.BuildExecuteAllTestsScript();

            return new TestResult { Success = true };
        }

        public TestResult RunSingleTest(TestRecord testToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testToRun);

            return new TestResult { Success = true };
        }

        public TestResult RunTestsInSchema(TestSchema testSchemaToRun)
        {
            var testScript = _scriptBuilder.BuildExecuteTestScript(testSchemaToRun);

            return new TestResult { Success = true };
        }
    }
}
