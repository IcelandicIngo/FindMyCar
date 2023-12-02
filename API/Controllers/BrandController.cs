using FindMyCar.Core.Data;
using FindMyCar.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class BrandController : Controller
{
    #region  Private Members
    private readonly IBrandService service;
    #endregion

    public BrandController(IBrandService service)
    {
        this.service = service;
    }

    /// <summary>
    /// Returns all brands available.
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
    [HttpGet(Name = "GetAllBrands")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Brand>))]
    public async Task<ActionResult> Get()
    {
        return Ok(await this.service.GetAsync());
    }
}
