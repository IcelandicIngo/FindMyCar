using FindMyCar.Core.Data;
using FindMyCar.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class VehicleEquipmentController : Controller
{
    #region  Private Members
    private readonly IVehicleEquipmentService service;
    #endregion

    public VehicleEquipmentController(IVehicleEquipmentService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Returns all vehicle equipments available.
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
    [HttpGet(Name = "GetAllVehicleEquipments")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VehicleEquipment>))]
    public async Task<ActionResult> Get()
    {
        return Ok(await this.service.GetAsync());
    }
}
