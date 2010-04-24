using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Default.Tasks.Generation
{
    public interface IGenerationContext
    {
        void AddFolder(string fullPath);
        void AddFile(string fullPath, IGenerator generator);
        IEnumerable<string> Args { get; }

        string GetArg(int index, string @default);
    }
}
