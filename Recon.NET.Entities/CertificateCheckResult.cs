using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Recon.NET.Entities {

    public class CertificateCheckResult<TId, TNames> : ICertificateCheckResult<TId, TNames> {

        protected virtual string DateTimeFormat => "yyyy-MM-dd";

        [JsonPropertyName ("id")]
        public virtual TId Id { get; set; }

        [JsonPropertyName ("not_before")]
        protected virtual string ValidToDateString { get; set; }
        public virtual DateTime ValidFrom {
            get {
                return DateTime.Parse (this.ValidToDateString, CultureInfo.InvariantCulture);
            }
        }

        [JsonPropertyName ("not_after")]
        protected virtual string ValidFromDateString { get; set; }
        public virtual DateTime ValidTo {
            get {
                return DateTime.Parse (this.ValidFromDateString, CultureInfo.InvariantCulture);
            }
        }

        [JsonPropertyName ("dns_names")]
        public virtual TNames Name { get; set; }

    }

    public class CrtShCheckResult : CertificateCheckResult<long, string> {

        [JsonPropertyName ("name_value")]
        public override string Name { get; set; }

    }

    public class CertSpotterCertificateCheckResult : CertificateCheckResult<string, IEnumerable<string>> {

       

    }
}