using System;
using System.IO;
using Recon.NET.Entities;
using Recon.NET.Interfaces;
using Recon.NET.Modules;

namespace Recon.NET.Terminal {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p /home/jsalitre/recon" };
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write (ReconLogo.DrawLogo);
            Console.ResetColor ();

            var options = new Options (args).Init ();

            Utilities.Detect ();
            var result = Utilities.CheckModule ("python");

            // RUN AGAINST ALL MODULES DECLARED AND CHECK FOR ENVIRONMENT EXISTENCE
            IModule currentScope = null;
            currentScope = new SystemFolders (options);
            currentScope.Notifier += (sender, args) => OnNotification (sender, args);
            //currentScope.Execute ();
            // currentScope = new Sublist3r (options);
            // currentScope.Notifier += (sender, args) => OnNotification (sender, args);
            // currentScope.Execute ();

            // // OUTPUT    
            // // var x = sublist3r.Output.Result;currentScope = new CertSpotter (options);

            currentScope = new CertSpotter (options);
            currentScope.Notifier += (sender, args) => OnNotification (sender, args);
            currentScope.Execute ();
            // var y = current.Output.Result;

        }
        private static void OnNotification (object sender, NotifierEventArgs args) {

            switch (args.Type) {
                case NotificationType.Info:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case NotificationType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                    case NotificationType.Debug:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            if (args.ReplaceLine) {
                Console.Write ($"\r{args.Message}");
            } else {
                Console.WriteLine (args.Message);
            }

            Console.ResetColor ();
        }

    }
}