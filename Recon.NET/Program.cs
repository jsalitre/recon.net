using System;
using Recon.Entities;

namespace Recon.NET {

    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };

            Console.Write (ReconLogo.DrawLogo);

            var parameters = new Parameters(args).Init();
        
            Utilities.Detect();
            var result = Utilities.CheckModule("python");
            if(result.Exists) { 


                    var s =new Modules.Python.Sublist3r();
                    s.Run();


                    var x = 0;


            }

        
            // if(!System.IO.Directory.Exists(parameters.WorkingPath))
            //     System.IO.Directory.CreateDirectory(parameters.WorkingPath);



        }
    }
}