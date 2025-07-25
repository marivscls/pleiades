using Pleiades.Application.DTOs;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.SolarSystem;

public class GetByIdSolarSystem(ISolarSystemRepository repository) {
  public async Task<GetByIdSolarSystemOutput> Execute(Guid id) {
    var solarSystem = await repository.GetByIdAsync(id);

    return new GetByIdSolarSystemOutput(new SolarSystemDto(solarSystem.Id.ToString(),
      solarSystem.Name, solarSystem.CreatedOn, solarSystem.UpdatedOn));
  }
}

public record GetByIdSolarSystemOutput(SolarSystemDto SolarSystem);
