using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace Task
{
    [TaskController("help", "displays help about specific tasks")]
    class Help : ITaskController
    {
        public string GetHelpText()
        {
            return "> task help <command name>\n\nDisplays help about the specified command.\nFor a full list of commands use 'task list' or 'task list --full'";
        }

        public void Execute(string[] args)
        {
            var commandName = args.FirstOrDefault();

            if (commandName == null)
                Feedback.WriteLine(GetHelpText());
            else
                ShowHelpForCommand(commandName);
        }

        private void ShowHelpForCommand(string commandName)
        {
            var command = Tasks.GetTask(commandName);
            if (command == null)
                throw new TaskNotFoundException(commandName);

            Feedback.WriteLine(command.GetHelpText());
        }

        [Import]
        protected TaskLibrary Tasks { get; set; }

        [Import(typeof(IFeedbackProvider))]
        protected IFeedbackProvider Feedback { get; set; }
    }
}
