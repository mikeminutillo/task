using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Default.Tasks.Generation
{
    class GeneratedItem
    {
        private Func<string, bool> _exists;
        private Action<string> _builder;

        private string _path;

        public GeneratedItem(string path, Action<string> builder, Func<string, bool> exists)
        {
            _path = path;
            _builder = builder;
            _exists = exists;
        }

        public bool Exists
        {
            get { return _exists(_path); }
        }

        public string Path
        {
            get { return _path; }
        }

        public void Create()
        {
            if (Exists) return;
            _builder(_path);
        }
    }
}
