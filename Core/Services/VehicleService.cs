namespace FindMyCar.Core.Services;
using FindMyCar.Core.Data;
using FindMyCar.Core.DTO;
using FindMyCar.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics;
using FindMyCar.Core.Extensions;

public class VehicleService : IVehicleService
{
    #region Private Members
    private readonly VehicleContext context;
    #endregion
    public VehicleService(VehicleContext context)
    {
        this.context = context;
    }

    #region IVehicleService
    public async Task<PagedResult<VehicleDTO>> GetAsync(int page = 1, int pageSize = 100)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleDTO> GetAsync(int id)
    {
        var vehicle = this.context.Vehicles.Include(x => x.Brand).Include(x => x.VehicleEquipments).SingleOrDefault(x => x.Id == id);
        if(vehicle == null)
        {
            throw new NotFoundException($"No vehicle with id '{id} could be found.");
        }
        return vehicle.ToDTO();
    }

    public async Task<VehicleDTO> CreateAsync(VehicleDTO vehicle)
    {
        var brand = this.context.Brands.SingleOrDefault(x => x.Id == vehicle.BrandId);
        if(brand == null)
        {
            throw new NotFoundException($"No brand with id '{vehicle.BrandId}' could be found");
        }
        var equipments = context.VehicleEquipments.Where(x => vehicle.EquipmentIds.Contains(x.Id)).ToList();
        if(equipments.Count() != vehicle.EquipmentIds.Count())
        {
            var ids = equipments.Select(x => x.Id);
            var invalidIds = vehicle.EquipmentIds.Where(x => !ids.Contains(x)).ToList();
            var idMsg = string.Join(',', invalidIds);
            throw new NotFoundException($"No vehicle equipments with ids '{idMsg}' could be found");
        }
        var dbObj = new Vehicle
        {
            VehicleId = vehicle.VehicleId,
            LicenseNumber = vehicle.LicenseNumber,
            ModelName = vehicle.ModelName,            
            Brand = brand,
            VehicleEquipments = equipments,
        };
        this.context.Vehicles.Add(dbObj);
        await this.context.SaveChangesAsync();
        return dbObj.ToDTO();
    }

    public async Task<VehicleDTO> UpdateAsync(int id, VehicleDTO vehicle)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    #endregion    
}
