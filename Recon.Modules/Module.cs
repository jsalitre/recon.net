using System;
using Recon.Entities;

namespace Recon.Modules {
    public abstract class Module {

        public virtual event EventHandler<NotifierEventArgs> Notifier;
        public virtual void OnNotification (NotifierEventArgs e) {
            if (this.Notifier != null) {
                this.Notifier (this, e);
            }
        }
        


    }

    public abstract class Module<T> : Module {

        public T Output {get;set;}

        public abstract void Execute();
    }
}