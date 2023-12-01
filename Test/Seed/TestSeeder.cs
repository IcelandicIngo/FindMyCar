namespace FindMyCar.Test.Seed;
using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
public class TestSeeder
{
    public void Seed(IServiceProvider serviceProvider)
    {
        using (var context =  serviceProvider.GetRequiredService<VehicleContext>())
        {
            if(!context.Vehicles.Any())
            {
                context.Vehicles.AddRange(TestSeed.Vehicles);
                context.SaveChanges();
            }
        }        

    }
}
