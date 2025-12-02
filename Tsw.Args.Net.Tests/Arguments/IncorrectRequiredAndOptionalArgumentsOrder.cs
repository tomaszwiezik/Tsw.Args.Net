namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Optional positional arguments must follow required ones. This definition breaks this rule and should never be parsed correctly.
    /// </summary>
    [Arguments]
    [Doc("IncorrectRequiredAndOptionalArgumentsOrder")]
    internal class IncorrectRequiredAndOptionalArgumentsOrder
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false, Position = 1)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; } = 0;

        [Argument(Name = "RAString", Required = true, Position = 2)]
        [Doc("RAString")]
        public string? RAString { get; set; }
    }
}
