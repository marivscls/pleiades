using Microsoft.Extensions.DependencyInjection;
using Pleiades.Application.UseCases.Auth;
using Pleiades.Application.UseCases.Comment;
using Pleiades.Application.UseCases.Expedition;
using Pleiades.Application.UseCases.Mission;
using Pleiades.Application.UseCases.Moon;
using Pleiades.Application.UseCases.MissionModule;
using Pleiades.Application.UseCases.Planet;
using Pleiades.Application.UseCases.SolarSystem;

namespace Pleiades.Infrastructure.IoC.ServiceExtensions;

public static class AddUseCasesServiceExtension {
  public static IServiceCollection AddUseCases(this IServiceCollection services) {
    // Auth
    services.AddScoped<Login>();
    services.AddScoped<RegisterUser>();

    // Solar System
    services.AddScoped<CreateSolarSystem>();
    services.AddScoped<DeleteSolarSystem>();
    services.AddScoped<GetAllSolarSystems>();
    services.AddScoped<GetByIdSolarSystem>();
    services.AddScoped<UpdateSolarSystem>();

    // Planet
    services.AddScoped<CreatePlanet>();
    services.AddScoped<DeletePlanet>();
    services.AddScoped<GetAllPlanets>();
    services.AddScoped<GetByIdPlanet>();
    services.AddScoped<UpdatePlanet>();

    // Mission
    services.AddScoped<CreateMission>();
    services.AddScoped<DeleteMission>();
    services.AddScoped<GetAllMissions>();
    services.AddScoped<GetByIdMission>();
    services.AddScoped<UpdateMission>();

    // Moon
    services.AddScoped<CreateMoon>();
    services.AddScoped<DeleteMoon>();
    services.AddScoped<GetAllMoons>();
    services.AddScoped<GetByIdMoon>();
    services.AddScoped<UpdateMoon>();

    // Mission Module
    services.AddScoped<CreateMissionModule>();
    services.AddScoped<DeleteMissionModule>();
    services.AddScoped<GetAllMissionModules>();
    services.AddScoped<GetByIdMissionModule>();
    services.AddScoped<UpdateMissionModule>();

    // Expedition
    services.AddScoped<CreateExpedition>();
    services.AddScoped<DeleteExpedition>();
    services.AddScoped<GetAllExpeditions>();
    services.AddScoped<GetByIdExpedition>();
    services.AddScoped<UpdateExpedition>();

    // Comment
    services.AddScoped<CreateCommentOnVideo>();
    services.AddScoped<DeleteCommentOnVideo>();
    services.AddScoped<EditCommentOnVideo>();

    return services;
  }
}
