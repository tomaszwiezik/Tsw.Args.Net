namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("UInt16Arguments")]
    internal class UInt16Arguments
    {
        [Argument(Name = "RAUInt16", Required = true, Position = 0)]
        [Doc("RAUInt16")]
        public ushort? RAUInt16 { get; set; }

        [Argument(Name = "OAUInt16", Required = false, Position = 1)]
        [Doc("OAUInt16")]
        public ushort? OAUInt16 { get; set; } = 0;
    }
}
