using System.Reflection;

namespace Tsw.Args.Net
{
    internal class OptionProperty : Property
    {
        public OptionProperty(ParserOptions parserOptions, SyntaxVariant owner, PropertyInfo propertyInfo)
            : base(parserOptions, owner, propertyInfo, ["Boolean", "Decimal", "Int16", "Int32", "Int64", "String", "List<Decimal>", "List<Int16>", "List<Int32>", "List<64>", "List<String>"])
        {
            _attribute = propertyInfo.GetCustomAttribute<OptionAttribute>() ?? throw new ApplicationException($"Property {propertyInfo.Name} has no [Option] attribute.");
        }

        private readonly OptionAttribute _attribute;

        public string? OptionName => !string.IsNullOrWhiteSpace(_attribute.Name) ? _attribute.Name : null;
        public string? OptionFullName => !string.IsNullOrWhiteSpace(_attribute.Name) ? $"{_parserOptions.OptionPrefix}{_attribute.Name}" : null;
        public string? OptionShortcutName => !string.IsNullOrWhiteSpace(_attribute.Name) ? _attribute.ShortcutName : null;
        public string? OptionShortcutFullName => !string.IsNullOrWhiteSpace(_attribute.ShortcutName) ? $"{_parserOptions.OptionShortcutPrefix}{_attribute.ShortcutName}" : null;
        public bool OptionRequired => _attribute.Required;
    }
}
