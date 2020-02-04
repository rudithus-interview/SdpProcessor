using NICE.SdpProcessor.Models;
using System.Collections.Generic;

namespace NICE.SdpProcessor.Ports.Input
{
    public interface IInputHandler
    {
        IAsyncEnumerable<InputMessage> ReadAsync();
    }
}
