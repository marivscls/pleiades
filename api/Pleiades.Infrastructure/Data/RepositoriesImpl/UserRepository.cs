using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using Pleiades.Core.Messages;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.Data.RepositoriesImpl;

public class UserRepository(AppDbContext context) : IUserRepository {
  public async Task AddAsync(User user) {
    await context.Users.AddAsync(user);
  }

  public async Task<User> GetByEmailAsync(string email) {
    var user =
      await context.Users.FirstOrDefaultAsync(u => u.Email.Value == email)
      ?? throw new AuthenticationException(Messages.EmailNotFound);
    return user;
  }

  public async Task<User> GetByIdAsync(Guid id) {
    var user =
      await context.Users.FirstOrDefaultAsync(u => u.Id == id)
      ?? throw new AuthenticationException($"User with id {id} not found");
    return user;
  }

  public async Task SaveAsync() {
    await context.SaveChangesAsync();
  }
}
