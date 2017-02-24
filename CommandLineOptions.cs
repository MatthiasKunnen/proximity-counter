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

        [Option("sensitivity", Required = false, DefaultValue = 1000,
            HelpText = "The minimum amount of time in milliseconds inbetween two vehicles passing by.")]
        public int Sensitivity { get; set; }

        [Option('s', "stop-id", Required = true,
            HelpText = "The ID of the stop which the system is watching.")]
        public int StopId { get; set; }

        [Option('t', "test", DefaultValue = false,
            HelpText = "Include this parameter to skip sending data to the server.")]
        public bool Test { get; set; }

        [Option('v', "vehicle", Required = true,
           HelpText = "Id of the vehicle that will pass.")]
        public int VehicleId { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current
                => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
