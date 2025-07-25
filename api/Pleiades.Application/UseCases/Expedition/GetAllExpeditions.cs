using Pleiades.Application.DTOs;
using Pleiades.Application.Mappers;
using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Expedition;

public class GetAllExpeditions(IExpeditionRepository repository) {
  public async Task<GetAllExpeditionsOutput> Execute() {
    var expeditions = await repository.GetAllAsync();
    var expeditionDtos = expeditions.Select(ExpeditionMapper.ToDto).ToList();
    return new GetAllExpeditionsOutput(expeditionDtos);
  }
}

public record GetAllExpeditionsOutput(List<ExpeditionDto> Expeditions);
