using System;
using Recon.NET.Entities;
using Recon.NET.Interfaces;

namespace Recon.NET.Modules
{
    public abstract class Module<T> : IModule where T : class, new()
    {
        public Module(Options options)
        {
            this.Options = options;
        }

        internal Options Options { get; private set; }

        public T Output { get; set; } = new T();

        public abstract void Execute();

        public event EventHandler<NotifierEventArgs> Notifier;

        public void Notify(NotifierEventArgs e)  { 

                if(this.Notifier != null) {
                    this.Notifier(this, e);
                }

        }

    }
}