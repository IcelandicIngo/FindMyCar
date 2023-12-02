using FindMyCar.Test.Extensions;

namespace FindMyCar.Test;

public partial class TestAPI
{
    [Fact]
    public async Task GetVehicleEquipmentsShouldReturn200()
    {
        var client = this.getClient();
        var response = await client.GetVehicleEquipmentsAsync();
        response.Assert200OK();
    }       
}
