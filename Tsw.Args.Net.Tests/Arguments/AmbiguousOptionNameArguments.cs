namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Arguments definition is incorrect, as it contains two options sharing the same name.
    /// </summary>
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
