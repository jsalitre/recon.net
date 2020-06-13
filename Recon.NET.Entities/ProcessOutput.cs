using System.Collections.Generic;
using System.Net.Http;

namespace Recon.NET.Entities {
    public class ProcessOutputResult : OutputResult<IList<string>> {
        public ProcessOutputResult () {
            this.Result = new List<string> ();
        }
    }

    public class WebRequestOutputResult : OutputResult<HttpResponseMessage> {

    }

    public class OutputResult<T> : OutputResult {
        public T Result { get; set; }
    }
    public class OutputResult {

    }
}