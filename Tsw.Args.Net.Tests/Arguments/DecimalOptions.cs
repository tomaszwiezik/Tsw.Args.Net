namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("DecimalOptions")]
    internal class DecimalOptions
    {
        [Option(Name = "RODecimal", Required = true)]
        [Doc("RODecimal")]
        public decimal? RODecimal { get; set; }

        [Option(Name = "OODecimal", Required = false)]
        [Doc("OODecimal")]
        public decimal? OODecimal { get; set; } = 0;
    }
}
