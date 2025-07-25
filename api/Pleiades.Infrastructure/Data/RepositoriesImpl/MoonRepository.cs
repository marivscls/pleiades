﻿using Microsoft.EntityFrameworkCore;
using Pleiades.Core.Exceptions;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.Data.RepositoriesImpl;

public class MoonRepository(AppDbContext context) : IMoonRepository {
  public async Task SaveAsync() {
    await context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Moon>> GetAllAsync() {
    var moons = await context.Moons.ToListAsync();
    if (moons == null) {
      throw new DbNotFoundException("No moons found");
    }

    return moons;
  }

  public async Task<Moon> GetByIdAsync(Guid id) {
    var moon = await context.Moons.FirstOrDefaultAsync(p => p.Id == id);
    if (moon == null) {
      throw new DbNotFoundException("No moon was found with this id");
    }

    return moon;
  }

  public async Task AddAsync(Moon moon) {
    await context.Moons.AddAsync(moon);
  }

  public async Task DeleteByIdAsync(Guid id) {
    var moon = await context.Moons.FirstOrDefaultAsync(p => p.Id == id);
    if (moon == null) {
      throw new DbNotFoundException("No moon was found with this id");
    }

    context.Moons.Remove(moon);
  }
}
