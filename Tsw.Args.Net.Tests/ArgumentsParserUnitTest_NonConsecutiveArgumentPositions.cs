using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_NonConsecutiveArgumentPositions
    {
        [Fact]
        public void TestArgumentParsing()
        {
            var result = Utils.GetParser(types: [typeof(NonConsecutiveArgumentPositions)])
                .Run<NonConsecutiveArgumentPositions>(Utils.ToArgs("required optional"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
