using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Default.Tasks.Generation;

namespace Default.Tasks
{
    [GenerationDefintion("general")]
    class GeneralFilesGenerator : IGenerationDefinition
    {
        public void Apply(IGenerationContext generationContext)
        {
            var projectName = generationContext.GetArg(0, "<project name>");
            var year = DateTime.Today.ToString("yyyy");
            var copyrightHolder = generationContext.GetArg(1, "<copyright holder>");

            generationContext.AddFolder(@"foo\bar\berry");
            generationContext.AddFile("README", new ContentGenerator(String.Format(ReadmeTemplate, projectName)));
            generationContext.AddFile("LICENSE", new ContentGenerator(String.Format(LicenceTemplate, year, copyrightHolder)));
            generationContext.AddFile("TODO", new ContentGenerator(TodoTemplate));
        }



        public const string ReadmeTemplate = @"
{0}
==============

TODO: description of project

";

        public const string LicenceTemplate = @"
Copyright (c) {0} {1}

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.";

        public const string TodoTemplate = @"
TODO
====

* Write Tests
* Write Code
* Update Readme
* Check Licence
";
    }
}
