using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_MissingArgumentPositions
    {
        [Fact]
        public void TestArgumentParsing()
        {
            var result = Utils.GetParser(types: [typeof(MissingArgumentPositions)])
                .Run<MissingArgumentPositions>(Utils.ToArgs("required optional"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
