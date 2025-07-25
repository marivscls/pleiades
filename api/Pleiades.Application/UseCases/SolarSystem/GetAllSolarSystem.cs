using Pleiades.Application.DTOs;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.SolarSystem;

public class GetAllSolarSystems(ISolarSystemRepository repository) {
  public async Task<GetAllSolarSystemOutput> Execute() {
    var solarSystems = await repository.GetAllAsync();

    var solarSystemDtos = solarSystems.Select(s => new SolarSystemDto(
      s.Id.ToString(),
      s.Name,
      s.CreatedOn,
      s.UpdatedOn
    )).ToList();

    return new GetAllSolarSystemOutput(solarSystemDtos);
  }
}

public record GetAllSolarSystemOutput(List<SolarSystemDto> SolarSystems);
