using System.Reflection;

namespace Tsw.Args.Net
{
    internal class OptionProperty : Property
    {
        public OptionProperty(ParserOptions parserOptions, SyntaxVariant owner, PropertyInfo propertyInfo)
            : base(parserOptions, owner, propertyInfo, ["Boolean", "Byte", "Decimal", "Int16", "Int32", "Int64", "String", "UInt16", "UInt32", "UInt64", "List<Byte>", "List<Decimal>", "List<Int16>", "List<Int32>", "List<Int64>", "List<String>", "List<UInt16>", "List<UInt32>", "List<UInt64>"])
        {
            _attribute = propertyInfo.GetCustomAttribute<OptionAttribute>() ?? throw new ParserException(Owner.TypeName, Name, $"Missing [Option] attribute.");
        }

        private readonly OptionAttribute _attribute;

        public string? OptionName => !string.IsNullOrWhiteSpace(_attribute.Name) ? _attribute.Name : null;
        public string? OptionFullName => !string.IsNullOrWhiteSpace(_attribute.Name) ? $"{_parserOptions.OptionPrefix}{_attribute.Name}" : null;
        public string? OptionShortcutName => !string.IsNullOrWhiteSpace(_attribute.Name) ? _attribute.ShortcutName : null;
        public string? OptionShortcutFullName => !string.IsNullOrWhiteSpace(_attribute.ShortcutName) ? $"{_parserOptions.OptionShortcutPrefix}{_attribute.ShortcutName}" : null;
        public bool OptionRequired => _attribute.Required;
    }
}
