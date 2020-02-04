using System.Collections.Generic;

namespace NICE.SdpProcessor.Models
{
    public class InputMessage
    {
        public IReadOnlyCollection<InputMessageItem> MessageItems { get; set; }
    }
}
