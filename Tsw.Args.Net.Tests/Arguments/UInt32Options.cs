namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt32Options")]
    internal class UInt32Options
    {
        [Option(Name = "ROUInt32", Required = true)]
        [Doc("ROUInt32")]
        public uint? ROUInt32 { get; set; }

        [Option(Name = "OOUInt32", Required = false)]
        [Doc("OOUInt32")]
        public uint? OOUInt32 { get; set; } = 0;
    }
}
