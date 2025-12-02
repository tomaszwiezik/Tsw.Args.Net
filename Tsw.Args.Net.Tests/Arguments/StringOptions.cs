namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("StringOptions")]
    internal class StringOptions
    {
        [Option(Name = "ROString", Required = true)]
        [Doc("ROString")]
        public string? ROString { get; set; }

        [Option(Name = "OOString", Required = false)]
        [Doc("OOString")]
        public string? OOString { get; set; } = "default";
    }
}
