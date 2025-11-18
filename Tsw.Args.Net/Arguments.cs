using System.Reflection;

namespace Tsw.Args.Net
{
    public static class Arguments
    {
        public static IEnumerable<Type> GetAll(Assembly assembly) => assembly.GetTypes()
            .Where(x => x.GetCustomAttribute<ArgumentsAttribute>() != null);

        public static IEnumerable<Type> GetAll(IEnumerable<Assembly> assemblies) => assemblies
            .SelectMany(x => GetAll(x));
    }
}
