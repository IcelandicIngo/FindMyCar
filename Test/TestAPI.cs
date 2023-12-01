namespace FindMyCar.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FindMyCar.Core.Data;
using FindMyCar.Test.Extensions;
using FindMyCar.Core.Services;
using FindMyCar.Test.Seed;
using FindMyCar.Core.Extensions;
using FindMyCar.Core.DTO;

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

    [Fact]
    public async Task CreateShouldReturn201()
    {
        var dto = new VehicleDTO
        {
            VehicleId = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = 1,
            EquipmentIds = new List<int>(){1}
        };
        var client = this.getClient();
        var response = await client.CreateAsync(dto);
        response.Assert201Created();
    }

    [Fact]
    public async Task CreateWithInvalidBrandShouldReturn404()
    {
        var dto = new VehicleDTO
        {
            VehicleId = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = -1,
            EquipmentIds = new List<int>(){1}
        };
        var client = this.getClient();
        var response = await client.CreateAsync(dto);
        response.Assert404NotFound();
    }

    [Fact]
    public async Task CreateWithInvalidEquipmentShouldReturn404()
    {
        var dto = new VehicleDTO
        {
            VehicleId = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = 1,
            EquipmentIds = new List<int>(){-1}
        };
        var client = this.getClient();
        var response = await client.CreateAsync(dto);
        response.Assert404NotFound();        
    }

    [Fact]
    public async Task UpdateShouldReturn200()
    {
        var volvo = TestSeed.Vehicles[0].ToDTO();
        volvo.LicenseNumber = "555";
        
        var client = this.getClient();
        var response = await client.UpdateAsync(volvo.Id, volvo);
        response.Assert200OK();
        await response.AssertAsync(x => {
            Assert.Equal(volvo.LicenseNumber, x.LicenseNumber);
        });
    }

    [Fact]
    public async Task UpdateWithInvalidVehicleShouldReturn404()
    {
        var dto = TestSeed.Vehicles[0].ToDTO();
        
        var client = this.getClient();
        var response = await client.UpdateAsync(-1, dto);
        response.Assert404NotFound();
    }

    [Fact]
    public async Task UpdateWithInvalidBrandShouldReturn404()
    {
        var dto = TestSeed.Vehicles[0].ToDTO();
        dto.BrandId = -1;

        var client = this.getClient();
        var response = await client.UpdateAsync(dto.Id, dto);
        response.Assert404NotFound();        
    }
    
    [Fact]
    public async Task UpdateWithInvalidEquipmentShouldReturn404()
    {
        var dto = TestSeed.Vehicles[0].ToDTO();
        dto.EquipmentIds = new List<int>(){-1};

        var client = this.getClient();
        var response = await client.UpdateAsync(dto.Id, dto);
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