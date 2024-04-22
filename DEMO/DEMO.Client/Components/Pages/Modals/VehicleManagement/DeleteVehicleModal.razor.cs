using DEMO.Client.Components.Pages.SubComponents;
using DEMO.Client.Components.Wrappers;
using DEMO.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages.Modals.VehicleManagement;

public partial class DeleteVehicleModal
{
    [Inject]
    public NotificationWrapper? NotificationWrapper { get; set; }

    [Inject]
    public IHttpClientService? HttpClientService { get; set; }

    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    private Modal? _modal;

    public int? Id { get; set; }
    public bool isDisabled = false;

    public async Task Open(int? id)
    {
        Id = id;

        _modal!.ShowModal();

        StateHasChanged();
    }
    public async Task Delete()
    {
        isDisabled = true;

        await NotificationWrapper!.ExecuteWithNotificationAsync(async () => await HttpClientService!.Delete($"Vehicles/{Id}"));

        // Delay task to allow for operation to be carried out
        await Task.Delay(3000);

        await _modal!.Close();

        StateHasChanged();

        isDisabled = false;
    }
}