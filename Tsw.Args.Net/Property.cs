using System.Globalization;
using System.Reflection;

namespace Tsw.Args.Net
{
    internal class Property
    {
        public Property(ParserOptions parserOptions, SyntaxVariant owner, PropertyInfo propertyInfo, IEnumerable<string> supportedTypes)
        {
            _parserOptions = parserOptions;
            _propertyInfo = propertyInfo ?? throw new ParserException(owner.TypeName, "Property info must not be null");
            _docAttribute = propertyInfo.GetCustomAttribute<DocAttribute>() ?? throw new ParserException(owner.TypeName, "Missing [Doc] attribute");
            _supportedTypes = supportedTypes;
            Owner = owner;
            TypeName = GetTypeName();
        }

        protected readonly ParserOptions _parserOptions;
        protected readonly PropertyInfo _propertyInfo;
        private readonly DocAttribute _docAttribute;
        private readonly IEnumerable<string> _supportedTypes;

        public SyntaxVariant Owner { get; }
        public string DocText => _docAttribute.Text;
        public string TypeName { get; }
        /// <summary>
        /// The property name.
        /// </summary>
        public string Name => _propertyInfo.Name;
        public bool ExpectsValue => TypeName != "Boolean";
        public bool IsSingleValue => !TypeName.Contains("List<");


        //public bool IsNullable => Nullable.GetUnderlyingType(_propertyInfo.PropertyType) != null;
        /// <summary>
        /// Indicates if the property is declared as nullable value.
        /// </summary>
        public bool IsNullable => new NullabilityInfoContext().Create(_propertyInfo).ReadState == NullabilityState.Nullable;

        public object? GetValue() => _propertyInfo.GetValue(Owner.ArgumentsDefinitionObject);

        public void SetValue(string? value)
        {
            switch (TypeName)
            {
                case "Boolean": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, true); break;
                case "Byte": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToByte(value)); break;
                case "Decimal": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, decimal.Parse(value!.Replace(",", "!"), CultureInfo.InvariantCulture)); break;   // Replace is to enforce incorrect format when coma is detected
                case "Int16": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToInt16(value)); break;
                case "Int32": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToInt32(value)); break;
                case "Int64": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToInt64(value)); break;
                case "String": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, value); break;
                case "UInt16": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToUInt16(value)); break;
                case "UInt32": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToUInt32(value)); break;
                case "UInt64": _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, Convert.ToUInt64(value)); break;
                case "List<Byte>": SetListValue(Convert.ToByte(value)); break;
                case "List<Decimal>": SetListValue(decimal.Parse(value!, CultureInfo.InvariantCulture)); break;
                case "List<Int16>": SetListValue(Convert.ToInt16(value)); break;
                case "List<Int32>": SetListValue(Convert.ToInt32(value)); break;
                case "List<Int64>": SetListValue(Convert.ToInt64(value)); break;
                case "List<String>": SetListValue(value); break;
                case "List<UInt16>": SetListValue(Convert.ToUInt16(value)); break;
                case "List<UInt32>": SetListValue(Convert.ToUInt32(value)); break;
                case "List<UInt64>": SetListValue(Convert.ToUInt64(value)); break;
            }
        }

        private void SetListValue<T>(T value)
        {
            if (GetValue() == null) _propertyInfo.SetValue(Owner.ArgumentsDefinitionObject, new List<T>());
            (GetValue() as List<T>)!.Add(value);
        }


        private Type GetPropertyType()
        {
            if (Nullable.GetUnderlyingType(_propertyInfo.PropertyType) != null) return Nullable.GetUnderlyingType(_propertyInfo.PropertyType)!;
            if (!_propertyInfo.PropertyType.IsValueType) return _propertyInfo.PropertyType;

            throw new ParserException(Owner.TypeName, Name, "Properties decorated with [Argument] or [Option] attributes must be nullable");
        }

        private string GetTypeName()
        {
            var type = GetPropertyType();
            var typeName = type.FullName ?? throw new ParserException(Owner.TypeName, Name, $"Cannot determine type");
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

            if (!_supportedTypes.Contains(typeName))
            {
                throw new ParserException(Owner.TypeName, Name, $"Unsupported type: {type.FullName}");
            }
            return typeName;
        }

        private bool IsGenericType(string typeName) => typeName.Contains('`');

    }
}
