namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int64Arguments")]
    internal class Int64Arguments
    {
        [Argument(Name = "RAInt64", Required = true, Position = 0)]
        [Doc("RAInt64")]
        public long? RAInt64 { get; set; }

        [Argument(Name = "OAInt64", Required = false, Position = 1)]
        [Doc("OAInt64")]
        public long? OAInt64 { get; set; } = 0;
    }
}
