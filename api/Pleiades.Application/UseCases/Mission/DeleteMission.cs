﻿using Pleiades.Domain.Repositories;

namespace Pleiades.Application.UseCases.Mission;

public class DeleteMission(IMissionRepository repository) {
  public async Task<DeleteMissionOutput> Execute(Guid id) {
    await repository.DeleteByIdAsync(id);
    await repository.SaveAsync();
    return new DeleteMissionOutput(id.ToString());
  }
}

public record DeleteMissionOutput(string Id);
