namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Incorrect argument positions - the values are duplicated, and not consecutive.
    /// </summary>
    [Arguments]
    [Doc("DuplicatedArgumentPositions")]
    internal class DuplicatedArgumentPositions
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false, Position = 0)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; } = 0;
    }
}
