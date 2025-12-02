using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListStringOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListStringOptions)])
                .Run<ListStringOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListStringOptions)])
                .Run<ListStringOptions>(Utils.ToArgs("--ROListString=--text1 --ROListString=--text2"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListString);
                    Assert.Equal(2, arguments.ROListString.Count);
                    Assert.Equal("--text1", arguments.ROListString[0]);
                    Assert.Equal("--text2", arguments.ROListString[1]);

                    Assert.Null(arguments.OOListString);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListStringOptions)])
                .Run<ListStringOptions>(Utils.ToArgs("--ROListString=--text1 --ROListString=--text2 --OOListString=name1 --OOListString=name2 --OOListString=name3"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListString);
                    Assert.Equal(2, arguments.ROListString.Count);
                    Assert.Equal("--text1", arguments.ROListString[0]);
                    Assert.Equal("--text2", arguments.ROListString[1]);

                    Assert.NotNull(arguments.OOListString);
                    Assert.Equal(3, arguments.OOListString.Count);
                    Assert.Equal("name1", arguments.OOListString[0]);
                    Assert.Equal("name2", arguments.OOListString[1]);
                    Assert.Equal("name3", arguments.OOListString[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListStringOptions)])
                .Run<ListStringOptions>(Utils.ToArgs("--ROListString --text1 --ROListString --text2 --OOListString name1 --OOListString name2 --OOListString name3"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListString);
                    Assert.Equal(2, arguments.ROListString.Count);
                    Assert.Equal("--text1", arguments.ROListString[0]);
                    Assert.Equal("--text2", arguments.ROListString[1]);

                    Assert.NotNull(arguments.OOListString);
                    Assert.Equal(3, arguments.OOListString.Count);
                    Assert.Equal("name1", arguments.OOListString[0]);
                    Assert.Equal("name2", arguments.OOListString[1]);
                    Assert.Equal("name3", arguments.OOListString[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
