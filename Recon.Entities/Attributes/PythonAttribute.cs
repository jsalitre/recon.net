using System;

namespace Recon.Entities.Attributes
{

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)] 
    public class PythonAttribute: Attribute
    {
        public PythonAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}