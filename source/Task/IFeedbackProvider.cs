
using System;
namespace Task
{
    public interface IFeedbackProvider
    {
        void Write(string format, params object[] args);
    }

    public static class FeedbackProviderExtensions
    {
        public static void WriteLine(this IFeedbackProvider provider)
        {
            provider.WriteLine(String.Empty);
        }

        public static void WriteLine(this IFeedbackProvider provider, string formatString, params object[] args)
        {
            provider.Write(String.Format("{0}{1}", formatString, Environment.NewLine), args);
        }
    }
}
