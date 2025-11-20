namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Arguments definition is incorrect, as it contains two positional arguments with the same position.
    /// </summary>
    [Arguments]
    [Doc("Duplicated Position")]
    internal class DuplicatedArgumentPositionArguments
    {
        [Argument(Required = true, RequiredValue = "command", Position = 0)]
        [Doc("Command")]
        public string? Command { get; set; }

        [Argument(Name = "<file>", Required = true, Position = 0)]
        [Doc("File name")]
        public string? File { get; set; }
    }
}
