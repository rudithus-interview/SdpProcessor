using NICE.SdpProcessor.Models;

namespace NICE.SdpProcessor.Converters
{
    public interface IInputToOutputConverter
    {
        OutputMessage ConvertToOutput(InputMessage inputMessage);
    }
}
