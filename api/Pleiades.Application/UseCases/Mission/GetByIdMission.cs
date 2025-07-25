using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Mission;

public class GetByIdMission(IMissionRepository repository) {
  public async Task<GetByIdMissionOutput> Execute(Guid id) {
    var mission = await repository.GetByIdAsync(id);
    var dto = MissionMapper.ToDto(mission);
    return new GetByIdMissionOutput(dto);
  }
}

public record GetByIdMissionOutput(MissionDto Mission);
