using System.Reflection;
using Tsw.Args.Net.Parser;

namespace Tsw.Args.Net
{
    /// <summary>
    /// <para>
    /// Command-line arguments parser.
    /// </para>
    /// <para>
    /// Terminology:
    /// <list type="table">
    /// <item>Argument - a positional argument.</item>
    /// <item>Option (switch) - options, prepeded with -- or -.</item>
    /// </list>
    /// </para>
    /// </summary>
    public class ArgumentsParser
    {
        [Obsolete("Use ArgumentsParser(IEnumerable<Type>, ParserOptions) instead, it is no longer needed to provide assembly for arguments extraction. Example: instead of 'new ArgumentsParser(assembly, options)', use 'new ArgumentsParser(types: Arguments.GetAll(assembly), options)'")]
        public ArgumentsParser(Assembly? assembly, ParserOptions? options = null)
        {
            _types = _types.Union(assembly != null ?
                Arguments.GetAll(assembly) :
                AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(x => Arguments.GetAll(x))
                );
            if (!_types.Any()) throw new ApplicationException("No types decorated with [Arguments] attribute have been found");

            ParserOptions.Merge(options);
        }

        public ArgumentsParser(IEnumerable<Type>? types = null, ParserOptions? options = null)
        {
            _types = _types.Union(types ?? AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(x => Arguments.GetAll(x)));
            if (!_types.Any()) throw new ApplicationException("No types decorated with [Arguments] attribute have been found");

            ParserOptions.Merge(options);
        }

        private readonly IEnumerable<Type> _types = [];


        public ParserOptions ParserOptions { get; private set; } = new ParserOptions()
        {
            OptionPrefix = "--",
            OptionShortcutPrefix = "-"
        };


        /// <summary>
        /// Parses arguments, select the matching one from defined syntax variants and pass them to the handler, or throw SyntaxException if none is matched.
        /// </summary>
        /// <param name="args">Arguments to parse.</param>
        /// <param name="handler">A function which receives arguments class selected from syntax variant.</param>
        /// <param name="onHelpRequested">An optional handler executed when a request for help is detected (--help or -h option is ued).</param>
        /// <param name="onSyntaxError">An optional handler executed when syntax problems are detected. The input parameter is the syntax error message.</param>
        /// <param name="onError">An optional handler executed when an exception is thrown in the application. The input parameter is the exception.</param>
        /// <returns>Returns 0 if arguments were correctly parsed and processed, 1 when syntax problems are detected, and 2 in all other cases.</returns>
        public int Run(string[] args, Func<object, int> handler, Func<int>? onHelpRequested = null, Func<string, int>? onSyntaxError = null, Func<Exception, int>? onError = null) =>
            Run(() => handler(Parse(args)), onHelpRequested, onSyntaxError, onError);


        /// <summary>
        /// Parse arguments and match them with arguments class of type T, then invoke the handler. Throw SyntaxException if arguments cannot be properly matched.
        /// </summary>
        /// <typeparam name="T">Argument definition class.</typeparam>
        /// <param name="args">Arguments to parse.</param>
        /// <param name="handler">A function which receives arguments class.</param>
        /// <param name="onHelpRequested">An optional handler executed when a request for help is detected (--help or -h option is ued).</param>
        /// <param name="onSyntaxError">An optional handler executed when syntax problems are detected. The input parameter is the syntax error message.</param>
        /// <param name="onError">An optional handler executed when an exception is thrown in the application. The input parameter is the exception.</param>
        /// <returns></returns>
        public int Run<T>(string[] args, Func<T, int> handler, Func<int>? onHelpRequested = null, Func<string, int>? onSyntaxError = null, Func<Exception, int>? onError = null) where T : class =>
            Run(() => handler(Parse<T>(args)), onHelpRequested, onSyntaxError, onError);


        private int Run(Func<int> handler, Func<int>? onHelpRequested = null, Func<string, int>? onSyntaxError = null, Func<Exception, int>? onError = null)
        {
            try
            {
                return handler();
            }
            catch (HelpRequestedException)
            {
                if (onHelpRequested != null)
                {
                    return onHelpRequested();
                }
                else
                {
                    Console.WriteLine(new ArgumentsHelp(types: _types, options: ParserOptions).GetText());
                    return 0;
                }
            }
            catch (SyntaxException ex)
            {
                if (onSyntaxError != null)
                {
                    return onSyntaxError(ex.Message);
                }
                else
                {
                    Console.WriteLine($"Syntax error: {ex.Message}");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    return onError(ex);
                }
                else
                {
                    Console.WriteLine($"Error: {ex}");
                    return 2;
                }
            }
        }


        private object Parse(string[] args)
        {
            if (args.Length == 1 && (args[0] == $"{ParserOptions.OptionPrefix}help" || args[0] == $"{ParserOptions.OptionShortcutPrefix}h")) throw new HelpRequestedException();

            var syntaxVariants = SyntaxVariantEnumerator.InstantiateSyntaxVariants(ParserOptions, _types);
            var arguments = ExtractArguments(args);
            var options = ExtractOptions(args);
            var parsedSyntaxVariants = new List<SyntaxVariant>();

            for (int i = 0; i < syntaxVariants.Count; i++)
            {
                var syntaxVariant = ParseOptions(options, ParseArguments(arguments, syntaxVariants[i]));
                if (syntaxVariant != null)
                {
                    parsedSyntaxVariants.Add(syntaxVariant);
                }
            }

            var selectedSyntaxVariants = SelectValidSyntaxVariants(parsedSyntaxVariants);

            return selectedSyntaxVariants.Count switch
            {
                1 => selectedSyntaxVariants[0].ArgumentsDefinitionObject,
                0 => throw new SyntaxException($"Missing or incorrect arguments; use {ParserOptions.OptionPrefix}help or {ParserOptions.OptionShortcutPrefix}h option to display help"),
                _ => throw new SyntaxException("Ambiguous syntax definition, multiple syntax variants match provided arguments")
            };
        }


        private T Parse<T>(string[] args) where T : class => (T)Parse(args);


        private List<string> ExtractArguments(string[] args) => args
            .ToList()
            .FindAll(x => !x.StartsWith(ParserOptions.OptionPrefix!) && !x.StartsWith(ParserOptions.OptionShortcutPrefix!));


        private List<Option> ExtractOptions(string[] args) => [..args
            .ToList()
            .FindAll(x => x.StartsWith(ParserOptions.OptionPrefix!) || x.StartsWith(ParserOptions.OptionShortcutPrefix!))
            .Select(x => new Option(x))];


        private SyntaxVariant? ParseArguments(List<string> arguments, SyntaxVariant? syntaxVariant)
        {
            if (syntaxVariant == null) return null;

            ArgumentsDefinitionConsistency.CheckPositions(ParserOptions, syntaxVariant);

            if (arguments.Count > syntaxVariant.ArgumentProperties.Count()) return null;   // There are more arguments than the variant can accept

            for (int position = 0; position < arguments.Count; position++)
            {
                var argument = arguments[position];

                var property = syntaxVariant.ArgumentProperties.Find(x => x.ArgumentPosition == position);
                if (property == null) return null;

                if (property.ArgumentRequiredValue == argument || property.ArgumentRequiredValue == null)
                {
                    property.SetValue(argument);
                }
            }

            return syntaxVariant;
        }


        private SyntaxVariant? ParseOptions(List<Option> options, SyntaxVariant? syntaxVariant)
        {
            if (syntaxVariant == null) return null;

            var usedOptions = new Dictionary<string, int>();
            ArgumentsDefinitionConsistency.CheckAmbiguity(ParserOptions, syntaxVariant);

            foreach (var option in options)
            {
                var property = syntaxVariant.OptionProperties.Find(x => x.OptionFullName == option.Name || x.OptionShortcutFullName == option.Name);
                if (property == null) return null;

                if (property.ExpectsValue && !option.HasValue) throw new SyntaxException($"Option {ParserOptions.OptionPrefix}{option.Name} is invalid, no value has been provided");
                if (property.IsSingleValue && usedOptions.ContainsKey(property.Name)) throw new SyntaxException($"Option {ParserOptions.OptionPrefix}{option.Name} is used more than once");

                property.SetValue(option.Value);
                usedOptions[property.Name] = 1;
            }

            return syntaxVariant;
        }


        private List<SyntaxVariant> SelectValidSyntaxVariants(List<SyntaxVariant> syntaxVariants)
        {
            var selectedSyntaxVariants = new List<SyntaxVariant>();

            foreach (var syntaxVariant in syntaxVariants)
            {
                var variantAccepted = true;

                foreach (var property in syntaxVariant.ArgumentProperties)
                {
                    if (property.ArgumentRequired && property.GetValue() == null) variantAccepted = false;
                }
                if (!variantAccepted) continue;

                foreach (var property in syntaxVariant.OptionProperties)
                {
                    if (property.OptionRequired && property.GetValue() == null) variantAccepted = false;
                }
                if (!variantAccepted) continue;

                selectedSyntaxVariants.Add(syntaxVariant);
            }

            return selectedSyntaxVariants;
        }

    }
}
