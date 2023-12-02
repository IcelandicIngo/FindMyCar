using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FindMyCar.Core.Data;
using FindMyCar.Core.Services;
using FindMyCar.Test.Seed;

namespace FindMyCar.Test;
public partial class TestAPI
{
    #region Private Helpers
    private HttpClient getClient()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<VehicleContext>(options =>
                {
                    options.UseInMemoryDatabase("MyDatabase");
                });
                services.AddTransient<IVehicleService, VehicleService>();
                services.AddTransient<IBrandService, BrandService>();
                services.AddTransient<IVehicleEquipmentService, VehicleEquipmentService>();
            });
        });

        var seeder = new TestSeeder();
        using (var scope = application.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            seeder.Seed(services);
        }
        return application.CreateClient();
    }
    #endregion
}