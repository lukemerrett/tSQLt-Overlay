using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsible for building the SQL statement used to run a test / set or tests.
    /// </summary>
    public class ScriptBuilder : IScriptBuilder
    {
        private const string EXEC_TSQLT_RUN = "EXEC tSQLt.Run";

        private const string EXEC_TSQLT_RUNALL = "EXEC tSQLt.RunAll";

        /// <summary>
        /// Returns a SQL statement for running all the tests in a solution.
        /// </summary>
        /// <returns>A SQL statement for running all the tests in a solution.</returns>
        public string BuildExecuteAllTestsScript()
        {
            return EXEC_TSQLT_RUNALL;
        }

        /// <summary>
        /// Returns a SQL statement for running a given test.
        /// </summary>
        /// <param name="testRecord">The test to be run.</param>
        /// <returns>A SQL statement for running a given test.</returns>
        public string BuildExecuteTestScript(TestRecord testRecord)
        {
            return string.Format("{0} '{1}.[{2}]';", EXEC_TSQLT_RUN, testRecord.Schema.Name, testRecord.TestName);
        }

        /// <summary>
        /// Returns a SQL statement for running all tests in a given schema.
        /// </summary>
        /// <param name="testSchema">The schema containing the tests to be run.</param>
        /// <returns>A SQL statement for running all tests in a given schema.</returns>
        public string BuildExecuteTestScript(TestSchema testSchema)
        {
            return string.Format("{0} '{1}';", EXEC_TSQLT_RUN, testSchema.Name);
        }
    }
}
