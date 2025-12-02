namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// The argument has a missing Name and RequiredValue attribute parameters. This is not acceptable, so parser error is reported.
    /// </summary>
    [Arguments]
    [Doc("MissingArgumentNamesWithoutRequiredValues")]
    internal class MissingArgumentNamesWithoutRequiredValues
    {
        [Argument(Name = "RAString", Required = true, Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Required = false, Position = 1)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default";
    }
}
