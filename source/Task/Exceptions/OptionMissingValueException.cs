using System;

namespace Task
{
    class OptionMissingValueException : Exception
    {
        public readonly string OptionName;

        public OptionMissingValueException(string optionName)
        {
            OptionName = optionName;
        }

        public override string Message
        {
            get
            {
                return String.Format("The Option '{0}' is missing its value.", OptionName);
            }
        }
    }
}
