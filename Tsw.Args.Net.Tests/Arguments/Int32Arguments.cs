namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int32Arguments")]
    internal class Int32Arguments
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false, Position = 1)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; } = 0;
    }
}
