namespace Tsw.Args.Net.Help
{
    internal class SyntaxDocBuilder
    {
        public SyntaxDocBuilder(List<SyntaxVariant> syntaxVariants, ParserOptions options)
        {
            _parserOptions = options;
            _syntaxVariants = syntaxVariants;
        }

        private readonly ParserOptions _parserOptions;
        private readonly List<SyntaxVariant> _syntaxVariants;


        public SyntaxDoc Build() => new(BuildSyntaxDoc());


        private List<SyntaxVariantDoc> BuildSyntaxDoc()
        {
            var syntaxDoc = new List<SyntaxVariantDoc>();

            foreach (var syntaxVariant in _syntaxVariants)
            {
                var arguments = BuildArgumentsDoc(syntaxVariant.ArgumentProperties);
                var options = BuildOptionsDoc(syntaxVariant.OptionProperties);

                syntaxDoc.Add(new SyntaxVariantDoc(
                    Text: syntaxVariant.DocText,
                    SyntaxVariantName: syntaxVariant.TypeName,
                    FullSyntax: CreateFullSyntax(arguments, options),
                    Arguments: arguments,
                    Options: options));
            }
            syntaxDoc.Sort((x, y) => x.FullSyntax.CompareTo(y.FullSyntax));

            return syntaxDoc;
        }


        private List<ArgumentDoc> BuildArgumentsDoc(List<ArgumentProperty> properties)
        {
            var argumentsDoc = new List<ArgumentDoc>();

            foreach (var property in properties)
            {
                if (string.IsNullOrWhiteSpace(property.ArgumentName) && string.IsNullOrWhiteSpace(property.ArgumentRequiredValue)) throw new ApplicationException($"Porperty {property.Name} has neither Name, nor RequiredValue specified in [Argument] attribute");

                argumentsDoc.Add(new ArgumentDoc(
                    Name: (string.IsNullOrWhiteSpace(property.ArgumentRequiredValue) ? property.ArgumentName : property.ArgumentRequiredValue)!,
                    Position: property.ArgumentPosition,
                    Required: property.ArgumentRequired,
                    Text: property.DocText,
                    FixedValue: !string.IsNullOrWhiteSpace(property.ArgumentRequiredValue)));
            }
            argumentsDoc.Sort((x, y) => x.Position - y.Position);

            return argumentsDoc;
        }


        private List<OptionDoc> BuildOptionsDoc(List<OptionProperty> properties)
        {
            var optionsDoc = new List<OptionDoc>();

            foreach (var property in properties)
            {
                optionsDoc.Add(new OptionDoc(
                    Name: property.TypeName == "Boolean" ? $"{property.OptionFullName}" : $"{property.OptionFullName}=<{property.TypeName.ToLower().Replace("list<", string.Empty).Replace(">", string.Empty)}>",
                    ShortcutName: string.IsNullOrWhiteSpace(property.OptionShortcutFullName) ? string.Empty : $"{property.OptionShortcutFullName}",
                    Required: property.OptionRequired,
                    Text: property.DocText,
                    Repeatable: !property.IsSingleValue));
            }
            optionsDoc.Sort((x, y) => x.Name.CompareTo(y.Name));

            return optionsDoc;
        }


        private string CreateFullSyntax(List<ArgumentDoc> arguments, List<OptionDoc> options)
        {
            var fullSyntax = string.Empty;
            arguments.ForEach(argument => fullSyntax += argument.Required ? $" {argument.Name}" : $" [{argument.Name}]");
            options.ForEach(option =>
            {
                var repetitionString = option.Repeatable ? " ..." : string.Empty;
                fullSyntax += option.Required ? $" {option.Name}{repetitionString}" : $" [{option.Name}{repetitionString}]";
            });

            return fullSyntax.Trim();
        }

    }
}
