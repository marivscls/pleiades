using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.SolarSystem;

public class CreateSolarSystem(ISolarSystemRepository repository) {
  public async Task<CreateSolarSystemOutput> Execute(CreateSolarSystemInput input) {
    var solarSystem = new Pleiades.Domain.Entities.SolarSystem(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      input.Name
    );

    await repository.AddAsync(solarSystem);
    await repository.SaveAsync();

    return new CreateSolarSystemOutput(solarSystem.Id.ToString(), solarSystem.Name);
  }
}

public record CreateSolarSystemInput(string Name);

public record CreateSolarSystemOutput(string Id, string Name);
