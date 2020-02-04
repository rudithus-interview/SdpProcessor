using NICE.SdpProcessor.Models;
using System.Linq;

namespace NICE.SdpProcessor.Converters
{
    public class InputToOutputConverter : IInputToOutputConverter
    {
        public OutputMessage ConvertToOutput(InputMessage inputMessage)
        {
            return new OutputMessage { Lines = inputMessage.MessageItems.Select(item => item.Value).ToList() };
        }
    }
}
