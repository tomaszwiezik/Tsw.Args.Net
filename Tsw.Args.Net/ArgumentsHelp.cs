using System.Reflection;
using System.Text;
using Tsw.Args.Net.Help;

namespace Tsw.Args.Net
{
    public class ArgumentsHelp
    {
        [Obsolete("Use ArgumentsHelp(IEnumerable<Type>?, ParserOptions?) instead, it is no longer needed to provide assembly for arguments extraction. Example: instead of new ArgumentsHelp(assembly, options), use new ArgumentsHelp(types: Arguments.GetAll(assembly), options)")]
        public ArgumentsHelp(Assembly? assembly, ParserOptions? options = null)
        {
            _types = _types.Union(assembly != null ?
                Arguments.GetAll(assembly) :
                AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(x => Arguments.GetAll(x))
                );
            if (!_types.Any()) throw new ApplicationException("No types decorated with [Arguments] attribute have been found");

            ParserOptions.Merge(options);
            ExecutableName = GetExecutableName();
        }

        public ArgumentsHelp(IEnumerable<Type>? types = null, ParserOptions? options = null)
        {
            _types = _types.Union(types ?? AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(x => Arguments.GetAll(x)));
            if (!_types.Any()) throw new ApplicationException("No types decorated with [Arguments] attribute have been found");

            ParserOptions.Merge(options);
            ExecutableName = GetExecutableName();
        }


        private readonly IEnumerable<Type> _types = [];


        public ParserOptions ParserOptions { get; private set; } = new ParserOptions()
        {
            OptionPrefix = "--",
            OptionShortcutPrefix = "-"
        };
        public string ExecutableName { get; }


        public string GetText()
        {
            var text = new StringBuilder();

            text.AppendLine();

            text.AppendLine("SYNTAX:");
            text.AppendLine(string.Empty);

            var syntaxDoc = new SyntaxDocBuilder(SyntaxVariantEnumerator.InstantiateSyntaxVariants(ParserOptions, _types), ParserOptions).Build();
            var formatter = new TextFormatter();

            GetColumsWidth(syntaxDoc, formatter,
                out int argumentNameColumnWidth,
                out int optionNameColumnWidth,
                out int optionShortcutNameColumnWidth);

            foreach (var doc in syntaxDoc.Documentation)
            {
                text.AppendLine($"{ExecutableName} {doc.FullSyntax}");
                text.AppendLine();
                text.AppendLine(formatter.ToColumns([0], [doc.Text]));
                text.AppendLine();

                foreach (var argument in doc.Arguments.FindAll(x => !x.FixedValue))
                {
                    text.AppendLine(formatter.ToColumns([argumentNameColumnWidth, 0], [argument.Name, argument.Text]));
                    text.AppendLine();
                }

                foreach (var option in doc.Options)
                {
                    text.AppendLine(formatter.ToColumns([optionShortcutNameColumnWidth, optionNameColumnWidth, 0], [option.ShortcutName, option.Name, option.Text]));
                    text.AppendLine();
                }
            }

            return text.ToString().Trim();
        }


        private string GetExecutableName()
        {
            if (ParserOptions.ApplicationName != null)
            {
                return ParserOptions.ApplicationName;
            }
            else
            {
                var entryAsseblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                return entryAsseblyName != null ?
                    entryAsseblyName.Split('.').Last() :
                    throw new ApplicationException("Cannot determine the application name, use ParserOptions to provide it");
            }
        }

        private void GetColumsWidth(SyntaxDoc syntaxDoc, TextFormatter formatter,
            out int argumentNameColumnWidth,
            out int optionNameColumnWidth,
            out int optionShortcutNameColumnWidth)
        {
            argumentNameColumnWidth = GetMaxArgumentLength(syntaxDoc.Documentation);
            optionNameColumnWidth = GetMaxOptionNameLength(syntaxDoc.Documentation);
            optionShortcutNameColumnWidth = GetMaxOptionShortcutNameLength(syntaxDoc.Documentation);
            if (argumentNameColumnWidth > optionShortcutNameColumnWidth + formatter.Spacing + optionNameColumnWidth)
            {
                optionNameColumnWidth = argumentNameColumnWidth - formatter.Spacing - optionShortcutNameColumnWidth;
            }
            if (argumentNameColumnWidth < optionShortcutNameColumnWidth + formatter.Spacing + optionNameColumnWidth)
            {
                argumentNameColumnWidth = optionShortcutNameColumnWidth + formatter.Spacing + optionNameColumnWidth;
            }
        }


        private int GetMaxArgumentLength(List<SyntaxVariantDoc> syntaxDoc) => 
            syntaxDoc.SelectMany(x => x.Arguments).Count() == 0 ?
                0 :
                syntaxDoc.SelectMany(x => x.Arguments).Max(x => x.Name.Length);

        private int GetMaxOptionShortcutNameLength(List<SyntaxVariantDoc> syntaxDoc) =>
            syntaxDoc.SelectMany(x => x.Options).Count() == 0 ?
                0 :
                syntaxDoc.SelectMany(x => x.Options).Max(x => x.ShortcutName.Length);

        private int GetMaxOptionNameLength(List<SyntaxVariantDoc> syntaxDoc) =>
            syntaxDoc.SelectMany(x => x.Options).Count() == 0 ?
                0 :
                syntaxDoc.SelectMany(x => x.Options).Max(x => x.Name.Length);

    }
}
