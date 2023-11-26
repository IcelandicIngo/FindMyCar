namespace FindMyCar.Core.Data;
/// <summary>
/// Data model for Vehicle.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Data model id.
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
    /// Vehicle brand.
    /// </summary>
    public virtual Brand Brand { get; set; }
    /// <summary>
    /// Vehicle equipment such as cameras, sensors etc.
    /// </summary>
    public virtual VehicleEquipment VehicleEquipment { get; set; }
}