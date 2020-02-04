using Microsoft.Extensions.Logging;
using NICE.SdpProcessor.Models;
using NICE.SdpProcessor.Ports.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace NICE.SdpProcessor.Adapters.Input.File
{
    public class FileReader : IInputHandler
    {
        private readonly FileReaderOptions _fileReaderOptions;
        private readonly ILineProcessorFactory _lineProcessorFactory;
        private readonly ILogger<FileReader> _logger;

        public FileReader(
            FileReaderOptions fileReaderOptions,
            ILineProcessorFactory lineProcessorFactory,
            ILogger<FileReader> logger)
        {
            _fileReaderOptions = fileReaderOptions;
            _lineProcessorFactory = lineProcessorFactory;
            _logger = logger;
        }

        public async IAsyncEnumerable<InputMessage> ReadAsync()
        {
            using StreamReader reader = new StreamReader(_fileReaderOptions.FilePath);
            var messageItems = new List<InputMessageItem>();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (string.Equals(_fileReaderOptions.MessageBreak, line, StringComparison.OrdinalIgnoreCase))
                {
                    yield return new InputMessage { MessageItems = messageItems };
                    continue;
                }

                if (!_lineProcessorFactory.TryCreateLineProcessor(line[0], out var lineProcessor))
                {
                    _logger.LogWarning($"I don't know how to process this line {line}");
                    continue;
                }

                var messageItem = lineProcessor.ProcessLine(line);
                messageItems.Add(messageItem);
            }
        }
    }
}
