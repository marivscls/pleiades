using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.MissionModule;

public class DeleteMissionModule(IMissionModuleRepository repository) {
  public async Task<DeleteMissionModuleOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();
    return new DeleteMissionModuleOutput(id.ToString());
  }
}

public record DeleteMissionModuleOutput(string Id);
