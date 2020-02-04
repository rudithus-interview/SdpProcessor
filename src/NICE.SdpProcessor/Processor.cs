using NICE.SdpProcessor.Converters;
using NICE.SdpProcessor.Ports.Input;
using NICE.SdpProcessor.Ports.Output;
using System.Threading.Tasks;

namespace NICE.SdpProcessor
{
    public class Processor : ISdpProcessor
    {
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;
        private readonly IInputToOutputConverter _inputToOutputConverter;

        public Processor(
            IInputHandler inputHandler,
            IOutputHandler outputHandler,
            IInputToOutputConverter inputToOutputConverter)
        {
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
            _inputToOutputConverter = inputToOutputConverter;
        }

        public async Task Start()
        {
            await foreach (var input in _inputHandler.ReadAsync())
            {
                var output = _inputToOutputConverter.ConvertToOutput(input);

                _outputHandler.Push(output);
            }
        }
    }
}
