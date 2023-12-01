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
        return await client.PutAsync($"/vehicle/{id}", JsonContent.Create(vehicle));
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
    /// Asserts that a HttpResponseMessage contains the exepected vehicle.
    /// </summary>
    /// <param name="msg">HttpResponseMessage that should vehicle.</param>
    /// <param name="expected">Expected vehicle.</param>
    public static async Task<HttpResponseMessage> AssertAsync<Vehicle>(this HttpResponseMessage msg, Vehicle expected)
    {
        string responseBody = await msg.Content.ReadAsStringAsync();
        string bodyJson = JsonSerializer.Serialize(expected);
        Assert.Equal(bodyJson.ToLower(), responseBody.ToLower());
        return msg;
    }

    private static HttpResponseMessage AssertStatusCode(this HttpResponseMessage msg, HttpStatusCode code)
    {
        Assert.Equal(code, msg.StatusCode);
        return msg;
    }
}
