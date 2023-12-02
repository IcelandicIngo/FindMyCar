/* Simple console application which applies migrations, 
 * suitable as an init container before deploying clustered resources.
 */
using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        var configurationRoot = builder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<VehicleContext>();
        optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("FindMyCar"));
        var context = new VehicleContext(optionsBuilder.Options);
        context.Database.Migrate();
    }
}