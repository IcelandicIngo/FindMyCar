using FindMyCar.Core.Data;

namespace FindMyCar.Core.Services;
/// <summary>
/// IBrandService is the contract for interacting with the vehicle equipment resource.
/// </summary>
public interface IVehicleEquipmentService
{
    /// <summary>
    /// Returns all vehicle equipments available.
    /// </summary>    
    Task<List<VehicleEquipment>> GetAsync();
}
