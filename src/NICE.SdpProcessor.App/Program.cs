using Microsoft.Extensions.DependencyInjection;
using NICE.SdpProcessor.Adapters.Input.File;
using NICE.SdpProcessor.Adapters.Output.Console;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NICE.SdpProcessor.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            var fileReaderOptions = new FileReaderOptions
            {
                FilePath = Path.Combine(Directory.GetCurrentDirectory(), "sdp_input.txt")
            };
            serviceCollection.AddLogging();
            serviceCollection.AddFileReader(fileReaderOptions);
            serviceCollection.AddConsoleOutput(new ConsoleOutputOptions());
            serviceCollection.AddSdpProcessor();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var sdpProcessor = serviceProvider.GetRequiredService<ISdpProcessor>();

            await sdpProcessor.Start();

        }
    }
}
