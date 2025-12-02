namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListInt16Options")]
    internal class ListInt16Options
    {
        [Option(Name = "ROListInt16", Required = true)]
        [Doc("ROListInt16")]
        public List<short>? ROListInt16 { get; set; }

        [Option(Name = "OOListInt16", Required = false)]
        [Doc("OOListInt16")]
        public List<short>? OOListInt16 { get; set; }
    }
}
