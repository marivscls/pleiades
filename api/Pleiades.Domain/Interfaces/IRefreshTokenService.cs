using Pleiades.Domain.Entities;

namespace Pleiades.Domain.Interfaces;

public interface IRefreshTokenService {
  Task<RefreshToken> CreateRefreshToken(string userId);
  Task<bool> ValidateRefreshToken(string token);
  Task<User> GetUserByRefreshToken(string token);
  Task InvalidateRefreshToken(string token);
}
