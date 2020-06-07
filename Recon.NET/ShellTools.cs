using System;
using System.Diagnostics;
using System.ComponentModel;

namespace Recon.NET
{
    public static class ShellTools
    {
        public static string RunAsShell(this string cmd) {

         var escape = cmd.Replace("\"", "\\\"");
         return escape;

        }
        
    }
}