using Tsw.Args.Net.Parser;
using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class StandaloneValuesInterpreterUnitTest
    {
        private ParserOptions _parserOptions = new ParserOptions().SetDefaultValues();


        [Fact]
        public void TestPositionalArgumentsOnly()
        {
            var clArguments = Utils.ToArgs("5   999").ToList();
            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(_parserOptions, [typeof(AllPossibleArgumentsAndOptions)]);
            var translatedArguments = new StandaloneValuesInterpreter(_parserOptions, syntaxVariants[0]).Translate(clArguments);

            Assert.Equal(["5", "999"], translatedArguments);
        }

        [Fact]
        public void TestOptionsOnly()
        {
            var clArguments = Utils.ToArgs("--OOBool   --OOString    --text--").ToList();
            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(_parserOptions, [typeof(AllPossibleArgumentsAndOptions)]);
            var translatedArguments = new StandaloneValuesInterpreter(_parserOptions, syntaxVariants[0]).Translate(clArguments);

            Assert.Equal(["--OOBool", "--OOString=--text--"], translatedArguments);
        }

        [Fact]
        public void TestArgumetnsAndOptions()
        {
            var clArguments = Utils.ToArgs("1 --OOBool 2  --OOString    --text-- 3").ToList();
            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(_parserOptions, [typeof(AllPossibleArgumentsAndOptions)]);
            var translatedArguments = new StandaloneValuesInterpreter(_parserOptions, syntaxVariants[0]).Translate(clArguments);

            Assert.Equal(["1", "--OOBool", "2", "--OOString=--text--", "3"], translatedArguments);
        }

        [Fact]
        public void TestUnknownOption()
        {
            var clArguments = Utils.ToArgs("1 --OOBool 2  --unknown    --text-- 3").ToList();
            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(_parserOptions, [typeof(AllPossibleArgumentsAndOptions)]);

            Assert.Throws<SyntaxException>(() => new StandaloneValuesInterpreter(_parserOptions, syntaxVariants[0]).Translate(clArguments));
        }

        [Fact]
        public void TestRepeatedSingleOption()
        {
            var clArguments = Utils.ToArgs("1 --OOString    --text-- --OOString --anotherText-- 3").ToList();
            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(_parserOptions, [typeof(AllPossibleArgumentsAndOptions)]);
            var translatedArguments = new StandaloneValuesInterpreter(_parserOptions, syntaxVariants[0]).Translate(clArguments);

            // This is OK, repeated options are not verified during translation
            Assert.Equal(["1", "--OOString=--text--", "--OOString=--anotherText--", "3"], translatedArguments);
        }

    }
}
