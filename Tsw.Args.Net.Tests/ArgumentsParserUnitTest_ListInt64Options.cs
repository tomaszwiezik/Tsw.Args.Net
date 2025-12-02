using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListInt64Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt64Options)])
                .Run<ListInt64Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt64Options)])
                .Run<ListInt64Options>(Utils.ToArgs("--ROListInt64=98 --ROListInt64=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt64);
                    Assert.Equal(2, arguments.ROListInt64.Count);
                    Assert.Equal((long)98, arguments.ROListInt64[0]);
                    Assert.Equal((long)99, arguments.ROListInt64[1]);

                    Assert.Null(arguments.OOListInt64);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt64Options)])
                .Run<ListInt64Options>(Utils.ToArgs("--ROListInt64=98 --ROListInt64=99 --OOListInt64=11 --OOListInt64=12 --OOListInt64=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt64);
                    Assert.Equal(2, arguments.ROListInt64.Count);
                    Assert.Equal((long)98, arguments.ROListInt64[0]);
                    Assert.Equal((long)99, arguments.ROListInt64[1]);

                    Assert.NotNull(arguments.OOListInt64);
                    Assert.Equal(3, arguments.OOListInt64.Count);
                    Assert.Equal((long)11, arguments.OOListInt64[0]);
                    Assert.Equal((long)12, arguments.OOListInt64[1]);
                    Assert.Equal((long)13, arguments.OOListInt64[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListInt64Options)])
                .Run<ListInt64Options>(Utils.ToArgs("--ROListInt64 98 --ROListInt64 99 --OOListInt64 11 --OOListInt64 12 --OOListInt64 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt64);
                    Assert.Equal(2, arguments.ROListInt64.Count);
                    Assert.Equal((long)98, arguments.ROListInt64[0]);
                    Assert.Equal((long)99, arguments.ROListInt64[1]);

                    Assert.NotNull(arguments.OOListInt64);
                    Assert.Equal(3, arguments.OOListInt64.Count);
                    Assert.Equal((long)11, arguments.OOListInt64[0]);
                    Assert.Equal((long)12, arguments.OOListInt64[1]);
                    Assert.Equal((long)13, arguments.OOListInt64[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
