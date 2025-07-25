using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Planet;

public class GetByIdPlanet(IPlanetRepository repository) {
  public async Task<GetByIdPlanetOutput> Execute(Guid id) {
    var planet = await repository.GetByIdAsync(id);
    var dto = PlanetMapper.ToDto(planet);
    return new GetByIdPlanetOutput(dto);
  }
}

public record GetByIdPlanetOutput(PlanetDto Planet);
