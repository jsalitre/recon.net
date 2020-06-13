using System;
using Recon.NET.Entities;
using Recon.NET.Interfaces;
using Recon.NET.Modules;

namespace Recon.NET.Terminal {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write (ReconLogo.DrawLogo);
            Console.ResetColor ();

            var options = new Options (args).Init ();

            Utilities.Detect ();
            var result = Utilities.CheckModule ("python");

            // RUN AGAINST ALL MODULES DECLARED AND CHECK FOR ENVIRONMENT EXISTENCE

            IModule x = new Sublist3r (options);
            x.Notifier += (sender, args) => OnNotification (sender, args);
            x.Execute ();

            // // OUTPUT    
            // // var x = sublist3r.Output.Result;

            x = new CertSpotter (options);
            x.Notifier += (sender, args) => OnNotification (sender, args);
            x.Execute ();
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
                default:
                    break;
            }

            Console.WriteLine (args.Message);
            Console.ResetColor ();
        }

    }
}