using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pleiades.Application.UseCases.MissionModule;

namespace Pleiades.AdminAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class MissionModuleController(
  CreateMissionModule createMissionModuleUc,
  DeleteMissionModule deleteMissionModuleUc,
  GetAllMissionModules getAllMissionModuleUc,
  GetByIdMissionModule getByIdMissionModuleUc,
  UpdateMissionModule updateMissionModuleUc
) : ControllerBase {
  [HttpPost("create-mission-module")]
  public async Task<IActionResult> CreateMissionModule(CreateMissionModuleInput req) {
    var output = await createMissionModuleUc.Execute(req);
    return Ok(output);
  }

  [HttpDelete("delete-mission-module/{id:guid}")]
  public async Task<IActionResult> DeleteMissionModule(Guid id) {
    var output = await deleteMissionModuleUc.Execute(id);
    return Ok(output);
  }

  [HttpGet("get-all-mission-modules")]
  public async Task<IActionResult> GetAllMissionModule() {
    var output = await getAllMissionModuleUc.Execute();
    return Ok(output);
  }

  [HttpGet("get-by-id-mission-module/{id:guid}")]
  public async Task<IActionResult> GetByIdMissionModule(Guid id) {
    var output = await getByIdMissionModuleUc.Execute(id);
    return Ok(output);
  }
}
