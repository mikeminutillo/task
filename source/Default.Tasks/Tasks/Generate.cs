using System;
using System.ComponentModel.Composition;
using System.Linq;
using Default.Tasks.Generation;
using Task;

namespace Default.Tasks.Tasks
{
    [TaskController("generate", "generate a collection of files based on some template")]
    class Generate : ITaskController
    {
        public string GetHelpText()
        {
            return "> task generate <generator> [<generation args>...]";
        }

        public void Execute(string[] args)
        {
            var generatorName = args.FirstOrDefault();
            var generationArgs = args.Skip(1).ToArray();
            if (generatorName == null)
                throw new Exception("You must supply a generator");

            var generator = GeneratorDefinitions.GetGeneratorDefinition(generatorName);

            if (generator == null)
                throw new Exception(String.Format("No generator named '{0}' was found", generatorName));

            var generationContext = new GenerationContext(FeedbackProvider, generationArgs);
            generator.Apply(generationContext);

            generationContext.Execute(InDryRunMode);
        }

        [Switch("dry-run")]
        public bool InDryRunMode { get; set; }

        [Import]
        protected GenerationDefinitionLibrary GeneratorDefinitions { get; set; }

        [Import(typeof(IFeedbackProvider))]
        protected IFeedbackProvider FeedbackProvider { get; set; }
    }
}
