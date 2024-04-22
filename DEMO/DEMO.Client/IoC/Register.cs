using DEMO.Client.Components.Wrappers;
using DEMO.Client.Services.Interfaces;
using DEMO.Client.Services;

namespace DEMO.Client.IoC;

public static class Register
{
    public static void UseNotificationServices(this IServiceCollection services)
    {
        services.AddScoped<NotificationsService>();
        services.AddScoped<NotificationWrapper>();
        services.AddScoped<IHttpClientService, HTTPClientService>();
    }
}