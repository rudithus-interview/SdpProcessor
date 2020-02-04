namespace NICE.SdpProcessor.Adapters.Input.File
{
    public interface ILineProcessorFactory
    {
        bool TryCreateLineProcessor(char key, out ILineProcessor lineProcessor);
    }
}
