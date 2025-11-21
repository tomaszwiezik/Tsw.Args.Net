using System.Reflection;

namespace Tsw.Args.Net
{
    internal class SyntaxVariantEnumerator
    {
        public static List<SyntaxVariant> InstantiateSyntaxVariants(ParserOptions parserOptions, IEnumerable<Type> types) =>
            [..types
                .Where(x => x.IsClass && x.GetCustomAttribute<ArgumentsAttribute>() != null)
                .Select(x => Activator.CreateInstance(x) ?? throw new ApplicationException($"Type {x.FullName} cannot be instantiated"))
                .Select(x => new SyntaxVariant(parserOptions, x))
            ];
    }
}
