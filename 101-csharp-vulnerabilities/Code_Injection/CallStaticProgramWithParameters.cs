using System.Diagnostics;

namespace _101_csharp_vulnerabilities.Code_Injection
{
    internal class CallStaticProgramWithParameters
    {
        public int ExecuteProcessWithArguments(HttpRequest request)
        {
            int exitCode = 0;
            String userParams = request.Form["ExeParams"];

            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = PATH_TO_PRECOMPILED_EXTERNAL_PROGRAM;
                proc.StartInfo.Arguments = SanitizeForProcess(userParams);
                proc.StartInfo.UseShellExecute = false;

                proc.Start();
                proc.WaitForExit(MAX_TIMEOUT);

                exitCode = proc.ExitCode;
            }

            return exitCode;
        }
    }
}