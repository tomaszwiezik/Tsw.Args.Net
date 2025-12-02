namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListUInt64Options")]
    internal class ListUInt64Options
    {
        [Option(Name = "ROListUInt64", Required = true)]
        [Doc("ROListUInt64")]
        public List<ulong>? ROListUInt64 { get; set; }

        [Option(Name = "OOListUInt64", Required = false)]
        [Doc("OOListUInt64")]
        public List<ulong>? OOListUInt64 { get; set; }
    }
}
