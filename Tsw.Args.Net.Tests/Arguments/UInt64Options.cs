namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt64Options")]
    internal class UInt64Options
    {
        [Option(Name = "ROUInt64", Required = true)]
        [Doc("ROUInt64")]
        public ulong? ROUInt64 { get; set; }

        [Option(Name = "OOUInt64", Required = false)]
        [Doc("OOUInt64")]
        public ulong? OOUInt64 { get; set; } = 0;
    }
}
