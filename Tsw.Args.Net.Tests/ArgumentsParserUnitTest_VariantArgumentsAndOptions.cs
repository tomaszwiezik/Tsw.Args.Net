using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_VariantArgumentsAndOptions
    {
        [Fact]
        public void TestMatchingArgumentsAndOptions1()
        {
            var result = Utils.GetParser(types: [typeof(VariantArgumentsAndOptions1), typeof(VariantArgumentsAndOptions2)])
                .Run(Utils.ToArgs("RAString1 --ROInt32=99"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantArgumentsAndOptions1>(arguments);
                    if (arguments is VariantArgumentsAndOptions1 selectedArguments)
                    {
                        Assert.Equal("RAString1", selectedArguments.RAString);
                        Assert.Equal("default1", selectedArguments.OAString);
                        Assert.Equal(99, selectedArguments.ROInt32);
                        Assert.Null(selectedArguments.OOInt32);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingArgumentsAndOptions2()
        {
            var result = Utils.GetParser(types: [typeof(VariantArgumentsAndOptions1), typeof(VariantArgumentsAndOptions2)])
                .Run(Utils.ToArgs("RAString2 value2 --ROInt32=99 --OOInt32=100"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantArgumentsAndOptions2>(arguments);
                    if (arguments is VariantArgumentsAndOptions2 selectedArguments)
                    {
                        Assert.Equal("RAString2", selectedArguments.RAString);
                        Assert.Equal("value2", selectedArguments.OAString);
                        Assert.Equal(99, selectedArguments.ROInt32);
                        Assert.Equal(100, selectedArguments.OOInt32);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingNoArgumentsAndOptions()
        {
            var result = Utils.GetParser(types: [typeof(VariantArgumentsAndOptions1), typeof(VariantArgumentsAndOptions2)])
                .Run(Utils.ToArgs("unknown --OOInt32=99"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
