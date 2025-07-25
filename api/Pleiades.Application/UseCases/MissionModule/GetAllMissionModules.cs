using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.MissionModule;

public class GetAllMissionModules(IMissionModuleRepository repository) {
  public async Task<GetAllMissionModulesOutput> Execute() {
    var missionsModules = await repository.GetAllAsync();
    var missionModuleDtos = missionsModules.Select(MissionModuleMapper.ToDto).ToList();
    return new GetAllMissionModulesOutput(missionModuleDtos);
  }
}

public record GetAllMissionModulesOutput(List<MissionModuleDto> MissionModules);
