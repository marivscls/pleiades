using System.Security.Authentication;
using Pleiades.Core.Messages;
using Pleiades.Domain.Interfaces;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Auth;

public class Login(
  IUserRepository userRepository,
  IPasswordEncryptionService passwordEncryptionService
) {
  public async Task<LoginOutput> Execute(LoginInput input) {
    var user = await userRepository.GetByEmailAsync(input.Email);
    if (!user.Password.IsMatch(input.Password, passwordEncryptionService)) {
      throw new AuthenticationException(Messages.InvalidCredentials);
    }

    return new LoginOutput(
      user.Id.ToString(),
      user.Role.ToString()
    );
  }
}

public record LoginInput(string Email, string Password);

public record LoginOutput(string Id, string Role);
