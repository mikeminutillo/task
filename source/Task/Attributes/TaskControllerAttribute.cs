using System;
using System.ComponentModel.Composition;

namespace Task
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TaskControllerAttribute : ExportAttribute
    {
        private TaskControllerAttribute()
            : base(typeof(ITaskController))
        {

        }

        public TaskControllerAttribute(string taskName, string description)
            : this()
        {
            TaskName = taskName;
            TaskDescription = description;
        }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
    }
}
