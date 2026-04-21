using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    [Arguments]
    [Doc("Show request statistics.")]
    internal class StatArguments : CommonArguments
    {
        [Argument(Name = "stat", Position = 0, Required = true, RequiredValue = "stat")]
        [Doc("Get statistics.")]
        public string? Command { get; set; }

        [Argument(Name = "<type>", Position = 1, Required = true)]
        [Doc("Statistics type: duration (per request), grouped, offers, orphaned, size, total.")]
        public string? Type { get; set; }

        [Argument(Name = "<log_file>", Position = 2, Required = true)]
        [Doc("Log file name.")]
        public string? LogFile { get; set; }


        [Option(Name = "csv", Required = false)]
        [Doc("Generate the output in CSV format.")]
        public bool? Csv { get; set; } = false;

        [Option(Name = "session", Required = false)]
        [Doc("Narrow the output to the session.")]
        public long? Session { get; set; } = null;
    }
}
