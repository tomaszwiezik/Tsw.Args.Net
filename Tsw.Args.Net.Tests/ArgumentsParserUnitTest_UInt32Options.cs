using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt32Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Options)])
                .Run<UInt32Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Options)])
                .Run<UInt32Options>(Utils.ToArgs("--ROUInt32=99"), (arguments) =>
                {
                    Assert.Equal((uint)99, arguments.ROUInt32);
                    Assert.Equal((uint)0, arguments.OOUInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Options)])
                .Run<UInt32Options>(Utils.ToArgs("--ROUInt32=99 --OOUInt32=88"), (arguments) =>
                {
                    Assert.Equal((uint)99, arguments.ROUInt32);
                    Assert.Equal((uint)88, arguments.OOUInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Options)])
                .Run<UInt32Options>(Utils.ToArgs("--ROUInt32=88 --ROUInt32=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
