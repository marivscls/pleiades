using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Mission;

public class GetAllMissions(IMissionRepository repository) {
  public async Task<GetAllMissionOutput> Execute() {
    var missions = await repository.GetAllAsync();
    var missionDtos = missions.Select(MissionMapper.ToDto).ToList();
    return new GetAllMissionOutput(missionDtos);
  }
}

public record GetAllMissionOutput(List<MissionDto> Mission);
