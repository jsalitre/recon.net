using System;
using CommandLine;

namespace Recon.Gears {
    class Program {

        static void Main (string[] args) {

            args = new string[] { "-u http://hackerone.com", "-p ~/recon" };

            Console.Write (ReconLogo.DrawLogo);


            var parameters = new Parameters (args);
            parameters.Init();

            Console.WriteLine(Environment.Detect());


            if(!System.IO.Directory.Exists(parameters.WorkingPath))
                System.IO.Directory.CreateDirectory(parameters.WorkingPath);



        }
    }
}