using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListUInt64Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt64Options)])
                .Run<ListUInt64Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt64Options)])
                .Run<ListUInt64Options>(Utils.ToArgs("--ROListUInt64=98 --ROListUInt64=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt64);
                    Assert.Equal(2, arguments.ROListUInt64.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt64[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt64[1]);

                    Assert.Null(arguments.OOListUInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt64Options)])
                .Run<ListUInt64Options>(Utils.ToArgs("--ROListUInt64=98 --ROListUInt64=99 --OOListUInt64=11 --OOListUInt64=12 --OOListUInt64=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt64);
                    Assert.Equal(2, arguments.ROListUInt64.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt64[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt64[1]);

                    Assert.NotNull(arguments.OOListUInt64);
                    Assert.Equal(3, arguments.OOListUInt64.Count);
                    Assert.Equal((uint)11, arguments.OOListUInt64[0]);
                    Assert.Equal((uint)12, arguments.OOListUInt64[1]);
                    Assert.Equal((uint)13, arguments.OOListUInt64[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListUInt64Options)])
                .Run<ListUInt64Options>(Utils.ToArgs("--ROListUInt64 98 --ROListUInt64 99 --OOListUInt64 11 --OOListUInt64 12 --OOListUInt64 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt64);
                    Assert.Equal(2, arguments.ROListUInt64.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt64[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt64[1]);

                    Assert.NotNull(arguments.OOListUInt64);
                    Assert.Equal(3, arguments.OOListUInt64.Count);
                    Assert.Equal((uint)11, arguments.OOListUInt64[0]);
                    Assert.Equal((uint)12, arguments.OOListUInt64[1]);
                    Assert.Equal((uint)13, arguments.OOListUInt64[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
