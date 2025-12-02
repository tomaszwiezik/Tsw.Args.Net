using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_StringArguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(StringArguments)])
                .Run<StringArguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(StringArguments)])
                .Run<StringArguments>(Utils.ToArgs("required"), (arguments) =>
                {
                    Assert.Equal("required", arguments.RAString);
                    Assert.Equal("default", arguments.OAString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(StringArguments)])
                .Run<StringArguments>(Utils.ToArgs("required optional"), (arguments) =>
                {
                    Assert.Equal("required", arguments.RAString);
                    Assert.Equal("optional", arguments.OAString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

    }
}
