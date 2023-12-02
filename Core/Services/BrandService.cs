using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMyCar.Core.Services;

public class BrandService : IBrandService
{
    #region Private Member
    private readonly VehicleContext context;
    #endregion

    public BrandService(VehicleContext context)
    {
        this.context = context;
    }

    public async Task<List<Brand>> GetAsync()
    {
        return await this.context.Brands.ToListAsync();
    }
}
