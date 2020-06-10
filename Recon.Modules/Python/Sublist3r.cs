using Recon.Entities;
using Recon.Entities.Attributes;

namespace Recon.Modules.Python
{

    [Python("Sublist3r")]
    public class Sublist3r: PythonModule
    {
        public Sublist3r()
        {
            
        }

        public override  void Run() {
            var result = Utilities.Execute("/usr/bin/python3", "/opt/Sublist3r/sublist3r.py -d hackerone.com");

            var i = 4;



        }
    }
}