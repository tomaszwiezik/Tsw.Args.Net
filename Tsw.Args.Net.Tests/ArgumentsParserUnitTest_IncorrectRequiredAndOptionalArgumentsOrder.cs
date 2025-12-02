using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_IncorrectRequiredAndOptionalArgumentsOrder
    {
        [Fact]
        public void TestArgumentParsing()
        {
            var result = Utils.GetParser(types: [typeof(IncorrectRequiredAndOptionalArgumentsOrder)])
                .Run<IncorrectRequiredAndOptionalArgumentsOrder>(Utils.ToArgs("1 2 required"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
