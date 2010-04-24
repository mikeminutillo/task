using System;
using System.ComponentModel.Composition;
using Task;

namespace Default.Tasks.Tasks
{
    [TaskController("sysinfo", "Displays information about your system")]
    public class SystemInfoTask : ITaskController
    {
        public string GetHelpText()
        {
            return "> task sysinfo";
        }

        public void Execute(string[] args)
        {
            Feedback.WriteLine("-= SYSTEM INFORMATION =-");

            Feedback.WriteLine("Machine Name: {0}", Environment.MachineName);
            Feedback.WriteLine("OS Verison  : {0}", Environment.OSVersion);
            Feedback.WriteLine("# Processors: {0}", Environment.ProcessorCount);
            Feedback.WriteLine("User Name    : {0}", Environment.UserName);
        }

        [Import(typeof(IFeedbackProvider))]
        protected IFeedbackProvider Feedback { get; set; }
    }
}
