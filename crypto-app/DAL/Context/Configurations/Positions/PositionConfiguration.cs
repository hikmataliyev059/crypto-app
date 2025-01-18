using crypto_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crypto_app.DAL.Context.Configurations.Positions;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.Property(x => x.Name)
           .IsRequired()
           .HasMaxLength(50);
    }
}
