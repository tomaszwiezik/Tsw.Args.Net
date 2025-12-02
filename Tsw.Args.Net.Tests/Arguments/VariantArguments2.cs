namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("VariantArguments2")]
    internal class VariantArguments2
    {
        [Argument(RequiredValue = "RAString2", Required = true, Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 1)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default2";
    }
}
