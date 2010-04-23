using System;
using System.Collections.Generic;

namespace Task
{
    class ParsedArgs
    {
        private readonly IList<string> _actualArgs = new List<string>();
        private readonly IList<string> _switches = new List<string>();
        private readonly IList<Tuple<string, string>> _options = new List<Tuple<string, string>>();

        public IEnumerable<string> ActualArgs
        {
            get { return _actualArgs; }
        }

        public IEnumerable<string> Switches
        {
            get { return _switches; }
        }

        public IEnumerable<Tuple<string, string>> Options
        {
            get { return _options; }
        }

        public void AddArg(string arg)
        {
            _actualArgs.Add(arg);
        }

        public void AddSwitch(string switchName)
        {
            _switches.Add(switchName);
        }

        public void AddOption(string name, string @value)
        {
            _options.Add(Tuple.Create(name, @value));
        }

    }

}
