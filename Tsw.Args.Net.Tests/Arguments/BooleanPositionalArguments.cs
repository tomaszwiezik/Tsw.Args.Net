namespace Tsw.Args.Net.Tests.Arguments
{
    [Arguments]
    [Doc("Unsupported boolean positional arguments")]
    internal class BooleanPositionalArguments
    {
        [Argument(Name = "argument", Required = true, Position = 0)]
        [Doc("Argument")]
        public bool? Argument { get; set; }
    }
}
