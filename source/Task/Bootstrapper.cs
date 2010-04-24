using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Task
{
    class Bootstrapper
    {
        public Runner Init(IFeedbackProvider feedbackProvider, string[] args)
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(typeof(Bootstrapper).Assembly));

            var currentDir = Environment.CurrentDirectory;
            var assemblyDir = new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Directory.FullName;

            var paths = new string[]
            {
                assemblyDir,
                Path.Combine(assemblyDir, "Tasks"),
                currentDir,
                Path.Combine(currentDir, "Tasks")
            }.Unique();

            var dirCatalogs = paths.Where(x => Directory.Exists(x))
                                   .Select(x => new DirectoryCatalog(x, "*.Tasks.dll"));
            dirCatalogs.Apply(x => catalog.Catalogs.Add(x));

            var container = new CompositionContainer(catalog);

            var parsed = new ArgumentParser().Parse(args);
            var runner = new Runner(parsed.ActualArgs.ToArray());

            var batch = new CompositionBatch();
            batch.AddExportedValue<IFeedbackProvider>(feedbackProvider);
            parsed.Options.Apply(x => batch.AddExportedValue<string>(x.Item1, x.Item2));
            parsed.Switches.Apply(x => batch.AddExportedValue<bool>(x, true));
            batch.AddPart(runner);
            container.Compose(batch);

            return runner;
        }


    }

}
