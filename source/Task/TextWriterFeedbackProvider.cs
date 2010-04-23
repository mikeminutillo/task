using System.IO;

namespace Task
{
    class TextWriterFeedbackProvider : IFeedbackProvider
    {
        private readonly TextWriter _writer;

        public TextWriterFeedbackProvider(TextWriter writer)
        {
            _writer = writer;
        }

        public void Write(string format, params object[] args)
        {
            _writer.Write(format, args);
        }
    }
}
