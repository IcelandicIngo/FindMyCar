using FindMyCar.Core.DTO;
using FindMyCar.Core.Extensions;
using FindMyCar.Test.Extensions;
using FindMyCar.Test.Seed;

namespace FindMyCar.Test;

public partial class TestAPI
{
    [Fact]
    public async Task GetSingleShouldReturn200()
    {
        var client = this.getClient();
        var response = await client.GetAsync(1);
        response.Assert200OK();
        var dto = await response.FromJSONAsync<VehicleDTO>();
        await response.AssertAsync(x => {
            
            Assert.Equal("123", dto.VehicleIdentificationNumber);
            Assert.Equal("123", dto.LicenseNumber);
            Assert.Equal("v70", dto.ModelName);
        });

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
            VehicleIdentificationNumber = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = 1,
            VehicleEquipmentIds = new List<int>(){1}
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
            VehicleIdentificationNumber = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = -1,
            VehicleEquipmentIds = new List<int>(){1}
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
            VehicleIdentificationNumber = "123",
            LicenseNumber = "123",
            ModelName = "v75",
            BrandId = 1,
            VehicleEquipmentIds = new List<int>(){-1}
        };
        var client = this.getClient();
        var response = await client.CreateAsync(dto);
        response.Assert404NotFound();
    }

    [Fact]
    public async Task UpdateShouldReturn200()
    {
        var client = this.getClient();
        var dto = new VehicleDTO
        {
            LicenseNumber = "123",
            VehicleIdentificationNumber = "ax1qs",
            ModelName = "v90",
            BrandId = 1,
            VehicleEquipmentIds = new List<int>(){1}
        };
        var createResponse = await client.CreateAsync(dto);
        createResponse.Assert201Created();
        var volvo = await createResponse.FromJSONAsync<VehicleDTO>();
        volvo.LicenseNumber = "xyz";
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
        dto.VehicleEquipmentIds = new List<int>(){-1};

        var client = this.getClient();
        var response = await client.UpdateAsync(dto.Id, dto);
        response.Assert404NotFound();
    }

    [Fact]
    public async Task DeleteShouldReturn200()
    {
        var client = this.getClient();
        var dto = new VehicleDTO
        {
            LicenseNumber = "123",
            VehicleIdentificationNumber = "ax1qs",
            ModelName = "v90",
            BrandId = 1,
            VehicleEquipmentIds = new List<int>(){1}
        };
        var createResponse = await client.CreateAsync(dto);
        createResponse.Assert201Created();
        var volvo = await createResponse.FromJSONAsync<VehicleDTO>();
        var deleteResponse = await client.DeleteAsync(volvo.Id);
        deleteResponse.Assert200OK();
    }

    [Fact]
    public async Task DeleteInvalidShouldReturn404()
    {
        var client = this.getClient();
        var deleteResponse = await client.DeleteAsync(-1);
        deleteResponse.Assert404NotFound();
    }
}

