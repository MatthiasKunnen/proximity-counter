using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximityCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Run(options);
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                //Keeps the console open when debugging.
                Console.ReadLine();
            }
        }

        static void Run(CommandLineOptions options)
        {
        }
    }
}
