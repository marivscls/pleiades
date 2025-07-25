﻿using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Planet;

public class DeletePlanet(ISolarSystemRepository repository) {
  public async Task<DeletePlanetOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();

    return new DeletePlanetOutput(id.ToString());
  }
}

public record DeletePlanetOutput(string Id);
