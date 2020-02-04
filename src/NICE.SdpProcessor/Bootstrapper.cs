using Microsoft.Extensions.DependencyInjection;
using NICE.SdpProcessor.Converters;

namespace NICE.SdpProcessor
{
    public static class Bootstrapper
    {
        public static void AddSdpProcessor(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IInputToOutputConverter, InputToOutputConverter>();
            serviceCollection.AddTransient<ISdpProcessor, Processor>();
        }
    }
}
