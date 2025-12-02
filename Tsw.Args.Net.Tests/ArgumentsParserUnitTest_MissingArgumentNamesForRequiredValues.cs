using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_MissingArgumentNamesForRequiredValues
    {
        [Fact]
        public void TestArgumentParsingWithoutOptionalArgument()
        {
            var result = Utils.GetParser(types: [typeof(MissingArgumentNamesForRequiredValues)])
                .Run<MissingArgumentNamesForRequiredValues>(Utils.ToArgs("RAString"), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestArgumentParsingWithOptionalArgument()
        {
            var result = Utils.GetParser(types: [typeof(MissingArgumentNamesForRequiredValues)])
                .Run<MissingArgumentNamesForRequiredValues>(Utils.ToArgs("RAString whatever"), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

    }

}
