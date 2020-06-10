using System;
using System.Collections.Generic;
using CommandLine;

namespace Recon.Entities {

    public class Parameters {

        [Option ('u', "url", Required = true, HelpText = "target domain")]
        public string Url { get; set; }

        [Option ('p', "path", Required = true, HelpText = "root folder where all data is stored")]
        public string WorkingPath {get;set;}

        private string[] args;

        public Parameters () {

        }

        public Parameters (string[] args) {
            this.args = args;
            
        }

        public Parameters Init () {

            Parser.Default.ParseArguments<Parameters> (this.args)
                .WithParsed (RunOptions).WithNotParsed (HandleErrors);

            return this;
                
        }

        public void RunOptions (Parameters o) {
            Uri _targetUrl;
            if (!Uri.TryCreate (o.Url, UriKind.Absolute, out _targetUrl)) {
                
            } else {
                this.Url = o.Url;
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