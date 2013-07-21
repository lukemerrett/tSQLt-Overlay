using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application;
using tSqlTOverlay.Application.Models;

namespace tSqlTOverlay.UnitTests.Application
{
    [TestFixture]
    public class ScriptBuilderTests
    {
        private IScriptBuilder _scriptBuilder;

        [SetUp]
        public void TestSetUp()
        {
            _scriptBuilder = new ScriptBuilder();
        }

        [Test]
        public void BuildExecuteAllTestsScript_MethodRun_ReturnsScriptToRunAllTests()
        {
            const string expectedValue = "EXEC tSQLt.RunAll";

            var actualValue = _scriptBuilder.BuildExecuteAllTestsScript();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void BuildExecuteTestScript_ProvidedTestRecord_ReturnsScriptToRunSingleTest()
        {
            const string expectedValue = "EXEC tSQLt.Run '[testSchema].[test record exists]';";

            var testRecord = new TestRecord
            {
                Schema = new TestSchema
                {
                    Name = "testSchema"
                },
                TestName = "test record exists"
            };

            var actualValue = _scriptBuilder.BuildExecuteTestScript(testRecord);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void BuildExecuteTestScript_ProvidedTestSchema_ReturnsScriptToRunAllTestsInThatSchema()
        {
            const string expectedValue = "EXEC tSQLt.Run '[testSchema]';";

            var testSchema = new TestSchema
            {
                Name = "testSchema"
            };

            var actualValue = _scriptBuilder.BuildExecuteTestScript(testSchema);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
