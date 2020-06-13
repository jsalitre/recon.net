using System;
using System.Collections.Generic;
using CommandLine;

namespace Recon.NET.Entities {

    public class Options {

        [Option ('u', "url", Required = true, HelpText = "target domain")]
        public Uri Target { get; set; }

        [Option ('p', "path", Required = true, HelpText = "root folder where all data is stored")]
        public string WorkingPath {get;set;}

        private string[] args;

        public Options () {

        }

        public Options (string[] args) {
            this.args = args;
            
        }

        public Options Init () {

            Parser.Default.ParseArguments<Options> (this.args)
                .WithParsed (RunOptions).WithNotParsed (HandleErrors);

            return this;
                
        }

        public void RunOptions (Options o) {
            Uri _targetUrl;
            if (!Uri.TryCreate (o.Target.ToString(), UriKind.Absolute, out _targetUrl)) {
                
            } else {
                this.Target = _targetUrl;
            }

            this.WorkingPath = o.WorkingPath;

        }

        public void HandleErrors (IEnumerable<Error> errors) {
            // foreach (var error in errors) {
            //     Console.WriteLine ($"Unhandle Error: {error}");
            // }
        }

    }
}