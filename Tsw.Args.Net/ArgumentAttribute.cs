namespace Tsw.Args.Net
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute : Attribute
    {
        public string? Name { get; set; }

        public bool Required { get; set; } = false;

        public string? RequiredValue { get; set; }

        public int Position { get; set; } = -1;
    }
}
