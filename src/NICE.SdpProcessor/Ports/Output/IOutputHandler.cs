using NICE.SdpProcessor.Models;

namespace NICE.SdpProcessor.Ports.Output
{
    public interface IOutputHandler
    {
        void Push(OutputMessage message);
    }
}
