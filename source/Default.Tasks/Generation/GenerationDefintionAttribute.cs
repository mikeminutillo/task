using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Default.Tasks.Generation
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class GenerationDefintionAttribute : ExportAttribute
    {
        public GenerationDefintionAttribute(string generatorName) : base(typeof(IGenerationDefinition))
        {
            GeneratorName = generatorName;
        }

        public string GeneratorName { get; set; }
    }
}
