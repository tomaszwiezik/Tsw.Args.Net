namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int16Arguments")]
    internal class Int16Arguments
    {
        [Argument(Name = "RAInt16", Required = true, Position = 0)]
        [Doc("RAInt16")]
        public short? RAInt16 { get; set; }

        [Argument(Name = "OAInt16", Required = false, Position = 1)]
        [Doc("OAInt16")]
        public short? OAInt16 { get; set; } = 0;
    }
}
