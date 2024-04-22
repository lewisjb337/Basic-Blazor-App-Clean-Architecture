using DEMO.Client.Services;
using DEMO.Domain.Entities.System;

namespace DEMO.Client.Components.Wrappers;

public class NotificationWrapper(NotificationsService notificationService)
{
    public async void ExecuteWithNotificationAsync(Func<Task> action)
    {
        try
        {
            await action.Invoke();

            await notificationService.PushNotificationAsync(new Notification
            {
                Title = "Success",
                Message = "Operation carried out successfully",
                ErrorDetails = string.Empty,
                HeaderStyle = "background: rgb(16,36,54); background: linear-gradient(90deg, rgba(16,36,54,1) 0%, rgba(32,91,77,1) 43%, rgba(42,126,92,1) 72%, rgba(55,172,112,1) 91%, rgba(63,200,124,1) 96%, rgba(66,209,128,1) 100%, rgba(78,255,147,1) 100%);"
            });
        }
        catch (Exception e)
        {
            await notificationService.PushNotificationAsync(new Notification
            {
                Title = "Error",
                Message = "Operation failed to be carried out",
                ErrorDetails = e.Message,
                HeaderStyle = "background: rgb(16,36,54); background: linear-gradient(90deg, rgba(16,36,54,1) 0%, rgba(67,39,52,1) 50%, rgba(99,41,51,1) 70%, rgba(125,42,50,1) 85%, rgba(148,43,49,1) 95%, rgba(161,44,49,1) 100%, rgba(211,47,47,1) 100%);"
            });
        }
    }

    public async Task<T> ExecuteWithNotificationAsync<T>(Func<Task<T>> action)
    {
        try
        {
            var result = await action.Invoke();

            if (result is null || result is false)
                throw new Exception();

            await notificationService.PushNotificationAsync(new Notification
            {
                Title = "Success",
                Message = "Operation carried out successfully",
                ErrorDetails = string.Empty,
                HeaderStyle = "background: rgb(16,36,54); background: linear-gradient(90deg, rgba(16,36,54,1) 0%, rgba(32,91,77,1) 43%, rgba(42,126,92,1) 72%, rgba(55,172,112,1) 91%, rgba(63,200,124,1) 96%, rgba(66,209,128,1) 100%, rgba(78,255,147,1) 100%);"
            });

            return result;
        }
        catch (Exception e)
        {
            await notificationService.PushNotificationAsync(new Notification
            {
                Title = "Error",
                Message = "Operation failed to be carried out",
                ErrorDetails = e.Message,
                HeaderStyle = "background: rgb(16,36,54); background: linear-gradient(90deg, rgba(16,36,54,1) 0%, rgba(67,39,52,1) 50%, rgba(99,41,51,1) 70%, rgba(125,42,50,1) 85%, rgba(148,43,49,1) 95%, rgba(161,44,49,1) 100%, rgba(211,47,47,1) 100%);"
            });

            return default!;
        }
    }
}