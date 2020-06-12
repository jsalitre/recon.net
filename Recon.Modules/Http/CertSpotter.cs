using Recon.Entities;
using Recon.Entities.Attributes;

namespace Recon.Modules.Http {
    [Http (Url = "https://certspotter.com/api/v0/certs?domain=")]
    public class CertSpotter : HttpModule {

        public CertSpotter (Options options) : base (options) {

            this.EndPoint = $"https://certspotter.com/api/v0/certs?domain={options.Target.Host}";
        }
        public override void Execute () {

            this.OnNotification (new NotifierEventArgs () { Message = "CertSpotter request!!!" });

            base.Execute ();

            var i = this.Output.Result;

            //parse json





            this.OnNotification (new NotifierEventArgs () { Message = "CertSpotter request end!!!" });

        }
    }
}