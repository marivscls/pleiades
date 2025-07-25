using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.MissionModule;

public class GetByIdMissionModule(IMissionModuleRepository repository) {
  public async Task<GetByIdMissionModuleOutput> Execute(Guid id) {
    var missionModule = await repository.GetByIdAsync(id);
    var dto = MissionModuleMapper.ToDto(missionModule);
    return new GetByIdMissionModuleOutput(dto);
  }
}

public record GetByIdMissionModuleOutput(MissionModuleDto MissionModule);
