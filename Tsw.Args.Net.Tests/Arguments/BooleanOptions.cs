namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("BooleanOptions")]
    internal class BooleanOptions
    {
        [Option(Name = "ROBool", Required = true)]
        [Doc("ROBool")]
        public bool? ROBool { get; set; }

        [Option(Name = "OOBool", Required = false)]
        [Doc("OOBool")]
        public bool? OOBool { get; set; } = false;
    }
}
