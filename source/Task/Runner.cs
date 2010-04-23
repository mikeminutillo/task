using System.ComponentModel.Composition;
using System.Linq;

namespace Task
{
    class Runner
    {
        private readonly string[] _args;

        public Runner(string[] args)
        {
            _args = args;
        }

        public void Run()
        {
            if (ShowVersion)
            {
                var version = typeof(Runner).Assembly.GetName().Version.ToString(2);
                Feedback.WriteLine("Task version {0}", version);
                return;
            }

            var taskName = _args.FirstOrDefault();
            if (taskName == null)
            {
                ShowUsage();
                taskName = "help";
            }
            var taskArgs = _args.Skip(1).ToArray();

            var task = Tasks.GetTask(taskName);
            if (task == null)
                throw new TaskNotFoundException(taskName);

            task.Execute(taskArgs);
        }

        private void ShowUsage()
        {
            Feedback.WriteLine("USAGE: task.exe <task name> [[<task arg>|--switch|-option value]...]");
        }

        [Switch("version")]
        protected bool ShowVersion { get; set; }

        [Import]
        protected TaskLibrary Tasks { get; set; }

        [Import(typeof(IFeedbackProvider))]
        protected IFeedbackProvider Feedback { get; set; }
    }
}
