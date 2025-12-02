using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Int64Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int64Options)])
                .Run<Int64Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int64Options)])
                .Run<Int64Options>(Utils.ToArgs("--ROInt64=99"), (arguments) =>
                {
                    Assert.Equal((long)99, arguments.ROInt64);
                    Assert.Equal((long)0, arguments.OOInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int64Options)])
                .Run<Int64Options>(Utils.ToArgs("--ROInt64=99 --OOInt64=88"), (arguments) =>
                {
                    Assert.Equal((long)99, arguments.ROInt64);
                    Assert.Equal((long)88, arguments.OOInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(Int64Options)])
                .Run<Int64Options>(Utils.ToArgs("--ROInt64=88 --ROInt64=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
