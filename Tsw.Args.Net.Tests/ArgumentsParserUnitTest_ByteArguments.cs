using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_ByteArguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((byte)1, arguments.RAByte);
                    Assert.Equal((byte)0, arguments.OAByte);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((byte)1, arguments.RAByte);
                    Assert.Equal((byte)2, arguments.OAByte);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonByteValues()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect Int32 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinByteValues()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs("0"), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxByteValues()
        {
            var result = Utils.GetParser(types: [typeof(ByteArguments)])
                .Run<ByteArguments>(Utils.ToArgs("255"), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
