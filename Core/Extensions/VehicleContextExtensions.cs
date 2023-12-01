using FindMyCar.Core.Data;
using FindMyCar.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FindMyCar.Core.Extensions;
/// <summary>
/// VehicleContextExtensions extends the VehicleContext
/// </summary>
public static class VehicleContextExtensions
{
    /// <summary>
    /// Returns a specific Brand or throws a NotFoundException with descriptive error message.
    /// </summary>
    /// <param name="context">VehicleContext</param>
    /// <param name="id">Brand id.</param>
    /// <exception cref="NotFoundException"></exception>
    public static async Task<Brand> GetBrandOrThrowAsync(this VehicleContext context, int id)
    {
        var brand = await context.Brands.SingleOrDefaultAsync(x => x.Id == id);
        if(brand == null)
        {
            throw new NotFoundException($"No brand with id '{id}' could be found");
        }
        return brand;
    }

    /// <summary>
    /// Returns specified VehicleEquipment or throws a NotFoundException with descriptive error message.
    /// </summary>
    /// <param name="context">VehicleContext</param>
    /// <param name="equipmentIds"></param>
    /// <exception cref="NotFoundException"></exception>
    public static async Task<List<VehicleEquipment>> GetEquipmentOrThrowAsync(this VehicleContext context, List<int> equipmentIds)
    {
        var equipments = await context.VehicleEquipments.Where(x => equipmentIds.Contains(x.Id)).ToListAsync();
        if(equipments.Count() != equipmentIds.Count())
        {
            var ids = equipments.Select(x => x.Id);
            var invalidIds = equipmentIds.Where(x => !ids.Contains(x)).ToList();
            var idMsg = string.Join(',', invalidIds);
            throw new NotFoundException($"No vehicle equipments with ids '{idMsg}' could be found");
        }
        return equipments;
    }

    /// <summary>
    /// Returns a specific Vehicle or throws a NotFoundException with descriptive error message.
    /// </summary>
    /// <param name="context">VehicleContext</param>
    /// <param name="id">Vehicle id.</param>
    /// <exception cref="NotFoundException"></exception>
    public static async Task<Vehicle> GetVehicleOrThrowAsync(this VehicleContext context, int id)
    {
        var vehicle = await context.Vehicles.Include(x => x.Brand).Include(x => x.VehicleEquipments).SingleOrDefaultAsync(x => x.Id == id);
        if(vehicle == null)
        {
            throw new NotFoundException($"No vehicle with id '{id} could be found.");
        }
        return vehicle;
    }

}
