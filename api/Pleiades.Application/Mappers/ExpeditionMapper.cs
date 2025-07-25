using Pleiades.Application.DTOs;
using Pleiades.Domain.Entities;

namespace Pleiades.Application.Mappers;

public static class ExpeditionMapper {
  public static ExpeditionDto ToDto(Expedition expedition) {
    return new ExpeditionDto(
      expedition.Id.ToString(),
      expedition.CreatedOn,
      expedition.UpdatedOn,
      expedition.VideoPath,
      expedition.Comments.Select(CommentMapper.ToDto).ToList()
    );
  }
}
