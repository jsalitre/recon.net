using System;

namespace Recon.NET.Entities {

    public class NotifierEventArgs : EventArgs {
        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public bool ReplaceLine { get; set; } = false;

        public NotifierEventArgs (string message) {
            this.Message = message;
        }
        public static NotifierEventArgs Info (string message, bool replaceLine = false) {
            return new InfoNotificationEventArgs (message) { ReplaceLine = replaceLine };
        }

        public static NotifierEventArgs Debug (string message, bool replaceLine = false) {
            return new DebugNotificationEventArgs (message) { ReplaceLine = replaceLine };
        }

        public static NotifierEventArgs Warning (string message, bool replaceLine = false) {
            return new WarningNotifierEventArgs (message) { ReplaceLine = replaceLine };
        }

    }

    public class StartNotifierEventArgs : NotifierEventArgs {
        public StartNotifierEventArgs (string message) : base (message) {
            this.Type = NotificationType.Info;

        }
    }

    public class WarningNotifierEventArgs : NotifierEventArgs {
        public WarningNotifierEventArgs (string message) : base (message) {
            this.Type = NotificationType.Warning;
        }
    }

    public class SuccessNotifierEventArgs : NotifierEventArgs {
        public SuccessNotifierEventArgs (string message = "") : base (message) {
            this.Type = NotificationType.Success;
        }
    }

    public class ErrorNotifierEventArgs : NotifierEventArgs {
        public ErrorNotifierEventArgs (string message) : base (message) {
            this.Message = message;
            this.Type = NotificationType.Error;
        }
    }

    public class EndNotificationEventArgs : StartNotifierEventArgs {
        public EndNotificationEventArgs (string message) : base (message) {

        }
    }

    public class InfoNotificationEventArgs : NotifierEventArgs {
        public InfoNotificationEventArgs (string message) : base (message) {
            this.Type = NotificationType.Info;
        }
    }

    public class DebugNotificationEventArgs : NotifierEventArgs {
        public DebugNotificationEventArgs (string message) : base (message) {
            this.Type = NotificationType.Debug;
        }
    }

}