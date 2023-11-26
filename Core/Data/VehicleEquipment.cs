namespace FindMyCar.Core.Data;
/// <summary>
/// Data model for vehicle equipment.
/// </summary>
public class VehicleEquipment
{
    /// <summary>
    /// Data model id.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Description of vehicle equipment
    /// </summary>
    public string Description { get; set; } = string.Empty;
}