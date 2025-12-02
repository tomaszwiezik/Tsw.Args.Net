using Tsw.Args.Net.Tests.Arguments;

namespace Tsw.Args.Net.Tests
{
    public class ArgumentsParserUnitTest_Handlers
    {
        [Fact]
        public void TestOnHelpRequestedHandler()
        {
            var result = Utils.GetParser(types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--help"), (arguments) => 0,
                    onHelpRequested: () => 99
                );
            Assert.Equal(99, result);
        }

        [Fact]
        public void TestOnSyntaxErrorHandler()
        {
            var result = Utils.GetParser(types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--unsupportedOption"), (arguments) => 0,
                    onSyntaxError: (message) => 99
                );
            Assert.Equal(99, result);
        }

        [Fact]
        public void TestOnErrorHandler()
        {
            var result = Utils.GetParser(types: [typeof(AllPossibleArgumentsAndOptions)])
                .Run<AllPossibleArgumentsAndOptions>(Utils.ToArgs("--OOBool"), (arguments) => throw new ApplicationException("Test exception"),
                    onError: (exception) =>
                    {
                        Assert.IsType<ApplicationException>(exception);
                        Assert.Equal("Test exception", exception.Message);
                        return 99;
                    }
                );
            Assert.Equal(99, result);
        }

    }
}
