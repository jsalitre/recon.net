using System;

namespace Recon.NET.Entities {

    public class NotifierEventArgs : EventArgs {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }

    public class StartNotifierEventArgs : NotifierEventArgs {
        public StartNotifierEventArgs (string message) {
            this.Type = NotificationType.Info;
            this.Message = $"Executing [{message}]...";
        }
    }

    public class WarningNotifierEventArgs : NotifierEventArgs {
        public WarningNotifierEventArgs () {
            this.Type = NotificationType.Warning;
        }
    }

     public class SuccessNotifierEventArgs : NotifierEventArgs {
        public SuccessNotifierEventArgs () {
            this.Type = NotificationType.Success;
        }
    }

    public class ErrorNotifierEventArgs : NotifierEventArgs {
        public ErrorNotifierEventArgs (string message) {
            this.Message = message;
            this.Type = NotificationType.Error;
        }
    }

    public class EndNotificationEventArgs : StartNotifierEventArgs {
        public EndNotificationEventArgs(string message):base(message)
        {
            
        }
    }
}