using Recon.Entities;
using Recon.Entities.Attributes;

namespace Recon.Modules {
    public abstract class PythonModule : ProcessModule {
        public PythonModule () {
            this.Cmd = "/usr/bin/python3";
        }

    }
}