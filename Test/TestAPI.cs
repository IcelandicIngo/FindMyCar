namespace FindMyCar.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FindMyCar.Core.Data;
using FindMyCar.Test.Extensions;
using FindMyCar.Core.Services;
using FindMyCar.Test.Seed;
using FindMyCar.Core.Extensions;

public class TestAPI
{
    [Fact]
    public async Task GetSingleShouldReturn200()
    {
        var client = this.getClient();
        var response = await client.GetAsync(1);
        response.Assert200OK();
        await response.AssertAsync(TestSeed.Vehicles[0].ToDTO());
    }

    [Fact]
    public async Task GetInvalidSingleShouldReturn404()
    {
        var client = this.getClient();
        var response = await client.GetAsync(-1);
        response.Assert404NotFound();
    }

    
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