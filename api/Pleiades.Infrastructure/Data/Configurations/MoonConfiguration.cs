using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pleiades.Domain.Entities;
using Pleiades.Infrastructure.Configurations.Extensions;

namespace Pleiades.Infrastructure.Data.Configurations;

public class MoonConfiguration : IEntityTypeConfiguration<Moon> {
  public void Configure(EntityTypeBuilder<Moon> builder) {
    builder.HasKey(m => m.Id);
    builder.Property(m => m.CreatedOn).IsRequired();
    builder.Property(m => m.UpdatedOn).IsRequired();

    builder.Property(m => m.Name).IsRequired().HasMaxLength(255);
    builder.Property(m => m.Lore).IsRequired().HasMaxLength(500);

    builder.HasOne(m => m.Planet)
      .WithMany(p => p.Moons)
      .HasForeignKey(m => m.PlanetId)
      .OnDelete(DeleteBehavior.Restrict);

    builder.OwnsOne(m => m.Appearance, a => a.ConfigureAppearance());
  }
}
