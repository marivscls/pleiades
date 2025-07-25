using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pleiades.Infrastructure.Data.Database;

namespace Pleiades.Infrastructure.IoC.ServiceExtensions;

public static class DbContextServiceExtension {
  public static IServiceCollection AddAppDbContext(
    this IServiceCollection services,
    string? connectionString
  ) {
    if (string.IsNullOrWhiteSpace(connectionString)) {
      throw new ArgumentException(
        "Database Connection String was not found.",
        nameof(connectionString)
      );
    }

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    return services;
  }
}
