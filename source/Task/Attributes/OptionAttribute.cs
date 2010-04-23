using System;
using System.ComponentModel.Composition;

namespace Task
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class OptionAttribute : ImportAttribute
    {
        public OptionAttribute(string optionName)
            : base(optionName)
        {
            this.AllowDefault = true;
        }
    }
}
