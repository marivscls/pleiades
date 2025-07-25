using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pleiades.Application.UseCases.SolarSystem;

namespace Pleiades.AdminAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class SolarSystemController(
  CreateSolarSystem createSolarSystemUc,
  DeleteSolarSystem deleteSolarSystemUc,
  GetAllSolarSystems getAllSolarSystemUc,
  GetByIdSolarSystem getByIdSolarSystemUc,
  UpdateSolarSystem updateSolarSystemUc
) : ControllerBase {
  [HttpPost("create-solar-system")]
  public async Task<IActionResult> CreateSolarSystem(CreateSolarSystemInput req) {
    var output = await createSolarSystemUc.Execute(req);
    return Ok(output);
  }

  [HttpDelete("delete-solar-system/{id:guid}")]
  public async Task<IActionResult> DeleteSolarSystem(Guid id) {
    var output = await deleteSolarSystemUc.Execute(id);
    return Ok(output);
  }

  [HttpGet("get-all-solar-systems")]
  public async Task<IActionResult> GetAllSolarSystem() {
    var output = await getAllSolarSystemUc.Execute();
    return Ok(output);
  }

  [HttpGet("get-by-id-solar-system/{id:guid}")]
  public async Task<IActionResult> GetByIdSolarSystem(Guid id) {
    var output = await getByIdSolarSystemUc.Execute(id);
    return Ok(output);
  }
}
