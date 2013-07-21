using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tSqlTOverlay.Application;

namespace tSqlTOverlay.UnitTests.Application
{
    [TestFixture]
    public class ResultParserTests
    {
        private IResultParser _resultParser;

        [SetUp]
        public void TestSetUp()
        {
            _resultParser = new ResultParser();
        }

        [Test]
        public void Parse_GivenBlankInput_ReturnsEmptyCollection()
        {
            var input = string.Empty;

            var resultCollection = _resultParser.Parse(input);

            Assert.IsNotNull(resultCollection);
            Assert.IsFalse(resultCollection.Any());
        }

        [Test]
        public void Parse_GivenInputWithNoTestResults_ReturnsEmptyCollection()
        {
            var input = 
                "Test Case Summary: 11 test case(s) executed, 10 succeeded, 1 failed, 0 errored."+
                "\r\n[AcceleratorTests].[test ready for experimentation if 2 particles] failed: "+
                "(Failure) Expected: <1> but was: <0>\r\n \r\n+----------------------+\r\n"+
                "|Test Execution Summary|\r\n+----------------------+\r\n \r\n|No|Test Case Name"+
                "                                                                               "+
                "             |Result |\r\n+--+-------------------------------------------------"+
                "---------------------------------------------------------+-------+\r\n";

            var resultCollection = _resultParser.Parse(input);

            Assert.IsNotNull(resultCollection);
            Assert.IsFalse(resultCollection.Any());
        }

        [Test]
        public void Parse_GivenInputWithATestResult_ReturnsCorrectTestSchema()
        {
            var input = 
                "|1 |"+
                "[AcceleratorTests]."+
                "[test a particle is included only if it fits inside the boundaries of the rectangle]   "+
                "|Success|";

            var resultCollection = _resultParser.Parse(input);

            var result = resultCollection.Single();

            Assert.AreEqual("[AcceleratorTests]", result.Test.Schema.Name);
        }

        [Test]
        public void Parse_GivenInputWithATestResult_ReturnsCorrectTestName()
        {
            var input =
                "|1 |" +
                "[AcceleratorTests]." +
                "[test a particle is included only if it fits inside the boundaries of the rectangle]   " +
                "|Success|";

            var resultCollection = _resultParser.Parse(input);

            var result = resultCollection.Single();

            Assert.AreEqual(
                "[test a particle is included only if it fits inside the boundaries of the rectangle]", 
                result.Test.TestName);
        }

        [Test]
        public void Parse_GivenInputWithASucceededTestResult_SetsSuccessToTrue()
        {
            var input =
                "|1 |" +
                "[AcceleratorTests]." +
                "[test a particle is included only if it fits inside the boundaries of the rectangle]   " +
                "|Success|";

            var resultCollection = _resultParser.Parse(input);

            var result = resultCollection.Single();

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Parse_GivenInputWithAFailedTestResult_SetsSuccessToFalse()
        {
            var input =
                "|1 |" +
                "[AcceleratorTests]." +
                "[test a particle is included only if it fits inside the boundaries of the rectangle]   " +
                "|Failure|";

            var resultCollection = _resultParser.Parse(input);

            var result = resultCollection.Single();

            Assert.IsFalse(result.Success);
        }
    }
}
