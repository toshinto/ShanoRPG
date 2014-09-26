using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using System.IO;

namespace ScriptLib
{
    public class ScenarioCompiler
    {
        public const string OutputFile = "abilities.dll";

        public readonly string AbilityDir;


        public ScenarioCompiler(string scenarioDir)
        {
            this.AbilityDir = scenarioDir;
        }

        protected EmitResult Compile()
        {
            //get all the files in AbilityDir and compile them
            var files = Directory.EnumerateFiles(AbilityDir, "*.cs");

            return CompileFiles(files, OutputFile);
        }

        public EmitResult CompileFiles(IEnumerable<string> inFiles, string outFile)
        {
            //get the syntax tree
            var syntaxTrees = inFiles.Select(f => SyntaxTree.ParseFile(f));

            //create the compilation unit. 
            var compilation = Compilation.Create(outFile, 
                    syntaxTrees: syntaxTrees,
                    references: new[] {
                        new MetadataFileReference(getAssemblyDir("mscorlib.dll")),
                        new MetadataFileReference(getLocalDir("Engine.dll")),
                        new MetadataFileReference(getLocalDir("Output.dll")),
                    },

                    options: new CompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                );

            //do the compilation
            using (var file = new FileStream(outFile, FileMode.Create))
            {
                return compilation.Emit(file);
            }
        }

        protected static string getAssemblyDir(string path)
        {
            var assemblyDir = Path.GetDirectoryName(typeof(object).Assembly.Location);
            return Path.Combine(assemblyDir, path);
        }

        protected static string getLocalDir(string path)
        {
            var currentDir = Directory.GetCurrentDirectory();
            return Path.Combine(currentDir, path);
        }
    }
}