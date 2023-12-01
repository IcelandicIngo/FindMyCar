namespace FindMyCar.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FindMyCar.Core.Services;
using FindMyCar.Core.DTO;
using FindMyCar.Core.Data;
using FindMyCar.Core;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    #region Private Members
    private readonly IVehicleService service;
    #endregion
    public VehicleController(IVehicleService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Returns a single page of vehicles.
    /// </summary>
    /// <param name="page">Page to return.</param>
    /// <param name="pageSize">Maximum number of results per page.</param>
    [HttpGet(Name = "GetPage")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<Vehicle>))]
    public async Task<ActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
    {
        return Ok(await this.service.GetAsync(page, pageSize));
    }

    /// <summary>
    /// Returns a single vehicle.
    /// </summary>
    /// <param name="id">Id of vehicle to return.</param>
    [HttpGet("{id}", Name = "GetSingle")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehicle))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(int id)
    {
        return Ok(await this.service.GetAsync(id));
    }

    /// <summary>
    /// Creates a single vehicle.
    /// </summary>
    /// <param name="vehicle">Vehicle to create.</param>
    [HttpPost(Name = "Create")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Vehicle))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create([FromBody] VehicleDTO vehicle)
    {
        var v = await this.service.CreateAsync(vehicle);
        return CreatedAtAction("GetSingle", new { id = v.Id}, v);
    }

    /// <summary>
    /// Updates a single vehicle.
    /// </summary>
    /// <param name="id">Id of vehicle to update.</param>
    /// <param name="vehicle">Vehicle to update.</param>
    [HttpPut("{id}", Name = "Update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehicle))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, VehicleDTO vehicle)
    {
        return Ok(await this.service.UpdateAsync(id, vehicle));
    }

    /// <summary>
    /// Deletes a single vehicle.
    /// </summary>
    /// <param name="id">Id of vehicle to delete.</param>
    [HttpDelete("{id}", Name = "Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        await this.service.DeleteAsync(id);
        return Ok();
    }
}
