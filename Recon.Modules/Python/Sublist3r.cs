using System;
using System.Collections.Generic;
using Recon.Entities;
using Recon.Entities.Attributes;

namespace Recon.Modules.Python {

    [Python ("Sublist3r")]
    public class Sublist3r : PythonModule {
        public Sublist3r (Uri domain) {

            
            this.Args = $"/opt/Sublist3r/sublist3r.py -d {domain.Host} --no-color";
        }

        public override void Execute() {

            base.Execute();
            
            List<string> parsedResults = new List<string>();    

            foreach(var x in this.Output.Result) {
                if(!x.StartsWith("[") && x.Contains("hackerone.com")) {
                    parsedResults.Add(x);
                }
            }
            this.Output.Result = parsedResults;


        }

       
    }
}