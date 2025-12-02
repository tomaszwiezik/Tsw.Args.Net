namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int64Options")]
    internal class Int64Options
    {
        [Option(Name = "ROInt64", Required = true)]
        [Doc("ROInt64")]
        public long? ROInt64 { get; set; }

        [Option(Name = "OOInt64", Required = false)]
        [Doc("OOInt64")]
        public long? OOInt64 { get; set; } = 0;
    }
}
