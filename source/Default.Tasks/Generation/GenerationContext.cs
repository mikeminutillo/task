using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Default.Tasks.Generation;
using Task;
using System.IO;

namespace Default.Tasks.Generation
{
    class GenerationContext : IGenerationContext
    {
        private readonly string[] generationArgs;
        private readonly IFeedbackProvider FeedbackProvider;
        private readonly IList<GeneratedItem> Items = new List<GeneratedItem>();

        public GenerationContext(IFeedbackProvider provider, string[] generationArgs)
        {
            this.generationArgs = generationArgs;
            FeedbackProvider = provider;
        }

        public void AddFolder(string fullPath)
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, fullPath);

            var item = new GeneratedItem(path, x => Directory.CreateDirectory(x), Directory.Exists);

            Items.Add(item);
        }

        public void AddFile(string fullPath, IGenerator generator)
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, fullPath);

            var item = new GeneratedItem(path, x => File.WriteAllText(path, generator.GetText()), File.Exists);

            Items.Add(item);
        }

        public void Execute(bool InDryRunMode)
        {
            FeedbackProvider.WriteLine("Executing generator{0}", InDryRunMode ? " in dry run" : "");

            foreach (var item in Items)
            {
                var itemExists = item.Exists;
                FeedbackProvider.WriteLine("{0} {1}", itemExists ? "." : "+", item.Path);
                if (itemExists || InDryRunMode) continue;
                item.Create();
            }
        }

        public IEnumerable<string> Args
        {
            get { return generationArgs; }
        }

        public string GetArg(int index, string @default)
        {
            return generationArgs.Skip(index).FirstOrDefault() ?? @default;
        }
    }
}
