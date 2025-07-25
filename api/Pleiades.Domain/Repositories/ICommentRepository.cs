using Pleiades.Domain.Entities;

namespace Pleiades.Domain.Repositories;

public interface ICommentRepository {
  Task SaveAsync();
  Task<IEnumerable<Comment>> GetAllAsync();
  Task<Comment> GetByIdAsync(Guid id);
  Task AddAsync(Comment comment);
  Task DeleteByIdAsync(Guid id);
}
