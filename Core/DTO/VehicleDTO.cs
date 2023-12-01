namespace FindMyCar.Core.DTO;
public class VehicleDTO
{
    /// <summary>
    /// Data model Id.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// VIN or Vehicle Identification Number that uniquely represents a Vehicle.
    /// </summary>
    public string VehicleId { get; set; } = string.Empty;
    /// <summary>
    /// License number currently used.
    /// </summary>
    public string LicenseNumber { get; set; } = string.Empty;
    /// <summary>
    /// Vehicle models.
    /// </summary>
    public string ModelName { get; set; } = string.Empty;    
    /// <summary>
    /// Id of vehicle brand.
    /// </summary>
    public int BrandId { get; set; }
    /// <summary>
    /// Ids of vehicle equipment in use.
    /// </summary>
    public List<int> EquipmentIds { get; set; }
}