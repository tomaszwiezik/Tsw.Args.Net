using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt64Arguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((ulong)1, arguments.RAUInt64);
                    Assert.Equal((ulong)0, arguments.OAUInt64);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((ulong)1, arguments.RAUInt64);
                    Assert.Equal((ulong)2, arguments.OAUInt64);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonUInt64Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect UInt64 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinUInt64Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs(ulong.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxUInt64Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt64Arguments)])
                .Run<UInt64Arguments>(Utils.ToArgs(ulong.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
