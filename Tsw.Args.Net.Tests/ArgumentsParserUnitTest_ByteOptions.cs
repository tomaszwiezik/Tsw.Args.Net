using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ByteOptions
    {
        [Fact]
        public void TestNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(ByteOptions)])
                .Run<ByteOptions>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredOptions()
        {
            var result = Utils.GetParser(types: [typeof(ByteOptions)])
                .Run<ByteOptions>(Utils.ToArgs("--ROByte=99"), (arguments) =>
                {
                    Assert.Equal((byte)99, arguments.ROByte);
                    Assert.Equal((byte)0, arguments.OOByte);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalOptions()
        {
            var result = Utils.GetParser(types: [typeof(ByteOptions)])
                .Run<ByteOptions>(Utils.ToArgs("--ROByte=99 --OOByte=11"), (arguments) =>
                {
                    Assert.Equal((byte)99, arguments.ROByte);
                    Assert.Equal((byte)11, arguments.OOByte);
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRepeatedOption()
        {
            var result = Utils.GetParser(types: [typeof(ByteOptions)])
                .Run<ByteOptions>(Utils.ToArgs("--ROByte=88 --ROByte=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
