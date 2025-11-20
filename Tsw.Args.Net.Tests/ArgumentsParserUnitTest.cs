using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest
    {
        private string[] ToArgs(string args) => args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        private ArgumentsParser GetParser(ParserOptions? options = null, IEnumerable<Type>? types = null) => new(types, options);


        [Fact]
        public void TestHelp()
        {
            var result = GetParser(types: [typeof(OptionUnitTest), typeof(SampleMixedArguments), typeof(SampleOptionArguments), typeof(SamplePositionalArguments)])
                .Run(ToArgs("--help"), (arguments) => 0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestHelp_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**"
            };
            var result = GetParser(options: options, types: [typeof(OptionUnitTest), typeof(SampleMixedArguments), typeof(SampleOptionArguments), typeof(SamplePositionalArguments)])
                .Run(ToArgs("**help"), (arguments) => 0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestHelpShortcut()
        {
            var result = GetParser(types: [typeof(OptionUnitTest), typeof(SampleMixedArguments), typeof(SampleOptionArguments), typeof(SamplePositionalArguments)])
                .Run(ToArgs("-h"), (arguments) => 0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestHelpShortcut_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(OptionUnitTest), typeof(SampleMixedArguments), typeof(SampleOptionArguments), typeof(SamplePositionalArguments)])
                .Run(ToArgs("*h"), (arguments) => 0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestNoArguments()
        {
            var result = GetParser(types: [typeof(OptionUnitTest), typeof(SampleMixedArguments), typeof(SampleOptionArguments), typeof(SamplePositionalArguments)])
                .Run(ToArgs(""), (arguments) => 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestPositionalArguments()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("command file"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Null(arguments.OutputFile);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestOptionalPositionalArguments()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("command file output"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Equal("output", arguments.OutputFile);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestTooManyPositionalArguments()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("command file output some others"), (arguments) => 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestInsufficientPositionalArguments()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("command"), (arguments) => 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestUnsupportedCommandInPositionalArguments()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("unsupportedCommand"), (arguments) => 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestOptionArguments()
        {
            var result = GetParser(types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("--boolRequired --stringRequired=required-string --intRequired=999 --boolOptional --stringOptional=optional-string --intOptional=200"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestOptionArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("**boolRequired **stringRequired=required-string **intRequired=999 **boolOptional **stringOptional=optional-string **intOptional=200"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyOptionArguments()
        {
            var result = GetParser(types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("--boolRequired --stringRequired=required-string --intRequired=999"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyOptionArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("**boolRequired **stringRequired=required-string **intRequired=999"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestOptionShortcutArguments()
        {
            var result = GetParser(types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("-br -sr=required-string -ir=999 -bo -so=optional-string -io=200"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestOptionShortcutArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("*br *sr=required-string *ir=999 *bo *so=optional-string *io=200"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyOptionShortcutArguments()
        {
            var result = GetParser(types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("-br -sr=required-string -ir=999"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyOptionShortcutArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("*br *sr=required-string *ir=999"), (arguments) =>
                {
                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestMixedArguments()
        {
            var result = GetParser(types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("command file output --boolRequired --stringRequired=required-string --intRequired=999 --boolOptional --stringOptional=optional-string --intOptional=200"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Equal("output", arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestMixedArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("command file output **boolRequired **stringRequired=required-string **intRequired=999 **boolOptional **stringOptional=optional-string **intOptional=200"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Equal("output", arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestMixedArgumentsWithOptionsBeforeArguments()
        {
            var result = GetParser(types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("--boolRequired --stringRequired=required-string --intRequired=999 --boolOptional --stringOptional=optional-string --intOptional=200 command file output"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Equal("output", arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestMixedArgumentsWithOptionsBeforeArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("**boolRequired **stringRequired=required-string **intRequired=999 **boolOptional **stringOptional=optional-string **intOptional=200 command file output"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Equal("output", arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(true, arguments.BoolOptional);
                    Assert.Equal("optional-string", arguments.StringOptional);
                    Assert.Equal(200, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyMixedArguments()
        {
            var result = GetParser(types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("command file --boolRequired --stringRequired=required-string --intRequired=999"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Null(arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestRequiredOnlyMixedArguments_WithOptions()
        {
            var options = new ParserOptions()
            {
                OptionPrefix = "**",
                OptionShortcutPrefix = "*"
            };
            var result = GetParser(options: options, types: [typeof(SampleMixedArguments)])
                .Run<SampleMixedArguments>(ToArgs("command file **boolRequired **stringRequired=required-string **intRequired=999"), (arguments) =>
                {
                    Assert.Equal("command", arguments.Command);
                    Assert.Equal("file", arguments.File);
                    Assert.Null(arguments.OutputFile);

                    Assert.Equal(true, arguments.BoolRequired);
                    Assert.Equal("required-string", arguments.StringRequired);
                    Assert.Equal(999, arguments.IntRequired);
                    Assert.Equal(false, arguments.BoolOptional);
                    Assert.Equal(string.Empty, arguments.StringOptional);
                    Assert.Equal(100, arguments.IntOptional);
                    return 0;
                });
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestIncompleteOptionArguments()
        {
            var result = GetParser(types: [typeof(IncompleteOptionArguments)])
                .Run(ToArgs("--o"), (arguments) => 0);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestAmbiguousOptionNameArguments()
        {
            var result = GetParser(types: [typeof(AmbiguousOptionNameArguments)])
                .Run(ToArgs("--option"), (arguments) => 0);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestAmbiguousOptionShortcutArguments()
        {
            var result = GetParser(types: [typeof(AmbiguousOptionNameArguments)])
                .Run(ToArgs("--optionA"), (arguments) => 0);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestOnHelpRequestedHandler()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("--help"), (arguments) => 0,
                    onHelpRequested: () => 99
                );
            Assert.Equal(99, result);
        }

        [Fact]
        public void TestOnSyntaxErrorHandler()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("unsupportedCommand"), (arguments) => 0,
                    onSyntaxError: (message) => 99
                );
            Assert.Equal(99, result);
        }

        [Fact]
        public void TestOnErrorHandler()
        {
            var result = GetParser(types: [typeof(SamplePositionalArguments)])
                .Run<SamplePositionalArguments>(ToArgs("command file"), (arguments) => throw new ApplicationException("Test exception"),
                    onError: (exception) =>
                    {
                        Assert.IsType<ApplicationException>(exception);
                        Assert.Equal("Test exception", exception.Message);
                        return 99;
                    }
                );
            Assert.Equal(99, result);
        }

        [Fact]
        public void TestMissingArgumentPosition()
        {
            var result = GetParser(types: [typeof(MissingArgumentPositionArguments)])
                .Run<MissingArgumentPositionArguments>(ToArgs("command file"), (arguments) => 0);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestDuplicatedArgumentPosition()
        {
            var result = GetParser(types: [typeof(DuplicatedArgumentPositionArguments)])
                .Run<MissingArgumentPositionArguments>(ToArgs("command file"), (arguments) => 0);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestAmbiguouslyProvidedParameters()
        {
            var result = GetParser(types: [typeof(SampleOptionArguments)])
                .Run<SampleOptionArguments>(ToArgs("-sr=somestring -ir=1 -br -br"), (arguments) => 0);
            Assert.Equal(1, result);
        }

    }
}
