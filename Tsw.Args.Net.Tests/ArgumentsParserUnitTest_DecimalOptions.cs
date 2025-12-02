using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_DecimalOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(DecimalOptions)])
                .Run<DecimalOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(DecimalOptions)])
                .Run<DecimalOptions>(Utils.ToArgs("--RODecimal=99.99"), (arguments) =>
                {
                    Assert.Equal(99.99M, arguments.RODecimal);
                    Assert.Equal(0, arguments.OODecimal);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(DecimalOptions)])
                .Run<DecimalOptions>(Utils.ToArgs("--RODecimal=99.99 --OODecimal=88.88"), (arguments) =>
                {
                    Assert.Equal(99.99M, arguments.RODecimal);
                    Assert.Equal(88.88M, arguments.OODecimal);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(DecimalOptions)])
                .Run<DecimalOptions>(Utils.ToArgs("--RODecimal=88 --RODecimal=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
