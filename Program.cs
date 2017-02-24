using System;
using System.Collections.Generic;
using System.IO.Ports;
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
            var port = new SerialPort()
            {
                PortName = options.Port,
                BaudRate = options.BaudRate,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                DtrEnable = true,
            };

            port.Open();
            Console.WriteLine("Listening on port: {0}", options.Port);

            var lastTrigger = DateTime.Now.AddMilliseconds(-options.Sensitivity);
            while (true)
            {
                var distance = int.Parse(port.ReadLine());
                if (distance > options.MaximumDistance
                    || lastTrigger.AddMilliseconds(options.Sensitivity) > DateTime.Now) continue;

                Console.WriteLine("Vehicle drive by detected.");
                lastTrigger = DateTime.Now;

                if (options.Test) continue;

                Task.Run(() => JsonConveyor.Post("https://sd4u.be/en-GB/ip-project/api/",
                    new KeyValuePair<string, string>("action", "vehicle_arriving"),
                    new KeyValuePair<string, string>("vehicleId", options.VehicleId.ToString()),
                    new KeyValuePair<string, string>("stopId", options.StopId.ToString())));
            }
        }
    }
}
