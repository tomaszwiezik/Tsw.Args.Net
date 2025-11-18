namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Incomplete option arguments")]
    internal class IncompleteOptionArguments
    {
        [Option(Required = true)]
        [Doc("missingName")]
        public bool? MissingName { get; set; }
    }
}
