namespace Tsw.Args.Net.Parser
{
    internal static class ArgumentsDefinitionConsistency
    {
        public static void CheckPositions(ParserOptions options, SyntaxVariant syntaxVariant)
        {
            var positionIndex = new List<int>();
            foreach (var property in syntaxVariant.ArgumentProperties)
            {
                if (property.ArgumentPosition < 0) throw new ApplicationException($"Argument {property.Name} has no position specified");
                if (positionIndex.Contains(property.ArgumentPosition)) throw new ApplicationException($"Argument {property.Name} has a position ({property.ArgumentPosition}) that overlaps with other arguments");
                positionIndex.Add(property.ArgumentPosition);
            }
        }


        public static void CheckAmbiguity(ParserOptions options, SyntaxVariant syntaxVariant)
        {
            var optionIndex = new List<string>();
            foreach (var property in syntaxVariant.OptionProperties)
            {
                if (property.OptionName == null) throw new ApplicationException($"Option {property.Name} name is not specified");
                if (optionIndex.Contains(property.OptionName)) throw new ApplicationException($"Option {property.Name} name ({property.OptionName}) is ambiguous, it has already been used with other option");
                if (property.OptionShortcutName != null && optionIndex.Contains(property.OptionShortcutName)) throw new ApplicationException($"Option {property.Name} shortcut ({property.OptionShortcutName}) is ambiguous, it has already been used with other option");

                optionIndex.Add(property.OptionName);
                if (property.OptionShortcutName != null) optionIndex.Add(property.OptionShortcutName);
            }
        }

    }
}
