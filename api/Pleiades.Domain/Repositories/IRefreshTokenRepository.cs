using Pleiades.Domain.Entities;

namespace Pleiades.Domain.Repositories;

public interface IRefreshTokenRepository {
  Task<RefreshToken> GetRefreshToken(string token);
  Task SaveRefreshToken(RefreshToken refreshToken);
  Task DeleteRefreshToken(string token);
}
