namespace Tsw.Args.Net
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute : Attribute
    {
        public string? Name { get; set; }

        public bool Required { get; set; } = false;

        public string? RequiredValue { get; set; }

        /// <summary>
        /// A zero-based argument position in the command-line argument list.
        /// </summary>
        public int Position { get; set; } = -1;
    }
}
