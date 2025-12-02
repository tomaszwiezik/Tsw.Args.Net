using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_BooleanOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(BooleanOptions)])
                .Run<BooleanOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(BooleanOptions)])
                .Run<BooleanOptions>(Utils.ToArgs("--ROBool"), (arguments) =>
                {
                    Assert.True(arguments.ROBool);
                    Assert.False(arguments.OOBool);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(BooleanOptions)])
                .Run<BooleanOptions>(Utils.ToArgs("--ROBool --OOBool"), (arguments) =>
                {
                    Assert.True(arguments.ROBool);
                    Assert.True(arguments.OOBool);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(BooleanOptions)])
                .Run<BooleanOptions>(Utils.ToArgs("--ROBool --ROBool"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
