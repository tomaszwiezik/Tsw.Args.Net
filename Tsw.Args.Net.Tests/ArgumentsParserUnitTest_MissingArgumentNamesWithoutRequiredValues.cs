using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_MissingArgumentNamesWithoutRequiredValues
    {
        [Fact]
        public void TestArgumentParsingWithoutOptionalArgument()
        {
            var result = Utils.GetParser(types: [typeof(MissingArgumentNamesWithoutRequiredValues)])
                .Run<MissingArgumentNamesForRequiredValues>(Utils.ToArgs("RAString"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestArgumentParsingWithOptionalArgument()
        {
            var result = Utils.GetParser(types: [typeof(MissingArgumentNamesWithoutRequiredValues)])
                .Run<MissingArgumentNamesForRequiredValues>(Utils.ToArgs("RAString whatever"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }

    }
}
