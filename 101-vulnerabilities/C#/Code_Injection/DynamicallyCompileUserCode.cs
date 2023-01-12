using System.Reflection;

namespace _101_csharp_vulnerabilities.Code_Injection
{
    internal class DynamicallyCompileUserCode
    {
        public int ExecuteDynamicCode(HttpRequest request)
        {
            int exitCode = 0;
            String userCode = request.Form["Code"];

            CSharpCodeProvider compiler = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = true;

            try
            {
                CompilerResults results = compiler.CompileAssemblyFromSource(parameters, userCode);

                Assembly compiledAssembly = results.CompiledAssembly;
                exitCode = (int)compiledAssembly.EntryPoint.Invoke(null, new object[0]);
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }

            return exitCode;
        }
    }
}