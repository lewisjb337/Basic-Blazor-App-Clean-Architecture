using DEMO.Domain.Shared;

namespace DEMO.Domain.Entities;

public class Vehicle :  BaseEntity
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int Owners { get; set; }
}