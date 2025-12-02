namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Int16Options")]
    internal class Int16Options
    {
        [Option(Name = "ROInt16", Required = true)]
        [Doc("ROInt16")]
        public short? ROInt16 { get; set; }

        [Option(Name = "OOInt16", Required = false)]
        [Doc("OOInt16")]
        public short? OOInt16 { get; set; } = 0;
    }
}
