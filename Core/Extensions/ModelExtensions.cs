
using FindMyCar.Core.Data;
using FindMyCar.Core.DTO;

namespace FindMyCar.Core.Extensions;
/// <summary>
/// Provides extensions for data models.
/// </summary>
public static class ModelExtensions
{
    /// <summary>
    /// Converts database object to a DTO.
    /// </summary>
    /// <param name="vehicle">Vehicle to convert.</param>
    public static VehicleDTO ToDTO(this Vehicle vehicle)
    {
        return new VehicleDTO
        {
            Id = vehicle.Id,
            VehicleIdentificationNumber = vehicle.VehicleId,
            LicenseNumber = vehicle.LicenseNumber,
            ModelName = vehicle.ModelName,
            BrandId = vehicle.Brand.Id,
            VehicleEquipmentIds = vehicle.VehicleEquipments.Select(x => x.Id).ToList()
        };
    }
}
