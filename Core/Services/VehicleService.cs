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
        throw new NotImplementedException();
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
