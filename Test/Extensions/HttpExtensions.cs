namespace FindMyCar.Test.Extensions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using FindMyCar.Core.Data;
using FindMyCar.Core.DTO;
public static class HttpExtensions
{
    /// <summary>
    /// Executes a create vehicle request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    /// <param name="vehicle">Vehicle to create.</param>
    public static async Task<HttpResponseMessage> CreateAsync(this HttpClient client, VehicleDTO vehicle)
    {
        var msg = JsonContent.Create(vehicle);
        return await client.PostAsync("/vehicle/", new StringContent(
                JsonSerializer.Serialize(vehicle),
                Encoding.UTF8,
                MediaTypeNames.Application.Json));
    }

    /// <summary>
    /// Executes a update vehicle request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    /// <param name="id">Id of vehicle.</param>
    /// <param name="vehicle">Vehicle to update.</param>
    public static async Task<HttpResponseMessage> UpdateAsync(this HttpClient client, int id, VehicleDTO vehicle)
    {
        return await client.PutAsync($"/vehicle/{id}", new StringContent(
                JsonSerializer.Serialize(vehicle),
                Encoding.UTF8,
                MediaTypeNames.Application.Json));
    }

    /// <summary>
    /// Executes a delete vehicle request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    /// <param name="id">Id of vehicle.</param>
    public static async Task<HttpResponseMessage> DeleteAsync(this HttpClient client, int id)
    {
        return await client.DeleteAsync($"/vehicle/{id}");
    }

    /// <summary>
    /// Executes a get vehicle request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    /// <param name="id">Id of vehicle.</param>
    public static async Task<HttpResponseMessage> GetAsync(this HttpClient client, int id)
    {
        return await client.GetAsync($"/vehicle/{id}");
    }

    /// <summary>
    /// Executes a get vehicle request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    /// <param name="id">Id of vehicle.</param>
    public static async Task<HttpResponseMessage> GetAsync(this HttpClient client, int page = 1, int pageSize = 100)
    {
        return await client.GetAsync($"/vehicle?page={page}&pageSize={pageSize}");
    }

    /// <summary>
    /// Executes a get all brands request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    public static async Task<HttpResponseMessage> GetBrandsAsync(this HttpClient client)
    {
        return await client.GetAsync("/brand");
    }

    /// <summary>
    /// Executes a get all vehicle equipment request.
    /// </summary>
    /// <param name="client">HttpClient performing request.</param>
    public static async Task<HttpResponseMessage> GetVehicleEquipmentsAsync(this HttpClient client)
    {
        return await client.GetAsync("/vehicleequipment");
    }

    /// <summary>
    /// Asserts that HttpReuestMessage generated HttpResponseMessage with HttpStatusCode 200.
    /// </summary>
    /// <param name="msg">Asserted response</param>
    public static HttpResponseMessage Assert200OK(this HttpResponseMessage msg)
    {
        return msg.AssertStatusCode(HttpStatusCode.OK);
    }

    /// <summary>
    /// Asserts that HttpReuestMessage generated HttpResponseMessage with HttpStatusCode 201.
    /// </summary>
    /// <param name="msg">Asserted response</param>
    public static HttpResponseMessage Assert201Created(this HttpResponseMessage msg)
    {
        return msg.AssertStatusCode(HttpStatusCode.Created);
    }

    /// <summary>
    /// Asserts that HttpReuestMessage generated HttpResponseMessage with HttpStatusCode 401.
    /// </summary>
    /// <param name="msg">Asserted response</param>
    public static HttpResponseMessage Assert400BadRequest(this HttpResponseMessage msg)
    {
        return msg.AssertStatusCode(HttpStatusCode.BadRequest);
    }

    /// <summary>
    /// Asserts that HttpReuestMessage generated HttpResponseMessage with HttpStatusCode 201.
    /// </summary>
    /// <param name="msg">Asserted response</param>
    public static HttpResponseMessage Assert404NotFound(this HttpResponseMessage msg)
    {
        return msg.AssertStatusCode(HttpStatusCode.NotFound);
    }

    /// <summary>
    /// Custom assert HttpResponseMessage using provided assert action.
    /// </summary>
    /// <param name="msg">HttpResponseMessage that should vehicle.</param>
    /// <param name="assert">Custom assert action.</param>
    /// <returns></returns>
    public static async Task<HttpResponseMessage> AssertAsync(this HttpResponseMessage msg, Action<VehicleDTO> assert)
    {
        string responseBody = await msg.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize<VehicleDTO>(responseBody, new JsonSerializerOptions{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        assert(obj);
        return msg;
    }

    /// <summary>
    /// Creates an object of T from a json body contained in a HttpResponseMessage.
    /// </summary>
    /// <param name="msg">HttpResponseMessage that should contain JSON.</param>
    public static async Task<T> FromJSONAsync<T>(this HttpResponseMessage msg)
    {
        string responseBody = await msg.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions{
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return obj;

    }

    private static HttpResponseMessage AssertStatusCode(this HttpResponseMessage msg, HttpStatusCode code)
    {
        Assert.Equal(code, msg.StatusCode);
        return msg;
    }
}
