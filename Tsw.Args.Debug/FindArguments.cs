using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    [Arguments]
    [Doc("Finds sessions matching given criteria.")]
    internal class FindArguments : CommonArguments
    {
        [Argument(Name = "find", Position = 0, Required = true, RequiredValue = "find")]
        [Doc("Find sessions.")]
        public string? Command { get; set; }

        [Argument(Name = "<log_file>", Position = 1, Required = true)]
        [Doc("Log file name.")]
        public string? LogFile { get; set; }


        [Option(Name = "date", Required = false)]
        [Doc("Transaction date (format: YYYY-MM-DD).")]
        public string? Date { get; set; } = null;

        [Option(Name = "pos", Required = false)]
        [Doc("A POS number.")]
        public string? Pos { get; set; } = null;

        [Option(Name = "store", Required = false)]
        [Doc("A store number.")]
        public string? Store { get; set; } = null;

        [Option(Name = "txn", Required = false)]
        [Doc("A transaction number.")]
        public string? Txn { get; set; } = null;
    }
}
