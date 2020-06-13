using System;
using System.IO;
using Recon.NET.Entities;

namespace Recon.NET.Modules {
    
    public class SystemFolders : Module<OutputResult> {
        public SystemFolders (Options options) : base (options) { }

        public override void Execute () {
            Notify (NotifierEventArgs.Warning ($"Creating system folders {this.Options.WorkingPath}"));
            CreateFolderStructure(this.Options);
        }

        private void CreateFolderStructure (Options options) {

            Notify(NotifierEventArgs.Info(options.WorkingPath));
            if (!Directory.Exists (options.WorkingPath))
                Directory.CreateDirectory (options.WorkingPath);

            
            // create recon folder structure        
            var contextPath = Path.Combine (options.WorkingPath, options.Target.Host);
            Notify(NotifierEventArgs.Info(contextPath, true));
            if (!Directory.Exists (contextPath))
                Directory.CreateDirectory (contextPath);

            contextPath = Path.Combine (contextPath, DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss"));
            Notify(NotifierEventArgs.Info(contextPath, true));
            if (!Directory.Exists (contextPath))
                Directory.CreateDirectory (contextPath);
        }
    }
}