using System;
using System.ComponentModel.Composition;

namespace Task
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SwitchAttribute : ImportAttribute
    {
        public SwitchAttribute(string switchName)
            : base(switchName)
        {
            this.AllowDefault = true;
        }
    }
}
