using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Int16Arguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((short)1, arguments.RAInt16);
                    Assert.Equal((short)0, arguments.OAInt16);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((short)1, arguments.RAInt16);
                    Assert.Equal((short)2, arguments.OAInt16);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonInt16Values()
        {
            var result = Utils.GetParser(types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect Int16 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinInt16Values()
        {
            // Default options prefixes are changed to avoid confusion with negative numbers
            var options = new ParserOptions
            {
                OptionPrefix = "//",
                OptionShortcutPrefix = "/"
            };
            var result = Utils.GetParser(options, types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs(short.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxInt16Values()
        {
            var result = Utils.GetParser(types: [typeof(Int16Arguments)])
                .Run<Int16Arguments>(Utils.ToArgs(short.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
