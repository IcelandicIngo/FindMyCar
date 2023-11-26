namespace FindMyCar.Core.Data; 
using Microsoft.EntityFrameworkCore;
/// <summary>
/// Provides data access for the vehicle context.
/// </summary>
public class VehicleContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<VehicleEquipment> VehicleEquipments { get; set; }    
}
