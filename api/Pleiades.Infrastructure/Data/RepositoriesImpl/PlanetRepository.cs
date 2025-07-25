using Microsoft.EntityFrameworkCore;
using Pleiades.Core.Exceptions;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.Data.RepositoriesImpl;

public class PlanetRepository(AppDbContext context) : IPlanetRepository {
  public async Task SaveAsync() {
    await context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Planet>> GetAllAsync() {
    var planets = await context.Planets.ToListAsync();
    if (planets == null) {
      throw new DbNotFoundException("No planets found");
    }

    return planets;
  }

  public async Task<Planet> GetByIdAsync(Guid id) {
    var planet = await context.Planets.FirstOrDefaultAsync(p => p.Id == id);
    if (planet == null) {
      throw new DbNotFoundException("No planet was found with this id");
    }

    return planet;
  }

  public async Task AddAsync(Planet planet) {
    await context.Planets.AddAsync(planet);
  }

  public async Task DeleteByIdAsync(Guid id) {
    var planet = await context.Planets.FirstOrDefaultAsync(p => p.Id == id);
    if (planet == null) {
      throw new DbNotFoundException("No planet was found with this id");
    }

    context.Planets.Remove(planet);
  }
}
