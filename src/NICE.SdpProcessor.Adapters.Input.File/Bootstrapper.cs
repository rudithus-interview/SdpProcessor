using Microsoft.Extensions.DependencyInjection;
using NICE.SdpProcessor.Ports.Input;
using System.Collections.Generic;

namespace NICE.SdpProcessor.Adapters.Input.File
{
    public static class Bootstrapper
    {
        public static void AddFileReader(this IServiceCollection serviceCollection, FileReaderOptions fileReaderOptions)
        {
            serviceCollection.AddTransient<IInputHandler, FileReader>();
            serviceCollection.AddSingleton(fileReaderOptions);
            serviceCollection.AddTransient<ILineProcessorFactory, LineProcessorFactory>();
        }
    }
}
