using System;
using Recon.Entities;
using Recon.Modules.Python;
using Recon.Modules.Http;

namespace Recon.NET {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };

            Console.Write (ReconLogo.DrawLogo);

            var options = new Options (args).Init ();

            Utilities.Detect ();
            var result = Utilities.CheckModule ("python");

            // RUN AGAINST ALL MODULES DECLARED AND CHECK FOR ENVIRONMENT EXISTENCE


            // if (result.Exists) {

            //     var sublist3r = new Sublist3r (options.Target);
            //     sublist3r.Notifier+= (sender, args) => OnNotification(sender, args);
            //     sublist3r.Execute();

            //     // OUTPUT    
            //     var x = sublist3r.Output.Result;
            // }


            var certSpotter = new CertSpotter(options);
            certSpotter.Notifier += (sender, args) => OnNotification(sender, args);
            certSpotter.Execute();
            var y = certSpotter.Output.Result;
            

        }
        private static void OnNotification(object sender, NotifierEventArgs args) => Console.WriteLine(args.Message);

    }
}