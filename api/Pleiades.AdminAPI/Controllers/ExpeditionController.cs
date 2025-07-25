using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pleiades.Application.UseCases.Expedition;

namespace Pleiades.AdminAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class ExpeditionController(
  CreateExpedition createExpeditionUc,
  DeleteExpedition deleteExpeditionUc,
  GetAllExpeditions getAllExpeditionUc,
  GetByIdExpedition getByIdExpeditionUc,
  UpdateExpedition updateExpeditionUc
) : ControllerBase {
  [HttpPost("create-expedition")]
  public async Task<IActionResult> CreateExpedition(CreateExpeditionInput req) {
    var output = await createExpeditionUc.Execute(req);
    return Ok(output);
  }

  [HttpDelete("delete-expedition/{id:guid}")]
  public async Task<IActionResult> DeleteExpedition(Guid id) {
    var output = await deleteExpeditionUc.Execute(id);
    return Ok(output);
  }

  [HttpGet("get-all-expeditions")]
  public async Task<IActionResult> GetAllExpedition() {
    var output = await getAllExpeditionUc.Execute();
    return Ok(output);
  }

  [HttpGet("get-by-id-expedition/{id:guid}")]
  public async Task<IActionResult> GetByIdExpedition(Guid id) {
    var output = await getByIdExpeditionUc.Execute(id);
    return Ok(output);
  }
}
