using Tsw.Args.Net;

namespace Tsw.Args.Debug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = ["stat", "size", @"c:\my\path\some.log", "-s=auto", "--csv"];
            //args = ["-h"];

            var options = new ParserOptions()
            {
                ApplicationName = "debug"
            };
            new ArgumentsParser(options: options).Run(args, (arguments) =>
            {
                if (arguments is ExtractArguments extractArguments) Show(extractArguments);
                if (arguments is FindArguments findArguments) Show(findArguments);
                if (arguments is StatArguments statArguments) Show(statArguments);
                if (arguments is SummaryArguments summaryArguments) Show(summaryArguments);
                return 0;
            });
        }

        static void Show(StatArguments arguments)
        {
        }

        static void Show(ExtractArguments arguments)
        {
        }

        static void Show(FindArguments arguments)
        {
        }

        static void Show(SummaryArguments arguments)
        {
        }
    }
}
