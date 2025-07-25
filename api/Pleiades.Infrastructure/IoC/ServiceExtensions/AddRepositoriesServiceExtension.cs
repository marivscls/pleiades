using Microsoft.Extensions.DependencyInjection;
using Pleiades.Domain.Repositories;
using Pleiades.Infrastructure.Data.RepositoriesImpl;

namespace Pleiades.Infrastructure.IoC.ServiceExtensions;

public static class AddRepositoriesServiceExtension {
  public static IServiceCollection AddRepositories(this IServiceCollection services) {
    // Auth
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

    // Solar System
    services.AddScoped<ISolarSystemRepository, SolarSystemRepository>();

    // Planet
    services.AddScoped<IPlanetRepository, PlanetRepository>();

    // Mission
    services.AddScoped<IMissionRepository , MissionRepository>();

    // Mission Module
    services.AddScoped<IMissionModuleRepository, MissionModuleRepository>();

    // Expedition
    services.AddScoped<IExpeditionRepository, ExpeditionRepository>();

    // Comment
    services.AddScoped<ICommentRepository, CommentRepository>();

    // Moon
    services.AddScoped<IMoonRepository, MoonRepository>();

    return services;
  }
}
