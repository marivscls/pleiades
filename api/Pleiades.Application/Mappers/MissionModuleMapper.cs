using Pleiades.Application.DTOs;
using Pleiades.Domain.Entities;

namespace Pleiades.Application.Mappers;

public static class MissionModuleMapper {
  public static MissionModuleDto ToDto(MissionModule module) {
    return new MissionModuleDto(
      module.Id.ToString(),
      module.CreatedOn,
      module.UpdatedOn,
      module.Name,
      module.Expeditions.Select(ExpeditionMapper.ToDto).ToList()
    );
  }
}
