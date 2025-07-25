using Pleiades.Core.Validators;
using Pleiades.Domain.Interfaces.Base;
using Pleiades.Domain.VOs;

namespace Pleiades.Domain.Entities;

/// <summary>
///     Moon equals to a Secondary Course associated to Planet
/// </summary>
public class Moon : IBaseEntity {
  public Guid Id { get; private set; }
  public DateTime CreatedOn { get; private set; }
  public DateTime UpdatedOn { get; private set; }
  public string Name { get; private set; }
  public string Lore { get; private set; }
  public Appearance Appearance { get; private set; }
  public Mission? Mission { get; private set; }

  // Navigation Properties
  public Guid PlanetId { get; private set; }
  public Planet? Planet { get; private set; }

  private Moon() {
  }

  public Moon(
    Guid id,
    DateTime createdOn,
    DateTime updatedOn,
    string name,
    string lore,
    Appearance appearance,
    Guid planetId
  ) {
    Validate(name, lore);
    Name = name;
    Lore = lore;
    Appearance = appearance;
    Id = id;
    CreatedOn = createdOn;
    UpdatedOn = updatedOn;
    PlanetId = planetId;
  }

  private static void Validate(string name, string lore) {
    StringValidator.Validate(name, "Name", 1, 255);
    StringValidator.Validate(lore, "Lore", 1, 500);
  }
}
