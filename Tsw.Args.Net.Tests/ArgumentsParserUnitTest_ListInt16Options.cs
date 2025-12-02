using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListInt16Options
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt16Options)])
                .Run<ListInt16Options>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt16Options)])
                .Run<ListInt16Options>(Utils.ToArgs("--ROListInt16=98 --ROListInt16=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt16);
                    Assert.Equal(2, arguments.ROListInt16.Count);
                    Assert.Equal((short)98, arguments.ROListInt16[0]);
                    Assert.Equal((short)99, arguments.ROListInt16[1]);

                    Assert.Null(arguments.OOListInt16);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListInt16Options)])
                .Run<ListInt16Options>(Utils.ToArgs("--ROListInt16=98 --ROListInt16=99 --OOListInt16=11 --OOListInt16=12 --OOListInt16=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt16);
                    Assert.Equal(2, arguments.ROListInt16.Count);
                    Assert.Equal((short)98, arguments.ROListInt16[0]);
                    Assert.Equal((short)99, arguments.ROListInt16[1]);

                    Assert.NotNull(arguments.OOListInt16);
                    Assert.Equal(3, arguments.OOListInt16.Count);
                    Assert.Equal((short)11, arguments.OOListInt16[0]);
                    Assert.Equal((short)12, arguments.OOListInt16[1]);
                    Assert.Equal((short)13, arguments.OOListInt16[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListInt16Options)])
                .Run<ListInt16Options>(Utils.ToArgs("--ROListInt16 98 --ROListInt16 99 --OOListInt16 11 --OOListInt16 12 --OOListInt16 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListInt16);
                    Assert.Equal(2, arguments.ROListInt16.Count);
                    Assert.Equal((short)98, arguments.ROListInt16[0]);
                    Assert.Equal((short)99, arguments.ROListInt16[1]);

                    Assert.NotNull(arguments.OOListInt16);
                    Assert.Equal(3, arguments.OOListInt16.Count);
                    Assert.Equal((short)11, arguments.OOListInt16[0]);
                    Assert.Equal((short)12, arguments.OOListInt16[1]);
                    Assert.Equal((short)13, arguments.OOListInt16[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
