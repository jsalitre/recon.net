namespace Recon.Entities.Attributes {
    public class HttpAttribute : ModuleAttribute {
        public string Url { get; set; }


        public HttpAttribute(string name, string url): base(name)
        {
            this.Url = url;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)] 
    public class ModuleAttribute : System.Attribute {
        public string Name { get; set; }


        public ModuleAttribute(string name)
        {
            this.Name = name;
        }
    }
}