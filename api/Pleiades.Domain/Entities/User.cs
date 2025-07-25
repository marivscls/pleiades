using Pleiades.Core.Validators;
using Pleiades.Domain.Entities.Join;
using Pleiades.Domain.Enums;
using Pleiades.Domain.Interfaces.Base;
using Pleiades.Domain.VOs;

namespace Pleiades.Domain.Entities;

public class User : IBaseEntity {
  public Guid Id { get; private set; }
  public DateTime CreatedOn { get; private set; }
  public DateTime UpdatedOn { get; private set; }

  // Auth data
  public Email Email { get; private set; }
  public Password Password { get; private set; }
  public UserRole Role { get; private set; }

  // Personal Data
  public string FullName { get; private set; }

  // Platform Data
  public string NickName { get; private set; }
  public List<UserMission> UserMissions { get; private set; } = [];
  public List<Comment> Comments { get; private set; } = [];

  public MissionProgressTracker Progress => new(UserMissions);

  private User() {
  }

  public User(Guid id,
    DateTime createdOn,
    DateTime updatedOn,
    Email email,
    Password password,
    UserRole role,
    string fullName,
    string nickName
  ) {
    Id = id;
    CreatedOn = createdOn;
    UpdatedOn = updatedOn;
    Email = email;
    Password = password;
    Role = role;
    Validate(fullName, nickName);
    FullName = fullName;
    NickName = nickName;
  }

  private static void Validate(string fullName, string nickName) {
    StringValidator.Validate(fullName, nameof(fullName), 1, 255);
    StringValidator.Validate(nickName, nameof(nickName), 1, 255);
  }

  public void UpdatePassword(Password newSecurePassword) {
    Password = newSecurePassword;
    UpdatedOn = DateTime.UtcNow;
  }
}
