namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("ListByteOptions")]
    internal class ListByteOptions
    {
        [Option(Name = "ROListByte", Required = true)]
        [Doc("ROListByte")]
        public List<byte>? ROListByte { get; set; }

        [Option(Name = "OOListByte", Required = false)]
        [Doc("OOListByte")]
        public List<byte>? OOListByte { get; set; }
    }
}
