using System;
using System.Collections.Generic;

namespace Recon.NET.Entities {
    public interface ICertificateCheckResult<IId, TDnsNames> {

        IId Id { get; set; }
        TDnsNames Name { get; set; }
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }

    }

}