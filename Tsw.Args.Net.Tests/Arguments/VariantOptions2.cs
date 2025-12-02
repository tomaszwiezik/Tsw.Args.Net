namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("VariantOptions1")]
    internal class VariantOptions2
    {
        [Option(Name = "ROString", Required = true)]
        [Doc("ROString")]
        public string? ROString { get; set; }

        [Option(Name = "RODecimal", Required = true)]
        [Doc("RODecimal")]
        public decimal? RODecimal { get; set; }

        [Option(Name = "OODecimal", Required = false)]
        [Doc("OODecimal")]
        public decimal? OODecimal { get; set; } = 0;
    }
}
