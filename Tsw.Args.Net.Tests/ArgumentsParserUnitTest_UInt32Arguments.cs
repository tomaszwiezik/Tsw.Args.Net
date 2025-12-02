using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt32Arguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((uint)1, arguments.RAUInt32);
                    Assert.Equal((uint)0, arguments.OAUInt32);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((uint)1, arguments.RAUInt32);
                    Assert.Equal((uint)2, arguments.OAUInt32);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonUInt32Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect UInt32 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinUInt32Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs(uint.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxUInt32Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt32Arguments)])
                .Run<UInt32Arguments>(Utils.ToArgs(uint.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
