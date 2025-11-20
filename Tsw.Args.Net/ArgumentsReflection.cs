using System.Reflection;

namespace Tsw.Args.Net
{
    internal static class ArgumentsReflection
    {
        public static List<object> InstantiateSyntaxVariants(IEnumerable<Type> types) =>
            [..types
                .Where(x => x.IsClass && x.GetCustomAttribute<ArgumentsAttribute>() != null)
                .Select(x => Activator.CreateInstance(x) ?? throw new ApplicationException($"Type {x.FullName} cannot be instantiated"))
            ];


        public static Type GetPropertyType(PropertyInfo property)
        {
            if (Nullable.GetUnderlyingType(property.PropertyType) != null) return Nullable.GetUnderlyingType(property.PropertyType)!;
            if (!property.PropertyType.IsValueType) return property.PropertyType;

            throw new ApplicationException($"{property.Name}: properties decorated with [Argument] or [Option] attributes must be nullable");
        }


        public static bool IsSingleValueOption(PropertyInfo property) =>
            ArgumentsReflection.GetPropertyType(property).FullName switch
            {
                 "System.Boolean" => true,
                "System.Int16" => true,
                "System.Int32" => true,
                "System.Int64" => true,
                "System.String" => true,
                _ => throw new ApplicationException($"Unsupported option type: {GetPropertyType(property).FullName}")
            };



        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttr>(object instance) => instance
            .GetType()
            .GetProperties()
            .Where(x => Attribute.IsDefined(x, typeof(TAttr)));


        public static TAttr? GetClassAttribute<TAttr>(object instance) where TAttr : Attribute =>
            instance.GetType().GetCustomAttribute<TAttr>();


        public static TAttr? GetPropertyAttribute<TAttr>(PropertyInfo property) where TAttr : Attribute =>
            property.GetCustomAttribute<TAttr>();

    }
}
