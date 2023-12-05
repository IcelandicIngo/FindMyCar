using FindMyCar.Core.Data;

namespace Migrator;
/// <summary>
/// Helper class that seeds a VehicleContext if no Brands or VehicleEquipment exists.
/// </summary>
public static class Seeder
{
    public static List<Brand> Brands = new List<Brand>()
    {
        new Brand{Name = "Volvo"}, new Brand{ Name = "Saab"},
        new Brand{ Name = "Toyota"}
    };

    public static List<VehicleEquipment> Equipments = new List<VehicleEquipment>()
    {
        new VehicleEquipment{Description = "Front Camera"},
        new VehicleEquipment{Description = "Rear Camera"},
        new VehicleEquipment{Description = "Radiation Sensor"},
    };

    public static void Seed(VehicleContext context)
    {
        if(!context.Brands.Any())
        {
            context.Brands.AddRange(Brands);
            context.SaveChanges();
            Console.WriteLine("Seeded brands");
        }

        if(!context.VehicleEquipments.Any())
        {
            context.VehicleEquipments.AddRange(Equipments);
            context.SaveChanges();
            Console.WriteLine("Seeded VehicleEquipment");
        }
    }

}
