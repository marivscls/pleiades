using Pleiades.Domain.Interfaces;

namespace Pleiades.Infrastructure.Security.Cryptography;

public class PasswordEncryptionServiceBCrypt : IPasswordEncryptionService {
  public string Hash(string plainTextPassword) {
    return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
  }

  public bool Verify(string hashedPassword, string plainTextPassword) {
    return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
  }
}
