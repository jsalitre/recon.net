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

    public abstract class Module<T> : Module where T : class, new () {

        public Module () {

        }

        public Module (Options options) {
            this.Options = options;
        }
        protected Options Options { get; set; }

        public T Output { get; set; } = new T ();

        public abstract void Execute ();
    }
}