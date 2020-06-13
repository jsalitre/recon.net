using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Recon.NET.Entities;

namespace Recon.NET.Entities {
    public static class Utilities {
        public static string Execute (this string cmd, string args) {

            var escape = cmd.Replace ("\"", "\\\"");

            var pinfo = new ProcessStartInfo ();
            pinfo.FileName = escape;
            pinfo.Arguments = args;
            pinfo.UseShellExecute = false;
            pinfo.RedirectStandardOutput = true;
            using (var process = Process.Start (pinfo)) {
                var strBuilder = new StringBuilder ();

                while (!process.StandardOutput.EndOfStream) {
                    return process.StandardOutput.ReadLine ();
                }

                return strBuilder.ToString ();
            }
        }

        public static ProcessStartInfo CreateProcess (string cmd, string args) { 

            var escape = cmd.Replace ("\"", "\\\"");

            var pinfo = new ProcessStartInfo ();
            pinfo.FileName = escape;
            pinfo.Arguments = args;
            pinfo.UseShellExecute = false;
            pinfo.RedirectStandardOutput = true;
            return pinfo;

        }

        public static ModuleCheckResult CheckModule (string name) {
            var result = Execute ("/usr/bin/bash", $"which {name}");
            return new ModuleCheckResult () { ModulePath = result };
        }

        public static string Detect () {

            var str = new StringBuilder ();
            str.Append ($"{WhichOS()} ({RuntimeInformation.ProcessArchitecture})");
            return str.ToString ();
        }

        public static string WhichOS () {

            if (RuntimeInformation.IsOSPlatform (OSPlatform.Linux))
                return "Linux";

            if (RuntimeInformation.IsOSPlatform (OSPlatform.Windows))
                return "Windows";

            if (RuntimeInformation.IsOSPlatform (OSPlatform.OSX))
                return "OSX";

            return string.Empty;

        }

    }
}