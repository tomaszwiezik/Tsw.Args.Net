namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("AllPossibleAttributeParametersCombinations")]
    internal class AllPossibleAttributeParametersCombinations
    {
        [Argument(Required = true, RequiredValue = "RAString", Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "RAInt32", Required = true, Position = 1)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 2)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default";


        [Option(Name = "ROBool", Required = true)]
        [Doc("ROBool")]
        public bool? ROBool { get; set; }

        [Option(Name = "OOBool", Required = false, ShortcutName = "oob")]
        [Doc("OOBool")]
        public bool? OOBool { get; set; } = false;

        [Option(Name = "ROInt32", Required = true, ShortcutName = "roi")]
        [Doc("ROInt32")]
        public int? ROInt32 { get; set; }

        [Option(Name = "OOInt32", Required = false)]
        [Doc("OOInt32")]
        public int? OOInt32 { get; set; } = 0;

        [Option(Name = "ROListInt32", Required = true)]
        [Doc("ROListInt32")]
        public List<int>? ROListInt32 { get; set; }

        [Option(Name = "OOListInt32", Required = false, ShortcutName = "ool")]
        [Doc("OOListInt32")]
        public List<int>? OOListInt32 { get; set; }
    }
}
