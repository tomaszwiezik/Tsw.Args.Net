namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListInt64Options")]
    internal class ListInt64Options
    {
        [Option(Name = "ROListInt64", Required = true)]
        [Doc("ROListInt64")]
        public List<long>? ROListInt64 { get; set; }

        [Option(Name = "OOListInt64", Required = false)]
        [Doc("OOListInt64")]
        public List<long>? OOListInt64 { get; set; }
    }
}
