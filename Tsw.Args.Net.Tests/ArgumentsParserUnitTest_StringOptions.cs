using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_StringOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(StringOptions)])
                .Run<StringOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(StringOptions)])
                .Run<StringOptions>(Utils.ToArgs("--ROString=required"), (arguments) =>
                {
                    Assert.Equal("required", arguments.ROString);
                    Assert.Equal("default", arguments.OOString);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(StringOptions)])
                .Run<StringOptions>(Utils.ToArgs("--ROString=required --OOString=optional"), (arguments) =>
                {
                    Assert.Equal("required", arguments.ROString);
                    Assert.Equal("optional", arguments.OOString);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(StringOptions)])
                .Run<StringOptions>(Utils.ToArgs("--ROString=88 --ROString=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
