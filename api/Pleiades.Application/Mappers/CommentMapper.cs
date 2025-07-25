using Pleiades.Application.DTOs;
using Pleiades.Domain.Entities;

namespace Pleiades.Application.Mappers;

public static class CommentMapper {
  public static CommentDto ToDto(Comment comment) {
    return new CommentDto(
      comment.Id.ToString(),
      comment.CreatedOn,
      comment.UpdatedOn,
      comment.Content,
      comment.ExpeditionId.ToString(),
      comment.UserId.ToString(),
      comment.User?.NickName ?? string.Empty
    );
  }
}
