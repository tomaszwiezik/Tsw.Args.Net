namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("PositionalArguments")]
    internal class PositionalArguments
    {
        [Argument(Name = "RAString", Required = true, Position = 0, RequiredValue = "test")]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "RAInt32", Required = true, Position = 1)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 2)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default";
    }
}
