using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt16Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Options)])
                .Run<UInt16Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Options)])
                .Run<UInt16Options>(Utils.ToArgs("--ROUInt16=99"), (arguments) =>
                {
                    Assert.Equal((ushort)99, arguments.ROUInt16);
                    Assert.Equal((ushort)0, arguments.OOUInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Options)])
                .Run<UInt16Options>(Utils.ToArgs("--ROUInt16=99 --OOUInt16=88"), (arguments) =>
                {
                    Assert.Equal((ushort)99, arguments.ROUInt16);
                    Assert.Equal((ushort)88, arguments.OOUInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Options)])
                .Run<UInt16Options>(Utils.ToArgs("--ROUInt16=88 --ROUInt16=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
