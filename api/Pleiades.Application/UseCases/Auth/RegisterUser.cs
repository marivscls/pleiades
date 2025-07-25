using Pleiades.Domain.Entities;
using Pleiades.Domain.Enums;
using Pleiades.Domain.Interfaces;
using Pleiades.Domain.Repositories;
using Pleiades.Domain.VOs;

namespace Pleiades.Application.UseCases.Auth;

public class RegisterUser(
  IUserRepository repository,
  IPasswordEncryptionService passwordEncryptionService) {
  public async Task<RegisterUserOutput> Execute(RegisterUserInput input) {
    var password = Password.CreateSecure(input.Password, passwordEncryptionService);

    var user = new User(
      Guid.NewGuid(),
      DateTime.UtcNow,
      DateTime.UtcNow,
      new Email(input.Email),
      password,
      UserRole.User,
      "FullName_Placeholder",
      "NickName_Placeholder"
    );

    await repository.AddAsync(user);
    await repository.SaveAsync();

    return new RegisterUserOutput(
      user.Id.ToString(),
      user.Role.ToString()
    );
  }
}

public record RegisterUserInput(
  string Email,
  string Password
);

public record RegisterUserOutput(string Id, string Role);
