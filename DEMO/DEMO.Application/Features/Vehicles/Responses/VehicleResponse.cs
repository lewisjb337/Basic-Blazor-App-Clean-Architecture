using DEMO.Domain.Entities;

namespace DEMO.Application.Features.Vehicles.Responses;

public class VehicleResponse
{
    public VehicleResponse() { }

    private VehicleResponse(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Make = vehicle.Make;
        Model = vehicle.Model;
        Year = vehicle.Year;
        Mileage = vehicle.Mileage;
        Owners = vehicle.Owners;
    }

    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int Owners { get; set; }

    public static implicit operator VehicleResponse(Vehicle vehicle) => new(vehicle);
}