namespace Recon.NET.Entities {
    public class ModuleCheckResult {
        public string ModulePath { get; set; }

        public bool Exists => !string.IsNullOrWhiteSpace (ModulePath);
    }
}