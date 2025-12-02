namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Boolean positional arguments are not supported.
    /// </summary>
    [Arguments]
    [Doc("BooleanArguments")]
    internal class BooleanArguments
    {
        [Argument(Name = "RABool", Required = true, Position = 0)]
        [Doc("RABool")]
        public bool? RABool { get; set; }

        [Argument(Name = "OABool", Required = false, Position = 1)]
        [Doc("OABool")]
        public bool? OABool { get; set; } = false;
    }
}
