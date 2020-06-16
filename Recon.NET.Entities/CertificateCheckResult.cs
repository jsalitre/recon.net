using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Recon.NET.Entities {
    [DataContract]
    public class CertificateCheckResult : ICertificateCheckResult {
        public virtual string Id { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
        public virtual IEnumerable<string> DNSNames { get; set; }
    }

    [DataContract]
    public class CertSpotterCertificateCheckResult : ICertificateCheckResult {

        private const string DateTimeFormat = "yyyy-MM-dd";

        [DataMember (Name = "id")]
        public virtual string Id { get; set; }

        [DataMember (Name = "dns_names")]
        public IEnumerable<string> DNSNames { get; set; }

        public DateTime ValidFrom {
            get {
                return DateTime.Parse (this.ValidFromDate, CultureInfo.InvariantCulture);
            }
            set {
                this.ValidFromDate = value.ToString (DateTimeFormat);
            }
        }

        [DataMember (Name = "not_before")]
        public string ValidFromDate { get; set; }

        public DateTime ValidTo {
            get {
                return DateTime.Parse(this.ValidToDate, CultureInfo.InvariantCulture);
            }
            set {
                this.ValidToDate = value.ToString (DateTimeFormat);
            }
        }

        [DataMember (Name = "not_after")]
        public string ValidToDate { get; set; }

        public override string ToString() {

            var dns_names = string.Join("=>", this.DNSNames);

            return $"{this.Id}|{dns_names}|valid_from:{this.ValidFromDate}|valid_to:{this.ValidToDate}";
        }

    }
}