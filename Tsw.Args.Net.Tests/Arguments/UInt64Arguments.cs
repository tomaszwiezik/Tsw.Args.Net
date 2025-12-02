namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt64Arguments")]
    internal class UInt64Arguments
    {
        [Argument(Name = "RAUInt64", Required = true, Position = 0)]
        [Doc("RAUInt64")]
        public ulong? RAUInt64 { get; set; }

        [Argument(Name = "OAUInt64", Required = false, Position = 1)]
        [Doc("OAUInt64")]
        public ulong? OAUInt64 { get; set; } = 0;
    }
}
