using Pleiades.Application.DTOs;
using Pleiades.Domain.VOs;

namespace Pleiades.Application.Mappers;

public class ColorPaletteMapper {
  public static ColorPaletteDto ToDto(ColorPalette colorPalette) {
    var gradient = new GradientDto(
      colorPalette.Gradient.StartHex,
      colorPalette.Gradient.MiddleHex,
      colorPalette.Gradient.EndHex
    );

    return new ColorPaletteDto(
      colorPalette.PrimaryColorHex,
      colorPalette.SecondaryColorHex,
      gradient
    );
  }

  public static ColorPalette FromDto(ColorPaletteDto colorPaletteDto) {
    var gradient = new Gradient(
      colorPaletteDto.Gradient.StartHex,
      colorPaletteDto.Gradient.MiddleHex,
      colorPaletteDto.Gradient.EndHex
    );

    return new ColorPalette(
      colorPaletteDto.PrimaryColorHex,
      colorPaletteDto.SecondaryColorHex,
      gradient
    );
  }
}
