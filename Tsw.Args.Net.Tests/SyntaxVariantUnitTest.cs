using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class SyntaxVariantUnitTest
    {
        [Fact]
        public void TestArgumentProperties()
        {
            var options = new ParserOptions();
            var syntaxVariant = new SyntaxVariant(options, new SampleMixedArguments());

            Assert.Equal(3, syntaxVariant.ArgumentProperties.Count);
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "Command");
                Assert.NotNull(property);
                Assert.Null(property.ArgumentName);
                Assert.True(property.ArgumentRequired);
                Assert.Equal("command", property.ArgumentRequiredValue);
                Assert.Equal(0, property.ArgumentPosition);
                Assert.Equal("String", property.TypeName);
            }
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "File");
                Assert.NotNull(property);
                Assert.Equal("<file>", property.ArgumentName);
                Assert.True(property.ArgumentRequired);
                Assert.Null(property.ArgumentRequiredValue);
                Assert.Equal(1, property.ArgumentPosition);
                Assert.Equal("String", property.TypeName);
            }
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "OutputFile");
                Assert.NotNull(property);
                Assert.Equal("<output_file>", property.ArgumentName);
                Assert.False(property.ArgumentRequired);
                Assert.Null(property.ArgumentRequiredValue);
                Assert.Equal(2, property.ArgumentPosition);
                Assert.Equal("String", property.TypeName);
            }
        }

        [Fact]
        public void TestSingleValueOptionProperties()
        {
            var options = new ParserOptions
            {
                OptionPrefix = "--",
                OptionShortcutPrefix = "-"
            };
            var syntaxVariant = new SyntaxVariant(options, new SampleMixedArguments());

            Assert.Equal(6, syntaxVariant.OptionProperties.Count);
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "BoolRequired");
                Assert.NotNull(property);
                Assert.Equal("boolRequired", property.OptionName);
                Assert.Equal("--boolRequired", property.OptionFullName);
                Assert.Equal("br", property.OptionShortcutName);
                Assert.Equal("-br", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("Boolean", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "StringRequired");
                Assert.NotNull(property);
                Assert.Equal("stringRequired", property.OptionName);
                Assert.Equal("--stringRequired", property.OptionFullName);
                Assert.Equal("sr", property.OptionShortcutName);
                Assert.Equal("-sr", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("String", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "IntRequired");
                Assert.NotNull(property);
                Assert.Equal("intRequired", property.OptionName);
                Assert.Equal("--intRequired", property.OptionFullName);
                Assert.Equal("ir", property.OptionShortcutName);
                Assert.Equal("-ir", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("Int32", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "BoolOptional");
                Assert.NotNull(property);
                Assert.Equal("boolOptional", property.OptionName);
                Assert.Equal("--boolOptional", property.OptionFullName);
                Assert.Equal("bo", property.OptionShortcutName);
                Assert.Equal("-bo", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("Boolean", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "StringOptional");
                Assert.NotNull(property);
                Assert.Equal("stringOptional", property.OptionName);
                Assert.Equal("--stringOptional", property.OptionFullName);
                Assert.Equal("so", property.OptionShortcutName);
                Assert.Equal("-so", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("String", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "IntOptional");
                Assert.NotNull(property);
                Assert.Equal("intOptional", property.OptionName);
                Assert.Equal("--intOptional", property.OptionFullName);
                Assert.Equal("io", property.OptionShortcutName);
                Assert.Equal("-io", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("Int32", property.TypeName);
            }
        }

        [Fact]
        public void TestMultipleValueOptionProperties()
        {
            var options = new ParserOptions
            {
                OptionPrefix = "--",
                OptionShortcutPrefix = "-"
            };
            var syntaxVariant = new SyntaxVariant(options, new ListArguments());

            Assert.Equal(6, syntaxVariant.OptionProperties.Count);
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "RequiredDecimals");
                Assert.NotNull(property);
                Assert.Equal("requiredDecimal", property.OptionName);
                Assert.Equal("--requiredDecimal", property.OptionFullName);
                Assert.Equal("rd", property.OptionShortcutName);
                Assert.Equal("-rd", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("List<Decimal>", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "RequiredInts");
                Assert.NotNull(property);
                Assert.Equal("requiredInt", property.OptionName);
                Assert.Equal("--requiredInt", property.OptionFullName);
                Assert.Equal("ri", property.OptionShortcutName);
                Assert.Equal("-ri", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("List<Int32>", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "RequiredStrings");
                Assert.NotNull(property);
                Assert.Equal("requiredString", property.OptionName);
                Assert.Equal("--requiredString", property.OptionFullName);
                Assert.Equal("rs", property.OptionShortcutName);
                Assert.Equal("-rs", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("List<String>", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OptionalDecimals");
                Assert.NotNull(property);
                Assert.Equal("optionalDecimal", property.OptionName);
                Assert.Equal("--optionalDecimal", property.OptionFullName);
                Assert.Equal("od", property.OptionShortcutName);
                Assert.Equal("-od", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("List<Decimal>", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OptionalInts");
                Assert.NotNull(property);
                Assert.Equal("optionalInt", property.OptionName);
                Assert.Equal("--optionalInt", property.OptionFullName);
                Assert.Equal("oi", property.OptionShortcutName);
                Assert.Equal("-oi", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("List<Int32>", property.TypeName);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OptionalStrings");
                Assert.NotNull(property);
                Assert.Equal("optionalString", property.OptionName);
                Assert.Equal("--optionalString", property.OptionFullName);
                Assert.Equal("os", property.OptionShortcutName);
                Assert.Equal("-os", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("List<String>", property.TypeName);
            }
        }

    }
}
