using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            using (var client = new HttpClient ()) {

                var response = client.SendAsync (new HttpRequestMessage (HttpMethod.Get, this.EndPoint)).GetAwaiter ();
                var result = response.GetResult ().Content.ReadAsStringAsync ().GetAwaiter ().GetResult ();
                var checkResult = JsonSerializer.Deserialize<IEnumerable<CertSpotterCertificateCheckResult>> (result);
                this.Notify (NotifierEventArgs.Debug (result));

            }

            // this.Notify (NotifierEventArgs.Debug (result));

            this.Notify (new EndNotificationEventArgs ("Completed"));

        }
    }
}