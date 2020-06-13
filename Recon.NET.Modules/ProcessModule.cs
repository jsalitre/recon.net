using System.Diagnostics;
using Recon.NET.Entities;
using Recon.NET.Modules;

namespace Recon.NET.Modules {
    public abstract class ProcessModule : Module<ProcessOutputResult> {

        protected string Cmd { get; set; }
        protected string Args { get; set; }
        public ProcessModule (Options options): base(options) {
            
        }

        public override void Execute () {

            Notify(new StartNotifierEventArgs("Executing..."));
            var pinfo = Utilities.CreateProcess (this.Cmd, this.Args);
            this.Output = new ProcessOutputResult ();
            using (var process = Process.Start (pinfo)) {

                
                while (!process.StandardOutput.EndOfStream) {
                    var line = process.StandardOutput.ReadLine ();
                    this.Output.Result.Add (line);
                    Notify (NotifierEventArgs.Info(line));
                }
            }
        }

    }
}