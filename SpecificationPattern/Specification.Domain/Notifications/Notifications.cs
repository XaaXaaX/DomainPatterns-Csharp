using System;
using System.Collections.Generic;

namespace Specification.Domain.Notifications;
public static class NotificationPublisher
{
    public static event EventHandler<NotificationEventArgs> RaiseNotificationEvent;
    public static void OnRaiseNotificationEvent(NotificationEventArgs e)
    {
        if (RaiseNotificationEvent == null)
            return;

        RaiseNotificationEvent(new object(), e);
    }
}

public class NotificationEventArgs : EventArgs
{
    public NotificationEventArgs(string message)
        => Message = message;

    public virtual string Message { get; init; }
}

public class Notification
{
    public IList<string> Errors = new List<string>();
    public bool IsValid => Errors.Count == 0;
}

public abstract class Notifier
{
    public readonly Notification Notifications = new Notification();

    protected Notifier()
        => NotificationPublisher.RaiseNotificationEvent += HandleNotificationEvent;

    public virtual void HandleNotificationEvent(object sender, NotificationEventArgs e)
    {
        if (Notifications.Errors.IndexOf(e.Message) == -1) 
        {
            Notifications.Errors.Add(e.Message);
        }
    }
}