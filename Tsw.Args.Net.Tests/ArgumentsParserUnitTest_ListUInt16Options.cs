using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListUInt16Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt16Options)])
                .Run<ListUInt16Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt16Options)])
                .Run<ListUInt16Options>(Utils.ToArgs("--ROListUInt16=98 --ROListUInt16=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt16);
                    Assert.Equal(2, arguments.ROListUInt16.Count);
                    Assert.Equal((ushort)98, arguments.ROListUInt16[0]);
                    Assert.Equal((ushort)99, arguments.ROListUInt16[1]);

                    Assert.Null(arguments.OOListUInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListUInt16Options)])
                .Run<ListUInt16Options>(Utils.ToArgs("--ROListUInt16=98 --ROListUInt16=99 --OOListUInt16=11 --OOListUInt16=12 --OOListUInt16=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt16);
                    Assert.Equal(2, arguments.ROListUInt16.Count);
                    Assert.Equal((ushort)98, arguments.ROListUInt16[0]);
                    Assert.Equal((ushort)99, arguments.ROListUInt16[1]);

                    Assert.NotNull(arguments.OOListUInt16);
                    Assert.Equal(3, arguments.OOListUInt16.Count);
                    Assert.Equal((ushort)11, arguments.OOListUInt16[0]);
                    Assert.Equal((ushort)12, arguments.OOListUInt16[1]);
                    Assert.Equal((ushort)13, arguments.OOListUInt16[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListUInt16Options)])
                .Run<ListUInt16Options>(Utils.ToArgs("--ROListUInt16 98 --ROListUInt16 99 --OOListUInt16 11 --OOListUInt16 12 --OOListUInt16 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListUInt16);
                    Assert.Equal(2, arguments.ROListUInt16.Count);
                    Assert.Equal((ushort)98, arguments.ROListUInt16[0]);
                    Assert.Equal((ushort)99, arguments.ROListUInt16[1]);

                    Assert.NotNull(arguments.OOListUInt16);
                    Assert.Equal(3, arguments.OOListUInt16.Count);
                    Assert.Equal((ushort)11, arguments.OOListUInt16[0]);
                    Assert.Equal((ushort)12, arguments.OOListUInt16[1]);
                    Assert.Equal((ushort)13, arguments.OOListUInt16[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
