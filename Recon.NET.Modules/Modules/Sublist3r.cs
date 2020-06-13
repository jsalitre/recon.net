using System;
using System.Collections.Generic;
using Recon.NET.Entities;
using Recon.NET.Entities.Attributes;
using Recon.NET.Modules;

namespace Recon.NET.Modules {

    [Python ("Sublist3r")]
    public class Sublist3r : ProcessModule {
        public Sublist3r (Options options):base(options) {

            this.Cmd = "/usr/bin/python3";
            this.Args = $"/opt/Sublist3r/sublist3r.py -d {this.Options.Target.Host} --no-color";
        }

        public override void Execute () {

            base.Execute ();

            List<string> parsedResults = new List<string> ();

            foreach (var x in this.Output.Result) {
                if (!x.StartsWith ("[") && x.Contains(this.Options.Target.Host)) {
                    parsedResults.Add (x);
                }
            }
            this.Output.Result = parsedResults;

        }

    }
}