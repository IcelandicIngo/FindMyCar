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
    public async Task<PagedResult<VehicleDTO>> GetAsync(int page = 1, int pageSize = 100, string licenseNumber = "")
    {
        var result = new List<VehicleDTO>();
        int total = 0;
        if(!string.IsNullOrEmpty(licenseNumber) )
        {
            total = await this.context.Vehicles.Where(x => x.LicenseNumber.StartsWith(licenseNumber))
                                                 .Include(x => x.Brand)
                                                 .Include(x => x.VehicleEquipments).CountAsync();
            result = await this.context.Vehicles.Where(x => x.LicenseNumber.StartsWith(licenseNumber))
                                                 .Include(x => x.Brand)
                                                 .Include(x => x.VehicleEquipments)
                                                 .OrderBy(x => x.LicenseNumber)
                                                 .Skip((page - 1) * pageSize)
                                                 .Take(pageSize)
                                                 .Select(x => x.ToDTO()).ToListAsync();
        }
        else
        {
            total = await this.context.Vehicles.Include(x => x.Brand)
                                                 .Include(x => x.VehicleEquipments).CountAsync();
            result = await this.context.Vehicles.Include(x => x.Brand)
                                                 .Include(x => x.VehicleEquipments)
                                                 .OrderBy(x => x.LicenseNumber)
                                                 .Skip((page - 1) * pageSize)
                                                 .Take(pageSize)
                                                 .Select(x => x.ToDTO()).ToListAsync();
        }
        return new PagedResult<VehicleDTO> { Page = page, PageSize = pageSize, Result = result, Total = total };
    }

    public async Task<VehicleDTO> GetAsync(int id)
    {
        var vehicle = await this.context.GetVehicleOrThrowAsync(id);
        if(vehicle == null)
        {
            throw new NotFoundException($"No vehicle with id '{id} could be found.");
        }
        return vehicle.ToDTO();
    }

    public async Task<VehicleDTO> CreateAsync(VehicleDTO vehicle)
    {
        var brand = await this.context.GetBrandOrThrowAsync(vehicle.BrandId);
        var equipments = await context.GetEquipmentOrThrowAsync(vehicle.VehicleEquipmentIds);
        var dbObj = new Vehicle
        {
            VehicleId = vehicle.VehicleIdentificationNumber,
            LicenseNumber = vehicle.LicenseNumber,
            ModelName = vehicle.ModelName,
            Brand = brand,
            VehicleEquipments = equipments,
        };
        await this.context.Vehicles.AddAsync(dbObj);
        await this.context.SaveChangesAsync();
        return dbObj.ToDTO();
    }

    public async Task<VehicleDTO> UpdateAsync(int id, VehicleDTO vehicle)
    {
        var dbVehicle = await this.context.GetVehicleOrThrowAsync(id);
        var brand = await this.context.GetBrandOrThrowAsync(vehicle.BrandId);
        var equipment = await this.context.GetEquipmentOrThrowAsync(vehicle.VehicleEquipmentIds);
        dbVehicle.LicenseNumber = vehicle.LicenseNumber;
        dbVehicle.VehicleId = vehicle.VehicleIdentificationNumber;
        dbVehicle.ModelName = vehicle.ModelName;
        dbVehicle.Brand = brand;
        dbVehicle.VehicleEquipments = equipment;
        await this.context.SaveChangesAsync();
        return dbVehicle.ToDTO();
    }

    public async Task DeleteAsync(int id)
    {
        var dbVehicle = await this.context.GetVehicleOrThrowAsync(id);
        this.context.Vehicles.Remove(dbVehicle);
        await this.context.SaveChangesAsync();
    }
    #endregion
}
