using System.Globalization;
using System.Reflection;

namespace Tsw.Args.Net
{
    internal class Property
    {
        public Property(ParserOptions parserOptions, SyntaxVariant owner, PropertyInfo propertyInfo, IEnumerable<string> supportedTypes)
        {
            _owner = owner;
            _parserOptions = parserOptions;
            _propertyInfo = propertyInfo ?? throw new ApplicationException($"Property info must ne be null");
            _docAttribute = propertyInfo.GetCustomAttribute<DocAttribute>() ?? throw new ApplicationException($"Property {propertyInfo.Name} has no [Doc] attribute.");
            _supportedTypes = supportedTypes;
            TypeName = GetTypeName();
        }

        private readonly SyntaxVariant _owner;
        protected readonly ParserOptions _parserOptions;
        protected readonly PropertyInfo _propertyInfo;
        private readonly DocAttribute _docAttribute;
        private readonly IEnumerable<string> _supportedTypes;

        public string DocText => _docAttribute.Text;
        public string TypeName { get; }
        /// <summary>
        /// The property name.
        /// </summary>
        public string Name => _propertyInfo.Name;
        public bool ExpectsValue => TypeName != "Boolean";
        public bool IsSingleValue => !TypeName.Contains("List<");


        public object? GetValue() => _propertyInfo.GetValue(_owner.ArgumentsDefinitionObject);


        public void SetValue(string? value)
        {
            switch (TypeName)
            {
                case "Boolean": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, true); break;
                case "Decimal": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, decimal.Parse(value!, CultureInfo.InvariantCulture)); break;
                case "Int16": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, Convert.ToInt16(value)); break;
                case "Int32": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, Convert.ToInt32(value)); break;
                case "Int64": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, Convert.ToInt64(value)); break;
                case "String": _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, value); break;
                case "List<Decimal>": SetListValue(decimal.Parse(value!, CultureInfo.InvariantCulture)); break;
                case "List<Int16>": SetListValue(Convert.ToInt16(value)); break;
                case "List<Int32>": SetListValue(Convert.ToInt32(value)); break;
                case "List<Int64>": SetListValue(Convert.ToInt64(value)); break;
                case "List<String>": SetListValue(value); break;
            }
        }

        private void SetListValue<T>(T value)
        {
            if (GetValue() == null) _propertyInfo.SetValue(_owner.ArgumentsDefinitionObject, new List<T>());
            (GetValue() as List<T>)!.Add(value);
        }


        private Type GetPropertyType()
        {
            if (Nullable.GetUnderlyingType(_propertyInfo.PropertyType) != null) return Nullable.GetUnderlyingType(_propertyInfo.PropertyType)!;
            if (!_propertyInfo.PropertyType.IsValueType) return _propertyInfo.PropertyType;

            throw new ApplicationException($"{_propertyInfo.Name}: properties decorated with [Argument] or [Option] attributes must be nullable");
        }

        private string GetTypeName()
        {
            var type = GetPropertyType();
            var typeName = type.FullName ?? throw new ApplicationException($"Property {_propertyInfo.Name}: cannot determine type");
            if (typeName.StartsWith("System.") && !IsGenericType(typeName))
            {
                typeName = typeName.Substring("System.".Length);
            }
            else if (typeName.StartsWith("System.Collections.Generic.List`1"))
            {
                // Sample type name: System.Collections.Generic.List`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
                var listElementType = typeName
                    .Split('[', StringSplitOptions.RemoveEmptyEntries)[1]
                    .Split(',')[0];
                if (listElementType.StartsWith("System.")) listElementType = listElementType.Substring("System.".Length);

                typeName = $"List<{listElementType}>";
            }

            if (!_supportedTypes.Contains(typeName)) throw new ApplicationException($"Property {_propertyInfo.Name}: unsupported type {type.FullName}");
            return typeName;
        }

        private bool IsGenericType(string typeName) => typeName.Contains('`');

    }
}
