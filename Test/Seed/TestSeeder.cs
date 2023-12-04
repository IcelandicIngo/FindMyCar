namespace FindMyCar.Test.Seed;
using FindMyCar.Core.Data;
using Microsoft.Extensions.DependencyInjection;
public class TestSeeder
{
    public List<Vehicle> Vehicles = new List<Vehicle>()
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
        },
        new Vehicle
        {
            Id = 2,
            VehicleId = "123",
            LicenseNumber = "333",
            ModelName = "v70",
            Brand = new Brand
            {
                Id = 2,
                Name = "Saab"
            },
            VehicleEquipments = new List<VehicleEquipment>()
            {
                new VehicleEquipment
                {
                    Id = 3,
                    Description = "Camera"
                },
                new VehicleEquipment
                {
                    Id = 4,
                    Description = "Television"
                }
            }
        }
    };

    public List<Brand> Brands = new List<Brand>()
    {
        new Brand
        {
            Id = 1,
            Name = "Volvo"
        },
        new Brand 
        {
            Id = 2,
            Name = ""
        }
    };

    public List<VehicleEquipment> Equipment = new List<VehicleEquipment>()
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
    public void Seed(IServiceProvider serviceProvider)
    {
        using (var context =  serviceProvider.GetRequiredService<VehicleContext>())
        {
            if(context.Vehicles.Any())
            {
                context.RemoveRange(context.Vehicles);
                context.SaveChanges();
            }
            if(context.Brands.Any())
            {
                context.RemoveRange(context.Brands);
                context.SaveChanges();
            }            
            if(context.VehicleEquipments.Any())
            {
                context.RemoveRange(context.VehicleEquipments);
                context.SaveChanges();
            }
            context.Vehicles.AddRange(Vehicles);
            context.SaveChanges();
        }        

    }
}
