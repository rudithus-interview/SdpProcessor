using NICE.SdpProcessor.Models;
using NICE.SdpProcessor.Ports.Output;
using System;

namespace NICE.SdpProcessor.Adapters.Output.Console
{
    public class ConsoleOutputHandler : IOutputHandler
    {
        private readonly ConsoleOutputOptions _consoleOutputOptions;

        public ConsoleOutputHandler(ConsoleOutputOptions consoleOutputOptions)
        {
            _consoleOutputOptions = consoleOutputOptions;
        }

        public void Push(OutputMessage message)
        {
            foreach (var line in message.Lines)
            {
                System.Console.WriteLine(line);
            }
        }
    }
}
