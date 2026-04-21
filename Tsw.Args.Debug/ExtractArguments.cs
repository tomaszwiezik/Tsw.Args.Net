using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    [Arguments]
    [Doc("Extract session entries from the log.")]
    internal class ExtractArguments : CommonArguments
    {
        [Argument(Name = "extract", Position = 0, Required = true, RequiredValue = "extract")]
        [Doc("Extract session command.")]
        public string? Command { get; set; }

        [Argument(Name = "<session_id>", Position = 1, Required = true)]
        [Doc("Session ID to extract from the log.")]
        public long? SessionId { get; set; }

        [Argument(Name = "<log_file>", Position = 2, Required = true)]
        [Doc("Log file name.")]
        public string? LogFile { get; set; }


        [Option(Name = "short", Required = false)]
        [Doc("Shorten the output by eliminating large values")]
        public bool? Short { get; set; } = false;

        [Option(Name = "saveVouchers", Required = false)]
        [Doc("Save voucher images to files. Option's value is the destination directory.")]
        public string? SaveVouchers { get; set; } = null;
    }
}
