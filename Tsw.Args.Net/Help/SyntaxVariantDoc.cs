namespace Tsw.Args.Net.Help
{
    internal record SyntaxVariantDoc(
        string Text,
        string SyntaxVariantName,
        string FullSyntax,
        List<ArgumentDoc> Arguments,
        List<OptionDoc> Options);
}
