using Pleiades.Application.DTOs;
using Pleiades.Domain.VOs;

namespace Pleiades.Application.Mappers;

public class GradientMapper {
  public static GradientDto ToDto(Gradient gradient) {
    return new GradientDto(
      gradient.StartHex,
      gradient.MiddleHex,
      gradient.EndHex
    );
  }
}
