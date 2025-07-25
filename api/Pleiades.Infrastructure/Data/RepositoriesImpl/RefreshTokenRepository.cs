using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using Pleiades.Core.Messages;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.Data.RepositoriesImpl;

// TODO: Agendar cron job diário pra limpar refresh tokens expirados
public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository {
  public async Task<RefreshToken> GetRefreshToken(string token) {
    return await context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token)
           ?? throw new AuthenticationException(Messages.RefreshTokenNotFound);
  }

  public async Task SaveRefreshToken(RefreshToken refreshToken) {
    await context.RefreshTokens.AddAsync(refreshToken);
    await context.SaveChangesAsync();
  }

  public async Task DeleteRefreshToken(string token) {
    var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);

    if (refreshToken != null) {
      context.RefreshTokens.Remove(refreshToken);
      await context.SaveChangesAsync();
    }
  }
}
