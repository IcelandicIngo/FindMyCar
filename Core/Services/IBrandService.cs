using FindMyCar.Core.Data;

namespace FindMyCar.Core.Services;
/// <summary>
/// IBrandService is the contract for interacting with the brand resource.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns all brands available.
    /// </summary>
    Task<List<Brand>> GetAsync();
}
