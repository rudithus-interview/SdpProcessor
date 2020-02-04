using Microsoft.Extensions.DependencyInjection;
using NICE.SdpProcessor.Ports.Output;

namespace NICE.SdpProcessor.Adapters.Output.Console
{
    public static class Boostrapper
    {
        public static void AddConsoleOutput(this IServiceCollection serviceCollection, ConsoleOutputOptions consoleOutputOptions)
        {
            serviceCollection.AddTransient<IOutputHandler, ConsoleOutputHandler>();
            serviceCollection.AddSingleton(consoleOutputOptions);
        }
    }
}
