using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_DuplicatedArgumentPositions
    {
        [Fact]
        public void TestArgumentParsing()
        {
            var result = Utils.GetParser(types: [typeof(DuplicatedArgumentPositions)])
                .Run<DuplicatedArgumentPositions>(Utils.ToArgs("1 2"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
