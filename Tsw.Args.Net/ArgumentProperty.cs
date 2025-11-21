using System.Reflection;

namespace Tsw.Args.Net
{
    internal class ArgumentProperty : Property
    {
        public ArgumentProperty(ParserOptions parserOptions, SyntaxVariant owner, PropertyInfo propertyInfo)
            : base(parserOptions, owner, propertyInfo, ["Decimal", "Int16", "Int32", "Int64", "String"])
        {
            _attribute = propertyInfo.GetCustomAttribute<ArgumentAttribute>() ?? throw new ApplicationException($"Property {propertyInfo.Name} has no [Argument] attribute.");
        }

        private readonly ArgumentAttribute _attribute;

        public string? ArgumentName => !string.IsNullOrWhiteSpace(_attribute.Name) ? _attribute.Name : null;
        public bool ArgumentRequired => _attribute.Required;
        public string? ArgumentRequiredValue => !string.IsNullOrWhiteSpace(_attribute.RequiredValue) ? _attribute.RequiredValue : null;
        public int ArgumentPosition => _attribute.Position;
    }
}
