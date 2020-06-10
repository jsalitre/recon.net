using System.Diagnostics;
using Recon.Entities;

namespace Recon.Modules {
    public abstract class ProcessModule : Module<ProcessOutputResult> {

        protected string Cmd { get; set; }
        protected string Args { get; set; }
        public ProcessModule () { }

        public override void Execute () {

            var pinfo = Utilities.CreateProcess (this.Cmd, this.Args);
            this.Output = new ProcessOutputResult ();
            using (var process = Process.Start (pinfo)) {

                var args = new NotifierEventArgs ();
                while (!process.StandardOutput.EndOfStream) {
                    var line = process.StandardOutput.ReadLine ();
                    args.Message = line;
                    this.Output.Result.Add(line);
                    OnNotification (args);
                }
            }
        }

    }
}