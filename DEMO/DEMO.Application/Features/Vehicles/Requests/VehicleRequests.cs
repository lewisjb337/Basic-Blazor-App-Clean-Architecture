namespace DEMO.Application.Features.Vehicles.Requests;

public record GetVehicleRequest(int? Id);
public record CreateVehicleRequest(string Make, string Model, int Year, int Mileage, int Owners);
public record UpdateVehicleRequest(int Id, string Make, string Model, int Year, int Mileage, int Owners);
public record DeleteVehicleRequest(int Id);