using Microsoft.AspNetCore.Components;
using DEMO.Domain.Entities.System;

namespace DEMO.Client.Services;

public class NotificationsService
{
    public List<Notification> Notifications { get; set; } = [];

    public EventCallback OnCallback { get; set; }

    public async Task PushNotificationAsync(Notification notification)
    {
        Notifications.Add(notification);
        await OnCallback.InvokeAsync();
    }

    public async Task DeleteNotificationAsync(Notification notification)
    {
        Notifications.Remove(notification);
        await OnCallback.InvokeAsync();
    }
}