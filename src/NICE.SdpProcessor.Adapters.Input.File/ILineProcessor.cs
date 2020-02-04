using NICE.SdpProcessor.Models;

namespace NICE.SdpProcessor.Adapters.Input.File
{
    public interface ILineProcessor
    {
        public InputMessageItem ProcessLine(string line);
    }
}