using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.SolarSystem;

public class DeleteSolarSystem(ISolarSystemRepository repository) {
  public async Task<DeleteSolarSystemOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();

    return new DeleteSolarSystemOutput(id.ToString());
  }
}

public record DeleteSolarSystemOutput(string Id);
