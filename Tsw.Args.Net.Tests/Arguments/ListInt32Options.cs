namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListInt32Options")]
    internal class ListInt32Options
    {
        [Option(Name = "ROListInt32", Required = true)]
        [Doc("ROListInt32")]
        public List<int>? ROListInt32 { get; set; }

        [Option(Name = "OOListInt32", Required = false)]
        [Doc("OOListInt32")]
        public List<int>? OOListInt32 { get; set; }
    }
}
