using System.Runtime.InteropServices;
using System.Text;

namespace Recon.Gears
{
    public static class Environment
    {
        public static string Detect() {

            var str = new StringBuilder();
            str.Append($"{WhichOS()} ({RuntimeInformation.ProcessArchitecture})");
            return str.ToString();
        }

        public static string WhichOS() {

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return "Linux";

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return "Windows";

            if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return "OSX";
            
            return string.Empty;            

        }
        
    }
}