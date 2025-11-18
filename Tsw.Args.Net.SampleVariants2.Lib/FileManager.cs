using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsw.Args.Net.SampleVariants2.Lib
{
    public class FileManager
    {
        public static int ExecuteCommand(object arguments)
        {
            if (arguments is CopyArguments copyArguments) return Copy(copyArguments);
            if (arguments is DeleteArguments deleteArguments) return Delete(deleteArguments);
            return 3;
        }

        static int Copy(CopyArguments arguments)
        {
            Console.WriteLine($"Action = {arguments.Action}, SourceFile = {arguments.SourceFile}, DestinationFile = {arguments.DestinationFile}, Quiet = {arguments.Quiet}, Retry = {arguments.Retry}");
            return 0;
        }

        static int Delete(DeleteArguments arguments)
        {
            Console.WriteLine($"Action = {arguments.Action}, File = {arguments.File}, Force = {arguments.Force}");
            return 0;
        }
    }
}
