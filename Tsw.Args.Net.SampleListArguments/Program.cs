namespace Tsw.Args.Net.SampleListArguments
{
    internal class Program
    {
        static int Main(string[] args)
        {
            return new ArgumentsParser().Run<Arguments>(args, (arguments) =>
            {
                Console.WriteLine($"Scripts:");
                arguments.ScriptFiles!.ForEach(scriptFile => Console.WriteLine($"- {scriptFile}"));
                Console.WriteLine($"Error file: {arguments.ErrorFile ?? "none"}");
                return 0;
            });
        }
    }
}
