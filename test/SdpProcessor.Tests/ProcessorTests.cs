using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using NICE.SdpProcessor;
using NICE.SdpProcessor.Models;
using NICE.SdpProcessor.Ports.Input;
using NICE.SdpProcessor.Ports.Output;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SdpProcessor.Tests
{
    public class ProcessorTests
    {
        [AutoMoqData, Theory]
        public async Task GivenInputHandlerReturnsMessages_EachMessageIsOutputted(
            IFixture fixture,
            [Frozen] Mock<IInputHandler> inputHandler,
            [Frozen] Mock<IOutputHandler> outputHandler,
            int numberOfMessages,
            Processor processor)
        {
            var messages = fixture.CreateMany<InputMessage>(numberOfMessages).ToAsyncEnumerable();
            inputHandler.Setup(handler => handler.ReadAsync()).Returns(messages);

            await processor.Start();

            outputHandler.Verify(handler => handler.Push(It.IsAny<OutputMessage>()), Times.Exactly(numberOfMessages));
        }
    }
}
