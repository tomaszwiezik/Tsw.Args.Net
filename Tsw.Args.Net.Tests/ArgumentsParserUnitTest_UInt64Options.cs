using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt64Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Options)])
                .Run<UInt64Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Options)])
                .Run<UInt64Options>(Utils.ToArgs("--ROUInt64=99"), (arguments) =>
                {
                    Assert.Equal((ulong)99, arguments.ROUInt64);
                    Assert.Equal((ulong)0, arguments.OOUInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Options)])
                .Run<UInt64Options>(Utils.ToArgs("--ROUInt64=99 --OOUInt64=88"), (arguments) =>
                {
                    Assert.Equal((ulong)99, arguments.ROUInt64);
                    Assert.Equal((ulong)88, arguments.OOUInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Options)])
                .Run<UInt64Options>(Utils.ToArgs("--ROUInt64=88 --ROUInt64=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
