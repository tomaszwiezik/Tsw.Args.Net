namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Ambiguous option name arguments")]
    internal class AmbiguousOptionNameArguments
    {
        [Option(Name = "option", Required = true)]
        [Doc("optionA")]
        public bool? OptionA { get; set; }

        [Option(Name = "option", Required = true)]
        [Doc("optionB")]
        public bool? OptionB { get; set; }
    }
}
