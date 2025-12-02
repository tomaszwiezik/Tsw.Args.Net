using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class SyntaxVariantUnitTest
    {
        [Fact]
        public void TestArgumentProperties()
        {
            var options = new ParserOptions().SetDefaultValues();
            var syntaxVariant = new SyntaxVariant(options, new AllPossibleAttributeParametersCombinations());

            Assert.Equal(3, syntaxVariant.ArgumentProperties.Count);
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "RAString");
                Assert.NotNull(property);
                Assert.Null(property.ArgumentName);
                Assert.True(property.ArgumentRequired);
                Assert.Equal("RAString", property.ArgumentRequiredValue);
                Assert.Equal(0, property.ArgumentPosition);
                Assert.Equal("String", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "RAInt32");
                Assert.NotNull(property);
                Assert.Equal("RAInt32", property.ArgumentName);
                Assert.True(property.ArgumentRequired);
                Assert.Null(property.ArgumentRequiredValue);
                Assert.Equal(1, property.ArgumentPosition);
                Assert.Equal("Int32", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.Name == "OAString");
                Assert.NotNull(property);
                Assert.Equal("OAString", property.ArgumentName);
                Assert.False(property.ArgumentRequired);
                Assert.Null(property.ArgumentRequiredValue);
                Assert.Equal(2, property.ArgumentPosition);
                Assert.Equal("String", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
        }

        [Fact]
        public void TestOptionProperties()
        {
            var options = new ParserOptions().SetDefaultValues();
            var syntaxVariant = new SyntaxVariant(options, new AllPossibleAttributeParametersCombinations());

            Assert.Equal(6, syntaxVariant.OptionProperties.Count);
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "ROBool");
                Assert.NotNull(property);
                Assert.Equal("ROBool", property.OptionName);
                Assert.Equal("--ROBool", property.OptionFullName);
                Assert.Null(property.OptionShortcutName);
                Assert.Null(property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("Boolean", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OOBool");
                Assert.NotNull(property);
                Assert.Equal("OOBool", property.OptionName);
                Assert.Equal("--OOBool", property.OptionFullName);
                Assert.Equal("oob", property.OptionShortcutName);
                Assert.Equal("-oob", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("Boolean", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "ROInt32");
                Assert.NotNull(property);
                Assert.Equal("ROInt32", property.OptionName);
                Assert.Equal("--ROInt32", property.OptionFullName);
                Assert.Equal("roi", property.OptionShortcutName);
                Assert.Equal("-roi", property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("Int32", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OOInt32");
                Assert.NotNull(property);
                Assert.Equal("OOInt32", property.OptionName);
                Assert.Equal("--OOInt32", property.OptionFullName);
                Assert.Null(property.OptionShortcutName);
                Assert.Null(property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("Int32", property.TypeName);
                Assert.True(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "ROListInt32");
                Assert.NotNull(property);
                Assert.Equal("ROListInt32", property.OptionName);
                Assert.Equal("--ROListInt32", property.OptionFullName);
                Assert.Null(property.OptionShortcutName);
                Assert.Null(property.OptionShortcutFullName);
                Assert.True(property.OptionRequired);
                Assert.Equal("List<Int32>", property.TypeName);
                Assert.False(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.Name == "OOListInt32");
                Assert.NotNull(property);
                Assert.Equal("OOListInt32", property.OptionName);
                Assert.Equal("--OOListInt32", property.OptionFullName);
                Assert.Equal("ool", property.OptionShortcutName);
                Assert.Equal("-ool", property.OptionShortcutFullName);
                Assert.False(property.OptionRequired);
                Assert.Equal("List<Int32>", property.TypeName);
                Assert.False(property.IsSingleValue);
                Assert.True(property.IsNullable);
            }
        }

    }
}
