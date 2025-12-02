namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ByteArguments")]
    internal class ByteArguments
    {
        [Argument(Name = "RAByte", Required = true, Position = 0)]
        [Doc("RAByte")]
        public byte? RAByte { get; set; }

        [Argument(Name = "OAByte", Required = false, Position = 1)]
        [Doc("OAByte")]
        public byte? OAByte { get; set; } = 0;
    }
}
