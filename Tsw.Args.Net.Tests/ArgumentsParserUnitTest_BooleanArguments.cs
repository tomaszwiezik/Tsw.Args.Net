using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_BooleanArguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(BooleanArguments)])
                .Run<BooleanArguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(BooleanArguments)])
                .Run<BooleanArguments>(Utils.ToArgs("requiredValue"), (arguments) => 0);

            // Boolean positional arguments are not supported.
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(BooleanArguments)])
                .Run<BooleanArguments>(Utils.ToArgs("requiredValue optionalValue"), (arguments) => 0);

            // Boolean positional arguments are not supported.
            Assert.Equal(ParseResult.Error, result);
        }
    }
}
