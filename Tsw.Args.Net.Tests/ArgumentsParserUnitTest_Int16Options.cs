using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Int16Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int16Options)])
                .Run<Int16Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int16Options)])
                .Run<Int16Options>(Utils.ToArgs("--ROInt16=99"), (arguments) =>
                {
                    Assert.Equal((short)99, arguments.ROInt16);
                    Assert.Equal((short)0, arguments.OOInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(Int16Options)])
                .Run<Int16Options>(Utils.ToArgs("--ROInt16=99 --OOInt16=88"), (arguments) =>
                {
                    Assert.Equal((short)99, arguments.ROInt16);
                    Assert.Equal((short)88, arguments.OOInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(Int16Options)])
                .Run<Int16Options>(Utils.ToArgs("--ROInt16=88 --ROInt16=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
