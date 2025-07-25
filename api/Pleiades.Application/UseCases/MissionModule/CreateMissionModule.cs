using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.MissionModule;

public class CreateMissionModule(IMissionModuleRepository repository) {
  public async Task<CreateMissionModuleOutput> Execute(CreateMissionModuleInput input) {
    var missionModule = new Pleiades.Domain.Entities.MissionModule(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      input.Name
    );

    await repository.AddAsync(missionModule);
    await repository.SaveAsync();

    return new CreateMissionModuleOutput(missionModule.Id.ToString());
  }
}

public record CreateMissionModuleInput(string Name);

public record CreateMissionModuleOutput(string Id);
