using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Moon;

public class CreateMoon(IMoonRepository repository) {
  public async Task<CreateMoonOutput> Execute(CreateMoonInput input) {
    var moon = new Pleiades.Domain.Entities.Moon(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      input.Name,
      input.Lore,
      AppearanceMapper.FromDto(input.Appearance),
      Guid.Parse(input.PlanetId)
    );
    await repository.AddAsync(moon);
    await repository.SaveAsync();

    return new CreateMoonOutput(moon.Id.ToString());
  }
}

public record CreateMoonInput(
  string Name,
  string Lore,
  AppearanceDto Appearance,
  string PlanetId
);

public record CreateMoonOutput(string Id);
