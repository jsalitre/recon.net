using System;
using System.Threading.Tasks;

using Recon.NET.Entities;

namespace Recon.NET.Interfaces
{
    public interface IModule
    {
        void Execute();
        void Notify(NotifierEventArgs e);

        event EventHandler<NotifierEventArgs> Notifier;
        
    }
}