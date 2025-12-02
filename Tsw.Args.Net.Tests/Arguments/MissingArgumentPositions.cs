namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// This incorrect argument definition class lacks Position paramters in some arguments.
    /// </summary>
    [Arguments]
    [Doc("MissingArgumentPositions")]
    internal class MissingArgumentPositions
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; } = 0;
    }
}
