using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    [Arguments]
    [Doc("Show session in concise form.")]
    internal class SummaryArguments : CommonArguments
    {
        [Argument(Name = "summary", Position = 0, Required = true, RequiredValue = "summary")]
        [Doc("Extract session command.")]
        public string? Command { get; set; }

        [Argument(Name = "<session_id>", Position = 1, Required = true)]
        [Doc("Session ID to extract from the log.")]
        public long? SessionId { get; set; }

        [Argument(Name = "<log_file>", Position = 2, Required = true)]
        [Doc("Log file name.")]
        public string? LogFile { get; set; }


        [Option(Name = "skipMsg", Required = false)]
        [Doc("Skip requests.")]
        public bool? SkipMsg { get; set; } = false;
    }
}
