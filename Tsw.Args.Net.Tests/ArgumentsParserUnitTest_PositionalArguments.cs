using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_PositionalArguments
    {
        [Fact]
        public void TestTooManyPositionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(PositionalArguments)])
                .Run<PositionalArguments>(Utils.ToArgs("test 1 2 3"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestInsufficientPositionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(PositionalArguments)])
                .Run<PositionalArguments>(Utils.ToArgs("test"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestUnsupportedCommandInPositionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(PositionalArguments)])
                .Run<PositionalArguments>(Utils.ToArgs("unsupportedCommand 1 2"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
