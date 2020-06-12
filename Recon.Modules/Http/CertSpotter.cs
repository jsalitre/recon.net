using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Recon.Entities;
using Recon.Entities.Attributes;

namespace Recon.Modules.Http {
    [Http("CertSpotter", "https://certspotter.com/api/v0/certs?domain=")]
    public class CertSpotter : HttpModule {

        public CertSpotter (Options options) : base (options) {

            this.EndPoint = $"https://certspotter.com/api/v0/certs?domain={options.Target.Host}";
        }
        public override void Execute () {

            this.OnNotification (new StartNotifierEventArgs ("CertSpotter"));

            base.Execute ();

            var response = this.Output.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //parse json
            var parsedJSON = JObject.Parse(response);

            this.OnNotification (new EndNotificationEventArgs ("Completed"));

        }
    }
}