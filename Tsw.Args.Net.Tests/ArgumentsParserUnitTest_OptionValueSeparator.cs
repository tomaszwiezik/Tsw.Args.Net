using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_OptionValueSeparator
    {
        [Fact]
        public void TestArgumentsBeforeOptions()
        {
            var options = new ParserOptions
            {
                OptionValueSeparator = ':'
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("255 3.14 32000 -b --OOByte:255 -d:3.14 -s:testString"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);

                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
