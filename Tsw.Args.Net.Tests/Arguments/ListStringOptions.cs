namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListStringOptions")]
    internal class ListStringOptions
    {
        [Option(Name = "ROListString", Required = true)]
        [Doc("ROListString")]
        public List<string>? ROListString { get; set; }

        [Option(Name = "OOListString", Required = false)]
        [Doc("OOListString")]
        public List<string>? OOListString { get; set; }
    }
}
