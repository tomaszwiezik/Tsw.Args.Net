using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Int32Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int32Options)])
                .Run<Int32Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int32Options)])
                .Run<Int32Options>(Utils.ToArgs("--ROInt32=99"), (arguments) =>
                {
                    Assert.Equal((int)99, arguments.ROInt32);
                    Assert.Equal((int)0, arguments.OOInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int32Options)])
                .Run<Int32Options>(Utils.ToArgs("--ROInt32=99 --OOInt32=88"), (arguments) =>
                {
                    Assert.Equal((int)99, arguments.ROInt32);
                    Assert.Equal((int)88, arguments.OOInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(Int32Options)])
                .Run<Int32Options>(Utils.ToArgs("--ROInt32=88 --ROInt32=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
