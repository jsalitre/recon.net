namespace Recon.Modules
{
    public abstract class Module
    {
        public string Name { get; set; }

        public string Alias {get;set;}

        public string Command {get;set;}

        public string Args {get;set;}



        public Module() {

        }
        public Module(string name)
        {
            this.Name = name;
        }

        public Module(string name, string command, string args):this(name)
        {
            this.Command = command;
            this.Args = args;
        }

        public abstract void Run();
    }
}