using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListDecimalOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListDecimalOptions)])
                .Run<ListDecimalOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListDecimalOptions)])
                .Run<ListDecimalOptions>(Utils.ToArgs("--ROListDecimal=98.1 --ROListDecimal=99.1"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListDecimal);
                    Assert.Equal(2, arguments.ROListDecimal.Count);
                    Assert.Equal(98.1M, arguments.ROListDecimal[0]);
                    Assert.Equal(99.1M, arguments.ROListDecimal[1]);

                    Assert.Null(arguments.OOListDecimal);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListDecimalOptions)])
                .Run<ListDecimalOptions>(Utils.ToArgs("--ROListDecimal=98.1 --ROListDecimal=99.1 --OOListDecimal=11.2 --OOListDecimal=12.2 --OOListDecimal=13.2"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListDecimal);
                    Assert.Equal(2, arguments.ROListDecimal.Count);
                    Assert.Equal(98.1M, arguments.ROListDecimal[0]);
                    Assert.Equal(99.1M, arguments.ROListDecimal[1]);

                    Assert.NotNull(arguments.OOListDecimal);
                    Assert.Equal(3, arguments.OOListDecimal.Count);
                    Assert.Equal(11.2M, arguments.OOListDecimal[0]);
                    Assert.Equal(12.2M, arguments.OOListDecimal[1]);
                    Assert.Equal(13.2M, arguments.OOListDecimal[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListDecimalOptions)])
                .Run<ListDecimalOptions>(Utils.ToArgs("--ROListDecimal 98.1 --ROListDecimal 99.1 --OOListDecimal 11.2 --OOListDecimal 12.2 --OOListDecimal 13.2"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListDecimal);
                    Assert.Equal(2, arguments.ROListDecimal.Count);
                    Assert.Equal(98.1M, arguments.ROListDecimal[0]);
                    Assert.Equal(99.1M, arguments.ROListDecimal[1]);

                    Assert.NotNull(arguments.OOListDecimal);
                    Assert.Equal(3, arguments.OOListDecimal.Count);
                    Assert.Equal(11.2M, arguments.OOListDecimal[0]);
                    Assert.Equal(12.2M, arguments.OOListDecimal[1]);
                    Assert.Equal(13.2M, arguments.OOListDecimal[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }
    }
}
