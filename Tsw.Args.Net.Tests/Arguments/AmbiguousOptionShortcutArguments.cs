namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Arguments definition is incorrect, as it contains two different options sharing the same shortcut.
    /// </summary>
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
