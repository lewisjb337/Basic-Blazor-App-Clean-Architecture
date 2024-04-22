using DEMO.Application.Features.Vehicles.Responses;
using DEMO.Client.Components.Pages.SubComponents;
using DEMO.Client.Components.Wrappers;
using DEMO.Client.Services.Interfaces;
using DEMO.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages.Modals.VehicleManagement;

public partial class UpdateVehicleModal
{
    [Inject]
    public NotificationWrapper? NotificationWrapper { get; set; }

    [Inject]
    public IHttpClientService? HttpClientService { get; set; }

    [Parameter]
    public EventCallback<bool> OnModalClosed { get; set; }

    public IEnumerable<VehicleResponse>? Vehicles { get; set; }

    private Modal? _modal;

    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int Owners { get; set; }
    public bool IsDisabled = false;

    public async Task Open(VehicleResponse vehicle)
    {
        Id = vehicle.Id;

        await LoadData(vehicle.Id);

        _modal!.ShowModal();

        StateHasChanged();
    }

    protected async Task LoadData(int? roleId)
    {

        var userRoles = await HttpClientService!.GetEnumerable<VehicleResponse>("Vehicles");
        var role = userRoles.Where(x => x.Id.Equals(roleId)).FirstOrDefault()!;

        Id = role.Id;
        Make = role.Make;
        Model = role.Model;
        Year = role.Year;
        Mileage = role.Mileage;
        Owners = role.Owners;
    }

    public async Task Update()
    {
        IsDisabled = true;

        await NotificationWrapper!.ExecuteWithNotificationAsync(async () => await HttpClientService!.Patch("Vehicles", new Vehicle
        {
            Id = Id,
            Make = Make,
            Model = Model,
            Year = Year,
            Mileage = Mileage,
            Owners = Owners
        }));

        // Delay task to allow for operation to be carried out
        await Task.Delay(3000);

        await _modal!.Close();

        StateHasChanged();

        IsDisabled = false;
    }
}