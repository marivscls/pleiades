using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Expedition;

public class GetByIdExpedition(IExpeditionRepository repository) {
  public async Task<GetByIdExpeditionOutput> Execute(Guid id) {
    var expedition = await repository.GetByIdAsync(id);
    var dto = ExpeditionMapper.ToDto(expedition);
    return new GetByIdExpeditionOutput(dto);
  }
}

public record GetByIdExpeditionOutput(ExpeditionDto Expedition);
