using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

#pragma warning disable RS1035 // Do not use banned APIs for analyzers

namespace CSharpSourceGeneratorSamples;

[Generator]
public class HelloWorldGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        // begin creating the source we'll inject into the users compilation
        var sourceBuilder = new StringBuilder(@"
using System;
namespace HelloWorldGenerated
{
    public static class HelloWorld
    {
        public static void SayHello() 
        {
            Console.WriteLine(""Hello from generated code!"");
            Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
");

        // using the context, get a list of syntax trees in the users compilation
        var syntaxTrees = context.Compilation.SyntaxTrees;

        // add the filepath of each tree to the class we're building
        foreach (var tree in syntaxTrees)
        {
            sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
        }

        // finish creating the source to inject
        sourceBuilder.Append(@"
        }
    }
}");

        // inject the created source into the users compilation
        context.AddSource("helloWorldGenerated.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // No initialization required
    }
}
