using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Planet;

public class CreatePlanet(IPlanetRepository repository) {
  public async Task<CreatePlanetOutput> Execute(CreatePlanetInput input) {
    var planet = new Pleiades.Domain.Entities.Planet(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      input.Name,
      input.Lore,
      AppearanceMapper.FromDto(input.Appearance),
      Guid.Parse(input.SolarSystemId)
    );
    await repository.AddAsync(planet);
    await repository.SaveAsync();

    return new CreatePlanetOutput(planet.Id.ToString());
  }
}

public record CreatePlanetInput(
  string Name,
  string Lore,
  AppearanceDto Appearance,
  string SolarSystemId);

public record CreatePlanetOutput(string Id);
