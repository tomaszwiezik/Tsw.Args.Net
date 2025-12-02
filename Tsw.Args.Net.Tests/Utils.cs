namespace Tsw.Args.Net.Tests
{
    internal static class Utils
    {
        public static string[] ToArgs(string args) => args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        public static ArgumentsParser GetParser(ParserOptions? options = null, IEnumerable<Type>? types = null) => new(types, options);
    }
}
