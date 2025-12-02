namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ByteOptions")]
    public class AmbiguousOptionNames
    {
        [Option(Name = "ROByte", Required = true)]
        [Doc("ROByte")]
        public byte? ROByte1 { get; set; }

        [Option(Name = "ROByte", Required = true)]
        [Doc("OOByte")]
        public byte? OOByte2 { get; set; } = 0;
    }
}
