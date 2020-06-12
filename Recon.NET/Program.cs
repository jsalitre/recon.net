using System;
using Recon.Entities;
using Recon.Modules.Http;
using Recon.Modules.Python;

namespace Recon.NET {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write (ReconLogo.DrawLogo);
            Console.ResetColor();

            var options = new Options (args).Init ();

            Utilities.Detect ();
            var result = Utilities.CheckModule ("python");

            // RUN AGAINST ALL MODULES DECLARED AND CHECK FOR ENVIRONMENT EXISTENCE

            if (result.Exists) {

                var sublist3r = new Sublist3r (options.Target);
                sublist3r.Notifier+= (sender, args) => OnNotification(sender, args);
                sublist3r.Execute();

                // OUTPUT    
                var x = sublist3r.Output.Result;
            }

            var certSpotter = new CertSpotter (options);
            certSpotter.Notifier += (sender, args) => OnNotification (sender, args);
            certSpotter.Execute ();
            var y = certSpotter.Output.Result;

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
            Console.ResetColor();
        }

    }
}