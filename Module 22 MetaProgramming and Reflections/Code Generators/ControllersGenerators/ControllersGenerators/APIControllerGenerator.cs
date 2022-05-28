using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;
using ControllersGenerators.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;

namespace ControllersGenerators
{
    [Generator]
    public class APIControllerGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {

            // Find the main method
            var mainMethod = context.Compilation.GetEntryPoint(context.CancellationToken);

            // Build up the source code
            string source = $@" // Auto-generated code
                                    using System;

                                    namespace {mainMethod.ContainingNamespace.ToDisplayString()}
                                    {{
                                        public static partial class {mainMethod.ContainingType.Name}
                                        {{
                                            static partial void HelloFrom(string name) =>
                                                Console.WriteLine($""Helllsscedc ec ec"");
                                        }}
                                    }}
                                    ";
            var typeName = mainMethod.ContainingType.Name;

            // Add the source code to the compilation
            //context.AddSource($"{nameof(APIControllerModelAttribute)}.g.cs", EmbeddedSources.APIControlllerModelAttribute);
            //context.AddSource($"{nameof(ControllerActions)}.g.cs", EmbeddedSources.ControllersActions);
            context.AddSource($"{typeName}.g.cs", source);

        }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {

            // Register the attribute and enum sources
            //context.RegisterPostInitializationOutput(i =>
            //{
            //    i.AddSource($"{nameof(APIControllerModelAttribute)}.g.cs", EmbeddedSources.APIControlllerModelAttribute);
            //    i.AddSource($"{nameof(ControllerActions)}.g.cs", EmbeddedSources.ControllersActions);
            //});

    //        IncrementalValuesProvider<AttributeSyntax> defaultAttributesDeclarations = context.SyntaxProvider
    //.CreateSyntaxProvider(
    //    predicate: static (s, _) => Parser.IsAttributeTargetForGeneration(s),
    //    transform: static (ctx, _) => Parser.GetAssemblyAttributeSemanticTargetForGeneration(ctx))
    //.Where(static m => m is not null)!;

    //        IncrementalValueProvider<(ImmutableArray<StructDeclarationSyntax>, ImmutableArray<AttributeSyntax>)> targetsAndDefaultAttributes
    //= structDeclarations.Collect().Combine(defaultAttributesDeclarations.Collect());

    //        IncrementalValueProvider<(Compilation Left, (ImmutableArray<StructDeclarationSyntax>, ImmutableArray<AttributeSyntax>) Right)> compilationAndValues
    //            = context.CompilationProvider.Combine(targetsAndDefaultAttributes);

    //        context.RegisterSourceOutput(compilationAndValues,
    //                 static (spc, source) => Execute(source.Item1, source.Item2.Item1, source.Item2.Item2, spc));

        }

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}


