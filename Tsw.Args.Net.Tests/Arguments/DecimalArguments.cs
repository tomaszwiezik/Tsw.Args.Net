namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("DecimalArguments")]
    internal class DecimalArguments
    {
        [Argument(Name = "RADecimal", Required = true, Position = 0)]
        [Doc("RADecimal")]
        public decimal? RADecimal { get; set; }

        [Argument(Name = "OADecimal", Required = false, Position = 1)]
        [Doc("OADecimal")]
        public decimal? OADecimal { get; set; } = 0;
    }
}
