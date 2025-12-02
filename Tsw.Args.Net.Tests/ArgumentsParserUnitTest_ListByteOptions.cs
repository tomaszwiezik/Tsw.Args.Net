using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ListByteOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListByteOptions)])
                .Run<ListByteOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListByteOptions)])
                .Run<ListByteOptions>(Utils.ToArgs("--ROListByte=98 --ROListByte=99"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListByte);
                    Assert.Equal(2, arguments.ROListByte.Count);
                    Assert.Equal((byte)98, arguments.ROListByte[0]);
                    Assert.Equal((byte)99, arguments.ROListByte[1]);

                    Assert.Null(arguments.OOListByte);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ListByteOptions)])
                .Run<ListByteOptions>(Utils.ToArgs("--ROListByte=98 --ROListByte=99 --OOListByte=11 --OOListByte=12 --OOListByte=13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListByte);
                    Assert.Equal(2, arguments.ROListByte.Count);
                    Assert.Equal((byte)98, arguments.ROListByte[0]);
                    Assert.Equal((byte)99, arguments.ROListByte[1]);

                    Assert.NotNull(arguments.OOListByte);
                    Assert.Equal(3, arguments.OOListByte.Count);
                    Assert.Equal((byte)11, arguments.OOListByte[0]);
                    Assert.Equal((byte)12, arguments.OOListByte[1]);
                    Assert.Equal((byte)13, arguments.OOListByte[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptionsWithStandaloneValues()
        {
            var options = new ParserOptions().SetDefaultValues().Merge(new ParserOptions { UseStandaloneValues = true });
            var result = Utils.GetParser(options, types: [typeof(ListByteOptions)])
                .Run<ListByteOptions>(Utils.ToArgs("--ROListByte 98 --ROListByte 99 --OOListByte 11 --OOListByte 12 --OOListByte 13"), (arguments) =>
                {
                    Assert.NotNull(arguments.ROListByte);
                    Assert.Equal(2, arguments.ROListByte.Count);
                    Assert.Equal((byte)98, arguments.ROListByte[0]);
                    Assert.Equal((byte)99, arguments.ROListByte[1]);

                    Assert.NotNull(arguments.OOListByte);
                    Assert.Equal(3, arguments.OOListByte.Count);
                    Assert.Equal((byte)11, arguments.OOListByte[0]);
                    Assert.Equal((byte)12, arguments.OOListByte[1]);
                    Assert.Equal((byte)13, arguments.OOListByte[2]);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

    }
}
