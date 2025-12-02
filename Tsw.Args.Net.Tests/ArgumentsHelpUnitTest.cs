using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsHelpUnitTest
    {
        [Fact]
        public void TestHelpForAmbiguousOptionNames()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(AmbiguousOptionNames)]).GetText());
        }

        [Fact]
        public void TestHelpForAmbiguousOptionShortcutNames()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(AmbiguousOptionShortcutNames)]).GetText());
        }

        [Fact]
        public void TestHelpForBooleanArguments()
        {
            // Boolean positional arguments are not supported.
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(BooleanArguments)]).GetText());
        }

        [Fact]
        public void TestHelpForBooleanOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(BooleanOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForByteArguments()
        {
            var result = new ArgumentsHelp(types: [typeof(ByteArguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForByteOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(ByteOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForDecimalArguments()
        {
            var result = new ArgumentsHelp(types: [typeof(DecimalArguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForDecimalOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(DecimalOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForDuplicatedArgumentPositions()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(DuplicatedArgumentPositions)]).GetText());
        }

        [Fact]
        public void TestIncorrectRequiredAndOptionalArgumentsOrder()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(IncorrectRequiredAndOptionalArgumentsOrder)]).GetText());
        }

        [Fact]
        public void TestHelpForInt16Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(Int16Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForInt16Options()
        {
            var result = new ArgumentsHelp(types: [typeof(Int16Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForInt32Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(Int32Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForInt32Options()
        {
            var result = new ArgumentsHelp(types: [typeof(Int32Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForInt64Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(Int64Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForInt64Options()
        {
            var result = new ArgumentsHelp(types: [typeof(Int64Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListByteOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(ListByteOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListDecimalOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(ListDecimalOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListInt16Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListInt16Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListInt32Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListInt32Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListInt64Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListInt64Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListStringOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(ListStringOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListUInt16Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListUInt16Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListUInt32Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListUInt32Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForListUInt64Options()
        {
            var result = new ArgumentsHelp(types: [typeof(ListUInt64Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForMissingArgumentNamesForRequiredValues()
        {
            var result = new ArgumentsHelp(types: [typeof(MissingArgumentNamesForRequiredValues)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForMissingArgumentNamesWithoutRequiredValues()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(MissingArgumentNamesWithoutRequiredValues)]).GetText());
        }

        [Fact]
        public void TestHelpForMissingArgumentPositions()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(MissingArgumentPositions)]).GetText());
        }

        [Fact]
        public void TestHelpForMissingDefaultValuesForOptionalArguments()
        {
#warning TODO: likely to remove this requirement
            //Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(MissingDefaultValuesForOptionalArguments)]).GetText());
        }

        [Fact]
        public void TestHelpForMissingOptionNames()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(MissingOptionNames)]).GetText());
        }

        [Fact]
        public void TestHelpForNonConsecutiveArgumentPositions()
        {
            Assert.Throws<ParserException>(() => new ArgumentsHelp(types: [typeof(NonConsecutiveArgumentPositions)]).GetText());
        }

        [Fact]
        public void TestHelpForPosionalArguments ()
        {
            var result = new ArgumentsHelp(types: [typeof(PositionalArguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForStringArguments()
        {
            var result = new ArgumentsHelp(types: [typeof(StringArguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForStringOptions()
        {
            var result = new ArgumentsHelp(types: [typeof(StringOptions)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt16Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt16Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt16Options()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt16Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt32Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt32Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt32Options()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt32Options)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt64Arguments()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt64Arguments)]).GetText();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestHelpForUInt64Options()
        {
            var result = new ArgumentsHelp(types: [typeof(UInt64Options)]).GetText();
            Assert.NotEmpty(result);
        }

    }
}
