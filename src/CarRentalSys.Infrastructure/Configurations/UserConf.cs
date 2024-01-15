using CarRentalSys.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSys.Infrastructure.Configurations;

public sealed class UserConf : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("users");
    builder.HasKey(user => user.Identifier);
    builder.HasIndex(user => user.Email).IsUnique();

    builder.Property(user => user.Email)
      .HasMaxLength(255);

    builder.OwnsOne(
      user => user.FullName,
      fullNameBuilder =>
      {
        fullNameBuilder.Property(fullName => fullName.Name);
        fullNameBuilder.Property(fullName => fullName.LastName);
      }
      );
  }
}
