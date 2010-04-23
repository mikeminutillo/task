using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace Task
{
    [TaskController("list", "displays a list of avaliable tasks")]
    class List : ITaskController
    {
        public string GetHelpText()
        {
            return String.Format("> task list [--full]\n\nProvides a list of all available tasks\n\nIf you provide the --full switch then a description is shown for each task.");
        }

        public void Execute(string[] args)
        {
            Feedback.WriteLine("Available Tasks");
            if (FullList)
                ShowFull();
            else
                ShowNames();
        }

        private void ShowFull()
        {
            var allMetaData = TaskLibrary.GetAllMetaData();
            var maxLength = allMetaData.Max(x => x.TaskName.Length);

            var formatString = String.Format("{{0,-{0}}} : {{1}}", maxLength);

            foreach (var metadata in TaskLibrary.GetAllMetaData())
            {
                Feedback.WriteLine(formatString, metadata.TaskName, metadata.TaskDescription);
                Feedback.WriteLine("");
            }
        }

        private void ShowNames()
        {
            Feedback.WriteLine(String.Join(", ", TaskLibrary.GetAllMetaData().Select(x => x.TaskName)));
        }

        [Switch("full")]
        protected bool FullList { get; set; }

        [Import]
        protected TaskLibrary TaskLibrary { get; set; }

        [Import(typeof(IFeedbackProvider))]
        protected IFeedbackProvider Feedback { get; set; }
    }
}
