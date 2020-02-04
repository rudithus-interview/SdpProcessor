using NICE.SdpProcessor.Adapters.Input.File.LineProcessors;

namespace NICE.SdpProcessor.Adapters.Input.File
{
    public class LineProcessorFactory : ILineProcessorFactory
    {
        public bool TryCreateLineProcessor(char key, out ILineProcessor lineProcessor)
        {
            lineProcessor = new DefaultLineProcessor();
            return true;
        }
    }
}
