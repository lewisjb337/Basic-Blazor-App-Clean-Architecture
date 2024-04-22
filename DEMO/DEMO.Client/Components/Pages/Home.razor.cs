using DEMO.Application.Features.Vehicles.Responses;
using DEMO.Client.Components.Pages.Modals.VehicleManagement;
using DEMO.Client.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace DEMO.Client.Components.Pages;

[Authorize]
public partial class Home
{
    [Inject]
    public IHttpClientService? HttpClientService { get; set; }

    public IEnumerable<VehicleResponse>? Vehicles { get; set; }

    private CreateVehicleModal? Create { get; set; }
    private UpdateVehicleModal? Update { get; set; }
    private DeleteVehicleModal? Delete { get; set; }

    public string SearchText { get; set; } = string.Empty;

    protected async Task LoadData()
    {
        Vehicles = await HttpClientService!.GetEnumerable<VehicleResponse>("Vehicles");
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected async Task Refresh()
    {
        await LoadData();

        StateHasChanged();
    }
}