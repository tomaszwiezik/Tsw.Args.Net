namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListDecimalOptions")]
    internal class ListDecimalOptions
    {
        [Option(Name = "ROListDecimal", Required = true)]
        [Doc("ROListDecimal")]
        public List<decimal>? ROListDecimal { get; set; }

        [Option(Name = "OOListDecimal", Required = false)]
        [Doc("OOListDecimal")]
        public List<decimal>? OOListDecimal { get; set; }
    }
}
