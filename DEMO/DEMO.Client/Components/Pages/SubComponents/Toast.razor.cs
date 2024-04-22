using Microsoft.AspNetCore.Components;
using DEMO.Client.Services;
using DEMO.Domain.Entities.System;

namespace DEMO.Client.Components.Pages.SubComponents;

public partial class Toast
{
    [Inject]
    NotificationsService? NotificationsService { get; set; }

    [Parameter]
    public Notification? Notification { get; set; }

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(6000);

        await NotificationsService!.DeleteNotificationAsync(Notification!);
    }
}