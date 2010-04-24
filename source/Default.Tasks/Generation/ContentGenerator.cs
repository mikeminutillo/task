namespace Default.Tasks.Generation
{
    public class ContentGenerator : IGenerator
    {
        private readonly string _text;

        public ContentGenerator(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}
