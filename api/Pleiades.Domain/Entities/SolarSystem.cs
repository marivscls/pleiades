using Pleiades.Core.Validators;
using Pleiades.Domain.Interfaces.Base;

namespace Pleiades.Domain.Entities;

/// <summary>
///     Solar System equals to a Knowledge Area (Frontend, Backend, etc.)
/// </summary>
public class SolarSystem : IBaseEntity {
  public Guid Id { get; private set; }
  public DateTime CreatedOn { get; private set; }
  public DateTime UpdatedOn { get; private set; }
  public string Name { get; private set; }
  public List<Planet> Planets { get; private set; } = [];

  private SolarSystem() {
  }

  public SolarSystem(Guid id, DateTime createdOn, DateTime updatedOn, string name) {
    Validate(name);
    Name = name;
    Id = id;
    CreatedOn = createdOn;
    UpdatedOn = updatedOn;
  }

  private static void Validate(string name) {
    StringValidator.Validate(name, "Name", 1, 255);
  }
}
