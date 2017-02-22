using CommandLine;
using CommandLine.Text;

namespace ProximityCounter
{
    class CommandLineOptions
    {
        [Option('p', "port", Required = true,
            HelpText = "The port to listen too.")]
        public string Port { get; set; }

        [Option('b', "baudrate", Required = false, DefaultValue = 9600,
            HelpText = "The data rate in bits to use for communicating with the device.")]
        public int BaudRate { get; set; }

        [Option('d', "distance", Required = false, DefaultValue = 13,
            HelpText = "The maximum distance on which to detect movement.")]
        public int MaximumDistance { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current
                => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
