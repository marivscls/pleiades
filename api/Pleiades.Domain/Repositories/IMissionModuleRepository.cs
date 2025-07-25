using Pleiades.Domain.Entities;

namespace Pleiades.Domain.Repositories;

public interface IMissionModuleRepository {
  Task SaveAsync();
  Task<IEnumerable<MissionModule>> GetAllAsync();
  Task<MissionModule> GetByIdAsync(Guid id);
  Task AddAsync(MissionModule missionModule);
  Task DeleteByIdAsync(Guid id);
}
