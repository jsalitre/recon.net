using System;
using System.Collections.Generic;

namespace Recon.NET.Entities
{
    public interface ICertificateCheckResult
    {
        string Id {get;set;}
        DateTime ValidFrom {get;set;}   
        DateTime ValidTo {get;set;}   
        IEnumerable<string> DNSNames {get;set;}

        
    }
}