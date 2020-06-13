using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Recon.NET.Entities;
using Recon.NET.Modules;

namespace Recon.NET.Modules {
    public class HttpModule : Module<WebRequestOutputResult> {

        public string EndPoint { get; set; } = "";

        public HttpModule (Options options) : base (options) {

        }

        public override void Execute () {

            try {
            var client = new HttpClient ();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var output = Task.FromResult (client.GetAsync (this.EndPoint)).GetAwaiter ();

            var result = output.GetResult ().Result;

            if (result.StatusCode == HttpStatusCode.OK) {
                var notification = new SuccessNotifierEventArgs ();
            
                Notify (notification);
                 this.Output.Result = result;
            }
            } catch (Exception e) {
                Notify(new ErrorNotifierEventArgs(e.InnerException.Message));
            }

           

        }

    }
}