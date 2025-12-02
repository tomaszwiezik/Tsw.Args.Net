using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_VariantOptions
    {
        [Fact]
        public void TestMatchingOptions1()
        {
            var result = Utils.GetParser(types: [typeof(VariantOptions1), typeof(VariantOptions2)])
                .Run(Utils.ToArgs("--ROString=testString --ROInt32=99"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantOptions1>(arguments);
                    if (arguments is VariantOptions1 selectedArguments)
                    {
                        Assert.Equal("testString", selectedArguments.ROString);
                        Assert.Equal(99, selectedArguments.ROInt32);
                        Assert.Null(selectedArguments.OOInt32);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingOptions2()
        {
            var result = Utils.GetParser(types: [typeof(VariantOptions1), typeof(VariantOptions2)])
                .Run(Utils.ToArgs("--ROString=testString --RODecimal=99.99"), (arguments) =>
                {
                    Assert.NotNull(arguments);
                    Assert.IsType<VariantOptions2>(arguments);
                    if (arguments is VariantOptions2 selectedArguments)
                    {
                        Assert.Equal("testString", selectedArguments.ROString);
                        Assert.Equal(99.99M, selectedArguments.RODecimal);
                        Assert.Equal(0, selectedArguments.OODecimal);
                    }
                    return 0;
                });
            Assert.Equal(ParseResult.Success, result);
        }

        [Fact]
        public void TestMatchingNoOptions()
        {
            var result = Utils.GetParser(types: [typeof(VariantOptions1), typeof(VariantOptions2)])
                .Run(Utils.ToArgs("--ROString=testString"), (arguments) => 0);
            Assert.Equal(ParseResult.IncorrectSyntax, result);
        }

    }
}
