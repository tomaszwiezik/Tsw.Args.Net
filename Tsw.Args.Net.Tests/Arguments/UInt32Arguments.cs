namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt32Arguments")]
    internal class UInt32Arguments
    {
        [Argument(Name = "RAUInt32", Required = true, Position = 0)]
        [Doc("RAUInt32")]
        public uint? RAUInt32 { get; set; }

        [Argument(Name = "OAUInt32", Required = false, Position = 1)]
        [Doc("OAUInt32")]
        public uint? OAUInt32 { get; set; } = 0;
    }
}
