namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int32Options")]
    internal class Int32Options
    {
        [Option(Name = "ROInt32", Required = true)]
        [Doc("ROInt32")]
        public int? ROInt32 { get; set; }

        [Option(Name = "OOInt32", Required = false)]
        [Doc("OOInt32")]
        public int? OOInt32 { get; set; } = 0;
    }
}
