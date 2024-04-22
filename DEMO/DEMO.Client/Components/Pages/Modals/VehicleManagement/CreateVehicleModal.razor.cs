using DEMO.Application.Features.Vehicles.Responses;
using DEMO.Client.Components.Pages.SubComponents;
using DEMO.Client.Components.Wrappers;
using DEMO.Client.Services.Interfaces;
using DEMO.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages.Modals.VehicleManagement;

public partial class CreateVehicleModal
{
    [Inject]
    public NotificationWrapper? NotificationWrapper { get; set; }

    [Inject]
    public IHttpClientService? HttpClientService { get; set; }

    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    public IEnumerable<VehicleResponse>? Vehicles { get; set; }

    private Modal? _modal;

    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int Owners { get; set; }
    public bool IsDisabled = false;

    protected async Task LoadData()
    {
        Vehicles = await HttpClientService!.GetEnumerable<VehicleResponse>("Vehicles");
    }

    public async Task Open()
    {
        await LoadData();

        _modal!.ShowModal();

        StateHasChanged();
    }

    public async Task Add()
    {
        IsDisabled = true;

        await NotificationWrapper!.ExecuteWithNotificationAsync(async () => await HttpClientService!.Post("Vehicles", new Vehicle
        {
            Make = Make,
            Model = Model,
            Year = Year,
            Mileage = Mileage,
            Owners = Owners
        }));

        ClearFields();

        // Delay task to allow for operation to be carried out
        await Task.Delay(3000);

        await _modal!.Close();

        StateHasChanged();

        IsDisabled = false;
    }

    public void ClearFields()
    {
        Make = string.Empty;
        Model = string.Empty;
        Year = 0;
        Mileage = 0;
        Owners = 0;
    }
}