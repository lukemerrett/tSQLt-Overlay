using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.Application
{
    /// <summary>
    /// Responsible for building the SQL statement used to run a test / set or tests.
    /// </summary>
    public interface IScriptBuilder
    {
        /// <summary>
        /// Returns a SQL statement for running all the tests in a solution.
        /// </summary>
        /// <returns>A SQL statement for running all the tests in a solution.</returns>
        string BuildExecuteAllTestsScript();

        /// <summary>
        /// Returns a SQL statement for running a given test.
        /// </summary>
        /// <param name="testRecord">The test to be run.</param>
        /// <returns>A SQL statement for running a given test.</returns>
        string BuildExecuteTestScript(TestRecord testRecord);

        /// <summary>
        /// Returns a SQL statement for running all tests in a given schema.
        /// </summary>
        /// <param name="testSchema">The schema containing the tests to be run.</param>
        /// <returns>A SQL statement for running all tests in a given schema.</returns>
        string BuildExecuteTestScript(TestSchema testSchema);
    }
}
