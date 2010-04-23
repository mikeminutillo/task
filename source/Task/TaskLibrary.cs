using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace Task
{
    [Export]
    class TaskLibrary
    {
        public ITaskController GetTask(string name)
        {
            var taskDef = Tasks.FirstOrDefault(x => String.Equals(x.Metadata.TaskName, name, StringComparison.InvariantCultureIgnoreCase));
            if (taskDef == null) return null;
            return taskDef.Value;
        }

        public ITaskMetadata[] GetAllMetaData()
        {
            return Tasks.Select(x => x.Metadata).ToArray();
        }

        [ImportMany]
        protected Lazy<ITaskController, ITaskMetadata>[] Tasks { get; set; }
    }
}
