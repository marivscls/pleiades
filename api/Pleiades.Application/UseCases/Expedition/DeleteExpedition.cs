using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Expedition;

public class DeleteExpedition(IExpeditionRepository repository) {
  public async Task<DeleteExpeditionOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();
    return new DeleteExpeditionOutput(id.ToString());
  }
}

public record DeleteExpeditionOutput(string Id);
