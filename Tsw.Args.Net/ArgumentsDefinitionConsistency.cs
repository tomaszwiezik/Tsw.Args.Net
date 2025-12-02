namespace Tsw.Args.Net
{
    internal static class ArgumentsDefinitionConsistency
    {
        public static void CheckArgumentDefinitions(ParserOptions options, SyntaxVariant syntaxVariant)
        {
            var optionalArgumentSpotted = false;
            for (var position = 0; position < syntaxVariant.ArgumentProperties.Count; position++)
            {
                var property = syntaxVariant.ArgumentProperties.Find(x => x.ArgumentPosition == position);
                if (property == null)
                {
                    throw new ParserException(syntaxVariant.TypeName, "Incorrect Position parameter in [Argument] attribute");
                }
                if (!property.IsNullable)
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Argument must be of nullable type (declare the property as {property.TypeName}?)");
                }
                //if (!property.ArgumentRequired && property.GetValue() == null)
                //{
                //    throw new ParserException(syntaxVariant.TypeName, property.Name, $"Optional arguments must must have a default value");
                //}
                if (string.IsNullOrWhiteSpace(property.ArgumentName) && string.IsNullOrWhiteSpace(property.ArgumentRequiredValue))
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Either Name, or RequiredValue parameter must be specified");
                }
                if (property.ArgumentRequired && optionalArgumentSpotted)
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Optional arguments must be defined after required arguments");
                }
                if (!property.ArgumentRequired) optionalArgumentSpotted = true;
            }
        }


        public static void CheckOptionDefinitions(ParserOptions options, SyntaxVariant syntaxVariant)
        {
            var optionIndex = new List<string>();
            foreach (var property in syntaxVariant.OptionProperties)
            {
                if (property.OptionName == null)
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Name parameter missing in [Option] attribute");
                }
                if (!property.IsNullable)
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Option must be of nullable type (declare the property as {property.TypeName}?)");
                }
                //if (!property.OptionRequired && property.GetValue() == null)
                //{
                //    throw new ParserException(syntaxVariant.TypeName, property.Name, "Optional options must must have a default value");
                //}
                if (optionIndex.Contains(property.OptionName))
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Ambiguous Name property in [Option] attribute");
                }
                if (property.OptionShortcutName != null && optionIndex.Contains(property.OptionShortcutName))
                {
                    throw new ParserException(syntaxVariant.TypeName, property.Name, "Ambiguous ShortcutName property in [Option] attribute");
                }

                optionIndex.Add(property.OptionName);
                if (property.OptionShortcutName != null) optionIndex.Add(property.OptionShortcutName);
            }
        }

    }
}
