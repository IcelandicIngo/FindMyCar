namespace FindMyCar.Core.Services;
using FindMyCar.Core.Data;
using FindMyCar.Core.DTO;
/// <summary>
/// IVehicleService is the contract for interacting with the vehicle resource.
/// </summary>
public interface IVehicleService
{
    /// <summary>
    /// Returns a single page of vehicles.
    /// </summary>
    /// <param name="page">Page to return.</param>
    /// <param name="pageSize">Maximum number of results in page.</param>
    Task<PagedResult<Vehicle>> GetAsync(int page = 1, int pageSize = 100);
    /// <summary>
    /// Returns a specific vehicle based on id.
    /// </summary>
    /// <param name="id">Vehicle id.</param>
    Task<Vehicle> GetAsync(int id);
    /// <summary>
    /// Creates a vehicle.
    /// </summary>
    /// <param name="vehicle">Vehicle to create.</param>
    Task<Vehicle> CreateAsync(VehicleDTO vehicle);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">Vehicle id.</param>
    /// <param name="vehicle">Vehicle to update.</param>
    Task<Vehicle> UpdateAsync(int id, VehicleDTO vehicle);
    /// <summary>
    /// Deletes a vehicle represented by an id.
    /// </summary>
    /// <param name="id">Vehicle id.</param>
    Task DeleteAsync(int id);
}