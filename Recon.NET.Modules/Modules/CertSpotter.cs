using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
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
            client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
            var result = client.GetStringAsync (this.EndPoint).GetAwaiter ().GetResult ();

            result = result.Replace (@"\", string.Empty).Replace (System.Environment.NewLine, "").Replace ("\r", string.Empty).Replace ("\t", string.Empty).Trim ();

            this.Notify(NotifierEventArgs.Debug(result));

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(result))) {
                
                DataContractJsonSerializer js = new DataContractJsonSerializer (typeof (IEnumerable<CertSpotterCertificateCheckResult>));
                var checkResult = (IEnumerable<CertSpotterCertificateCheckResult>)js.ReadObject(ms);

                foreach(var r in checkResult) {
                    this.Notify(NotifierEventArgs.Debug(r.ToString()));
                }

                //
            };

            // this.Notify (NotifierEventArgs.Debug (result));

            this.Notify (new EndNotificationEventArgs ("Completed"));

        }
    }
}