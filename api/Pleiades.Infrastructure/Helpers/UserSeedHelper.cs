using Pleiades.Domain.Enums;
using Pleiades.Domain.Entities;
using Pleiades.Domain.Interfaces;
using Pleiades.Domain.VOs;

namespace Pleiades.Infrastructure.Helpers;

public static class UserSeedHelper {
  public static User CreateAdmin(
    string email,
    string fullName,
    string nickName,
    string plainTextPassword,
    IPasswordEncryptionService encryptionService
  ) {
    return new User(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      new Email(email),
      Password.CreateSecure(plainTextPassword, encryptionService),
      UserRole.Admin,
      fullName,
      nickName
    );
  }
}
