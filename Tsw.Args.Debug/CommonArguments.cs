using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    internal class CommonArguments
    {
        [Option(Name = "serverType", Required = false, ShortcutName = "s")]
        [Doc("Server type, one of: 'auto', 'lcs', 'wlcs'. Default value is 'auto'.")]
        public string? ServerType { get; set; } = "auto";
    }
}
