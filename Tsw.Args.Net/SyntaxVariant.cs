using System.Reflection;

namespace Tsw.Args.Net
{
    internal class SyntaxVariant
    {
        public SyntaxVariant(ParserOptions parserOptions, object instance)
        {
            _parserOptions = parserOptions;
            _docAttribute = instance.GetType().GetCustomAttribute<DocAttribute>() ?? throw new ApplicationException($"Syntax variant {instance.GetType().FullName} has no [Doc] attribute");
            ArgumentsDefinitionObject = instance;
            TypeName = instance.GetType().Name; //?? throw new ApplicationException($"Argument definition class cannot be of a generic type");
            ArgumentProperties = GetArgumentProperties(instance);
            OptionProperties = GetOptionProperties(instance);
        }

        private readonly ParserOptions _parserOptions;
        private readonly DocAttribute _docAttribute;

        public object ArgumentsDefinitionObject { get; }
        public string DocText => _docAttribute.Text;
        public string TypeName { get; }
        public List<ArgumentProperty> ArgumentProperties { get; }
        public List<OptionProperty> OptionProperties { get; }


        private List<ArgumentProperty> GetArgumentProperties(object instance) =>
            [..instance
                .GetType()
                .GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(ArgumentAttribute)))
                .Select(x => new ArgumentProperty(_parserOptions, this, x))
            ];

        private List<OptionProperty> GetOptionProperties(object instance) =>
            [..instance
                .GetType()
                .GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(OptionAttribute)))
                .Select(x => new OptionProperty(_parserOptions, this, x))
            ];

    }
}
