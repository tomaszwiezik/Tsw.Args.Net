namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("List arguments")]
    internal class ListArguments
    {
        [Option(Name = "requiredDecimal", Required = true, ShortcutName = "rd")]
        [Doc("requiredDecimal")]
        public List<decimal>? RequiredDecimals { get; set; }

        [Option(Name = "requiredInt", Required = true, ShortcutName = "ri")]
        [Doc("requiredInt")]
        public List<int>? RequiredInts { get; set; }

        [Option(Name = "requiredString", Required = true, ShortcutName = "rs")]
        [Doc("requiredString")]
        public List<string>? RequiredStrings { get; set; }


        [Option(Name = "optionalDecimal", Required = false, ShortcutName = "od")]
        [Doc("optionalDecimal")]
        public List<decimal>? OptionalDecimals { get; set; } = [];

        [Option(Name = "optionalInt", Required = false, ShortcutName = "oi")]
        [Doc("optionalInt")]
        public List<int>? OptionalInts { get; set; } = [];

        [Option(Name = "optionalString", Required = false, ShortcutName = "os")]
        [Doc("optionalString")]
        public List<string>? OptionalStrings { get; set; } = [];
    }
}
