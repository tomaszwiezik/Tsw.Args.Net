namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt16Options")]
    internal class UInt16Options
    {
        [Option(Name = "ROUInt16", Required = true)]
        [Doc("ROUInt16")]
        public ushort? ROUInt16 { get; set; }

        [Option(Name = "OOUInt16", Required = false)]
        [Doc("OOUInt16")]
        public ushort? OOUInt16 { get; set; } = 0;
    }
}
