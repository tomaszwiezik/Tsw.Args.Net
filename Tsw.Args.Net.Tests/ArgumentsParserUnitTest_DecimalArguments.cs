using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_DecimalArguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs("1.23"), (arguments) =>
                {
                    Assert.Equal(1.23M, arguments.RADecimal);
                    Assert.Equal(0, arguments.OADecimal);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs("1.23 4.56"), (arguments) =>
                {
                    Assert.Equal(1.23M, arguments.RADecimal);
                    Assert.Equal(4.56M, arguments.OADecimal);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonDecimalValues()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs("a.23"), (arguments) => 0);

            // Incorrect decimal number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestComaSeparatedDecimalValues()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs("1,23"), (arguments) => 0);

            // Coma is not accepted as a decimal point
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinDecimalValues()
        {
            // Default options prefixes are changed to avoid confusion with negative numbers
            var options = new ParserOptions
            {
                OptionPrefix = "//",
                OptionShortcutPrefix = "/"
            };
            var result = Utils.GetParser(options, types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs(decimal.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxDecimalValues()
        {
            var result = Utils.GetParser(types: [typeof(DecimalArguments)])
                .Run<DecimalArguments>(Utils.ToArgs(decimal.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
