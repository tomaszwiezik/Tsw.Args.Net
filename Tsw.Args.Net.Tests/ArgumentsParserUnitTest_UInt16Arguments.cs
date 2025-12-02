using System.Globalization;
using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_UInt16Arguments
    {
        [Fact]
        public void TestNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs(""), (arguments) => 0);

            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

        [Fact]
        public void TestRequiredArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs("1"), (arguments) =>
                {
                    Assert.Equal((ushort)1, arguments.RAUInt16);
                    Assert.Equal((ushort)0, arguments.OAUInt16);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestRequiredAndOptionalArguments()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs("1 2"), (arguments) =>
                {
                    Assert.Equal((ushort)1, arguments.RAUInt16);
                    Assert.Equal((ushort)2, arguments.OAUInt16);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestNonUInt16Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs("a"), (arguments) => 0);

            // Incorrect UInt16 number format
            Assert.Equal(ParseResult.Error, result);
        }

        [Fact]
        public void TestMinUInt16Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs(ushort.MinValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMaxUInt16Values()
        {
            var result = Utils.GetParser(types: [typeof(UInt16Arguments)])
                .Run<UInt16Arguments>(Utils.ToArgs(ushort.MaxValue.ToString(CultureInfo.InvariantCulture)), (arguments) => 0);

            Assert.Equal(ParseResult.Success, result);
        }
    }
}
