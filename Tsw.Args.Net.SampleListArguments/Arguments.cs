namespace Tsw.Args.Net.SampleListArguments
{
    [Arguments]
    [Doc("Execute scripts and reports errors to error file.")]
    internal class Arguments
    {
        [Option(Name = "script", Required = true, ShortcutName = "s")]
        [Doc("Script path. Can be repeated.")]
        public List<string>? ScriptFiles { get; set; }

        [Option(Name = "error", Required = false, ShortcutName = "e")]
        [Doc("Error file path.")]
        public string? ErrorFile { get; set; }
    }
}
