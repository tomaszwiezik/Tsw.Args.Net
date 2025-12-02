using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_AmbiguousOptionNames
    {
        [Fact]
        public void TestArgumentParsing()
        {
            var result = Utils.GetParser(types: [typeof(AmbiguousOptionNames)])
                .Run<AmbiguousOptionNames>(Utils.ToArgs("--ROByte=1"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
