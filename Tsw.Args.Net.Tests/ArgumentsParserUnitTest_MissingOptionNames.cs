using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_MissingOptionNames
    {
        [Fact]
        public void TestMissingOptionName()
        {
            var result = Utils.GetParser(types: [typeof(MissingOptionNames)])
                .Run<MissingOptionNames>(Utils.ToArgs("--ROString=required"), (arguments) => 0);

            Assert.Equal(ParseResult.Error, result);
        }
    }
}
