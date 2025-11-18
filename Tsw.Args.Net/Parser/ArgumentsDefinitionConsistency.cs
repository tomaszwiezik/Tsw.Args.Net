namespace Tsw.Args.Net.Parser
{
    internal static class ArgumentsDefinitionConsistency
    {
        public static void CheckPositions(object syntaxVariant)
        {
            var positionIndex = new List<int>();
            foreach (var property in ArgumentsReflection.GetPropertiesWithAttribute<ArgumentAttribute>(syntaxVariant))
            {
                var attribute = ArgumentsReflection.GetPropertyAttribute<ArgumentAttribute>(property);
                if (attribute != null)
                {
                    if (attribute.Position < 0)
                    {
                        throw new ApplicationException($"Argument {property.Name} has no position specified");
                    }
                    if (positionIndex.Contains(attribute.Position))
                    {
                        throw new ApplicationException($"Argument {property.Name} has a position ({attribute.Position}) that overlaps with other arguments");
                    }

                    positionIndex.Add(attribute.Position);
                }
            }
        }


        public static void CheckAmbiguity(object syntaxVariant)
        {
            var optionIndex = new List<string>();
            foreach (var property in ArgumentsReflection.GetPropertiesWithAttribute<OptionAttribute>(syntaxVariant))
            {
                var attribute = ArgumentsReflection.GetPropertyAttribute<OptionAttribute>(property);
                if (attribute != null)
                {
                    var name = attribute.Name;
                    var shortcut = attribute.ShortcutName;

                    if (name == null)
                    {
                        throw new ApplicationException($"Option {property.Name} name is not specified");
                    }
                    if (optionIndex.Contains(name))
                    {
                        throw new ApplicationException($"Option {property.Name} name ({name}) is ambiguous, it has already been used with other option");
                    }
                    if (shortcut != null && optionIndex.Contains(shortcut))
                    {
                        throw new ApplicationException($"Option {property.Name} shortcut ({shortcut}) is ambiguous, it has already been used with other option");
                    }

                    if (name != null) optionIndex.Add(name);
                    if (shortcut != null) optionIndex.Add(shortcut);
                }
            }
        }

    }
}
