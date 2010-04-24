using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Default.Tasks.Generation
{
    [Export]
    class GenerationDefinitionLibrary
    {
        public IGenerationDefinition GetGeneratorDefinition(string name)
        {
            var generatorDef = GenerationDefinitions.FirstOrDefault(x => String.Equals(x.Metadata.GeneratorName, name, StringComparison.InvariantCultureIgnoreCase));
            if (generatorDef == null) return null;
            return generatorDef.Value;
        }

        [ImportMany]
        protected Lazy<IGenerationDefinition, IGenerationDefintionMetadata>[] GenerationDefinitions { get; set; }
    }
}
