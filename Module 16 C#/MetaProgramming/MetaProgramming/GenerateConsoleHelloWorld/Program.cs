using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;

namespace GenerateConsoleHelloWorld;
public static class Program
{
    private static void Main(params string[] args)
    {
        var prgNamespace = BuildProgram(args[0], args[1]);
        var compilerOptions = new CodeGeneratorOptions()
        {
            IndentString = " ",
            BracingStyle = "C",
            BlankLinesBetweenMembers = false
        };
        var codeText = new StringBuilder();
        using (var codeWriter = new StringWriter(codeText))
        {
            CodeDomProvider.CreateProvider("c#")
                .GenerateCodeFromNamespace(
                    prgNamespace, codeWriter, compilerOptions);
        }
        var script = codeText.ToString();
        Console.WriteLine(script);
    }

    static CodeNamespace BuildProgram(string nameSpace, string helloWorldStatement)
    {
        var ns = new CodeNamespace(nameSpace);
        var systemImport = new CodeNamespaceImport("System");
        ns.Imports.Add(systemImport);
        var programClass = new CodeTypeDeclaration("Program");
        ns.Types.Add(programClass);
        var mainMethod = new CodeMemberMethod
        {
            Name = "Main",
            Attributes = MemberAttributes.Static
        };
        mainMethod.Statements.Add(new CodeMethodInvokeExpression(
            new CodeSnippetExpression("Console"), "WriteLine", new CodePrimitiveExpression(helloWorldStatement)));
        programClass.Members.Add(mainMethod);
        return ns;
    }
}
