namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ByteOptions")]
    internal class AmbiguousOptionShortcutNames
    {
        [Option(Name = "ROByte", Required = true, ShortcutName = "b")]
        [Doc("ROByte")]
        public byte? ROByte { get; set; }

        [Option(Name = "OOByte", Required = false, ShortcutName = "b")]
        [Doc("OOByte")]
        public byte? OOByte { get; set; } = 0;
    }
}
