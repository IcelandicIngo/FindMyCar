namespace FindMyCar.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FindMyCar.Core.Data;
using FindMyCar.Core.Services;
public class TestAPI
{
    [Fact]
    public void Test1()
    {

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
                    options.UseInMemoryDatabase("MyDatabase-" + Guid.NewGuid());
                });
                services.AddTransient<IVehicleService, VehicleService>();
            });
        });
        return application.CreateClient();
    }
    #endregion
}