namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// If RequiredValue is provided to an argument, then there's no need to specify the Name.
    /// This is the only case when missing Name is a correct definition.
    /// </summary>
    [Arguments]
    [Doc("MissingArgumentNamesForRequiredValues")]
    internal class MissingArgumentNamesForRequiredValues
    {
        [Argument(Required = true, RequiredValue = "RAString", Position = 0)]
        [Doc("RAString")]
        public string? RAString { get; set; }

        [Argument(Name = "OAString", Required = false, Position = 1)]
        [Doc("OAString")]
        public string? OAString { get; set; } = "default";
    }
}
