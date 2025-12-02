using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_StandaloneValues
    {
        [Fact]
        public void TestArgumentsOnly()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("255 3.14 32000"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestOptionsOnly()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--OOBool --OOByte 255 --OODecimal 3.14 --OOString testString"), (arguments) =>
                {
                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestArgumentsBeforeOptions()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("255 3.14 32000 --OOBool --OOByte 255 --OODecimal 3.14 --OOString testString"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);

                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestArgumentsAfterOptions()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--OOBool --OOByte 255 --OODecimal 3.14 --OOString testString 255 3.14 32000"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);

                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestArgumentsBetweenOptions()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--OOBool --OOByte 255 255 3.14 --OODecimal 3.14 --OOString testString 32000"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);

                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestOptionsBetweenArguments()
        {
            var options = new ParserOptions
            {
                UseStandaloneValues = true,
            };
            var result = Utils.GetParser(options, types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("255 --OOBool --OOByte 255 3.14 --OODecimal 3.14 --OOString testString 32000"), (arguments) =>
                {
                    Assert.Equal((byte)255, arguments.OAByte);
                    Assert.Equal(3.14M, arguments.OADecimal);
                    Assert.Equal((short)32000, arguments.OAInt16);

                    Assert.True(arguments.OOBool);
                    Assert.Equal(3.14M, arguments.OODecimal);
                    Assert.Equal("testString", arguments.OOString);
                    return 0;
                });

            Assert.Equal(ParseResult.Success, result);
        }

    }
}
