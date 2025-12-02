using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListInt32Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt32Options)])
                .Run<ListInt32Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt32Options)])
                .Run<ListInt32Options>(Utils.ToArgs("--ROListInt32=98 --ROListInt32=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt32);
                    Assert.Equal(2, arguments.ROListInt32.Count);
                    Assert.Equal((int)98, arguments.ROListInt32[0]);
                    Assert.Equal((int)99, arguments.ROListInt32[1]);

                    Assert.Null(arguments.OOListInt32);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt32Options)])
                .Run<ListInt32Options>(Utils.ToArgs("--ROListInt32=98 --ROListInt32=99 --OOListInt32=11 --OOListInt32=12 --OOListInt32=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt32);
                    Assert.Equal(2, arguments.ROListInt32.Count);
                    Assert.Equal((int)98, arguments.ROListInt32[0]);
                    Assert.Equal((int)99, arguments.ROListInt32[1]);

                    Assert.NotNull(arguments.OOListInt32);
                    Assert.Equal(3, arguments.OOListInt32.Count);
                    Assert.Equal((int)11, arguments.OOListInt32[0]);
                    Assert.Equal((int)12, arguments.OOListInt32[1]);
                    Assert.Equal((int)13, arguments.OOListInt32[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListInt32Options)])
                .Run<ListInt32Options>(Utils.ToArgs("--ROListInt32 98 --ROListInt32 99 --OOListInt32 11 --OOListInt32 12 --OOListInt32 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt32);
                    Assert.Equal(2, arguments.ROListInt32.Count);
                    Assert.Equal((int)98, arguments.ROListInt32[0]);
                    Assert.Equal((int)99, arguments.ROListInt32[1]);

                    Assert.NotNull(arguments.OOListInt32);
                    Assert.Equal(3, arguments.OOListInt32.Count);
                    Assert.Equal((int)11, arguments.OOListInt32[0]);
                    Assert.Equal((int)12, arguments.OOListInt32[1]);
                    Assert.Equal((short)13, arguments.OOListInt32[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
