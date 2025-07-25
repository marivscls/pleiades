using Microsoft.EntityFrameworkCore;
using Pleiades.Core.Exceptions;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.Data.RepositoriesImpl;

public class MissionRepository(AppDbContext context) : IMissionRepository {
  public async Task SaveAsync() {
    await context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Mission>> GetAllAsync() {
    var missions = await context.Missions.ToListAsync();
    if (missions == null) {
      throw new DbNotFoundException("No missions found");
    }

    return missions;
  }

  public async Task<Mission> GetByIdAsync(Guid id) {
    var mission = await context.Missions.FirstOrDefaultAsync(p => p.Id == id);
    if (mission == null) {
      throw new DbNotFoundException("No mission was found with this id");
    }

    return mission;
  }

  public async Task AddAsync(Mission mission) {
    await context.Missions.AddAsync(mission);
  }

  public async Task DeleteByIdAsync(Guid id) {
    var mission = await context.Missions.FirstOrDefaultAsync(p => p.Id == id);
    if (mission == null) {
      throw new DbNotFoundException("No mission was found with this id");
    }

    context.Missions.Remove(mission);
  }
}
