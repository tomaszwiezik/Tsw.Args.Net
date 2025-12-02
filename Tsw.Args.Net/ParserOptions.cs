namespace Tsw.Args.Net
{
    public class ParserOptions
    {
        /// <summary>
        /// Application name to display in help text.
        /// If not provided, then the name of entry assembly is used.
        /// </summary>
        public string? ApplicationName { get; set; }

        /// <summary>
        /// A prefix used to recognize option in argument list.
        /// </summary>
        public string? OptionPrefix { get; set; }

        /// <summary>
        /// A prefix used to recognize option shortcut in argument list.
        /// </summary>
        public string? OptionShortcutPrefix { get; set; }

        /// <summary>
        /// The separator between option name and its value.
        /// </summary>
        public char? OptionValueSeparator { get; set; }

        /// <summary>
        /// If true, then values to options are provided as separate arguments.
        /// Example 1: UseStandaloneValues is false and OptionValueSeparator is '=', the option values must be provided as: --option=value
        /// Example 2: UseStandaloneValues is true, option values must be provided as: --option value
        /// </summary>
        public bool? UseStandaloneValues { get; set; }


        public ParserOptions SetDefaultValues()
        {
            ApplicationName = string.Empty;
            OptionPrefix = "--";
            OptionShortcutPrefix = "-";
            OptionValueSeparator = '=';
            UseStandaloneValues = false;
            return this;
        }

        /// <summary>
        /// Combines current values with these provided in options parameter. All non-null values in options overwrite the current values.
        /// </summary>
        /// <param name="options">New values.</param>
        public ParserOptions Merge(ParserOptions? options)
        {
            ApplicationName = options?.ApplicationName ?? ApplicationName;
            OptionPrefix = options?.OptionPrefix ?? OptionPrefix;
            OptionShortcutPrefix = options?.OptionShortcutPrefix ?? OptionShortcutPrefix;
            OptionValueSeparator = options?.OptionValueSeparator ?? OptionValueSeparator;
            UseStandaloneValues |= options?.UseStandaloneValues ?? false;
            return this;
        }
    }
}
