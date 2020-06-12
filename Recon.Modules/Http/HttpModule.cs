using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Recon.Entities;

namespace Recon.Modules.Http {
    public class HttpModule : Module<WebRequestOutputResult> {

        public string EndPoint { get; set; } = "";

        public HttpModule (Options options) : base (options) {

        }

        public override void Execute () {

            var client = new HttpClient ();
            var output = Task.FromResult (client.GetAsync (this.EndPoint)).GetAwaiter ();

            var result = output.GetResult ().Result;

            if (result.StatusCode == HttpStatusCode.OK) {
                var notification = new NotifierEventArgs ();
                notification.Message = "Ok";

                OnNotification (notification);
            }

            this.Output.Result = result;

        }

    }
}