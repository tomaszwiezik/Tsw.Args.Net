namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("VariantOptions1")]
    internal class VariantOptions1
    {
        [Option(Name = "ROString", Required = true)]
        [Doc("ROString")]
        public string? ROString { get; set; }

        [Option(Name = "ROInt32", Required = true)]
        [Doc("ROInt32")]
        public int? ROInt32 { get; set; }

        [Option(Name = "OOInt32", Required = false)]
        [Doc("OOInt32")]
        public int? OOInt32 { get; set; }
    }
}
