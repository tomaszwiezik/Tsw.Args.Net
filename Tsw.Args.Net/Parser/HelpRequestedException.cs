namespace Tsw.Args.Net.Parser
{
    public class HelpRequestedException : SyntaxException
    {
        public HelpRequestedException() : base("Help is requested")
        { }
    }
}
