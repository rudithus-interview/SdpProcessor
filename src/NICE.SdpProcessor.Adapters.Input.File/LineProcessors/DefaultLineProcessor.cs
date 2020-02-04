using NICE.SdpProcessor.Models;

namespace NICE.SdpProcessor.Adapters.Input.File.LineProcessors
{
    public class DefaultLineProcessor : ILineProcessor
    {
        public InputMessageItem ProcessLine(string line)
        {
            return new InputMessageItem { Value = line };
        }
    }
}
