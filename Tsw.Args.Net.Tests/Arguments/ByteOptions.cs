namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ByteOptions")]
    internal class ByteOptions
    {
        [Option(Name = "ROByte", Required = true)]
        [Doc("ROByte")]
        public byte? ROByte { get; set; }

        [Option(Name = "OOByte", Required = false)]
        [Doc("OOByte")]
        public byte? OOByte { get; set; } = 0;
    }
}
