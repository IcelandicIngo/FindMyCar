using FindMyCar.Test.Extensions;

namespace FindMyCar.Test;
public partial class TestAPI
{
    [Fact]
    public async Task GetBrandShouldReturn200()
    {
        var client = this.getClient();
        var response = await client.GetBrandsAsync();
        response.Assert200OK();
    }   
}
