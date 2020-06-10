using System.Collections.Generic;

namespace Recon.Entities {
    public class ProcessOutputResult : OutputResult<IList<string>> {
        public ProcessOutputResult () {
            this.Result = new List<string> ();
        }
    }

    public class OutputResult<T> {
        public T Result { get; set; }
    }
}