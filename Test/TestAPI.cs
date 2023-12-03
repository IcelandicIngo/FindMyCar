using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FindMyCar.Core.Data;
using FindMyCar.Core.Services;
using FindMyCar.Test.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace FindMyCar.Test;
public partial class TestAPI
{
    #region Private Helpers
    private HttpClient getClient()
    {
        var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureLogging(op => {
                op.ClearProviders();
            });
            builder.ConfigureServices(services =>
            {
                var context = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(VehicleContext));
                if (context != null)
                {
                    services.Remove(context);
                    var options = services.Where(r => (r.ServiceType == typeof(DbContextOptions))
                        || (r.ServiceType.IsGenericType && r.ServiceType.GetGenericTypeDefinition() == typeof(DbContextOptions<>))).ToArray();
                    foreach (var option in options)
                    {
                        services.Remove(option);
                    }
                }
                services.AddDbContext<VehicleContext>(options =>
                {
                    options.UseInMemoryDatabase("MyDatabase");
                });
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