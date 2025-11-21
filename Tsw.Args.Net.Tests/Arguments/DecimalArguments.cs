namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Decimal arguments, new feature in version 9.1.1")]
    internal class DecimalArguments
    {
        [Argument(Name = "positional", Required = true, Position = 0)]
        [Doc("positional")]
        public decimal? Positional { get; set; }

        [Option(Name = "option", Required = true, ShortcutName = "o")]
        [Doc("option")]
        public decimal? Option { get; set; }
    }
}
