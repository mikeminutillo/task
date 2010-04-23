using System;

namespace Task
{
    class TaskNotFoundException : Exception
    {
        public readonly string TaskName;

        public TaskNotFoundException(string taskName)
        {
            TaskName = taskName;
        }

        public override string Message
        {
            get
            {
                return String.Format("The task '{0}' could not be found.", TaskName);
            }
        }
    }
}
