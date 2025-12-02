namespace Tsw.Args.Net.Tests
{
    public class ParserOptionsUnitTest
    {
        [Fact]
        public void TestInitialValues()
        {
            var options = new ParserOptions();

            Assert.Null(options.ApplicationName);
            Assert.Null(options.OptionPrefix);
            Assert.Null(options.OptionShortcutPrefix);
            Assert.Null(options.OptionValueSeparator);
            Assert.Null(options.UseStandaloneValues);
        }

        [Fact]
        public void TestSettingDefaultValues()
        {
            var options = new ParserOptions().SetDefaultValues();

            Assert.NotNull(options.ApplicationName);
            Assert.NotNull(options.OptionPrefix);
            Assert.NotNull(options.OptionShortcutPrefix);
            Assert.NotNull(options.OptionValueSeparator);
            Assert.NotNull(options.UseStandaloneValues);
        }

        [Fact]
        public void TestMerge()
        {
            var options = new ParserOptions()
                .SetDefaultValues()
                .Merge(new ParserOptions { ApplicationName = "test"})
                .Merge(new ParserOptions { OptionPrefix = "**" })
                .Merge(new ParserOptions { OptionShortcutPrefix = "*" });

            Assert.Equal("test", options.ApplicationName);
            Assert.Equal("**", options.OptionPrefix);
            Assert.Equal("*", options.OptionShortcutPrefix);
        }

    }
}
