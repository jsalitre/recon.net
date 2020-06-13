using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Recon.NET.Entities;
using Recon.NET.Entities.Attributes;

namespace Recon.NET.Modules {

    [Http ("CertSpotter", "https://api.certspotter.com/v1/issuances?domain={domain}&include_subdomains=true&expand=dns_names")]
    public class CertSpotter : HttpModule {

        public CertSpotter (Options options) : base (options) {

            this.EndPoint = $"https://api.certspotter.com/v1/issuances?domain={options.Target.Host}&include_subdomains=true&expand=dns_names";
        }
        public override void Execute () {

            this.Notify (NotifierEventArgs.Info ($"Executing CertSpotter v1"));

            HttpClient client = new HttpClient ();
            client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("appliation/json"));
            var result = client.GetStringAsync (this.EndPoint).GetAwaiter ().GetResult ();

            var x = result.Replace (@"\", string.Empty).Replace (System.Environment.NewLine, "").Replace ("\r", string.Empty).Replace ("\t", string.Empty).Trim ();

            var list_dns = JArray.Parse (x);

            // foreach (var item in list_dns) {
            //     var i = item["dns_names"];
            //     if (i != null) {
            //         foreach (var name in i.Children) {
            //             Notify (NotifierEventArgs.Info ($"Dns_name: {name}"));
            //         }
            //     }
            // }

            this.Notify (NotifierEventArgs.Debug (x));

            this.Notify (new EndNotificationEventArgs ("Completed"));

        }
    }
}