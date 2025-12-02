namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("VariantArgumentsAndOptions2")]
    internal class VariantArgumentsAndOptions2
    {
        [Argument(RequiredValue = "RAString2", Required = true, Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 1)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default2";


        [Option(Name = "ROInt32", Required = true)]
        [Doc("ROInt32")]
        public int? ROInt32 { get; set; }

        [Option(Name = "OOInt32", Required = false)]
        [Doc("OOInt32")]
        public int? OOInt32 { get; set; }
    }
}
