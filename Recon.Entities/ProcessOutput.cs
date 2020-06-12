using System.Collections.Generic;
using System.Net.Http;

namespace Recon.Entities {
    public class ProcessOutputResult : OutputResult<IList<string>> {
        public ProcessOutputResult () {
            this.Result = new List<string> ();
        }
    }

 public class WebRequestOutputResult: OutputResult<HttpResponseMessage> 
 {
     
 }

    public class OutputResult<T> {
        public T Result { get; set; }
    }
}