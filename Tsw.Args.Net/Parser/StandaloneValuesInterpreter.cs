namespace Tsw.Args.Net.Parser
{
    internal class StandaloneValuesInterpreter
    {
        public StandaloneValuesInterpreter(ParserOptions parserOptions, SyntaxVariant syntaxVariant)
        {
            _parserOptions = parserOptions;
            _syntaxVariant = syntaxVariant;
        }

        private readonly ParserOptions _parserOptions;
        private readonly SyntaxVariant _syntaxVariant;


        public List<string> Translate(List<string> clArguments)
        {
            var translatedArguments = new List<string>();
            var valueRequired = false;
            var partialOption = string.Empty;

            foreach (var arg in clArguments)
            {
                if (!IsOption(arg) && !valueRequired)
                {
                    translatedArguments.Add(arg);
                }
                else if (IsOption(arg) && !valueRequired)
                {
                    partialOption = arg;
                    var optionDefinition = _syntaxVariant.OptionProperties.Find(x => x.OptionFullName == arg || x.OptionShortcutFullName == arg) ?? throw new SyntaxException($"Unknown option {arg}");
                    if (optionDefinition.ExpectsValue)
                    {
                        partialOption += _parserOptions.OptionValueSeparator;
                        valueRequired = true;
                    }
                    else
                    {
                        translatedArguments.Add(partialOption);
                    }
                }
                else if (valueRequired)
                {
                    partialOption+= arg;
                    valueRequired = false;
                    translatedArguments.Add(partialOption);
                    partialOption = string.Empty;
                }
                else
                {
                    throw new SyntaxException("Incorrect syntax");
                }
            }

            return translatedArguments;
        }

        private bool IsOption(string arg) => arg.StartsWith(_parserOptions.OptionPrefix!) || arg.StartsWith(_parserOptions.OptionShortcutPrefix!);

    }
}
