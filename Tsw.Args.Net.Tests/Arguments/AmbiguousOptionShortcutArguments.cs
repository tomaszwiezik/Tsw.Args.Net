namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Ambiguous option shortcut arguments")]
    internal class AmbiguousOptionShortcutArguments
    {
        [Option(Name = "optionA", ShortcutName = "o", Required = true)]
        [Doc("optionA")]
        public bool? OptionA { get; set; }

        [Option(Name = "optionB", ShortcutName = "o", Required = true)]
        [Doc("optionB")]
        public bool? OptionB { get; set; }
    }
}
