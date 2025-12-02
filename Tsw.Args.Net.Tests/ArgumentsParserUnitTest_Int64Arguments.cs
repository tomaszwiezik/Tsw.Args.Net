using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Int64Arguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((short)1, arguments.RAInt64);
                    Assert.Equal((short)0, arguments.OAInt64);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((short)1, arguments.RAInt64);
                    Assert.Equal((short)2, arguments.OAInt64);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonInt64Values()
        {
            var result = Utils.GetParser(types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect Int32 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinInt64Values()
        {
            // Default options prefixes are changed to avoid confusion with negative numbers
            var options = new ParserOptions
            {
                OptionPrefix = "//",
                OptionShortcutPrefix = "/"
            };
            var result = Utils.GetParser(options, types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs(long.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxInt64Values()
        {
            var result = Utils.GetParser(types: [typeof(Int64Arguments)])
                .Run<Int64Arguments>(Utils.ToArgs(long.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
