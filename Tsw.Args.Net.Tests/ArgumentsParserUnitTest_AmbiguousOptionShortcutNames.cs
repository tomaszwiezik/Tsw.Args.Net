using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_AmbiguousOptionShortcutNames
    {
        [Fact]
        public void TestArgumentNames()
        {
            var result = Utils.GetParser(types: [typeof(AmbiguousOptionShortcutNames)])
                .Run<AmbiguousOptionShortcutNames>(Utils.ToArgs("--ROByte=1"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestArgumentShortcutNames()
        {
            var result = Utils.GetParser(types: [typeof(AmbiguousOptionShortcutNames)])
                .Run<AmbiguousOptionShortcutNames>(Utils.ToArgs("-b=1"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
