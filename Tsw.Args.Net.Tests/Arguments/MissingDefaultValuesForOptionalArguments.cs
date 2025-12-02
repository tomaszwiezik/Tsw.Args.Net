namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Optional argument has no obligatory default value.
    /// </summary>
    [Arguments]
    [Doc("MissingDefaultValuesForOptionalArguments")]
    internal class MissingDefaultValuesForOptionalArguments
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false, Position = 1)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; }
    }
}
