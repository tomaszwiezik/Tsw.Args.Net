using Tsw.Args.Net.SampleVariants2.Lib;

namespace Tsw.Args.Net.SampleVariants2
{
    internal class Program
    {
        static int Main(string[] args)
        {
            /*
             * This is to show that initially the Tsw.Args.Net.SampleVariants2.Lib2 assembly is not loaded.
             * All argument types defined in this assembly cannot be automatically obtained from it.
             */
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies().ToList().FindAll(x => !string.IsNullOrWhiteSpace(x.FullName) && x.FullName.StartsWith("Tsw.")))
            {
                Console.WriteLine(a.FullName);
            }

            /*
             * The code below is redundat, but it illustrates how to join argument types from multiple sources into a single list using a Union operator.
             * The final list contains unique type names, duplicates are eliminated (so CopyArguments type is not duplicated here).
             */
            var argumentTypes = 
                new List<Type>() { typeof(CopyArguments) }
                .Union(Arguments.GetAll(typeof(FileManager).Assembly));

            return new ArgumentsParser(types: argumentTypes).Run(args, (arguments) =>
            {
                return FileManager.ExecuteCommand(arguments);
            });
        }

    }
}
