using Microsoft.AspNetCore.Components;
using DEMO.Client.Services;

namespace DEMO.Client.Components.Pages.SubComponents;

public partial class ToastContainer
{
    [Inject]
    public NotificationsService? NotificationsService { get; set; }

    [Parameter]
    public EventCallback EventCallback { get; set; }

    protected override void OnInitialized()
    {
        NotificationsService!.OnCallback = EventCallback;
    }
}