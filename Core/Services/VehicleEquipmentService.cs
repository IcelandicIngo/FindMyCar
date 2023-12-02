using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMyCar.Core.Services;

public class VehicleEquipmentService : IVehicleEquipmentService
{
    private readonly VehicleContext context;
    public VehicleEquipmentService(VehicleContext context)
    {
        this.context = context;
    }
    public async Task<List<VehicleEquipment>> GetAsync()
    {
        return await this.context.VehicleEquipments.ToListAsync();
    }
}
