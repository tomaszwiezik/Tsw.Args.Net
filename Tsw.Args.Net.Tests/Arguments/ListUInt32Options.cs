namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListUInt32Options")]
    internal class ListUInt32Options
    {
        [Option(Name = "ROListUInt32", Required = true)]
        [Doc("ROListUInt32")]
        public List<uint>? ROListUInt32 { get; set; }

        [Option(Name = "OOListUInt32", Required = false)]
        [Doc("OOListUInt32")]
        public List<uint>? OOListUInt32 { get; set; }
    }
}
