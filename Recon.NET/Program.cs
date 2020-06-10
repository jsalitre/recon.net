using System;
using Recon.Entities;

namespace Recon.NET {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };

            Console.Write (ReconLogo.DrawLogo);

            var options = new Options (args).Init ();

            Utilities.Detect ();
            var result = Utilities.CheckModule ("python");

            // RUN AGAINST ALL MODULES DECLARED AND CHECK FOR ENVIRONMENT EXISTENCE


            if (result.Exists) {

                var s = new Modules.Python.Sublist3r (options.Url);
                s.Notifier+= (object sender, NotifierEventArgs args) => { Console.WriteLine(args.Message); };
                s.Execute();

                var x = s.Output.Result;
            }

            // if(!System.IO.Directory.Exists(parameters.WorkingPath))
            //     System.IO.Directory.CreateDirectory(parameters.WorkingPath);

        }
    }
}