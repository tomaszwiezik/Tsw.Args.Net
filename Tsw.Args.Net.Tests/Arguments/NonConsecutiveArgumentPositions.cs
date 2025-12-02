namespace Tsw.Args.Net.Tests.Arguments
{
    /// <summary>
    /// Argument positions are incorrectly numbered in non-consequtive manner: 0,2 instead of expected 0, 1.
    /// </summary>
    [Arguments]
    [Doc("NonConsequtiveArgumentPositions")]
    internal class NonConsecutiveArgumentPositions
    {
        [Argument(Name = "RAInt32", Required = true, Position = 0)]
        [Doc("RAInt32")]
        public int? RAInt32 { get; set; }

        [Argument(Name = "OAInt32", Required = false, Position = 2)]
        [Doc("OAInt32")]
        public int? OAInt32 { get; set; } = 0;
    }
}
