namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("StringArguments")]
    internal class StringArguments
    {
        [Argument(Name = "RAString", Required = true, Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 1)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default";
    }
}
