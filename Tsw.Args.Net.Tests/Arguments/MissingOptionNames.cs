namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("MissingOptionNames")]
    internal class MissingOptionNames
    {
        [Option(Name = "ROString", Required = true)]
        [Doc("ROString")]
        public string? ROString { get; set; }

        [Option(Required = false)]
        [Doc("OOString")]
        public string? OOString { get; set; } = "default";
    }
}
