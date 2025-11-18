namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Missing Position")]
    internal class MissingArgumentPositionArguments
    {
        [Argument(Required = true, RequiredValue = "command", Position = 0)]
        [Doc("Command")]
        public string? Command { get; set; }

        [Argument(Name = "<file>", Required = true)]
        [Doc("File name")]
        public string? File { get; set; }
    }
}
