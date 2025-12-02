using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListUInt32Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt32Options)])
                .Run<ListUInt32Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt32Options)])
                .Run<ListUInt32Options>(Utils.ToArgs("--ROListUInt32=98 --ROListUInt32=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt32);
                    Assert.Equal(2, arguments.ROListUInt32.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt32[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt32[1]);

                    Assert.Null(arguments.OOListUInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt32Options)])
                .Run<ListUInt32Options>(Utils.ToArgs("--ROListUInt32=98 --ROListUInt32=99 --OOListUInt32=11 --OOListUInt32=12 --OOListUInt32=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt32);
                    Assert.Equal(2, arguments.ROListUInt32.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt32[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt32[1]);

                    Assert.NotNull(arguments.OOListUInt32);
                    Assert.Equal(3, arguments.OOListUInt32.Count);
                    Assert.Equal((uint)11, arguments.OOListUInt32[0]);
                    Assert.Equal((uint)12, arguments.OOListUInt32[1]);
                    Assert.Equal((uint)13, arguments.OOListUInt32[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListUInt32Options)])
                .Run<ListUInt32Options>(Utils.ToArgs("--ROListUInt32 98 --ROListUInt32 99 --OOListUInt32 11 --OOListUInt32 12 --OOListUInt32 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt32);
                    Assert.Equal(2, arguments.ROListUInt32.Count);
                    Assert.Equal((uint)98, arguments.ROListUInt32[0]);
                    Assert.Equal((uint)99, arguments.ROListUInt32[1]);

                    Assert.NotNull(arguments.OOListUInt32);
                    Assert.Equal(3, arguments.OOListUInt32.Count);
                    Assert.Equal((uint)11, arguments.OOListUInt32[0]);
                    Assert.Equal((uint)12, arguments.OOListUInt32[1]);
                    Assert.Equal((uint)13, arguments.OOListUInt32[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }
    }
}
