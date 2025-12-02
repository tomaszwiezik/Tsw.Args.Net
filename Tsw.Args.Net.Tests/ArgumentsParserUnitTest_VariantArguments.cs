using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_VariantArguments
    {
        [Fact]
        public void TestMatchingArguments1()
        {
            var result = Utils.GetParser(types: [typeof(VariantArguments1), typeof(VariantArguments2)])
                .Run(Utils.ToArgs("RAString1"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantArguments1>(arguments);
                    if (arguments is VariantArguments1 selectedArguments)
                    {
                        Assert.Equal("RAString1", selectedArguments.RAString);
                        Assert.Equal("default1", selectedArguments.OAString);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingArguments2()
        {
            var result = Utils.GetParser(types: [typeof(VariantArguments1), typeof(VariantArguments2)])
                .Run(Utils.ToArgs("RAString2 value2"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantArguments2>(arguments);
                    if (arguments is VariantArguments2 selectedArguments)
                    {
                        Assert.Equal("RAString2", selectedArguments.RAString);
                        Assert.Equal("value2", selectedArguments.OAString);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingNoArguments()
        {
            var result = Utils.GetParser(types: [typeof(VariantArguments1), typeof(VariantArguments2)])
                .Run(Utils.ToArgs("unknown"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
