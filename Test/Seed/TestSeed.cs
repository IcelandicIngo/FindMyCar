namespace FindMyCar.Test.Seed;
using FindMyCar.Core.Data;
using FindMyCar.Core.DTO;
using FindMyCar.Core.Extensions;

public static class TestSeed
{

    public static List<Vehicle> Vehicles = new List<Vehicle>()
    {
        new Vehicle
        {
            Id = 1,
            VehicleId = "123",
            LicenseNumber = "123",
            ModelName = "v70",
            Brand = new Brand
            {
                Id = 1,
                Name = "Volvo"
            },
            VehicleEquipments = new List<VehicleEquipment>()
            {
                new VehicleEquipment
                {
                    Id = 1,
                    Description = "Camera"
                },
                new VehicleEquipment
                {
                    Id = 2,
                    Description = "Television"
                }
            }
        }
    };

    public static List<Brand> Brands = new List<Brand>()
    {
        new Brand
        {
            Id = 1,
            Name = "Volvo"
        }
    };

    public static List<VehicleEquipment> Equipment = new List<VehicleEquipment>()
    {
        new VehicleEquipment
        {
            Id = 1,
            Description = "Camera"
        },
        new VehicleEquipment
        {
            Id = 2,
            Description = "Television"
        }
    };
    
}