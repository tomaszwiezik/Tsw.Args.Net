namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListUInt16Options")]
    internal class ListUInt16Options
    {
        [Option(Name = "ROListUInt16", Required = true)]
        [Doc("ROListUInt16")]
        public List<ushort>? ROListUInt16 { get; set; }

        [Option(Name = "OOListUInt16", Required = false)]
        [Doc("OOListUInt16")]
        public List<ushort>? OOListUInt16 { get; set; }
    }
}
