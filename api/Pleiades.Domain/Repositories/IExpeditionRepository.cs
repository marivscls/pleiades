using Pleiades.Domain.Entities;

namespace Pleiades.Domain.Repositories;

public interface IExpeditionRepository {
  Task SaveAsync();
  Task<IEnumerable<Expedition>> GetAllAsync();
  Task<Expedition> GetByIdAsync(Guid id);
  Task AddAsync(Expedition expedition);
  Task DeleteByIdAsync(Guid id);
}
