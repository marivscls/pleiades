using Pleiades.Domain.Enums;

namespace Pleiades.Application.DTOs;

public record MissionDetailDto(
  int ExpeditionsNumber,
  int ExplorationTimeInMinutes,
  AreaCategory AreaCategory,
  Difficulty Difficulty,
  string Lore
);
