using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Comment;

public class DeleteCommentOnVideo(ICommentRepository repository) {
  public async Task<DeleteCommentOnVideoOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();
    return new DeleteCommentOnVideoOutput(id.ToString());
  }
}

public record DeleteCommentOnVideoOutput(string Id);
